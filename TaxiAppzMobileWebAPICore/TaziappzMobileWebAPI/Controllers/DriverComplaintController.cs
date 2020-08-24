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
    public class DriverComplaintController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        private IValidate validate;
        public DriverComplaintController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        #region Complaint_List
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("complaintList")]
        public IActionResult ComplaintList(GeneralModel generalModel)
        {
            List<ComplaintApiModel> complaintApiModel = new List<ComplaintApiModel>();
            complaintApiModel[0].Complaint_List = new Complaint_List();
            complaintApiModel[0].Admin_key = "64654";
            complaintApiModel[0].Complaint_List.Id = 2;
            complaintApiModel[0].Complaint_List.Title = "Lunch break";           
            return this.OK<List<ComplaintApiModel>>(complaintApiModel, complaintApiModel == null ? "Complaint_Not_Found" : "Complaint_found", complaintApiModel == null ? 0 : 1);
        }
        #endregion

        #region Complaint_General
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("generalComplaint")]
        public IActionResult GeneralComplaint(GeneralModel generalModel)
        {
            GeneralComplainModel generalComplainModel = new GeneralComplainModel();            
            return this.OKRESPONSE<GeneralComplainModel>(generalComplainModel, generalComplainModel == null ? "General_Complaint_Not_Found" : "General_Complaint_found");
        }
        #endregion

        #region Complaint_Request
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("requestComplaint")]
        public IActionResult RequestComplaint(GeneralModel generalModel)
        {
            RequestComplainModel requestComplainModel = new RequestComplainModel();
            return this.OKRESPONSE<RequestComplainModel>(requestComplainModel, requestComplainModel == null ? "Request_Complaint_Not_Found" : "Request_Complaint_found");
        }
        #endregion
    }
}
