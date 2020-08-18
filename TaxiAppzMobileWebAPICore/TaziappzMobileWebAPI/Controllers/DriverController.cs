using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        public DriverController(TaxiAppzDBContext context)
        {
            _context = context;

        }

        #region Payment_Apis
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("getwallet")]
        public IActionResult GetWallet(GeneralModel generalModel)
        {
            GetWalletModel getWalletModel = new GetWalletModel();
            getWalletModel.Amount_Added = 500;
            getWalletModel.Amount_Balance = 100;
            getWalletModel.Amount_Spent = 400;
            getWalletModel.Currency = "&";
            return this.OKRESPONSE<GetWalletModel>(getWalletModel, getWalletModel == null ? "wallet_not_found" : "wallet_found");
        }

        [HttpPost]
        [Route("cardlist")]
        public IActionResult CardList(GeneralModel generalModel)
        {
            CardListModel cardListModel = new CardListModel();
            cardListModel.Payment = new Payment();
            cardListModel.Payment.Card_Id = 1;
            cardListModel.Payment.Last_Number = "555";
            cardListModel.Payment.Card_Type = "VISA";
            cardListModel.Payment.Is_Default = true;            
            return this.OKRESPONSE<CardListModel>(cardListModel, cardListModel == null ? "CardList_Not_Found" : "CardList_Found");
        }

        [HttpPost]
        [Route("addwallet")]
        public IActionResult AddWallet(GeneralModel generalModel)
        {
            AddWalletModel addWalletModel = new AddWalletModel();
            addWalletModel.Amount_Added = 500;
            addWalletModel.Amount_Balance = 100;
            addWalletModel.Amount_Spent = 400;
            addWalletModel.Currency = "&";
            return this.OKRESPONSE<AddWalletModel>(addWalletModel, addWalletModel == null ? "AddWallet_not_found" : "AddWallet_found");
        }

        [HttpPost]
        [Route("addcard")]
        public IActionResult AddCard(GeneralModel generalModel)
        {
            AddCardModel addCardModel = new AddCardModel();
            addCardModel.Payment = new Payment();
            addCardModel.Payment.Card_Id = 1;
            addCardModel.Payment.Last_Number = "555";
            addCardModel.Payment.Card_Type = "VISA";
            addCardModel.Payment.Is_Default = true;
            return this.OKRESPONSE<AddCardModel>(addCardModel, addCardModel == null ? "AddWallet_not_found" : "AddWallet_found");
        }

        #endregion

        #region Request_Apis
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("requestInprogress")]
        public IActionResult RequestInProgress(GeneralModel generalModel)
        {
            RequestInProgressModel requestInProgressModel = new RequestInProgressModel();
            requestInProgressModel.Request = new IsRequest();
            requestInProgressModel.Driver_Status = new DriverStatus();
            requestInProgressModel.Share_Status = false;
            requestInProgressModel.Enable_Referral = true;
            requestInProgressModel.Admin_Phone_Number = "9658436528";
            requestInProgressModel.Customer_Care_Number = "8569326534";
            requestInProgressModel.Request.Trip = false;
            requestInProgressModel.Driver_Status.Is_Active = 1;
            requestInProgressModel.Driver_Status.Is_Approve = 1;
            requestInProgressModel.Driver_Status.Is_Available = 1;
            requestInProgressModel.Driver_Status.Document_Upload_Status = true;
            requestInProgressModel.Emergecy = null;
            return this.OKRESPONSE<RequestInProgressModel>(requestInProgressModel, requestInProgressModel == null ? "Request_Not_Found" : "Request_found");
        }

        [HttpPost]
        [Route("historyList")]
        public IActionResult HistoryList(GeneralModel generalModel)
        {
            List<DriverHistoryListModel> driverHistoryListModels =new List<DriverHistoryListModel> ();
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
            driverHistoryListModel.History.Pick_Latitude = 11.00874532;
            driverHistoryListModel.History.Pick_Longitude = 76.97907552;
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
            driver.History.Pick_Latitude = 11.00874532;
            driver.History.Pick_Longitude = 76.97907552;
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
    }
}
