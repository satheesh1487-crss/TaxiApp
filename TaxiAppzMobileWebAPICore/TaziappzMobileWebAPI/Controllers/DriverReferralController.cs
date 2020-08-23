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
    public class DriverReferralController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public DriverReferralController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Referral_code
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("code")]
        public IActionResult Code(GeneralModel generalModel)
        {
            GetCodeModel getCodeModel = new GetCodeModel();
            return this.OKRESPONSE<GetCodeModel>(getCodeModel, getCodeModel == null ? "Get_Code_not_found" : "Get_Code_found");
        }
        #endregion

        #region Referral_apply
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("apply")]
        public IActionResult Apply(GeneralModel generalModel)
        {
            ApplyCodeModel applyCodeModel = new ApplyCodeModel();
            return this.OKRESPONSE<ApplyCodeModel>(applyCodeModel, applyCodeModel == null ? "Apply_Code_not_found" : "Apply_Code_found");
        }
        #endregion
    }
}
