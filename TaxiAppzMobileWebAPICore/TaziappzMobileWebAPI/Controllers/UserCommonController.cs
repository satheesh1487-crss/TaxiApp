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
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("profile")]
        public IActionResult Profile(GeneralModel generalModel)
        {
            List<UserProfileModel> userProfileModel = new List<UserProfileModel>();
            userProfileModel[0].User = new UserProfile();
            userProfileModel[0].Sos = new List<UserProfileSos>();
            userProfileModel[0].User.Id = 32;
            userProfileModel[0].User.FirstName = "RAJESH";
            userProfileModel[0].User.LastName = "KANNAN";
            userProfileModel[0].User.Email = "raj@gmail.com";
            userProfileModel[0].User.Phone = "+919865365236";
            userProfileModel[0].User.Login_By = "android";
            userProfileModel[0].User.Login_Method = "manual";
            userProfileModel[0].User.Token = "$2y$10$R5FO7pys3hgE8Sfy2gBR7.msCpEmviVTLjaRiq.l5NEwUjNAYiiZ.";
            userProfileModel[0].User.Profile_Pic = "";
            userProfileModel[0].User.Is_Active = 1;
            userProfileModel[0].User.Corporate = 0;
            userProfileModel[0].corporate = 0;
            return this.OK<UserProfileModel>(userProfileModel, userProfileModel == null ? "User_Profile_Not_Found" : "User_Profile_found", userProfileModel == null ? 0 : 1);
        }
        #endregion

        #region Common-zonesos
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("zonesos")]
        public IActionResult ZoneSos(GeneralModel generalModel)
        {
            List<UserSosModel> userSosModels = new List<UserSosModel>();
            UserSosModel userSosModel = new UserSosModel();
            userSosModel.sos = new List<SosUser>();
            userSosModel.User_Sos = new List<User_Sos>();
            List<User_Sos> usersos = new List<User_Sos>();
            List<SosUser> userSos = new List<SosUser>();
            userSosModel.sos.Add(new SosUser() { Id = 1, name = "CEO", number = "9632596589" });
            return this.OKRESPONSE<UserSosModel>(userSosModel, userSosModel == null ? "User_Sos_Not_Found" : "User_Sos_found");
        }
        #endregion

        #region Common-faq_list
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("faq_list")]
        public IActionResult Faq_List(GeneralModel generalModel)
        {
            List<UserFaqListModel> userFaqListModels = new List<UserFaqListModel>();
            UserFaqListModel userFaqListModel = new UserFaqListModel();
            userFaqListModel.Faq_List = new List<User_Faq_List>();
            List<User_Faq_List> userfaq = new List<User_Faq_List>();
            userFaqListModel.Faq_List.Add(new User_Faq_List() { Id = 1, Question = "DOB?", Answer = "257994" });
            return this.OKRESPONSE<UserFaqListModel>(userFaqListModel, userFaqListModel == null ? "FAQ_List_Not_Found" : "FAQ_List_found");
        }
        #endregion
    }
}
