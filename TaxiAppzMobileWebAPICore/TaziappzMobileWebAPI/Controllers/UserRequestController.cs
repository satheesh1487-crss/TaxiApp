using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserRequestController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Request-historySingle
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("historySingle")]
        public IActionResult HistorySingle(GeneralModel generalModel)
        {
            List<UserHistoryModel> userHistoryModel = new List<UserHistoryModel>();
            userHistoryModel[0].UserRequest = new UserRequest();
            userHistoryModel[0].UserRequest.Driver = new Drivers();
            userHistoryModel[0].UserRequest.UserBill = new UserBill();
            userHistoryModel[0].UserRequest.Id = 525;
            userHistoryModel[0].UserRequest.Is_Share = 0;
            userHistoryModel[0].UserRequest.Later = 0;
            userHistoryModel[0].UserRequest.Request_Id = "RES_36904";
            userHistoryModel[0].UserRequest.Pick_Latitude = 11.0150595;
            userHistoryModel[0].UserRequest.Pick_Longitude = 76.9825105;
            userHistoryModel[0].UserRequest.Drop_Latitude = 11.0150595;
            userHistoryModel[0].UserRequest.Drop_Longitude = 76.9825105;
            userHistoryModel[0].UserRequest.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            userHistoryModel[0].UserRequest.Drop_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            userHistoryModel[0].UserRequest.Trip_Start_Time = DateTime.Now;
            userHistoryModel[0].UserRequest.Is_Completed = 1;
            userHistoryModel[0].UserRequest.Is_Cancelled = 0;
            userHistoryModel[0].UserRequest.Payment_Opt = 1;
            userHistoryModel[0].UserRequest.User_Id = 1;
            userHistoryModel[0].UserRequest.Enable_Dispute_Button = true;
            userHistoryModel[0].UserRequest.Driver.Id = 25;
            userHistoryModel[0].UserRequest.Driver.FirstName = "rajesh";
            userHistoryModel[0].UserRequest.Driver.LastName = "kannan";
            userHistoryModel[0].UserRequest.Driver.Profile_Pic = " ";
            userHistoryModel[0].UserRequest.Driver.Review = 0.35;
            userHistoryModel[0].UserRequest.Driver.Phone_Number = "+919865896532";
            userHistoryModel[0].UserRequest.Driver.Email = "raj@gmail.com";
            userHistoryModel[0].UserRequest.Driver.Car_Model = "hhhh";
            userHistoryModel[0].UserRequest.Driver.Car_Number = "AD23";
            userHistoryModel[0].UserRequest.Driver_Type = 1;
            userHistoryModel[0].UserRequest.Type_Icon = "http://192.168.1.32/captaincar/public/assets/img/uploads/89987.jpg";
            userHistoryModel[0].UserRequest.Type_Name = "DKJH";
            userHistoryModel[0].UserRequest.Distance = 0.20366141442004368;
            userHistoryModel[0].UserRequest.Time = 3;
            userHistoryModel[0].UserRequest.UserBill.Base_Price = 10;
            userHistoryModel[0].UserRequest.UserBill.Ride_Fare = 0;
            userHistoryModel[0].UserRequest.UserBill.Base_Distance = 1;
            userHistoryModel[0].UserRequest.UserBill.Price_Per_Distance = 2;
            userHistoryModel[0].UserRequest.UserBill.Price_Per_Time = 5;
            userHistoryModel[0].UserRequest.UserBill.Distance_Price = 0;
            userHistoryModel[0].UserRequest.UserBill.Time_Price = 15;
            userHistoryModel[0].UserRequest.UserBill.Waiting_Price = 0;
            userHistoryModel[0].UserRequest.UserBill.Tollgate_Price = 0;
            userHistoryModel[0].UserRequest.UserBill.Tollgate_List = null;
            userHistoryModel[0].UserRequest.UserBill.Service_Tax = 2.5;
            userHistoryModel[0].UserRequest.UserBill.Service_Tax_Percentage = 10;
            userHistoryModel[0].UserRequest.UserBill.Promo_Amount = 0;
            userHistoryModel[0].UserRequest.UserBill.Referral_Amount = 0;
            userHistoryModel[0].UserRequest.UserBill.Wallet_Amount = 0;
            userHistoryModel[0].UserRequest.UserBill.Service_Fee = 5;
            userHistoryModel[0].UserRequest.UserBill.Driver_Amount = 25;
            userHistoryModel[0].UserRequest.UserBill.Total = 27.5;
            userHistoryModel[0].UserRequest.UserBill.Currency = "JFJF";
            userHistoryModel[0].UserRequest.UserBill.Show_Bill = 1;
            userHistoryModel[0].UserRequest.UserBill.Unit = 0;
            userHistoryModel[0].UserRequest.UserBill.Unit_In_Words_Without_Lang = "mile";
            userHistoryModel[0].UserRequest.UserBill.Unit_In_Words = "mile";
            userHistoryModel[0].UserRequest.UserBill.TotalAdditionalCharge = 0;
            userHistoryModel[0].UserRequest.UserBill.AdditionalCharge = null;

            return this.OK<UserHistoryModel>(userHistoryModel, userHistoryModel == null ? "User_History_Not_Found" : "User_History_found", userHistoryModel == null ? 0 : 1);
        }
        #endregion

        #region Request-hhistoryList
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("historyList")]
        public IActionResult HistoryList(GeneralModel generalModel)
        {
            List<UserHistoryListModel> userHistoryListModels = new List<UserHistoryListModel>();
            UserHistoryListModel userHistoryListModel = new UserHistoryListModel();
            userHistoryListModel.History = new UserHistory();
            userHistoryListModel.History.Request_Id = "RES_61863";
            userHistoryListModel.History.Id = 444;
            userHistoryListModel.History.Later = 0;
            userHistoryListModel.History.Is_Share = null;
            userHistoryListModel.History.User_Id = 25;
            userHistoryListModel.History.Pick_Latitude = 11.0150898;
            userHistoryListModel.History.Pick_Longitude = 76.9825394;
            userHistoryListModel.History.Drop_Latitude = 11.00874532;
            userHistoryListModel.History.Drop_Longitude = 76.97907552;
            userHistoryListModel.History.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            userHistoryListModel.History.Drop_Location = "Anna Silai, 1025/2, Avinashi Rd, Race Course, P N Palayam, Coimbatore, Tamil Nadu 641018, India";
            userHistoryListModel.History.Trip_Start_Time = DateTime.Now;
            userHistoryListModel.History.Is_Completed = 0;
            userHistoryListModel.History.Is_Cancelled = 0;
            userHistoryListModel.History.Driver_Id = 21;
            userHistoryListModel.History.Car_Model = "KKKK";
            userHistoryListModel.History.Car_Number = "5555";
            userHistoryListModel.History.Driver_Type = 1;
            userHistoryListModel.History.Driver_Profile_Pic = "http://192.168.1.32/captaincar/public/assets/img/uploads/155741646036381.png";
            userHistoryListModel.History.Type_Icon = "http://192.168.1.25/production/captain_care/public/assets/img/uploads/54738.jpg";
            userHistoryListModel.History.Type_Name = "MPV";
            userHistoryListModel.History.Ride_Fare = 0;
            userHistoryListModel.History.Total = 0;
            userHistoryListModel.History.Currency = "JOD";
            userHistoryListModel.History.TotalAdditionalCharge = 0;
            userHistoryListModel.History.Charge = null;
            userHistoryListModel.History.Enable_Dispute_Button = true;

            UserHistoryListModel user = new UserHistoryListModel();
            user.History = new UserHistory();
            user.History.Request_Id = "RES_61863";
            user.History.Id = 444;
            user.History.Later = 0;
            user.History.Is_Share = null;
            user.History.User_Id = 25;
            user.History.Pick_Latitude = 11.0150898;
            user.History.Pick_Longitude = 76.9825394;
            user.History.Drop_Latitude = 11.00874532;
            user.History.Drop_Longitude = 76.97907552;
            user.History.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            user.History.Drop_Location = "Anna Silai, 1025/2, Avinashi Rd, Race Course, P N Palayam, Coimbatore, Tamil Nadu 641018, India";
            user.History.Trip_Start_Time = DateTime.Now;
            user.History.Is_Completed = 0;
            user.History.Is_Cancelled = 0;
            user.History.Driver_Id = 21;
            user.History.Car_Model = "KKKK";
            user.History.Car_Number = "5555";
            user.History.Driver_Type = 1;
            user.History.Driver_Profile_Pic = "http://192.168.1.32/captaincar/public/assets/img/uploads/155741646036381.png";
            user.History.Type_Icon = "http://192.168.1.25/production/captain_care/public/assets/img/uploads/54738.jpg";
            user.History.Type_Name = "MPV";
            user.History.Ride_Fare = 0;
            user.History.Total = 0;
            user.History.Currency = "JOD";
            user.History.TotalAdditionalCharge = 0;
            user.History.Charge = null;
            user.History.Enable_Dispute_Button = true;

            userHistoryListModels.Add(user);
            userHistoryListModels.Add(userHistoryListModel);
            return this.OKRESPONSE<List<UserHistoryListModel>>(userHistoryListModels, userHistoryListModels == null ? "User_History_List_Not_Found" : "User_History_List_found");
        }
        #endregion

        #region Request-temptoken
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("temptoken")]
        public IActionResult TempToken(GeneralModel generalModel)
        {
            List<TempTokenModel> tempTokenModel = new List<TempTokenModel>();
            tempTokenModel[0].Corporate = 0;
            tempTokenModel[0].Request = new Request();
            tempTokenModel[0].Sos = null;
            tempTokenModel[0].User_Sos = null;
            return this.OK<TempTokenModel>(tempTokenModel, tempTokenModel == null ? "Temp_Token_Not_Found" : "Temp_Token_found", tempTokenModel == null ? 0 : 1);
        }
        #endregion

        #region Request-requestInprogress
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("requestInprogress")]
        public IActionResult RequestInProgress(GeneralModel generalModel)
        {
            List<TempTokenModel> tempTokenModel = new List<TempTokenModel>();
            tempTokenModel[0].Corporate = 0;
            tempTokenModel[0].Request = new Request();
            tempTokenModel[0].Sos = null;
            tempTokenModel[0].User_Sos = null;
            return this.OK<TempTokenModel>(tempTokenModel, tempTokenModel == null ? "Request_InProgress_Not_Found" : "Request_InProgress_found", tempTokenModel == null ? 0 : 1);
        }
        #endregion

        #region Request-createRequest
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("createRequest")]
        public IActionResult CreateRequest(GeneralModel generalModel)
        {
            CreateRequestModel createRequestModel = new CreateRequestModel();
            return this.OKRESPONSE<CreateRequestModel>(createRequestModel, createRequestModel == null ? "Create_Request_Not_Found" : "Create_Request_found");
        }
        #endregion

        #region Request-cancelRequest
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("cancelRequest")]
        public IActionResult CancelRequest(GeneralModel generalModel)
        {
            CancelRequestModel cancelRequestModel = new CancelRequestModel();
            return this.OKRESPONSE<CancelRequestModel>(cancelRequestModel, cancelRequestModel == null ? "Cancel_Request_Not_Found" : "Cancel_Request_found");
        }
        #endregion

        #region Request-paymentStatus
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("paymentStatus")]
        public IActionResult PaymentStatus(GeneralModel generalModel)
        {
            PaymentStatusModel paymentStatusModel = new PaymentStatusModel();
            return this.OKRESPONSE<PaymentStatusModel>(paymentStatusModel, paymentStatusModel == null ? "Payment_Status_Not_Found" : "Payment_Status_found");
        }
        #endregion

        #region Request-createRequestFirebase
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("createRequestFirebase")]
        public IActionResult CreateRequestFirebase(GeneralModel generalModel)
        {
            List<CreateRequestFirebaseModel> createRequestFirebaseModel = new List<CreateRequestFirebaseModel>();
            createRequestFirebaseModel[0].CreateRequest = new CreateRequest();
            createRequestFirebaseModel[0].CreateRequest.Id = 1050;
            createRequestFirebaseModel[0].CreateRequest.Request_Id = "RES_9787";
            createRequestFirebaseModel[0].CreateRequest.Pick_Latitude = "11.3109683";
            createRequestFirebaseModel[0].CreateRequest.Pick_Location = "37, Manthampalayam Road, Manthampalayam, Tamil Nadu 638052, India";
            createRequestFirebaseModel[0].CreateRequest.Pick_Longitude = "77.59382";
            createRequestFirebaseModel[0].CreateRequest.Drop_Latitude = "11.2790913";
            createRequestFirebaseModel[0].CreateRequest.Drop_Location = "Anna Silai Perundurai, NH47, Perundurai, Tamil Nadu, India";
            createRequestFirebaseModel[0].CreateRequest.Drop_Longitude = "77.5849145";
            createRequestFirebaseModel[0].CreateRequest.Time_Left = "50";
            createRequestFirebaseModel[0].User = new RequestUser();
            createRequestFirebaseModel[0].User.Id = 96;
            createRequestFirebaseModel[0].User.FirstName = "RAJESH";
            createRequestFirebaseModel[0].User.LastName = "KANNAN";
            createRequestFirebaseModel[0].User.Email = "raj@gmail.com";
            createRequestFirebaseModel[0].User.Phone_Number = "+919685325698";
            createRequestFirebaseModel[0].User.Profile_Pic = null;
            createRequestFirebaseModel[0].User.Latitude = 0;
            createRequestFirebaseModel[0].User.Longitude = 0;
            return this.OK<CreateRequestFirebaseModel>(createRequestFirebaseModel, createRequestFirebaseModel == null ? "Create_Request_Firebase_Not_Found" : "Create_Request_Firebase_found", createRequestFirebaseModel == null ? 0 : 1);
        }
        #endregion

        #region Request-firebaseEta
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("firebaseEta")]
        public IActionResult FirebaseEta(GeneralModel generalModel)
        {
            List<EtaFirebaseModel> etaFirebaseModel = new List<EtaFirebaseModel>();
            etaFirebaseModel[0].Show_Price = 1;
            etaFirebaseModel[0].Distance = 4.43;
            etaFirebaseModel[0].Time = 11;
            etaFirebaseModel[0].Base_Distance = 10;
            etaFirebaseModel[0].Base_Price = 5;
            etaFirebaseModel[0].Price_Per_Distance = 5;
            etaFirebaseModel[0].Price_Per_Time = 5;
            etaFirebaseModel[0].Distance_Price = 27.76;
            etaFirebaseModel[0].time_price = 41.416666666666664;
            etaFirebaseModel[0].Total = 5;
            etaFirebaseModel[0].Approximate_Value = 1;
            etaFirebaseModel[0].Min_Amount = 5;
            etaFirebaseModel[0].Max_Amount = 5.2332;
            etaFirebaseModel[0].Tax = "00";
            etaFirebaseModel[0].Tax_Amount = 0;
            etaFirebaseModel[0].Ride_Fare = 5;
            etaFirebaseModel[0].Currency = "#";
            etaFirebaseModel[0].Type_Id = "10";
            etaFirebaseModel[0].Is_Private_Key_Trip = true;
            etaFirebaseModel[0].Type_Name = "Suv - Tamilnadu";
            etaFirebaseModel[0].Is_Accept_Share_Ride = 0;
            etaFirebaseModel[0].Base_Share_Ride_Price = 0;
            etaFirebaseModel[0].Unit = "0";
            etaFirebaseModel[0].Unit_In_Words_Without_Lang = "Miles";
            etaFirebaseModel[0].Unit_In_Words = "Miles";
            etaFirebaseModel[0].Driver_Arival_Estimation = "1 min";
            etaFirebaseModel[0].Share_Ride_Details = new Share_Ride();
            etaFirebaseModel[0].Share_Ride_Details.Number_Of_Seats = 1;
            etaFirebaseModel[0].Share_Ride_Details.Subtotal_Price = 0;
            etaFirebaseModel[0].Share_Ride_Details.Tax_Amount = 0;
            etaFirebaseModel[0].Share_Ride_Details.Total_Price = 0;

            return this.OK<EtaFirebaseModel>(etaFirebaseModel, etaFirebaseModel == null ? "Firebase_ETA_Not_Found" : "Firebase_ETA_found", etaFirebaseModel == null ? 0 : 1);
        }
        #endregion

        public List<RequestInProgress> UserRequestInprogress(LoggedInUser loggedInUser, TaxiAppzDBContext context)
        {
            List<RequestInProgress> requestInProgresses = new List<RequestInProgress>();
            var driverdtls = context.TabDrivers.Include(t => t.Serviceloc).Include(t => t.Type).Where(t => t.ContactNo == loggedInUser.Contactno && t.IsApproved == true &&
            t.IsAvailable == true && t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            if (driverdtls == null)
                return requestInProgresses;
            var requestmeta = context.TabRequestMeta.Include(t => t.User).Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
            var tripdtls = new TabRequest();
            if (requestmeta == null)
            {
                tripdtls = context.TabRequest.Include(t => t.User).Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
            }
            var servicelocdetails = context.TabServicelocation.Where(t => t.Servicelocid == driverdtls.Serviceloc.Servicelocid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            if (servicelocdetails == null)
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
