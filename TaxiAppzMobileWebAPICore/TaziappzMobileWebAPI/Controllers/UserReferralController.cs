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
    public class UserReferralController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserReferralController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Referral-getreferral
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("getreferral")]
        public IActionResult GetReferral(GeneralModel generalModel)
        {
            List<UserGetReferralModel> userGetReferralModel = new List<UserGetReferralModel>();
            userGetReferralModel[0].Code = "86Nvu";
            userGetReferralModel[0].Earned = 1;
            userGetReferralModel[0].Spent = 0;
            userGetReferralModel[0].balance = 0;
            userGetReferralModel[0].currency = "$";
            return this.OK<UserGetReferralModel>(userGetReferralModel, userGetReferralModel == null ? "Get_Referral_Not_Found" : "Get_Referral_found", userGetReferralModel == null ? 0 : 1);
        }
        #endregion

        #region Referral-referralcheck
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("referralcheck")]
        public IActionResult ReferralCheck(GeneralModel generalModel)
        {
            UserCheckReferralModel userCheckReferralModel = new UserCheckReferralModel();           
            return this.OKRESPONSE<UserCheckReferralModel>(userCheckReferralModel, userCheckReferralModel == null ? "Check_Referral_Not_Found" : "Check_Referral_found");
        }
        #endregion
    }
}
