using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.Helper;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DAUserCommon
    {
        public List<UserProfileModel> GetProfile(TaxiAppzDBContext context, ProfileModel profileModel, LoggedInUser loggedInUser)
        {
            var zoneexist = context.TabUser.FirstOrDefault(t => t.IsDelete == 0 && t.IsActive == true && t.Id == profileModel.Id && t.Token == null);
            if (zoneexist != null)
                throw new DataValidationException($"User does not have a permission");

            List<UserProfileModel> userProfileModel = new List<UserProfileModel>();
            UserProfile userProfile = new UserProfile();
            var listProfile = context.TabUser.FirstOrDefault(t => t.Id == profileModel.Id && t.PhoneNumber == loggedInUser.Contactno && t.IsDelete == 0 && t.IsActive == true);
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

        public List<UserSosModel> List(TaxiAppzDBContext context, UserZoneSOSModel userZoneSOSModel, LoggedInUser loggedInUser)
        {
            var zoneexist = context.TabSos.FirstOrDefault(t => t.IsDeleted == 0 && t.IsActive == 1 && t.Sosid == userZoneSOSModel.Id && t.ContactNumber == null);
            if (zoneexist != null)
                throw new DataValidationException($"User does not have a permission");

            List<UserSosModel> userSosModels = new List<UserSosModel>();
            List<SosUser> sosUsers = new List<SosUser>();
            var listZone = context.TabSos.Where(t => t.IsDeleted == 0 && t.IsActive == 1).ToList().OrderByDescending(t => t.UpdatedAt);
            foreach (var zone in listZone)
            {
                sosUsers.Add(new SosUser()
                {
                    Id = zone.Sosid,
                    name = zone.Sosname,
                    number = zone.ContactNumber,
                });
            }
            userSosModels.Add(new UserSosModel()
            {
                sos = sosUsers
            });
            return userSosModels;
        }

        public List<UserFaqListModel> FaqList(TaxiAppzDBContext context, UserFAQListModel userFAQListModel, LoggedInUser loggedInUser)
        {
            var fAQexist = context.TabFaq.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.Faqid == userFAQListModel.Id);
            if (fAQexist != null)
                throw new DataValidationException($"User does not have a permission");

            List<UserFaqListModel> userFaqLists = new List<UserFaqListModel>();
            List<User_Faq_List> user_Faqs = new List<User_Faq_List>();
            var listFaq = context.TabFaq.Where(t => t.IsDelete == false && t.IsActive == true).ToList().OrderByDescending(t => t.UpdatedAt);
            foreach (var faq in listFaq)
            {
                user_Faqs.Add(new User_Faq_List()
                {
                    Id = faq.Faqid,
                    Question = faq.FaqQuestion,
                    Answer = faq.FaqAnswer
                });
            }
            userFaqLists.Add(new UserFaqListModel()
            {
                Faq_List = user_Faqs
            });
            return userFaqLists;
        }
    }
}
