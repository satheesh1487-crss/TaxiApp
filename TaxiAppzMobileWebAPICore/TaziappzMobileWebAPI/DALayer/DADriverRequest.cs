using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        public readonly IOptions<SettingModel> settingModel;
        public DADriverRequest(IOptions<SettingModel> _settingmodel)
        {
            settingModel = _settingmodel;
        }
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
                tripdtls = context.TabRequest.Include(t => t.User).Where(t => t.DriverId == driverdtls.Driverid && t.IsCancelled ==false && t.DriverRated == 0 && t.UserRated == 0).FirstOrDefault();
            }
            var servicelocdetails = context.TabServicelocation.Where(t => t.Servicelocid == driverdtls.Serviceloc.Servicelocid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if (servicelocdetails == null)
                return requestInProgresses;
            if(tripdtls == null)
            {
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
                    metaRequest = null
                });
                return requestInProgresses;
            }
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
                if (requestdata.IsDriverStarted  == true || requestdata.IsDriverArrived  == true ||
                    requestdata.IsTripStart  == true || requestdata.IsCompleted  == false || requestdata.IsCancelled  == false )
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

        public List<RequestStatusModel> onlineStatus(TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var profileexist = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.ContactNo == loggedInUser.Contactno);
            //var profileexist = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.ContactNo == driverStatusModel.Contact_Number && t.Token == null);
            if (profileexist == null)
            throw new DataValidationException($"Driver does not Exist");
            List<RequestStatusModel> requestStatusModel = new List<RequestStatusModel>();           
            var updatedate = context.TabDrivers.FirstOrDefault(t => t.ContactNo == loggedInUser.Contactno && t.IsDelete == false && t.IsActive == true);
            if (updatedate != null)
            {
                updatedate.OnlineStatus = !updatedate.OnlineStatus;
                updatedate.UpdatedAt = DateTime.UtcNow;
                updatedate.UpdatedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                requestStatusModel.Add(new RequestStatusModel()
                {
                    OnlineStatus = updatedate.OnlineStatus
                }) ;
                return requestStatusModel;
            }
           return requestStatusModel;
        } 

        public bool RequestAcceptReject(long requestid, Boolean Acceptstatus, TaxiAppzDBContext context,LoggedInUser loggedInUser)
        {
            var driverdtls = context.TabDrivers.Where(t => t.ContactNo == loggedInUser.Contactno && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
                if (driverdtls == null)
                    return false;
            if (Acceptstatus)
            {
                var requestdata = context.TabRequest.Where(t => t.Id == requestid).FirstOrDefault();
                requestdata.DriverId = driverdtls.Driverid;
                requestdata.IsDriverStarted = true;
                context.TabRequest.Update(requestdata);
                context.SaveChanges();
                var requestmeta = context.TabRequestMeta.Where(t => t.RequestId == requestid).ToList();
                context.TabRequestMeta.RemoveRange(requestmeta);
                context.SaveChanges();
                return true;
            }
            else
            {
                var requestmeta = context.TabRequestMeta.Where(t => t.RequestId == requestid && t.DriverId == driverdtls.Driverid).FirstOrDefault();
                //requestmeta.RequestId = requestmeta.RequestId;
                //requestmeta.DriverId = requestmeta.DriverId;
                //requestmeta.IsActive = false;
                context.TabRequestMeta.Remove(requestmeta);
                context.SaveChanges();
                var secondrequestmeta = context.TabRequestMeta.Where(t => t.RequestId == requestid).OrderBy(t => t.MetaId).FirstOrDefault();
                secondrequestmeta.IsActive = true;
                context.TabRequestMeta.Update(secondrequestmeta);
                context.SaveChanges();
                return true;
            }
            
         }

        public bool TripCancel(long requestid, long reasonid, string reasondescription,TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var driverdtls = context.TabDrivers.Where(t => t.ContactNo == loggedInUser.Contactno && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            if (driverdtls == null)
                return false;
            TabCancellationFeeForDriver tabCancellationFeeForDriver = new TabCancellationFeeForDriver();
            tabCancellationFeeForDriver.Driverid = driverdtls.Driverid;
            tabCancellationFeeForDriver.RequestId = requestid;
            tabCancellationFeeForDriver.CreatedAt = DateTime.UtcNow;
            context.TabCancellationFeeForDriver.Add(tabCancellationFeeForDriver);
            context.SaveChanges();
            var requestdtls = context.TabRequest.Where(t => t.Id == requestid && t.DriverId == driverdtls.Driverid).FirstOrDefault();
            if (requestdtls == null)
                return false;
            requestdtls.IsCancelled = true;
            requestdtls.Reason = reasonid;
            requestdtls.CancelOtherReason = reasondescription;
            requestdtls.CancelMethod = "DRIVER";
            context.TabRequest.Update(requestdtls);
            context.SaveChanges();
               return true;
       }
        public bool TripStart(long requestid, long OTP,TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var requestdata = context.TabRequest.Where(t => t.Id == requestid && t.RequestOtp == OTP && t.DriverId == loggedInUser.id).FirstOrDefault();
            if (requestdata == null)
                return false;
                requestdata.TripStartTime = DateTime.UtcNow;
                requestdata.IsTripStart = true;
                requestdata.UpdatedAt = DateTime.UtcNow;
                context.TabRequest.Update(requestdata);
                context.SaveChanges();
                return true;
        }
        public bool TripEnd(string requestid, TaxiAppzDBContext context, LoggedInUser loggedInUser,double lat,double lng)
        {
            var requestdata = context.TabRequest.Where(t => t.RequestId == requestid && t.DriverId == loggedInUser.id).FirstOrDefault();
            if (requestdata == null)
                return false;
            var requestplace = context.TabRequestPlace.Where(t => t.RequestId == requestdata.Id).FirstOrDefault();
            var zoneid = context.TabDrivers.Where(t => t.Driverid == requestdata.DriverId).Select(t => t.Zoneid).FirstOrDefault();
            var zonetypeid = context.TabZonetypeRelationship.Where(t => t.Zoneid == zoneid && t.Typeid == requestdata.Typeid).Select(t => t.Zonetypeid).FirstOrDefault();
            var setprice = context.TabSetpriceZonetype.Where(t => t.Zonetypeid == zonetypeid).FirstOrDefault();
            if (setprice == null)
                return false;
            double distancekm = HaversineInKM(Convert.ToDouble(requestplace.PickLatitude),Convert.ToDouble(requestplace.PickLongitude), lat, lng);
            DateTime start = Convert.ToDateTime(requestdata.TripStartTime);
            int timeinminutes = (int)DateTime.UtcNow.Subtract(start).TotalMinutes;
            var baseprice = setprice.Baseprice;
            var basedistance = setprice.Basedistance;
            var priceperdistance = setprice.Priceperdistance;
            var pricepertime = setprice.Pricepertime;
            var waitingcharge = setprice.Waitingcharges;
            var distanceprice = Convert.ToDecimal(distancekm - basedistance) * priceperdistance;
            var timeprice = timeinminutes * pricepertime;
            var subtotal = baseprice + distanceprice + timeprice + waitingcharge;

            var taxpercentage = 2;
            var taxamount = subtotal * (taxpercentage / 100);

            var admincommvalue = setprice.Admincommission;
            var admincommission = subtotal * (admincommvalue / 100);

            var taxandadmincommission = taxamount + admincommission;

            var drivercommission = subtotal;
            var grandtotal = subtotal + taxandadmincommission;

            requestdata.IsCompleted = true;
            requestdata.Distance = Convert.ToDecimal(distancekm);
            requestdata.Time = timeinminutes;
            requestdata.Total =Convert.ToDouble(grandtotal);
            requestdata.IsPaid = "CASH";
          
            requestdata.UpdatedAt = DateTime.UtcNow;
            context.TabRequest.Update(requestdata);
            context.SaveChanges();
            return true;
        }
        public bool DriverArrived(long requestid, LatLong latLong, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var requestdata = context.TabRequest.Where(t => t.Id == requestid).FirstOrDefault();
            if (requestdata == null)
                return false;
            var requestplace = context.TabRequestPlace.Where(t => t.RequestId == requestdata.Id).FirstOrDefault();
            if (requestplace == null)
                return false;
            int meter = HaversineInM(Convert.ToDouble(requestplace.PickLatitude), Convert.ToDouble(requestplace.PickLongitude),
                Convert.ToDouble(latLong.Picklatitude), Convert.ToDouble(latLong.Picklongtitude));
            var radiusarrivedlimit = context.TabTripSettings.Where(t => t.TripSettingsId == settingModel.Value.tripsettingquestionid).Select( t => t.TripSettingsAnswer).FirstOrDefault();
           if(meter <= Convert.ToInt32(radiusarrivedlimit))
            {
                requestdata.IsDriverArrived = true;
                requestdata.UpdatedAt = DateTime.UtcNow;
                context.TabRequest.Update(requestdata);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        static double _eQuatorialEarthRadius = 6378.1370D;
        static double _d2r = (Math.PI / 180D);

      

        public List<TripCancelModel> CancelList(TaxiAppzDBContext context, DriverLocation driverLocation, LoggedInUser loggedInUser)
        {
            List<TripCancelModel> tripCancelModels = new List<TripCancelModel>();
            var driverexist = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.Driverid ==loggedInUser.id);
            if (driverexist == null)
                throw new DataValidationException($"Driver does not have a permission");
            DARequest dARequest = new DARequest(settingModel);
            LatLong latLong = new LatLong();
            latLong.Picklatitude = Convert.ToDecimal(driverLocation.Latitude);
            latLong.Picklongtitude = Convert.ToDecimal(driverLocation.Longitude);
            long? zoneid = dARequest.GetPolygon(latLong,loggedInUser.Country, context);
            if (zoneid == 0)
                return tripCancelModels;
            var zonetypeid = context.TabZonetypeRelationship.Where(t => t.Zoneid == zoneid && t.Typeid == driverexist.Typeid).Select(t => t.Zoneid).FirstOrDefault();
            if (zonetypeid == null)
                return tripCancelModels;
            var listCancel = context.TabDriverCancellation.Where(t => t.IsDelete == false && t.IsActive == true && t.Zonetypeid == zonetypeid).ToList().OrderByDescending(t => t.UpdatedAt);
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

        #region calculate Distance meter
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
        #endregion
    }
}
