using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

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
        public UserInfo GenerateJWTTokenDtls(LoginRequest admin)
        {
          DARoles dARoles = new DARoles();
          var user = new UserInfo();
            var IQAdmin = _context.TabAdmin.Include(a => a.RoleNavigation).Where(a => a.Email.ToLower().Contains(admin.Email.ToLower()) && a.Password == admin.Password).FirstOrDefault();
            if (IQAdmin != null)
            {
                var tokenString = GenerateJWTToken(IQAdmin, _context);
                var refreshtoken = CreateRefreshToken();
                user = new UserInfo()
                {
                    Email = admin.Email,
                    RememberToken = tokenString,
                    Role = IQAdmin.RoleNavigation.RoleName,
                    Menukey = dARoles.GetMenukey(IQAdmin.RoleNavigation.RoleName, _context),
                    RefeshToken = refreshtoken.RefeshToken
                    //   ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                    //   InsertedDate = IQAdmin.CreatedAt
                };
                  bool updatetoken = UpdateToken(IQAdmin.Id, user, _context);

                return user;
            }
            user.Message = "Invalid Credentials";
            return user;
        }
        public UserInfo ReGenerateJWTTokenDtls(string refreshtoken, string mailid)
        {
          DARoles dARoles = new DARoles();
           var user = new UserInfo();
            var IQAdmin = _context.TabAdmin.Include(a => a.RoleNavigation).Where(a => a.Email.ToLower().Contains(mailid.ToLower()) && a.RememberToken == refreshtoken).FirstOrDefault();
            if(IQAdmin != null)
            {
                var tokenString = GenerateJWTToken(IQAdmin, _context);
                var regrefreshtoken = CreateRefreshToken();
                user = new UserInfo()
                {
                    Email = mailid,
                    RememberToken = tokenString,
                    Role = IQAdmin.RoleNavigation.RoleName,
                    Menukey = dARoles.GetMenukey(IQAdmin.RoleNavigation.RoleName, _context),
                    RefeshToken = regrefreshtoken.RefeshToken
                    //   ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                    //   InsertedDate = IQAdmin.CreatedAt
                };
                bool updatetoken = UpdateToken(IQAdmin.Id, user, _context);
                return user;
             }
            user.Message = "Token did not match any users.";
            return user;
        }
        private  string GenerateJWTToken(TabAdmin userinfo, TaxiAppzDBContext context)
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
                new Claim("role", userinfo.RoleNavigation.RoleName),
                   new Claim("MailID", userinfo.Email),
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

        internal static bool UpdateToken(long userid, UserInfo userInfo, TaxiAppzDBContext context)
        {
            try
            {
                insertlog("Update Token", userInfo.Email, "GenerateJWTToken", context);
                var getuserinfo = context.TabAdmin.Where(a => a.Id == userid).FirstOrDefault();
                getuserinfo.RememberToken = userInfo.RefeshToken;
                getuserinfo.UpdatedAt = DateTime.Now;
                context.TabAdmin.Update(getuserinfo);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                insertlog(ex.Message, userInfo.Email, "GenerateJWTToken", context);
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
