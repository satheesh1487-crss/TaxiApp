using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public FAQController(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listFAQ")]
        [Authorize]
        public IActionResult ListFAQ()
        {
            DAFAQ dAFAQ = new DAFAQ();
            return this.OK<List<ManageFAQList>>(dAFAQ.ListFAQ(_context));
        }

        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editFAQ")]
        [Authorize]
        public IActionResult EditFAQ([FromBody] ManageFAQList manageFAQList)
        {
            try
            {
                DAFAQ dAFAQ = new DAFAQ();
                return this.OKResponse(dAFAQ.EditFAQ(_context, manageFAQList, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
            }
            catch (DataValidationException ex)
            {

                return this.KnowOperationError(ex.Message);
            }
        }

        [HttpGet]
        [Route("getbyFAQId")]
        [Authorize]
        public IActionResult GetbyFAQId(long id)
        {
            DAFAQ dAFAQ = new DAFAQ();
            return this.OK<ManageFAQInfo>(dAFAQ.GetbyFAQId(_context, id));
        }

        //TODO:: Duplicate record check
        [HttpPost]
        [Route("saveFAQ")]
        [Authorize]
        public IActionResult SaveFAQ([FromBody] ManageFAQList manageFAQList)
        {
            try
            {
                DAFAQ dAFAQ = new DAFAQ();
                return this.OKResponse(dAFAQ.SaveFAQ(_context, manageFAQList, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
            }
            catch (DataValidationException ex)
            {

                return this.KnowOperationError(ex.Message);
            }

        }

        [HttpPut]
        [Route("statusFAQ")]
        [Authorize]
        public IActionResult StatusFAQ(long id, bool isStatus)
        {
            try
            {
                DAFAQ dAFAQ = new DAFAQ();
                return this.OKResponse(dAFAQ.StatusFAQ(_context, id, isStatus, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
            }
            catch (DataValidationException ex)
            {

                return this.KnowOperationError(ex.Message);
            }
        }
    }
}
