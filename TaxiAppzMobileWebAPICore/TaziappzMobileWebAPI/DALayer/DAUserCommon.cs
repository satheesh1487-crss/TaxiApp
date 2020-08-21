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

        public List<UserSosModel> List(TaxiAppzDBContext context, long id, decimal lang, decimal lat)
        {
            try
            {
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
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "List", context);
                return null;
            }

        }

        public List<UserFaqListModel> FaqList(TaxiAppzDBContext context, long id, decimal lang, decimal lat, string type)
        {
            try
            {
                List<UserFaqListModel> userFaqLists = new List<UserFaqListModel>();
                List<User_Faq_List> user_Faqs = new List<User_Faq_List>();
                var listFaq = context.TabFaq.Where(t => t.IsDelete == false && t.IsActive == true).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var faq in listFaq)
                {
                    user_Faqs.Add(new User_Faq_List()
                    {
                        Id=faq.Faqid,
                        Question=faq.FaqQuestion,
                        Answer=faq.FaqAnswer                        
                    });
                }
                userFaqLists.Add(new UserFaqListModel()
                {
                    Faq_List = user_Faqs
                });
                return userFaqLists;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "FaqList", context);
                return null;
            }

        }
    }
}
