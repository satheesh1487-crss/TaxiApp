using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        public List<DetailsWithToken> GenerateJWTTokenDtls(SignInmodel signInmodel)
        {

            List<DetailsWithToken> user = new List<DetailsWithToken>();
            var IQUser = _context.TabUser.Where(t => t.PhoneNumber == signInmodel.Contactno).FirstOrDefault();
            if (IQUser != null)
            {
                var tokenString = GenerateJWTToken(IQUser, _context);
                var refreshtoken = CreateRefreshToken();
                user.Add(new DetailsWithToken()
                {
                    Id = IQUser.Id,
                    FirstName = IQUser.Firstname,
                    LastName = IQUser.Lastname,
                    Mobileno = IQUser.PhoneNumber,
                    Emailid = IQUser.Email,
                    AccessToken = tokenString,
                    RefreshToken = refreshtoken.RefeshToken,
                    IsExist = 1,
                    IsActive = IQUser.IsActive
                    //ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                    //InsertedDate = IQAdmin.CreatedAt
                });
                bool updatetoken = UpdateToken(IQUser.Id, user[0], _context);

                return user;
            }
            return user;
        }
         
        

        public List<DetailsWithDriverToken> GenerateJWTDriverTokenDtls(SignInmodel signInmodel)
        {
                  List<DetailsWithDriverToken> driver = new List<DetailsWithDriverToken>();
                var IQDriver = _context.TabDrivers.Where(t => t.ContactNo == signInmodel.Contactno).FirstOrDefault();
                if (IQDriver != null)
                {
                    var tokenString = GenerateDriverJWTToken(IQDriver, _context);
                    var refreshtoken = CreateRefreshToken();
                    driver.Add(new DetailsWithDriverToken()
                    {
                        Id = IQDriver.Driverid,
                        FirstName = IQDriver.FirstName,
                        LastName = IQDriver.LastName,
                        Mobileno = IQDriver.ContactNo,
                        Emailid = IQDriver.Email,
                        AccessToken = tokenString,
                        RefreshToken = refreshtoken.RefeshToken,
                        IsExist = 1,
                        IsActive = IQDriver.IsActive

                        //   ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                        //   InsertedDate = IQAdmin.CreatedAt
                    });
                    bool updatetoken = UpdateDriverToken(IQDriver.Driverid, driver[0], _context);

                    return driver;
                }
         
            return driver;
        }

        public List<DetailsWithToken> ReGenerateJWTTokenDtls(string refreshtoken, string contactno)
        {
            List<DetailsWithToken> user = new List<DetailsWithToken>();
            var IQUser = _context.TabUser.Where(t => t.PhoneNumber == contactno &&  t.Token == refreshtoken).FirstOrDefault();
            if (IQUser != null)
            {
                var tokenString = GenerateJWTToken(IQUser, _context);
                var regenfreshtoken = CreateRefreshToken();
                user.Add(new DetailsWithToken()
                {
                    Id = IQUser.Id,
                    FirstName = IQUser.Firstname,
                    LastName = IQUser.Lastname,
                    Mobileno = IQUser.PhoneNumber,
                    Emailid = IQUser.Email,
                    AccessToken = tokenString,
                    RefreshToken = regenfreshtoken.RefeshToken,
                    IsActive = IQUser.IsActive,
                    IsExist = 1
                    //   ExpireDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(300)),
                    //   InsertedDate = IQAdmin.CreatedAt
                });
                bool updatetoken = UpdateToken(IQUser.Id, user[0] , _context);
                return user;
            }
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
                 new Claim("country", userinfo.Countryid.ToString()),
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

        private string GenerateDriverJWTToken(TabDrivers driverinfo, TaxiAppzDBContext context)
        {
            try
            {
                insertlog("Token Generation", driverinfo.Email, "GenerateJWTToken", context);
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, driverinfo.FirstName),
                new Claim("lastName", driverinfo.LastName),
                new Claim("mailID", driverinfo.Email),
                 new Claim("Contactno", driverinfo.ContactNo),
                //new Claim("isActive", driverinfo.IsActive.ToString()),
                //new Claim("Carmodel", driverinfo.Carmodel),
                // new Claim("carnumber", driverinfo.Carnumber),
                // new Claim("typeid", driverinfo.Typeid.ToString()),
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
                insertlog(ex.Message, driverinfo.Email, "GenerateJWTToken", context);
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
                insertlog("Update Token", userInfo.Emailid, "GenerateJWTToken", context);
                var getuserinfo = context.TabUser.Where(a => a.Id == userid).FirstOrDefault();
                getuserinfo.Token = userInfo.RefreshToken;
                getuserinfo.UpdatedAt = DateTime.Now;
                context.TabUser.Update(getuserinfo);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                insertlog(ex.Message, userInfo.Emailid, "UpdateToken", context);
                return false;
            }
        }
        internal static bool UpdateDriverToken(long driverid, DetailsWithDriverToken driverInfo, TaxiAppzDBContext context)
        {
            try
            {
                insertlog("Update Token", driverInfo.Emailid, "GenerateJWTToken", context);
                var getuserinfo = context.TabDrivers.Where(a => a.Driverid == driverid).FirstOrDefault();
                getuserinfo.Token  = driverInfo.RefreshToken;
                getuserinfo.UpdatedAt = DateTime.Now;
                context.TabDrivers.Update(getuserinfo);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                insertlog(ex.Message, driverInfo.Emailid, "UpdateToken", context);
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
