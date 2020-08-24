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
    public class UserETAController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserETAController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region List-Types by Pickup location
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("types")]
        public IActionResult Types(GeneralModel generalModel)
        {
            List<ETAListTypesModel> eTAListTypesModels = new List<ETAListTypesModel>();
            ETAListTypesModel eTAListTypesModel = new ETAListTypesModel();
            eTAListTypesModel.Data = new List<ETAData>();
            eTAListTypesModel.Types = new List<ETAData>();
            List<ETAData> eTADatas = new List<ETAData>();
            ETAData eTAData = new ETAData();
            eTAData.Payment_Type = new List<Payment_Type>();
            eTAData.Payment_Type.Add(new Payment_Type() { Card=1, Cash=2, Wallet=3 });
            List<Payment_Type> payment_Types=new List<Payment_Type>();
            eTAListTypesModel.Data.Add(new ETAData() { Id = 1, Type_Id = 20, Name= "Suv - Tamilnadu", Icon= "http://52.15.44.26/taxi/public/storage/uploads/driver/types/nom4lmSgL7RJvgAYXJ5mBby7jWgyZougNmeG6XbF.jpg", Capacity=0, Driver_Search_Radius="3", Is_Accept_Share_Ride=0, Active=1, Preferred_Payment=1 });
            eTAListTypesModel.Types.Add(new ETAData() { Id = 1, Type_Id = 20, Name = "Suv - Tamilnadu", Icon = "http://52.15.44.26/taxi/public/storage/uploads/driver/types/nom4lmSgL7RJvgAYXJ5mBby7jWgyZougNmeG6XbF.jpg", Capacity = 0, Driver_Search_Radius = "3", Is_Accept_Share_Ride = 0, Active = 1, Preferred_Payment = 1 });
            return this.OKRESPONSE<ETAListTypesModel>(eTAListTypesModel, eTAListTypesModel == null ? "ETA_List_Types_Not_Found" : "ETA_List_Types_found");
        }
        #endregion

        #region ETA
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("eta")]
        public IActionResult ETA(GeneralModel generalModel)
        {
            List<ETAListModel> eTAList = new List<ETAListModel>();
            ETAListModel eTAListModel = new ETAListModel();
            eTAListModel = new ETAListModel();
            eTAListModel.Distance = 4.43;
            eTAListModel.Time = 11;
            eTAListModel.Base_Distance = 10;
            eTAListModel.Base_Price = 5;
            eTAListModel.Price_Per_Distance = 5;
            eTAListModel.Price_Per_Time = 5;
            eTAListModel.Distance_Price = 27.76;
            eTAListModel.time_price = 41.416666666666664;
            eTAListModel.Total = 5;
            eTAListModel.Approximate_Value = 1;
            eTAListModel.Min_Amount = 5;
            eTAListModel.Max_Amount = 5.2332;
            eTAListModel.Tax = "00";
            eTAListModel.Tax_Amount = 0;
            eTAListModel.Ride_Fare = 5;
            eTAListModel.Currency = "#";
            eTAListModel.Type_Id = "10";      
            eTAListModel.Type_Name = "Suv - Tamilnadu";
            eTAListModel.Is_Accept_Share_Ride = 0;
            eTAListModel.Base_Share_Ride_Price = 0;
            eTAListModel.Unit = "0";
            eTAListModel.Unit_In_Words_Without_Lang = "Miles";
            eTAListModel.Unit_In_Words = "Miles";
            eTAListModel.Driver_Arival_Estimation = "1 min";
            eTAListModel.Share_Ride_Details = new Share_Ride();
            eTAListModel.Share_Ride_Details.Number_Of_Seats = 1;
            eTAListModel.Share_Ride_Details.Subtotal_Price = 0;
            eTAListModel.Share_Ride_Details.Tax_Amount = 0;
            eTAListModel.Share_Ride_Details.Total_Price = 0;
            eTAList.Add(eTAListModel);
            return this.OK<List<ETAListModel>>(eTAList, eTAList.Count == 0 ? "Firebase_ETA_Not_Found" : "Firebase_ETA_found", eTAList.Count == 0 ? 0 : 1);
        }
        #endregion
    }
}
