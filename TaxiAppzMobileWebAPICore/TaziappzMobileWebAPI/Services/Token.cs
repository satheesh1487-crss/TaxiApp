using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaxiAppsWebAPICore.Helper;
using TaziappzMobileWebAPI;
using TaziappzMobileWebAPI.TaxiModels;
namespace TaxiAppsWebAPICore.Services
{
    public class Token : IToken
    {
        public readonly TaxiAppzDBContext _context;
        public readonly JWT _jwt;
        public Token(TaxiAppzDBContext context,IOptions<JWT> jwt)
        {
            _context = context;
            _jwt = jwt.Value; 
        }
        public DetailsWithToken GenerateJWTTokenDtls(SignInmodel signInmodel)
        {
         var user = new DetailsWithToken();
            var IQUser = _context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno).FirstOrDefault();
            if (IQUser != null)
            {
                var tokenString = GenerateJWTToken(IQUser, _context);
                var refreshtoken = CreateRefreshToken();
                user = new DetailsWithToken()
                {
                    Id=IQUser.Id,
                    FirstName = IQUser.Firstname,
                    LastName = IQUser.Lastname,
                    mobileno= IQUser.PhoneNumber,
                    MailID = IQUser.Email,
                    AccessToken = tokenString,
                    RefreshToken = refreshtoken.RefeshToken,
                   Status = "User_Logged",
                   IsActive= IQUser.IsActive
                    //   ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                    //   InsertedDate = IQAdmin.CreatedAt
                };
                  bool updatetoken = UpdateToken(IQUser.Id, user, _context);

                return user;
            }
            user.Status = "Invalid Credentials";
            return user;
        }
        public DetailsWithToken ReGenerateJWTTokenDtls(string refreshtoken, string contactno)
        {
            var user = new DetailsWithToken();
            var IQUser = _context.TabUser.Where(t => t.PhoneNumber == contactno &&  t.Token == refreshtoken).FirstOrDefault();
            if(IQUser != null)
            {
                var tokenString = GenerateJWTToken(IQUser, _context);
                var regenfreshtoken = CreateRefreshToken();
                user = new DetailsWithToken()
                {
                    Id = IQUser.Id,
                    FirstName = IQUser.Firstname,
                    LastName = IQUser.Lastname,
                    mobileno = IQUser.PhoneNumber,
                    MailID = IQUser.Email,
                    AccessToken = tokenString,
                    RefreshToken = regenfreshtoken.RefeshToken,
                    Status = "User_Logged",
                    IsActive = IQUser.IsActive
                    //   ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                    //   InsertedDate = IQAdmin.CreatedAt
                };
                bool updatetoken = UpdateToken(IQUser.Id, user, _context);
                return user;
             }
            user.Status = "Token did not match any users.";
            return user;
        }
        private  string GenerateJWTToken(TabUser userinfo, TaxiAppzDBContext context)
        {
            try
            {
                insertlog("Token Generation", userinfo.Email, "GenerateJWTToken", context);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userinfo.Firstname),
                new Claim("lastName", userinfo.Lastname),
                new Claim("mailID", userinfo.Email),
                 new Claim("Contactno", userinfo.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                var token = new JwtSecurityToken(
                    issuer: _jwt.Issuer,
                    audience: _jwt.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwt.AccessTokenDuration),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                insertlog(ex.Message, userinfo.Email, "GenerateJWTToken", context);
                return null;
            }

        }
        private UserInfo CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new UserInfo
                {
                    RefeshToken = Convert.ToBase64String(randomNumber),
                    ExpireDate = DateTime.UtcNow.AddDays(_jwt.RefreshTokenDuration),
                    InsertedDate = DateTime.UtcNow
                };

            }
        }

        internal static bool UpdateToken(long userid, DetailsWithToken userInfo, TaxiAppzDBContext context)
        {
            try
            {
                insertlog("Update Token", userInfo.MailID, "GenerateJWTToken", context);
                var getuserinfo = context.TabUser.Where(a => a.Id == userid).FirstOrDefault();
                getuserinfo.Token = userInfo.RefreshToken;
                getuserinfo.UpdatedAt = DateTime.Now;
                context.TabUser.Update(getuserinfo);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                insertlog(ex.Message, userInfo.MailID, "UpdateToken", context);
                return false;
            }
        }
        internal static bool insertlog(string description, string userid, string functionname, TaxiAppzDBContext context)
        {
            TblErrorlog tblErrorlog = new TblErrorlog();
            tblErrorlog.Description = description;
            tblErrorlog.CreatedBy = userid;
            tblErrorlog.FunctionName = functionname;
            TaxiAppzDBContext _context = new TaxiAppzDBContext();
            context.TblErrorlog.Add(tblErrorlog);
            // context.SaveChanges();
            return true;
        }
    }
}
