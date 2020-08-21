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
    public class UserCommonController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserCommonController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Common-rating
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("rating")]
        public IActionResult Rating(GeneralModel generalModel)
        {
            UserRatingModel userRatingModel = new UserRatingModel();
            return this.OKRESPONSE<UserRatingModel>(userRatingModel, userRatingModel == null ? "Rating_Not_Found" : "Rating_found");
        }
        #endregion


        #region Common-profile        
        [HttpPost]
        [Authorize]
        [Route("profile")]
        public IActionResult Profile(long id)
        {
            DAUserCommon dAUserCommon = new DAUserCommon();
            List<UserProfileModel> userProfiles = new List<UserProfileModel>();
            userProfiles = dAUserCommon.GetProfile(_context, id, User.ToAppUser());
            return this.OK<UserProfileModel>(userProfiles, userProfiles.Count == 0 ? "Profile data not found" : "Profie Data Found", userProfiles.Count == 0 ? 0 : 1);          
        }
        #endregion

        #region Common-zonesos       
        [HttpPost]
        [Route("zonesos")]
        public IActionResult ZoneSos(long id, decimal lang, decimal lat)
        {
            DAUserCommon dAUserCommon = new DAUserCommon();            
            List<UserSosModel> userSosModels = new List<UserSosModel>();            
            userSosModels = dAUserCommon.List(_context,id, lang, lat);
            return this.OK<UserSosModel>(userSosModels, userSosModels.Count == 0 ? "User SOS Details Not Found" : "User SOS Details Found", userSosModels.Count == 0 ? 0 : 1);            
        }
        #endregion

        #region Common-faq_list        
        [HttpPost]
        [Route("faq_list")]
        public IActionResult Faq_List(long id, decimal lang, decimal lat, string type)
        {
            DAUserCommon dAUserCommon = new DAUserCommon();
            List<UserFaqListModel> userFaqLists = new List<UserFaqListModel>();
            userFaqLists = dAUserCommon.FaqList(_context, id, lang, lat, type);
            return this.OK<UserFaqListModel>(userFaqLists, userFaqLists.Count == 0 ? "FAQ_List_Not_Found" : "FAQ_List_found", userFaqLists.Count == 0 ? 0 : 1);
        }
        #endregion
    }
}
