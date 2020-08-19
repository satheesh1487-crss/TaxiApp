using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Interface;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverRequestController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public DriverRequestController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Request_Apis
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("requestInprogress")]
        public IActionResult RequestInProgress()
        {
            List<RequestInProgress> requestInProgressModel = new List<RequestInProgress>();
            DADriverRequest dADriverRequest = new DADriverRequest();
            //requestInProgressModel.Request = new IsRequest();
            //requestInProgressModel.Driver_Status = new DriverStatus();
            //requestInProgressModel.Share_Status = false;
            //requestInProgressModel.Enable_Referral = true;
            //requestInProgressModel.Admin_Phone_Number = "9658436528";
            //requestInProgressModel.Customer_Care_Number = "8569326534";
            //requestInProgressModel.Request.Trip = false;
            //requestInProgressModel.Driver_Status.Is_Active = 1;
            //requestInProgressModel.Driver_Status.Is_Approve = 1;
            //requestInProgressModel.Driver_Status.Is_Available = 1;
            //requestInProgressModel.Driver_Status.Document_Upload_Status = true;
            //requestInProgressModel.Emergecy = null;
            requestInProgressModel = dADriverRequest.DriverRequestInprogress(User.ToAppUser(),_context);
            return this.OK<RequestInProgress>(requestInProgressModel, requestInProgressModel == null ? "Request_Not_Found" : "Request_found", requestInProgressModel == null ? 0 : 1);
        }

        [HttpPost]
        [Route("historyList")]
        public IActionResult HistoryList(GeneralModel generalModel)
        {
            List<DriverHistoryListModel> driverHistoryListModels = new List<DriverHistoryListModel>();
            DriverHistoryListModel driverHistoryListModel = new DriverHistoryListModel();
            driverHistoryListModel.History = new History();
            driverHistoryListModel.History.Request_Id = "RES_61863";
            driverHistoryListModel.History.Id = 444;
            driverHistoryListModel.History.Later = 0;
            driverHistoryListModel.History.Ride_Later_Custom_Driver = 0;
            driverHistoryListModel.History.Is_Share = null;
            driverHistoryListModel.History.User_Id = 25;
            driverHistoryListModel.History.Pick_Latitude = 11.0150898;
            driverHistoryListModel.History.Pick_Longitude = 76.9825394;
            driverHistoryListModel.History.Drop_Latitude = 11.00874532;
            driverHistoryListModel.History.Drop_Longitude = 76.97907552;
            driverHistoryListModel.History.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            driverHistoryListModel.History.Drop_Location = "Anna Silai, 1025/2, Avinashi Rd, Race Course, P N Palayam, Coimbatore, Tamil Nadu 641018, India";
            driverHistoryListModel.History.Trip_Start_Time = DateTime.Now;
            driverHistoryListModel.History.Is_Completed = 0;
            driverHistoryListModel.History.Is_Cancelled = 0;
            driverHistoryListModel.History.Driver_Id = 21;
            driverHistoryListModel.History.Car_Model = "KKKK";
            driverHistoryListModel.History.Car_Number = "5555";
            driverHistoryListModel.History.Driver_Type = 1;
            driverHistoryListModel.History.User_Profile_Pic = "http://192.168.1.32/captaincar/public/assets/img/uploads/155741646036381.png";
            driverHistoryListModel.History.Type_Icon = "http://192.168.1.25/production/captain_care/public/assets/img/uploads/54738.jpg";
            driverHistoryListModel.History.Total = 0;
            driverHistoryListModel.History.Currency = "JOD";
            driverHistoryListModel.History.TotalAdditionalCharge = 0;
            driverHistoryListModel.History.Charge = null;


            DriverHistoryListModel driver = new DriverHistoryListModel();
            driver.History = new History();
            driver.History.Request_Id = "RES_61863";
            driver.History.Id = 444;
            driver.History.Later = 0;
            driver.History.Ride_Later_Custom_Driver = 0;
            driver.History.Is_Share = null;
            driver.History.User_Id = 25;
            driver.History.Pick_Latitude = 11.0150898;
            driver.History.Pick_Longitude = 76.9825394;
            driver.History.Drop_Latitude = 11.00874532;
            driver.History.Drop_Longitude = 76.97907552;
            driver.History.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            driver.History.Drop_Location = "Anna Silai, 1025/2, Avinashi Rd, Race Course, P N Palayam, Coimbatore, Tamil Nadu 641018, India";
            driver.History.Trip_Start_Time = DateTime.Now;
            driver.History.Is_Completed = 0;
            driver.History.Is_Cancelled = 0;
            driver.History.Driver_Id = 22;
            driver.History.Car_Model = "KKKK";
            driver.History.Car_Number = "5555";
            driver.History.Driver_Type = 1;
            driver.History.User_Profile_Pic = "http://192.168.1.32/captaincar/public/assets/img/uploads/155741646036381.png";
            driver.History.Type_Icon = "http://192.168.1.25/production/captain_care/public/assets/img/uploads/54738.jpg";
            driver.History.Total = 0;
            driver.History.Currency = "JOD";
            driver.History.TotalAdditionalCharge = 0;
            driver.History.Charge = null;

            driverHistoryListModels.Add(driver);
            driverHistoryListModels.Add(driverHistoryListModel);
            return this.OKRESPONSE<List<DriverHistoryListModel>>(driverHistoryListModels, driverHistoryListModel == null ? "History_List_Not_Found" : "History_List_found");
        }

        [HttpPost]
        [Route("cancel")]
        public IActionResult Cancel(GeneralModel generalModel)
        {
            TripCancelModel tripCancelModel = new TripCancelModel();
            return this.OKRESPONSE<TripCancelModel>(tripCancelModel, tripCancelModel == null ? "Trip_Cancel_Not_Found" : "Trip_Cancel_found");
        }

        [HttpPost]
        [Route("start")]
        public IActionResult Start(GeneralModel generalModel)
        {
            TripStartModel tripStartModel = new TripStartModel();
            return this.OKRESPONSE<TripStartModel>(tripStartModel, tripStartModel == null ? "Trip_Start_Not_Found" : "Trip_Start_found");
        }


        [HttpPost]
        [Route("historySingle")]
        public IActionResult HistorySingle(GeneralModel generalModel)
        {
            HistoryDetailModel historyDetailModel = new HistoryDetailModel();
            historyDetailModel.Request = new Request();
            historyDetailModel.Request.User = new User();
            historyDetailModel.Request.Bill = new Bill();
            historyDetailModel.Request.Id = 525;
            historyDetailModel.Request.Is_Share = 0;
            historyDetailModel.Request.Later = 0;
            historyDetailModel.Request.Ride_Later_Custom_Driver = 0;
            historyDetailModel.Request.Show_Driver_Start_Btn = 0;
            historyDetailModel.Request.Request_Id = "RES_36904";
            historyDetailModel.Request.Pick_Latitude = 11.0150595;
            historyDetailModel.Request.Pick_Longitude = 76.9825105;
            historyDetailModel.Request.Drop_Latitude = 11.0150595;
            historyDetailModel.Request.Drop_Longitude = 76.9825105;
            historyDetailModel.Request.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            historyDetailModel.Request.Drop_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            historyDetailModel.Request.Trip_Start_Time = DateTime.Now;
            historyDetailModel.Request.Is_Completed = 1;
            historyDetailModel.Request.Is_Cancelled = 0;
            historyDetailModel.Request.Payment_Opt = 1;
            historyDetailModel.Request.Driver_Id = 1;
            historyDetailModel.Request.Enable_Dispute_Button = true;
            historyDetailModel.Request.User.Id = 25;
            historyDetailModel.Request.User.FirstName = "rajesh";
            historyDetailModel.Request.User.LastName = "kannan";
            historyDetailModel.Request.User.Profile_Pic = " ";
            historyDetailModel.Request.User.Review = 0.35;
            historyDetailModel.Request.User.Phone_Number = "+919865896532";
            historyDetailModel.Request.User.Email = "raj@gmail.com";
            historyDetailModel.Request.Car_Model = "hhhh";
            historyDetailModel.Request.Car_Number = "AD23";
            historyDetailModel.Request.Driver_Type = 1;
            historyDetailModel.Request.Type_Icon = "http://192.168.1.32/captaincar/public/assets/img/uploads/89987.jpg";
            historyDetailModel.Request.Distance = 0.20366141442004368;
            historyDetailModel.Request.Time = 3;
            historyDetailModel.Request.Bill.Base_Price = 10;
            historyDetailModel.Request.Bill.Ride_Fare = 0;
            historyDetailModel.Request.Bill.Base_Distance = 1;
            historyDetailModel.Request.Bill.Price_Per_Distance = 2;
            historyDetailModel.Request.Bill.Price_Per_Time = 5;
            historyDetailModel.Request.Bill.Distance_Price = 0;
            historyDetailModel.Request.Bill.Time_Price = 15;
            historyDetailModel.Request.Bill.Waiting_Price = 0;
            historyDetailModel.Request.Bill.Tollgate_Price = 0;
            historyDetailModel.Request.Bill.Tollgate_List = null;
            historyDetailModel.Request.Bill.Service_Tax = 2.5;
            historyDetailModel.Request.Bill.Service_Tax_Percentage = 10;
            historyDetailModel.Request.Bill.Promo_Amount = 0;
            historyDetailModel.Request.Bill.Referral_Amount = 0;
            historyDetailModel.Request.Bill.Service_Fee = 5;
            historyDetailModel.Request.Bill.Driver_Amount = 25;
            historyDetailModel.Request.Bill.Total = 27.5;
            historyDetailModel.Request.Bill.Currency = "JFJF";
            historyDetailModel.Request.Bill.Show_Bill = 1;
            historyDetailModel.Request.Bill.Unit = 0;
            historyDetailModel.Request.Bill.Unit_In_Words_Without_Lang = "mile";
            historyDetailModel.Request.Bill.Unit_In_Words = "mile";
            historyDetailModel.Request.Bill.TotalAdditionalCharge = 0;
            historyDetailModel.Request.Bill.AdditionalCharge = null;

            return this.OKRESPONSE<HistoryDetailModel>(historyDetailModel, historyDetailModel == null ? "History_Detail_Not_Found" : "History_Detail_found");
        }


        [HttpPost]
        [Route("requestAccept")]
        public IActionResult RequestAccept(GeneralModel generalModel)
        {
            RequestAcceptedModel requestAcceptedModel = new RequestAcceptedModel();
            requestAcceptedModel.Request = new RequestAccept();
            requestAcceptedModel.Request.User = new UserAccept();

            requestAcceptedModel.Request.Id = 525;
            requestAcceptedModel.Request.Is_Share = 0;
            requestAcceptedModel.Request.Later = 0;
            requestAcceptedModel.Request.Ride_Later_Custom_Driver = 0;
            requestAcceptedModel.Request.Trip_Start_Time = DateTime.Now;
            requestAcceptedModel.Request.Is_Driver_Started = 0;
            requestAcceptedModel.Request.Is_Driver_Arrived = 0;
            requestAcceptedModel.Request.Is_Trip_Start = 0;
            requestAcceptedModel.Request.Is_Completed = 1;
            requestAcceptedModel.Request.Payment_Opt = 1;
            requestAcceptedModel.Request.Type = 1;
            requestAcceptedModel.Request.Pick_Latitude = 11.0150595;
            requestAcceptedModel.Request.Pick_Longitude = 76.9825105;
            requestAcceptedModel.Request.Drop_Latitude = 11.0150595;
            requestAcceptedModel.Request.Drop_Longitude = 76.9825105;
            requestAcceptedModel.Request.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            requestAcceptedModel.Request.Drop_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            requestAcceptedModel.Request.User.Id = 25;
            requestAcceptedModel.Request.User.FirstName = "rajesh";
            requestAcceptedModel.Request.User.LastName = "kannan";
            requestAcceptedModel.Request.User.Profile_Pic = " ";
            requestAcceptedModel.Request.User.Review = 0.35;
            requestAcceptedModel.Request.User.Phone_Number = "+919865896532";
            requestAcceptedModel.Request.User.Email = "raj@gmail.com";

            return this.OKRESPONSE<RequestAcceptedModel>(requestAcceptedModel, requestAcceptedModel == null ? "History_Detail_Not_Found" : "History_Detail_found");
        }

        [HttpPost]
        [Route("requestBill")]
        public IActionResult RequestBill(GeneralModel generalModel)
        {
            RequestBillModel requestBillModel = new RequestBillModel();
            requestBillModel.Request = new RequestBill();
            requestBillModel.Request.Bill = new BillReq();

            requestBillModel.Request.Id = 525;
            requestBillModel.Request.Request_Id = "RES_29898";
            requestBillModel.Request.Distance = 7.4564520000000005;
            requestBillModel.Request.Payment_Opt = 1;
            requestBillModel.Request.Time = 1;
            requestBillModel.Request.Bill.Base_Price = 10;
            requestBillModel.Request.Bill.Base_Distance = 1;
            requestBillModel.Request.Bill.Price_Per_Distance = 2;
            requestBillModel.Request.Bill.Price_Per_Time = 5;
            requestBillModel.Request.Bill.Distance_Price = 0;
            requestBillModel.Request.Bill.Time_Price = 15;
            requestBillModel.Request.Bill.Waiting_Price = 0;
            requestBillModel.Request.Bill.Tollgate_Price = 0;
            requestBillModel.Request.Bill.Tollgate_Lists = null;
            requestBillModel.Request.Bill.Service_Tax = 2.5;
            requestBillModel.Request.Bill.Service_Tax_Percentage = 10;
            requestBillModel.Request.Bill.Promo_Amount = 0;
            requestBillModel.Request.Bill.Referral_Amount = 0;
            requestBillModel.Request.Bill.Service_Fee = 5;
            requestBillModel.Request.Bill.Cancellation_Fee = 25;
            requestBillModel.Request.Bill.Driver_Amount = 25;
            requestBillModel.Request.Bill.Total = 27.5;
            requestBillModel.Request.Bill.Currency = "JFJF";
            requestBillModel.Request.Bill.Conversion = "-";
            requestBillModel.Request.Bill.Show_Bill = 1;
            requestBillModel.Request.Bill.Unit = 0;
            requestBillModel.Request.Bill.Unit_In_Words_Without_Lang = "mile";
            requestBillModel.Request.Bill.Unit_In_Words = "mile";
            requestBillModel.Request.Bill.Trip_Start_Time = " 15:15PM";
            requestBillModel.Request.Bill.Distance = 7.4564520000000005;
            requestBillModel.Request.Bill.TotalAdditionalCharge = 0;
            requestBillModel.Request.Bill.AdditionalCharge = null;

            return this.OKRESPONSE<RequestBillModel>(requestBillModel, requestBillModel == null ? "History_Detail_Not_Found" : "History_Detail_found");
        }

        [HttpPost]
        [Route("arrived")]
        public IActionResult Arrived(GeneralModel generalModel)
        {
            TripArrivedModel tripArrivedModel = new TripArrivedModel();
            return this.OKRESPONSE<TripArrivedModel>(tripArrivedModel, tripArrivedModel == null ? "Trip_Arrived_Not_Found" : "Trip_Arrived_found");
        }

        [HttpPost]
        [Route("requestReject")]
        public IActionResult RequestReject(GeneralModel generalModel)
        {
            RequestRejectModel requestRejectModel = new RequestRejectModel();
            return this.OKRESPONSE<RequestRejectModel>(requestRejectModel, requestRejectModel == null ? "Trip_Reject_Not_Found" : "Trip_Reject_found");
        }

        [HttpPost]
        [Route("fromrequest")]
        public IActionResult FromRequest(GeneralModel generalModel)
        {
            RequestRejectModel requestRejectModel = new RequestRejectModel();
            return this.OKRESPONSE<RequestRejectModel>(requestRejectModel, requestRejectModel == null ? "From_Request_Not_Found" : "From_Request_found");
        }
        #endregion
    }
}
