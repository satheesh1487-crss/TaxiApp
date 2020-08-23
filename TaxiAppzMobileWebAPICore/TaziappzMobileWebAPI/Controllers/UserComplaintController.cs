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
    public class UserComplaintController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public UserComplaintController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Complaint-list
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("list")]
        public IActionResult List(GeneralModel generalModel)
        {
            List<ComplaintListModel> complaintListModels = new List<ComplaintListModel>();
            ComplaintListModel complaintListModel = new ComplaintListModel();
            complaintListModel.Admin_Key = "731414";
            complaintListModel.Complaint_List = new List<User_Complaint_List>();
            List<User_Complaint_List> userList = new List<User_Complaint_List>();
            complaintListModel.Complaint_List.Add(new User_Complaint_List() { Id = 1, Title = "plan changed" });
            return this.OKRESPONSE<ComplaintListModel>(complaintListModel, complaintListModel == null ? "List_Not_Found" : "List_found");
        }
        #endregion

        #region Complaint-userDispute
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("userDispute")]
        public IActionResult UserDispute(GeneralModel generalModel)
        {
            UserDisputeModel userDisputeModel = new UserDisputeModel();            
            return this.OKRESPONSE<UserDisputeModel>(userDisputeModel, userDisputeModel == null ? "User_Not_Found" : "User_found");
        }
        #endregion

        #region Complaint-complaintsAdd
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("complaintsAdd")]
        public IActionResult ComplaintsAdd(GeneralModel generalModel)
        {
            UserComplaintsAddModel userComplaintsAddModel = new UserComplaintsAddModel();
            return this.OKRESPONSE<UserComplaintsAddModel>(userComplaintsAddModel, userComplaintsAddModel == null ? "Complaints_Add_Not_Found" : "Complaints_Add_found");
        }
        #endregion
    }
}
