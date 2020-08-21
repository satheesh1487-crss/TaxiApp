using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
           
            var requestdatadtls = context.TabRequest.Where(t => t.RequestId == requestmeta.RequestId.ToString()).FirstOrDefault();
            if (requestmeta != null)
            {
                //NEED TO WRITE META REQUEST OBJECT
                MetaRequest metaRequest = new MetaRequest();
                //metaRequest.Id = requestdata.Id;
                //metaRequest.Request_number = requestdata.RequestId;
                //metaRequest.Is_later = requestdata.Later;
                //metaRequest.User_id = requestdata.UserId;
                //metaRequest.Trip_start_time = requestdata.TripStartTime;
                //metaRequest.Arrived_at = "";
                //metaRequest.Accepted_at = requestdata.DriverAcceptedTime;
                //metaRequest.Completed_at = "";

                //metaRequest.is_driver_started = requestdata.IsDriverStarted;
                //metaRequest.Is_driver_arrived = requestdata.IsDriverArrived;
                //metaRequest.Is_trip_start = requestdata.IsTripStart;
                //metaRequest.Is_completed = requestdata.IsCompleted;
                //metaRequest.Is_cancelled = requestdata.IsCancelled;
                //metaRequest.Cancel_method = requestdata.CancelMethod;
                //metaRequest.Payment_opt = requestdata.PaymentOpt;
                //metaRequest.Is_paid = requestdata.IsPaid;

                //metaRequest.User_rated = requestdata.UserRated;
                //metaRequest.Driver_rated = requestdata.DriverRated;
                //metaRequest.Unit = requestdata.Unit;
                //metaRequest.Zone_type_id = requestdata.Typeid;
                //metaRequest.Pick_lat = requestdata.TabRequestPlace
                //metaRequest.Pick_lng = requestdata.Id;
                //metaRequest.Pick_address = requestdata.Id;
                //metaRequest.Drop_address = requestdata.Id;
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
    }
}
