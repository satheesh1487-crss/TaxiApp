using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("historySingle")]
        public IActionResult HistorySingle(GeneralModel generalModel)
        {
            UserHistoryModel userHistoryModel = new UserHistoryModel();
            userHistoryModel.UserRequest = new UserRequest();
            userHistoryModel.UserRequest.Driver = new Drivers();
            userHistoryModel.UserRequest.UserBill = new UserBill();
            userHistoryModel.UserRequest.Id = 525;
            userHistoryModel.UserRequest.Is_Share = 0;
            userHistoryModel.UserRequest.Later = 0;
            userHistoryModel.UserRequest.Request_Id = "RES_36904";
            userHistoryModel.UserRequest.Pick_Latitude = 11.0150595;
            userHistoryModel.UserRequest.Pick_Longitude = 76.9825105;
            userHistoryModel.UserRequest.Drop_Latitude = 11.0150595;
            userHistoryModel.UserRequest.Drop_Longitude = 76.9825105;
            userHistoryModel.UserRequest.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            userHistoryModel.UserRequest.Drop_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            userHistoryModel.UserRequest.Trip_Start_Time = DateTime.Now;
            userHistoryModel.UserRequest.Is_Completed = 1;
            userHistoryModel.UserRequest.Is_Cancelled = 0;
            userHistoryModel.UserRequest.Payment_Opt = 1;
            userHistoryModel.UserRequest.User_Id = 1;
            userHistoryModel.UserRequest.Enable_Dispute_Button = true;
            userHistoryModel.UserRequest.Driver.Id = 25;
            userHistoryModel.UserRequest.Driver.FirstName = "rajesh";
            userHistoryModel.UserRequest.Driver.LastName = "kannan";
            userHistoryModel.UserRequest.Driver.Profile_Pic = " ";
            userHistoryModel.UserRequest.Driver.Review = 0.35;
            userHistoryModel.UserRequest.Driver.Phone_Number = "+919865896532";
            userHistoryModel.UserRequest.Driver.Email = "raj@gmail.com";
            userHistoryModel.UserRequest.Driver.Car_Model = "hhhh";
            userHistoryModel.UserRequest.Driver.Car_Number = "AD23";
            userHistoryModel.UserRequest.Driver_Type = 1;
            userHistoryModel.UserRequest.Type_Icon = "http://192.168.1.32/captaincar/public/assets/img/uploads/89987.jpg";
            userHistoryModel.UserRequest.Type_Name = "DKJH";
            userHistoryModel.UserRequest.Distance = 0.20366141442004368;
            userHistoryModel.UserRequest.Time = 3;
            userHistoryModel.UserRequest.UserBill.Base_Price = 10;
            userHistoryModel.UserRequest.UserBill.Ride_Fare = 0;
            userHistoryModel.UserRequest.UserBill.Base_Distance = 1;
            userHistoryModel.UserRequest.UserBill.Price_Per_Distance = 2;
            userHistoryModel.UserRequest.UserBill.Price_Per_Time = 5;
            userHistoryModel.UserRequest.UserBill.Distance_Price = 0;
            userHistoryModel.UserRequest.UserBill.Time_Price = 15;
            userHistoryModel.UserRequest.UserBill.Waiting_Price = 0;
            userHistoryModel.UserRequest.UserBill.Tollgate_Price = 0;
            userHistoryModel.UserRequest.UserBill.Tollgate_List = null;
            userHistoryModel.UserRequest.UserBill.Service_Tax = 2.5;
            userHistoryModel.UserRequest.UserBill.Service_Tax_Percentage = 10;
            userHistoryModel.UserRequest.UserBill.Promo_Amount = 0;
            userHistoryModel.UserRequest.UserBill.Referral_Amount = 0;
            userHistoryModel.UserRequest.UserBill.Wallet_Amount = 0;
            userHistoryModel.UserRequest.UserBill.Service_Fee = 5;
            userHistoryModel.UserRequest.UserBill.Driver_Amount = 25;
            userHistoryModel.UserRequest.UserBill.Total = 27.5;
            userHistoryModel.UserRequest.UserBill.Currency = "JFJF";
            userHistoryModel.UserRequest.UserBill.Show_Bill = 1;
            userHistoryModel.UserRequest.UserBill.Unit = 0;
            userHistoryModel.UserRequest.UserBill.Unit_In_Words_Without_Lang = "mile";
            userHistoryModel.UserRequest.UserBill.Unit_In_Words = "mile";
            userHistoryModel.UserRequest.UserBill.TotalAdditionalCharge = 0;
            userHistoryModel.UserRequest.UserBill.AdditionalCharge = null;

            return this.OKRESPONSE<UserHistoryModel>(userHistoryModel, userHistoryModel == null ? "User_History_Not_Found" : "User_History_found");
        }

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

        [HttpPost]
        [Route("temptoken")]
        public IActionResult TempToken(GeneralModel generalModel)
        {
            TempTokenModel tempTokenModel = new TempTokenModel();
            tempTokenModel.Corporate = 0;
            tempTokenModel.Request = new Request();
            tempTokenModel.Sos = null;
            tempTokenModel.User_Sos = null;
            return this.OKRESPONSE<TempTokenModel>(tempTokenModel, tempTokenModel == null ? "Temp_Token_Not_Found" : "Temp_Token_found");
        }

        [HttpPost]
        [Route("requestInprogress")]
        public IActionResult RequestInProgress(GeneralModel generalModel)
        {
            TempTokenModel tempTokenModel = new TempTokenModel();
            tempTokenModel.Corporate = 0;
            tempTokenModel.Request = new Request();
            tempTokenModel.Sos = null;
            tempTokenModel.User_Sos = null;
            return this.OKRESPONSE<TempTokenModel>(tempTokenModel, tempTokenModel == null ? "Request_InProgress_Not_Found" : "Request_InProgress_found");
        }

        [HttpPost]
        [Route("createRequest")]
        public IActionResult CreateRequest(GeneralModel generalModel)
        {
            CreateRequestModel createRequestModel = new CreateRequestModel();
            return this.OKRESPONSE<CreateRequestModel>(createRequestModel, createRequestModel == null ? "Create_Request_Not_Found" : "Create_Request_found");
        }

        [HttpPost]
        [Route("cancelRequest")]
        public IActionResult CancelRequest(GeneralModel generalModel)
        {
            CancelRequestModel cancelRequestModel = new CancelRequestModel();
            return this.OKRESPONSE<CancelRequestModel>(cancelRequestModel, cancelRequestModel == null ? "Cancel_Request_Not_Found" : "Cancel_Request_found");
        }

        [HttpPost]
        [Route("paymentStatus")]
        public IActionResult PaymentStatus(GeneralModel generalModel)
        {
            PaymentStatusModel paymentStatusModel = new PaymentStatusModel();
            return this.OKRESPONSE<PaymentStatusModel>(paymentStatusModel, paymentStatusModel == null ? "Payment_Status_Not_Found" : "Payment_Status_found");
        }

        [HttpPost]
        [Route("createRequestFirebase")]
        public IActionResult CreateRequestFirebase(GeneralModel generalModel)
        {
            CreateRequestFirebaseModel createRequestFirebaseModel = new CreateRequestFirebaseModel();
            createRequestFirebaseModel.CreateRequest = new CreateRequest();
            createRequestFirebaseModel.CreateRequest.Id = 1050;
            createRequestFirebaseModel.CreateRequest.Request_Id = "RES_9787";
            createRequestFirebaseModel.CreateRequest.Pick_Latitude = "11.3109683";
            createRequestFirebaseModel.CreateRequest.Pick_Location = "37, Manthampalayam Road, Manthampalayam, Tamil Nadu 638052, India";
            createRequestFirebaseModel.CreateRequest.Pick_Longitude = "77.59382";
            createRequestFirebaseModel.CreateRequest.Drop_Latitude = "11.2790913";
            createRequestFirebaseModel.CreateRequest.Drop_Location = "Anna Silai Perundurai, NH47, Perundurai, Tamil Nadu, India";
            createRequestFirebaseModel.CreateRequest.Drop_Longitude = "77.5849145";
            createRequestFirebaseModel.CreateRequest.Time_Left = "50";
            createRequestFirebaseModel.User = new RequestUser();
            createRequestFirebaseModel.User.Id = 96;
            createRequestFirebaseModel.User.FirstName = "RAJESH";
            createRequestFirebaseModel.User.LastName = "KANNAN";
            createRequestFirebaseModel.User.Email = "raj@gmail.com";
            createRequestFirebaseModel.User.Phone_Number = "+919685325698";
            createRequestFirebaseModel.User.Profile_Pic = null;
            createRequestFirebaseModel.User.Latitude = 0;
            createRequestFirebaseModel.User.Longitude = 0;
            return this.OKRESPONSE<CreateRequestFirebaseModel>(createRequestFirebaseModel, createRequestFirebaseModel == null ? "Create_Request_Firebase_Not_Found" : "Create_Request_Firebase_found");
        }

        [HttpPost]
        [Route("firebaseEta")]
        public IActionResult FirebaseEta(GeneralModel generalModel)
        {
            EtaFirebaseModel etaFirebaseModel = new EtaFirebaseModel();
            etaFirebaseModel.Show_Price = 1;
            etaFirebaseModel.Distance = 4.43;
            etaFirebaseModel.Time = 11;
            etaFirebaseModel.Base_Distance = 10;
            etaFirebaseModel.Base_Price = 5;
            etaFirebaseModel.Price_Per_Distance = 5;
            etaFirebaseModel.Price_Per_Time = 5;
            etaFirebaseModel.Distance_Price = 27.76;
            etaFirebaseModel.time_price = 41.416666666666664;
            etaFirebaseModel.Total = 5;
            etaFirebaseModel.Approximate_Value = 1;
            etaFirebaseModel.Min_Amount = 5;
            etaFirebaseModel.Max_Amount = 5.2332;
            etaFirebaseModel.Tax = "00";
            etaFirebaseModel.Tax_Amount = 0;
            etaFirebaseModel.Ride_Fare = 5;
            etaFirebaseModel.Currency = "#";
            etaFirebaseModel.Type_Id = "10";
            etaFirebaseModel.Is_Private_Key_Trip = true;
            etaFirebaseModel.Type_Name = "Suv - Tamilnadu";
            etaFirebaseModel.Is_Accept_Share_Ride = 0;
            etaFirebaseModel.Base_Share_Ride_Price = 0;
            etaFirebaseModel.Share_Ride_Details = new Share_Ride();
            etaFirebaseModel.Share_Ride_Details.Number_Of_Seats = 1;
            etaFirebaseModel.Share_Ride_Details.Subtotal_Price = 0;
            etaFirebaseModel.Share_Ride_Details.Tax_Amount = 0;
            etaFirebaseModel.Share_Ride_Details.Total_Price = 0;

            return this.OKRESPONSE<EtaFirebaseModel>(etaFirebaseModel, etaFirebaseModel == null ? "Firebase_ETA_Not_Found" : "Firebase_ETA_found");
        }
    }
}
