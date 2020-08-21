using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DAUserCommon
    {
        public List<UserProfileModel> GetProfile(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {
                List<UserProfileModel> userProfileModel = new List<UserProfileModel>();
                UserProfile userProfile = new UserProfile();
                var listProfile = context.TabUser.FirstOrDefault(t => t.Id == id && t.PhoneNumber == loggedInUser.Contactno && t.IsDelete == 0 && t.IsActive == true);
                if (listProfile != null)
                {
                    userProfile.Id = listProfile.Id;
                    userProfile.Corporate = listProfile.CorporateAdminReference;
                    userProfile.FirstName = listProfile.Firstname;
                    userProfile.LastName = listProfile.Lastname;
                    userProfile.Login_By = listProfile.LoginBy;
                    userProfile.Login_Method = listProfile.LoginMethod;
                    userProfile.Phone = listProfile.PhoneNumber;
                    userProfile.Profile_Pic = listProfile.ProfilePic;
                    userProfile.Token = listProfile.Token;
                    userProfile.Email = listProfile.Email;
                    userProfile.Is_Active = listProfile.IsActive;
                }
                userProfileModel.Add(new UserProfileModel()
                {
                    User = userProfile
                });                
                return userProfileModel;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetProfile", context);
                return null;
            }
        }
    }
}
