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
    public class DriverCommonController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public DriverCommonController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Common_review
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("review")]
        public IActionResult Review(GeneralModel generalModel)
        {
            RequestReviewModel requestReviewModel = new RequestReviewModel();
            return this.OKRESPONSE<RequestReviewModel>(requestReviewModel, requestReviewModel == null ? "Request_Review_not_found" : "Request_Review_found");
        }
        #endregion

        #region Common_retrieve
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("retrieve")]
        public IActionResult Retrieve(GeneralModel generalModel)
        {
            List<GetProfileModel> getProfileModel = new List<GetProfileModel>();
            Driver driver = new Driver();
            driver.Id = 15;
            driver.FirstName = "rajesh";
            driver.LastName = "kannan";
            driver.Email = "raj@gmail.com";
            driver.Phone = "918888888888";
            driver.Login_By = "android";
            driver.Login_Method = "manual";
            driver.Token = "$2y$10$sMv.qYgeNoiaJ4r1GqgEWO59BMGRi0EEN17t/hmFS0S92YUqd70QS";
            driver.Profile_Pic = "";
            driver.Is_Active = 1;
            driver.Is_Approve = 1;
            driver.Is_Available = 1;
            driver.Car_Model = "FFDJ";
            driver.Car_Number = "8888";
            driver.Total_Reward_Point = 0.5;
            driver.Type_Name = "FKLF";
            driver.Type_Icon = "http://192.168.1.25/production/captain_care/public/assets/img/uploads/54738.jpg";
            getProfileModel.Add(new GetProfileModel()
            {
                Driver =driver
            });
         return this.OK<GetProfileModel>(getProfileModel, getProfileModel.Count == 0 ? "Get_Profile_not_found" : "Get_Profile_found", getProfileModel.Count == 0 ? 0 : 1);
        }
        #endregion

        #region Common_earninglist
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("earninglist")]
        public IActionResult Earninglist(GeneralModel generalModel)
        {
            List<EarningsListModel> earningsListModel = new List<EarningsListModel>();
             earningsListModel[0].Earnings = new Earnings();
            earningsListModel[0].Earnings.Today = new Earned();
            earningsListModel[0].Earnings.Yesterday = new Earned();
            earningsListModel[0].Earnings.PreviousMonth = new Earned();
            earningsListModel[0].Earnings.CurrentMonth = new Earned();
            earningsListModel[0].Earnings.CurrentWeek = new CurrentEarned();
            earningsListModel[0].Earnings.LastTrip = new LastTrip();

            earningsListModel[0].CurrencyCode = "$";
            earningsListModel[0].CurrencySymbol = "USD";
            earningsListModel[0].Earnings.Today.TotalTrips = 2;
            earningsListModel[0].Earnings.Today.TotalEarned = 4;
            earningsListModel[0].Earnings.Yesterday.TotalTrips = 3;
            earningsListModel[0].Earnings.Yesterday.TotalEarned = 15.564857456;
            earningsListModel[0].Earnings.PreviousMonth.TotalTrips = 2;
            earningsListModel[0].Earnings.PreviousMonth.TotalEarned = 5;
            earningsListModel[0].Earnings.CurrentMonth.TotalTrips = 3;
            earningsListModel[0].Earnings.CurrentMonth.TotalEarned = 11.2646;
            earningsListModel[0].Earnings.CurrentWeek.TotalTrips = 5;
            earningsListModel[0].Earnings.CurrentWeek.TotalEarned = 12.653;
            earningsListModel[0].Earnings.CurrentWeek.DaysBased = new List<DaysBased>();
            List<DaysBased> daysBaseds = new List<DaysBased>();
            
           
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() {Name="Sunday",TotalEarned=34,TotalTrips=45 });
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() { Name = "Monday", TotalEarned = 34, TotalTrips = 45 });
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() { Name = "Tueday", TotalEarned = 34, TotalTrips = 45 });
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() { Name = "Wednesday", TotalEarned = 34, TotalTrips = 45 });
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() { Name = "Thursday", TotalEarned = 34, TotalTrips = 45 });
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() { Name = "Friday", TotalEarned = 34, TotalTrips = 45 });
            earningsListModel[0].Earnings.CurrentWeek.DaysBased.Add(new DaysBased() { Name = "Saturday", TotalEarned = 34, TotalTrips = 45 });


            earningsListModel[0].Earnings.LastTrip.RequestId = 251;
            earningsListModel[0].Earnings.LastTrip.UserName = "rajesh kannan";
            earningsListModel[0].Earnings.LastTrip.TripStartTime = DateTime.Now;
            earningsListModel[0].Earnings.LastTrip.DriverEarned = 5.32;
            earningsListModel[0].Earnings.LastTrip.TotalBill = 6.89;
            earningsListModel[0].Earnings.LastTrip.AdminEarned = 0.95;

            return this.OK<EarningsListModel>(earningsListModel, earningsListModel.Count == 0 ? "Earning_List_not_found" : "Earning_List_found", earningsListModel.Count == 0 ? 0 : 1);
        }
        #endregion

        #region Common_fAQlist
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("fAQlist")]
        public IActionResult FAQlist(GeneralModel generalModel)
        {
            List<FAQListModel> fAQListModel = new List<FAQListModel>();
            Faq_List faq_List = new Faq_List();
            faq_List.Id = 2;
            faq_List.Question = "how can i get more trips?";
            faq_List.Answer=  "you should follow the heat map tips";
            fAQListModel.Add(new FAQListModel()
            {
                Faq_List = faq_List
            }) ;
            return this.OK<FAQListModel>(fAQListModel, fAQListModel.Count == 0 ? "FAQ_List_not_found" : "FAQ_List_found", fAQListModel.Count == 0 ? 0 :1);
        }
        #endregion
    }
}
