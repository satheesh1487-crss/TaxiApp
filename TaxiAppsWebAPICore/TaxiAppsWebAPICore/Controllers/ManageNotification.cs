using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageNotification : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public ManageNotification(TaxiAppzDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listEmail")]
        [Authorize]
        public IActionResult ListEmail()
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OK<List<ManageEmailOption>>(dAManangeNotify.ListEmail(_context));
        }

        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editEmail")]
        [Authorize]
        public IActionResult Edit([FromBody] ManageEmailOption manageEmailOption)
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OKResponse(dAManangeNotify.EditEmail(_context, manageEmailOption, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
        }

        [HttpGet]
        [Route("getbyEmailId")]
        [Authorize]
        public IActionResult GetbyId(long id)
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OK<ManageEmailOption>(dAManangeNotify.GetbyEmailId(_context, id));
        }

        [HttpPut]
        [Route("statusEmail")]
        [Authorize]
        public IActionResult Status(long id, bool isStatus)
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OKResponse(dAManangeNotify.StatusEmail(_context, id, isStatus, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
        }

        [HttpGet]
        [Route("listSms")]
        [Authorize]
        public IActionResult ListSms()
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OK<List<ManageSMSOption>>(dAManangeNotify.ListSms(_context));
        }

        //TODO:: Duplicate record check
        [HttpPut]
        [Route("editSms")]
        [Authorize]
        public IActionResult EditSms([FromBody] ManageSMSOption manageSMSOption)
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OKResponse(dAManangeNotify.EditSms(_context, manageSMSOption, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
        }

        [HttpGet]
        [Route("getbySmsId")]
        [Authorize]
        public IActionResult GetbySmsId(long id)
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OK<ManageSMSOption>(dAManangeNotify.GetbySmsId(_context, id));
        }

        [HttpPut]
        [Route("statusSms")]
        [Authorize]
        public IActionResult StatusSms(long id, bool isStatus)
        {
            DAManangeNotify dAManangeNotify = new DAManangeNotify();
            return this.OKResponse(dAManangeNotify.StatusSms(_context, id, isStatus, User.ToAppUser()) ? "Active Successfully" : "InActive Successfully");
        }
    }
}
