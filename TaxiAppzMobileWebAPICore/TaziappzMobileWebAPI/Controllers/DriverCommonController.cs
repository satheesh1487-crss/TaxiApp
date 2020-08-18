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

        #region Common_Apis
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

        [HttpPost]
        [Route("retrieve")]
        public IActionResult Retrieve(GeneralModel generalModel)
        {
            GetProfileModel getProfileModel = new GetProfileModel();
            getProfileModel.Driver = new Driver();
            getProfileModel.Driver.Id = 15;
            getProfileModel.Driver.FirstName = "rajesh";
            getProfileModel.Driver.LastName = "kannan";
            getProfileModel.Driver.Email = "raj@gmail.com";
            getProfileModel.Driver.Phone = "918888888888";
            getProfileModel.Driver.Login_By = "android";
            getProfileModel.Driver.Login_Method = "manual";
            getProfileModel.Driver.Token = "$2y$10$sMv.qYgeNoiaJ4r1GqgEWO59BMGRi0EEN17t/hmFS0S92YUqd70QS";
            getProfileModel.Driver.Profile_Pic = "";
            getProfileModel.Driver.Is_Active = 1;
            getProfileModel.Driver.Is_Approve = 1;
            getProfileModel.Driver.Is_Available = 1;
            getProfileModel.Driver.Car_Model = "FFDJ";
            getProfileModel.Driver.Car_Number = "8888";
            getProfileModel.Driver.Total_Reward_Point = 0.5;
            getProfileModel.Driver.Type_Name = "FKLF";
            getProfileModel.Driver.Type_Icon = "http://192.168.1.25/production/captain_care/public/assets/img/uploads/54738.jpg";
            return this.OKRESPONSE<GetProfileModel>(getProfileModel, getProfileModel == null ? "Get_Profile_not_found" : "Get_Profile_found");
        }

        [HttpPost]
        [Route("earninglist")]
        public IActionResult Earninglist(GeneralModel generalModel)
        {
            EarningsListModel earningsListModel = new EarningsListModel();
            earningsListModel.CurrencyCode = "$";
            earningsListModel.CurrencySymbol = "USD";
            earningsListModel.Earnings = new Earnings();
            earningsListModel.Earnings.Today = new Earned();
            earningsListModel.Earnings.Yesterday = new Earned();
            earningsListModel.Earnings.PreviousMonth = new Earned();
            earningsListModel.Earnings.CurrentMonth = new Earned();
            earningsListModel.Earnings.CurrentWeek = new CurrentEarned();
            earningsListModel.Earnings.LastTrip = new LastTrip();
            earningsListModel.Earnings.Today.TotalTrips = 2;
            earningsListModel.Earnings.Today.TotalEarned = 4;
            earningsListModel.Earnings.Yesterday.TotalTrips = 3;
            earningsListModel.Earnings.Yesterday.TotalEarned = 15.564857456;
            earningsListModel.Earnings.PreviousMonth.TotalTrips = 2;
            earningsListModel.Earnings.PreviousMonth.TotalEarned = 5;
            earningsListModel.Earnings.CurrentMonth.TotalTrips = 3;
            earningsListModel.Earnings.CurrentMonth.TotalEarned = 11.2646;
            earningsListModel.Earnings.CurrentWeek.TotalTrips = 5;
            earningsListModel.Earnings.CurrentWeek.TotalEarned = 12.653;
            earningsListModel.Earnings.CurrentWeek.DaysBased = new DaysBased();
            List<DaysBased> daysBaseds = new List<DaysBased>();
            
            DaysBased sunday = new DaysBased();            
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "SUNDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 5;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 8;

            DaysBased monday = new DaysBased();
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "MONDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 3;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 2;

            DaysBased tuesday = new DaysBased();
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "TUESDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 5;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 2;

            DaysBased wednesday = new DaysBased();
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "WEDNESDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 3;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 4;

            DaysBased thursday = new DaysBased();
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "THURSDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 6;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 2;

            DaysBased friday = new DaysBased();
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "FRIDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 3;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 5;

            DaysBased saturday = new DaysBased();
            earningsListModel.Earnings.CurrentWeek.DaysBased.Name = "SATURDAY";
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalTrips = 3;
            earningsListModel.Earnings.CurrentWeek.DaysBased.TotalEarned = 7;

            earningsListModel.Earnings.LastTrip.RequestId = 251;
            earningsListModel.Earnings.LastTrip.UserName = "rajesh kannan";
            earningsListModel.Earnings.LastTrip.TripStartTime = DateTime.Now;
            earningsListModel.Earnings.LastTrip.DriverEarned = 5.32;
            earningsListModel.Earnings.LastTrip.TotalBill = 6.89;
            earningsListModel.Earnings.LastTrip.AdminEarned = 0.95;

            return this.OKRESPONSE<EarningsListModel>(earningsListModel, earningsListModel == null ? "Earning_List_not_found" : "Earning_List_found");
        }

        [HttpPost]
        [Route("fAQlist")]
        public IActionResult FAQlist(GeneralModel generalModel)
        {
            FAQListModel fAQListModel = new FAQListModel();
            fAQListModel.Faq_List = new Faq_List();
            fAQListModel.Faq_List.Id = 2;
            fAQListModel.Faq_List.Question = "how can i get more trips?";
            fAQListModel.Faq_List.Answer = "you should follow the heat map tips";
            return this.OKRESPONSE<FAQListModel>(fAQListModel, fAQListModel == null ? "FAQ_List_not_found" : "FAQ_List_found");
        }
        #endregion
    }
}
