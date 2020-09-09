using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Services;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.Helper;
using TaziappzMobileWebAPI.TaxiModels;
using Microsoft.EntityFrameworkCore;
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
        public List<UserRequestInProgress> UserProfileRetrive(LoggedInUser loggedInUser, TaxiAppzDBContext context)
        {
            List<UserRequestInProgress> requestInProgresses = new List<UserRequestInProgress>();
            var userdtls = context.TabUser.Where(t => t.PhoneNumber == loggedInUser.Contactno && t.IsActive == true && t.IsDelete == 0).FirstOrDefault();
            if (userdtls == null)
                return requestInProgresses;
            var requestmeta = context.TabRequestMeta.Include(t => t.Driver).Where(t => t.UserId == userdtls.Id).FirstOrDefault();
            var tripdtls = new TabRequest();
            if (requestmeta == null)
            {
                tripdtls = context.TabRequest.Include(t => t.Driver).Where(t => t.Id == userdtls.Id && t.IsCancelled == false && t.DriverRated == 0 && t.UserRated == 0).FirstOrDefault();
            }
            if (tripdtls == null)
            {
                requestInProgresses.Add(new UserRequestInProgress()
                {
                    Id = userdtls.Id,
                    Name = userdtls.Firstname,
                    Email = userdtls.Email,
                    Mobile = userdtls.PhoneNumber,
                    Profile_picture = "",
                    Active = userdtls.IsActive,
                     metaRequest = null
                });
                return requestInProgresses;
            }
            DriverDetails driverDetails = new DriverDetails();
            driverDetails.Id = requestmeta != null ? requestmeta.Driver.Driverid : tripdtls.Driver.Driverid; 
            driverDetails.FirstName = requestmeta != null ? requestmeta.Driver.FirstName : tripdtls.Driver.FirstName;
            driverDetails.LastName = requestmeta != null ? requestmeta.Driver.LastName : tripdtls.Driver.LastName;
            driverDetails.Email = requestmeta != null ? requestmeta.Driver.Email : tripdtls.Driver.Email;
            driverDetails.Mobile = requestmeta != null ? requestmeta.Driver.ContactNo : tripdtls.Driver.ContactNo;

            driverDetails.Profile_picture = "";
            driverDetails.Active = requestmeta != null ? requestmeta.Driver.IsActive : tripdtls.Driver.IsActive;
            driverDetails.Approve = requestmeta != null ? requestmeta.Driver.IsApproved : tripdtls.Driver.IsApproved;
            driverDetails.Availabe = requestmeta != null ? requestmeta.Driver.IsAvailable : tripdtls.Driver.IsAvailable;

            driverDetails.Service_location_id = requestmeta != null ? requestmeta.Driver.Servicelocid : tripdtls.Driver.Servicelocid;
            driverDetails.Vehicle_type_id = requestmeta != null ? requestmeta.Driver.Typeid : tripdtls.Driver.Typeid;
            driverDetails.Car_make = requestmeta != null ? requestmeta.Driver.Carmanufacturer : tripdtls.Driver.Carmanufacturer;


            driverDetails.Car_model = requestmeta != null ? requestmeta.Driver.Carmodel : tripdtls.Driver.Carmodel;
            driverDetails.Car_color = requestmeta != null ? requestmeta.Driver.Carcolor : tripdtls.Driver.Carcolor;
            driverDetails.Car_number = requestmeta != null ? requestmeta.Driver.Carnumber : tripdtls.Driver.Carnumber;

            if (requestmeta != null)
            {

                var requestdatadtls = context.TabRequestPlace.Include(t => t.Request).Where(t => t.RequestId == requestmeta.RequestId).FirstOrDefault();
                //NEED TO WRITE META REQUEST OBJECT
                UserMetaRequest metaRequest = new UserMetaRequest();
                metaRequest.Id = requestdatadtls.Request.Id;
                metaRequest.Request_number = requestdatadtls.Request.RequestId;
                metaRequest.Is_later = requestdatadtls.Request.Later;
                metaRequest.User_id = requestdatadtls.Request.UserId;
                metaRequest.Trip_start_time = requestdatadtls.Request.TripStartTime;
                metaRequest.Arrived_at = "";
                metaRequest.Accepted_at = requestdatadtls.Request.DriverAcceptedTime;
                metaRequest.Completed_at = "";

                metaRequest.is_driver_started = requestdatadtls.Request.IsDriverStarted;
                metaRequest.Is_driver_arrived = requestdatadtls.Request.IsDriverArrived;
                metaRequest.Is_trip_start = requestdatadtls.Request.IsTripStart;
                metaRequest.Is_completed = requestdatadtls.Request.IsCompleted;
                metaRequest.Is_cancelled = requestdatadtls.Request.IsCancelled;
                metaRequest.Cancel_method = requestdatadtls.Request.CancelMethod;
                metaRequest.Payment_opt = requestdatadtls.Request.PaymentOpt;
                metaRequest.Is_paid = requestdatadtls.Request.IsPaid;

                metaRequest.User_rated = requestdatadtls.Request.UserRated;
                metaRequest.Driver_rated = requestdatadtls.Request.DriverRated;
                metaRequest.Unit = requestdatadtls.Request.Unit;
                metaRequest.Zone_type_id = requestdatadtls.Request.Typeid;
                metaRequest.Pick_lat = requestdatadtls.PickLatitude;
                metaRequest.Pick_lng = requestdatadtls.PickLongitude;
                metaRequest.Pick_address = requestdatadtls.PickLocation;
                metaRequest.Drop_address = requestdatadtls.DropLocation;
                metaRequest.DriverDetails = driverDetails;
                requestInProgresses.Add(new UserRequestInProgress()
                {
                    Id = userdtls.Id,
                    Name = userdtls.Firstname,
                    Email = userdtls.Email,
                    Mobile = userdtls.PhoneNumber,
                    Profile_picture = "",
                    Active = userdtls.IsActive,
                    metaRequest = metaRequest
                });

            }
            else
            {
                var requestdata = context.TabRequest.Include(x => x.TabRequestPlace).Where(t => t.UserId == userdtls.Id).FirstOrDefault();
                var requestplace = context.TabRequestPlace.Where(t => t.RequestId == Convert.ToInt64(requestdata.RequestId)).FirstOrDefault();
                if (requestdata == null)
                    return requestInProgresses;
                if (requestdata.IsDriverStarted == true || requestdata.IsDriverArrived == true ||
                    requestdata.IsTripStart == true || requestdata.IsCompleted == false || requestdata.IsCancelled == false)
                {
                    //NEED TO WRITE TRIP REQUEST OBJECT
                    UserTripRequestinProgress tripRequest = new UserTripRequestinProgress();
                    tripRequest.Id = requestdata.Id;
                    tripRequest.Request_number = requestdata.RequestId;
                    tripRequest.Is_later = requestdata.Later;
                    tripRequest.User_id = requestdata.UserId;
                    tripRequest.Trip_start_time = requestdata.TripStartTime;
                    tripRequest.Arrived_at = "";
                    tripRequest.Accepted_at = requestdata.DriverAcceptedTime;
                    tripRequest.Completed_at = "";

                    tripRequest.is_driver_started = requestdata.IsDriverStarted;
                    tripRequest.Is_driver_arrived = requestdata.IsDriverArrived;
                    tripRequest.Is_trip_start = requestdata.IsTripStart;
                    tripRequest.Is_completed = requestdata.IsCompleted;
                    tripRequest.Is_cancelled = requestdata.IsCancelled;
                    tripRequest.Cancel_method = requestdata.CancelMethod;
                    tripRequest.Payment_opt = requestdata.PaymentOpt;
                    tripRequest.Is_paid = requestdata.IsPaid;

                    tripRequest.User_rated = requestdata.UserRated;
                    tripRequest.Driver_rated = requestdata.DriverRated;
                    tripRequest.Unit = requestdata.Unit;
                    tripRequest.Zone_type_id = requestdata.Typeid;
                    tripRequest.Pick_lat = requestplace.PickLatitude;
                    tripRequest.Pick_lng = requestplace.PickLongitude;
                    tripRequest.Pick_address = requestplace.PickLocation;
                    tripRequest.Drop_address = requestplace.DropLocation;
                    tripRequest.DriverDetails = driverDetails;

                    requestInProgresses.Add(new UserRequestInProgress()
                    {

                        Id = userdtls.Id,
                        Name = userdtls.Firstname,
                        Email = userdtls.Email,
                        Mobile = userdtls.PhoneNumber,
                        Profile_picture = "",
                        Active = userdtls.IsActive,
                        OnTripRequest = tripRequest
                    });

                }
            }
            return requestInProgresses;
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
