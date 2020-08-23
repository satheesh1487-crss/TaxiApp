using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Helper;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DADriverRequest
    {
        public List<RequestInProgress> DriverRequestInprogress(LoggedInUser loggedInUser,TaxiAppzDBContext context)
        {
            List<RequestInProgress> requestInProgresses = new List<RequestInProgress>();
            var driverdtls = context.TabDrivers.Include(t => t.Serviceloc).Include(t => t.Type).Where(t => t.ContactNo == loggedInUser.Contactno && t.IsApproved == true && 
            t.IsAvailable == true &&   t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            if (driverdtls == null)
                return requestInProgresses;
            var requestmeta = context.TabRequestMeta.Include(t => t.User).Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
            var tripdtls = new TabRequest();
            if (requestmeta == null)
            {
                tripdtls = context.TabRequest.Include(t => t.User).Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
            }
            var servicelocdetails = context.TabServicelocation.Where(t => t.Servicelocid == driverdtls.Serviceloc.Servicelocid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if(servicelocdetails == null)
                return requestInProgresses;
            Details userdetails = new Details();
            userdetails.Id = requestmeta != null ? requestmeta.User.Id : tripdtls.User.Id;
            userdetails.Name = requestmeta != null ? requestmeta.User.Firstname : tripdtls.User.Firstname;
            userdetails.Last_name = requestmeta != null ? requestmeta.User.Lastname : tripdtls.User.Lastname;
            userdetails.Email = requestmeta != null ? requestmeta.User.Email : tripdtls.User.Email;
            userdetails.Mobile = requestmeta != null ? requestmeta.User.PhoneNumber : tripdtls.User.PhoneNumber;

            userdetails.Profile_picture = "";
            userdetails.Active = requestmeta != null ? requestmeta.User.IsActive : tripdtls.User.IsActive;
            userdetails.Email_confirmed = "";
            userdetails.Mobile_confirmed = 0;
            userdetails.Last_known_ip = "0";
            userdetails.Last_login_at = null;

            if (requestmeta != null)
            {
                
                var requestdatadtls = context.TabRequestPlace.Include(t => t.Request).Where(t => t.RequestId == requestmeta.RequestId).FirstOrDefault();
                //NEED TO WRITE META REQUEST OBJECT
                MetaRequest metaRequest = new MetaRequest();
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
                metaRequest.UserDetails = userdetails;
                requestInProgresses.Add(new RequestInProgress()
                {
                    Id = driverdtls.Driverid,
                    Name = driverdtls.FirstName,
                    Email = driverdtls.Email,
                    Mobile = driverdtls.ContactNo,
                    Profile_picture = "",
                    Active = driverdtls.IsActive,

                    Approve = driverdtls.IsApproved,
                    Availabe = driverdtls.IsAvailable,
                    Uploaded_document = driverdtls.Email,
                    Service_location_id = driverdtls.ContactNo,
                    Vehicle_type_id = driverdtls.Type.Typeid,
                    Vehicle_type_name = driverdtls.Type.Typename,

                    Car_make = driverdtls.Carmanufacturer,
                    Car_model = driverdtls.Carmodel,
                    Car_color = driverdtls.Carcolor,
                    Car_number = driverdtls.Carnumber,
                    metaRequest = metaRequest
                });

            }
            else
            {
                var requestdata = context.TabRequest.Include(x => x.TabRequestPlace).Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
                var requestplace = context.TabRequestPlace.Where(t => t.RequestId == Convert.ToInt64(requestdata.RequestId)).FirstOrDefault();
                if (requestdata == null)
                    return requestInProgresses;
                if (requestdata.IsDriverStarted.ToUpper() == "TRUE" || requestdata.IsDriverArrived.ToUpper() == "TRUE" ||
                    requestdata.IsTripStart.ToUpper() == "TRUE" || requestdata.IsCompleted.ToUpper() == "FALSE" || requestdata.IsCancelled.ToUpper() == "FALSE")
                {
                    //NEED TO WRITE TRIP REQUEST OBJECT
                    TripRequest tripRequest = new TripRequest();
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
                    tripRequest.UserDetails = userdetails;

                    requestInProgresses.Add(new RequestInProgress()
                    {
                        Id = driverdtls.Driverid,
                        Name = driverdtls.FirstName,
                        Email = driverdtls.Email,
                        Mobile = driverdtls.ContactNo,
                        Profile_picture = "",
                        Active = driverdtls.IsActive,

                        Approve = driverdtls.IsApproved,
                        Availabe = driverdtls.IsAvailable,
                        Uploaded_document = driverdtls.Email,
                        Service_location_id = driverdtls.ContactNo,
                        Vehicle_type_id = driverdtls.Type.Typeid,
                        Vehicle_type_name = driverdtls.Type.Typename,

                        Car_make = driverdtls.Carmanufacturer,
                        Car_model = driverdtls.Carmodel,
                        Car_color = driverdtls.Carcolor,
                        Car_number = driverdtls.Carnumber,
                        OnTripRequest = tripRequest
                    });

                }
            }
            return requestInProgresses;
        }

        public RequestStatusModel onlineStatus(TaxiAppzDBContext context, DriverStatusModel driverStatusModel, LoggedInUser loggedInUser)
        {
            var profileexist = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.ContactNo == driverStatusModel.Contact_Number && t.Token == null);
            if (profileexist != null)
                throw new DataValidationException($"Driver does not have a permission");

            RequestStatusModel requestStatusModel = new RequestStatusModel();           
            var updatedate = context.TabDrivers.FirstOrDefault(t => t.ContactNo == driverStatusModel.Contact_Number && t.IsDelete == false && t.IsActive == true);
            if (updatedate != null)
            {
                updatedate.OnlineStatus = requestStatusModel.OnlineStatus = driverStatusModel.Online_Status;
                updatedate.UpdatedAt = DateTime.UtcNow;
                updatedate.UpdatedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                return requestStatusModel;
            }
            return requestStatusModel;
        } 
        static double _eQuatorialEarthRadius = 6378.1370D;
        static double _d2r = (Math.PI / 180D);

        private static int HaversineInM(double lat1, double long1, double lat2, double long2)
        {
            return (int)(1000D * HaversineInKM(lat1, long1, lat2, long2));
        }

        private static double HaversineInKM(double lat1, double long1, double lat2, double long2)
        {
            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            return d;
        }

        public List<TripCancelModel> CancelList(TaxiAppzDBContext context, DriverCancelTripModel driverCancelTripModel, LoggedInUser loggedInUser)
        {
            var driverexist = context.TabDriverCancellation.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.DriverCancelId == driverCancelTripModel.Id);
            if (driverexist != null)
                throw new DataValidationException($"Driver does not have a permission");

            List<TripCancelModel> tripCancelModels = new List<TripCancelModel>();            
            var listCancel = context.TabDriverCancellation.Where(t => t.IsDelete == false && t.IsActive == true && t.DriverCancelId==driverCancelTripModel.Id).ToList().OrderByDescending(t => t.UpdatedAt);
            foreach (var cancel in listCancel)
            {
                tripCancelModels.Add(new TripCancelModel()
                {
                    Driver_Cancelld=cancel.DriverCancelId,
                    Zone_TypeId=cancel.Zonetypeid,
                    Cancellation_Reason_English=cancel.CancellationReasonEnglish                    
                });
            }            
            return tripCancelModels;
        }
    }
}
