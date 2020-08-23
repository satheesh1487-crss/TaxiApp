using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Helper;
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

        #region Request_requestInprogress
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
            requestInProgressModel = dADriverRequest.DriverRequestInprogress(User.ToAppUser(), _context);
            //requestInProgressModel[0].Request = new IsRequest();
            //requestInProgressModel[0].Driver_Status = new DriverStatus();
            //requestInProgressModel[0].Share_Status = false;
            //requestInProgressModel[0].Enable_Referral = true;
            //requestInProgressModel[0].Admin_Phone_Number = "9658436528";
            //requestInProgressModel[0].Customer_Care_Number = "8569326534";
            //requestInProgressModel[0].Request.Trip = false;
            //requestInProgressModel[0].Driver_Status.Is_Active = 1;
            //requestInProgressModel[0].Driver_Status.Is_Approve = 1;
            //requestInProgressModel[0].Driver_Status.Is_Available = 1;
            //requestInProgressModel[0].Driver_Status.Document_Upload_Status = true;
            //requestInProgressModel[0].Emergecy = null;
            return this.OK<RequestInProgress>(requestInProgressModel, requestInProgressModel.Count == 0 ? "Request_Not_Found" : "Request_found", requestInProgressModel.Count == 0 ? 0 : 1);
        }

        #endregion

        #region Request_historyList
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
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
        #endregion

        #region Request_cancel
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("cancel")]
        public IActionResult Cancel(GeneralModel generalModel)
        {
            TripCancelModel tripCancelModel = new TripCancelModel();
            return this.OKRESPONSE<TripCancelModel>(tripCancelModel, tripCancelModel == null ? "Trip_Cancel_Not_Found" : "Trip_Cancel_found");
        }
        #endregion

        #region Request_start
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("start")]
        public IActionResult Start(GeneralModel generalModel)
        {
            TripStartModel tripStartModel = new TripStartModel();
            return this.OKRESPONSE<TripStartModel>(tripStartModel, tripStartModel == null ? "Trip_Start_Not_Found" : "Trip_Start_found");
        }
        #endregion

        #region Request_historySingle
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("historySingle")]
        public IActionResult HistorySingle(GeneralModel generalModel)
        {
            List<HistoryDetailModel> historyDetailModel = new List<HistoryDetailModel>();
            historyDetailModel[0].Request = new Request();
            historyDetailModel[0].Request.User = new User();
            historyDetailModel[0].Request.Bill = new Bill();
            historyDetailModel[0].Request.Id = 525;
            historyDetailModel[0].Request.Is_Share = 0;
            historyDetailModel[0].Request.Later = 0;
            historyDetailModel[0].Request.Ride_Later_Custom_Driver = 0;
            historyDetailModel[0].Request.Show_Driver_Start_Btn = 0;
            historyDetailModel[0].Request.Request_Id = "RES_36904";
            historyDetailModel[0].Request.Pick_Latitude = 11.0150595;
            historyDetailModel[0].Request.Pick_Longitude = 76.9825105;
            historyDetailModel[0].Request.Drop_Latitude = 11.0150595;
            historyDetailModel[0].Request.Drop_Longitude = 76.9825105;
            historyDetailModel[0].Request.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            historyDetailModel[0].Request.Drop_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            historyDetailModel[0].Request.Trip_Start_Time = DateTime.Now;
            historyDetailModel[0].Request.Is_Completed = 1;
            historyDetailModel[0].Request.Is_Cancelled = 0;
            historyDetailModel[0].Request.Payment_Opt = 1;
            historyDetailModel[0].Request.Driver_Id = 1;
            historyDetailModel[0].Request.Enable_Dispute_Button = true;
            historyDetailModel[0].Request.User.Id = 25;
            historyDetailModel[0].Request.User.FirstName = "rajesh";
            historyDetailModel[0].Request.User.LastName = "kannan";
            historyDetailModel[0].Request.User.Profile_Pic = " ";
            historyDetailModel[0].Request.User.Review = 0.35;
            historyDetailModel[0].Request.User.Phone_Number = "+919865896532";
            historyDetailModel[0].Request.User.Email = "raj@gmail.com";
            historyDetailModel[0].Request.Car_Model = "hhhh";
            historyDetailModel[0].Request.Car_Number = "AD23";
            historyDetailModel[0].Request.Driver_Type = 1;
            historyDetailModel[0].Request.Type_Icon = "http://192.168.1.32/captaincar/public/assets/img/uploads/89987.jpg";
            historyDetailModel[0].Request.Distance = 0.20366141442004368;
            historyDetailModel[0].Request.Time = 3;
            historyDetailModel[0].Request.Bill.Base_Price = 10;
            historyDetailModel[0].Request.Bill.Ride_Fare = 0;
            historyDetailModel[0].Request.Bill.Base_Distance = 1;
            historyDetailModel[0].Request.Bill.Price_Per_Distance = 2;
            historyDetailModel[0].Request.Bill.Price_Per_Time = 5;
            historyDetailModel[0].Request.Bill.Distance_Price = 0;
            historyDetailModel[0].Request.Bill.Time_Price = 15;
            historyDetailModel[0].Request.Bill.Waiting_Price = 0;
            historyDetailModel[0].Request.Bill.Tollgate_Price = 0;
            historyDetailModel[0].Request.Bill.Tollgate_List = null;
            historyDetailModel[0].Request.Bill.Service_Tax = 2.5;
            historyDetailModel[0].Request.Bill.Service_Tax_Percentage = 10;
            historyDetailModel[0].Request.Bill.Promo_Amount = 0;
            historyDetailModel[0].Request.Bill.Referral_Amount = 0;
            historyDetailModel[0].Request.Bill.Service_Fee = 5;
            historyDetailModel[0].Request.Bill.Driver_Amount = 25;
            historyDetailModel[0].Request.Bill.Total = 27.5;
            historyDetailModel[0].Request.Bill.Currency = "JFJF";
            historyDetailModel[0].Request.Bill.Show_Bill = 1;
            historyDetailModel[0].Request.Bill.Unit = 0;
            historyDetailModel[0].Request.Bill.Unit_In_Words_Without_Lang = "mile";
            historyDetailModel[0].Request.Bill.Unit_In_Words = "mile";
            historyDetailModel[0].Request.Bill.TotalAdditionalCharge = 0;
            historyDetailModel[0].Request.Bill.AdditionalCharge = null;

            return this.OK<HistoryDetailModel>(historyDetailModel, historyDetailModel == null ? "History_Detail_Not_Found" : "History_Detail_found", historyDetailModel == null ? 0 : 1);
        }
        #endregion

        #region Request_Accept
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("requestAccept")]
        public IActionResult RequestAccept(GeneralModel generalModel)
        {
            List<RequestAcceptedModel> requestAcceptedModel = new List<RequestAcceptedModel>();
            requestAcceptedModel[0].Request = new RequestAccept();
            requestAcceptedModel[0].Request.User = new UserAccept();

            requestAcceptedModel[0].Request.Id = 525;
            requestAcceptedModel[0].Request.Is_Share = 0;
            requestAcceptedModel[0].Request.Later = 0;
            requestAcceptedModel[0].Request.Ride_Later_Custom_Driver = 0;
            requestAcceptedModel[0].Request.Trip_Start_Time = DateTime.Now;
            requestAcceptedModel[0].Request.Is_Driver_Started = 0;
            requestAcceptedModel[0].Request.Is_Driver_Arrived = 0;
            requestAcceptedModel[0].Request.Is_Trip_Start = 0;
            requestAcceptedModel[0].Request.Is_Completed = 1;
            requestAcceptedModel[0].Request.Payment_Opt = 1;
            requestAcceptedModel[0].Request.Type = 1;
            requestAcceptedModel[0].Request.Pick_Latitude = 11.0150595;
            requestAcceptedModel[0].Request.Pick_Longitude = 76.9825105;
            requestAcceptedModel[0].Request.Drop_Latitude = 11.0150595;
            requestAcceptedModel[0].Request.Drop_Longitude = 76.9825105;
            requestAcceptedModel[0].Request.Pick_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            requestAcceptedModel[0].Request.Drop_Location = "56, LMS Street, P N Palayam, Tamil Nadu, 641044, India";
            requestAcceptedModel[0].Request.User.Id = 25;
            requestAcceptedModel[0].Request.User.FirstName = "rajesh";
            requestAcceptedModel[0].Request.User.LastName = "kannan";
            requestAcceptedModel[0].Request.User.Profile_Pic = " ";
            requestAcceptedModel[0].Request.User.Review = 0.35;
            requestAcceptedModel[0].Request.User.Phone_Number = "+919865896532";
            requestAcceptedModel[0].Request.User.Email = "raj@gmail.com";

            return this.OK<RequestAcceptedModel>(requestAcceptedModel, requestAcceptedModel == null ? "History_Detail_Not_Found" : "History_Detail_found", requestAcceptedModel == null ? 0 : 1);
        }
        #endregion

        #region Request_bill
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("requestBill")]
        public IActionResult RequestBill(GeneralModel generalModel)
        {
            List<RequestBillModel> requestBillModel = new List<RequestBillModel>();
            requestBillModel[0].Request = new RequestBill();
            requestBillModel[0].Request.Bill = new BillReq();

            requestBillModel[0].Request.Id = 525;
            requestBillModel[0].Request.Request_Id = "RES_29898";
            requestBillModel[0].Request.Distance = 7.4564520000000005;
            requestBillModel[0].Request.Payment_Opt = 1;
            requestBillModel[0].Request.Time = 1;
            requestBillModel[0].Request.Bill.Base_Price = 10;
            requestBillModel[0].Request.Bill.Base_Distance = 1;
            requestBillModel[0].Request.Bill.Price_Per_Distance = 2;
            requestBillModel[0].Request.Bill.Price_Per_Time = 5;
            requestBillModel[0].Request.Bill.Distance_Price = 0;
            requestBillModel[0].Request.Bill.Time_Price = 15;
            requestBillModel[0].Request.Bill.Waiting_Price = 0;
            requestBillModel[0].Request.Bill.Tollgate_Price = 0;
            requestBillModel[0].Request.Bill.Tollgate_Lists = null;
            requestBillModel[0].Request.Bill.Service_Tax = 2.5;
            requestBillModel[0].Request.Bill.Service_Tax_Percentage = 10;
            requestBillModel[0].Request.Bill.Promo_Amount = 0;
            requestBillModel[0].Request.Bill.Referral_Amount = 0;
            requestBillModel[0].Request.Bill.Service_Fee = 5;
            requestBillModel[0].Request.Bill.Cancellation_Fee = 25;
            requestBillModel[0].Request.Bill.Driver_Amount = 25;
            requestBillModel[0].Request.Bill.Total = 27.5;
            requestBillModel[0].Request.Bill.Currency = "JFJF";
            requestBillModel[0].Request.Bill.Conversion = "-";
            requestBillModel[0].Request.Bill.Show_Bill = 1;
            requestBillModel[0].Request.Bill.Unit = 0;
            requestBillModel[0].Request.Bill.Unit_In_Words_Without_Lang = "mile";
            requestBillModel[0].Request.Bill.Unit_In_Words = "mile";
            requestBillModel[0].Request.Bill.Trip_Start_Time = " 15:15PM";
            requestBillModel[0].Request.Bill.Distance = 7.4564520000000005;
            requestBillModel[0].Request.Bill.TotalAdditionalCharge = 0;
            requestBillModel[0].Request.Bill.AdditionalCharge = null;

            return this.OK<RequestBillModel>(requestBillModel, requestBillModel == null ? "History_Detail_Not_Found" : "History_Detail_found", requestBillModel == null ? 0 : 1);
        }
        #endregion

        #region Request_arrived
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("arrived")]
        public IActionResult Arrived(GeneralModel generalModel)
        {
            TripArrivedModel tripArrivedModel = new TripArrivedModel();
            return this.OKRESPONSE<TripArrivedModel>(tripArrivedModel, tripArrivedModel == null ? "Trip_Arrived_Not_Found" : "Trip_Arrived_found");
        }
        #endregion

        #region Request_Reject
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("requestReject")]
        public IActionResult RequestReject(GeneralModel generalModel)
        {
            RequestRejectModel requestRejectModel = new RequestRejectModel();
            return this.OKRESPONSE<RequestRejectModel>(requestRejectModel, requestRejectModel == null ? "Trip_Reject_Not_Found" : "Trip_Reject_found");
        }
        #endregion

        #region Request_fromrequest
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("fromrequest")]
        public IActionResult FromRequest(GeneralModel generalModel)
        {
            RequestRejectModel requestRejectModel = new RequestRejectModel();
            return this.OKRESPONSE<RequestRejectModel>(requestRejectModel, requestRejectModel == null ? "From_Request_Not_Found" : "From_Request_found");
        }
        #endregion

        #region Request_OnlineStatus        
        [HttpPost]
        [Route("onlinStatus")]
        public IActionResult OnlinStatus(DriverStatusModel driverStatusModel)
        {
            try
            {
                DADriverRequest dADriverRequest = new DADriverRequest();
                var result = dADriverRequest.onlineStatus(_context, driverStatusModel, User.ToAppUser());
                List<RequestStatusModel> requestStatusModels = new List<RequestStatusModel>();
                requestStatusModels.Add(result);
                return this.OK<RequestStatusModel>(requestStatusModels, requestStatusModels.Count == 0 ? "Driver_Online" : "Driver_Offline", 1);
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
        }
        #endregion

        #region Accept Status
        [HttpPost]
        [Route("AcceptStatus")]
        public IActionResult AcceptRequest(long requestid,Boolean Acceptstatus)
        {
            try
            {
                DADriverRequest dADriverRequest = new DADriverRequest();
                var result = dADriverRequest.RequestAcceptReject(requestid, Acceptstatus,_context, User.ToAppUser());
                return this.OKStatus(result ? "Success" : "Failed", result ? 1 : 0);
            }
            catch (DataValidationException ex)
            {
                return this.KnowOperationError(ex.Message);
            }
            #endregion
        }
    }
}
