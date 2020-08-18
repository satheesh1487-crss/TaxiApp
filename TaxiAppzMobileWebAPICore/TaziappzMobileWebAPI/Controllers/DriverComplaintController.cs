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

        #region Request_Apis
        /// <summary>
        /// Hard Coded Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("complaintList")]
        public IActionResult ComplaintList(GeneralModel generalModel)
        {
            ComplaintApiModel complaintApiModel = new ComplaintApiModel();
            complaintApiModel.Complaint_List = new Complaint_List();
            complaintApiModel.Admin_key = "64654";
            complaintApiModel.Complaint_List.Id = 2;
            complaintApiModel.Complaint_List.Title = "Lunch break";           
            return this.OKRESPONSE<ComplaintApiModel>(complaintApiModel, complaintApiModel == null ? "Complaint_Not_Found" : "Complaint_found");
        }

        [HttpPost]
        [Route("generalComplaint")]
        public IActionResult GeneralComplaint(GeneralModel generalModel)
        {
            GeneralComplainModel generalComplainModel = new GeneralComplainModel();            
            return this.OKRESPONSE<GeneralComplainModel>(generalComplainModel, generalComplainModel == null ? "General_Complaint_Not_Found" : "General_Complaint_found");
        }

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
