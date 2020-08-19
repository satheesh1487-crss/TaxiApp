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

        [HttpPost]
        [Route("getreferral")]
        public IActionResult GetReferral(GeneralModel generalModel)
        {
            UserGetReferralModel userGetReferralModel = new UserGetReferralModel();
            userGetReferralModel.Code = "86Nvu";
            userGetReferralModel.Earned = 1;
            userGetReferralModel.Spent = 0;
            userGetReferralModel.balance = 0;
            userGetReferralModel.currency = "$";
            return this.OKRESPONSE<UserGetReferralModel>(userGetReferralModel, userGetReferralModel == null ? "Get_Referral_Not_Found" : "Get_Referral_found");
        }

        [HttpPost]
        [Route("referralcheck")]
        public IActionResult ReferralCheck(GeneralModel generalModel)
        {
            UserCheckReferralModel userCheckReferralModel = new UserCheckReferralModel();           
            return this.OKRESPONSE<UserCheckReferralModel>(userCheckReferralModel, userCheckReferralModel == null ? "Check_Referral_Not_Found" : "Check_Referral_found");
        }
    }
}
