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
    public class PromoManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public PromoManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("ManageOption")]
        [Authorize]
        public IActionResult ManageOption()
        {
            DAPromo dAPromo = new DAPromo();
              return this.OK<List<ManagePromo>>(dAPromo.ManageOption(_content));
        }
        [HttpGet]
        [Route("PromoTransaction")]
        [Authorize]
        public IActionResult PromoTransaction()
        {
            DAPromo dAPromo = new DAPromo();
            return this.OK<List<PromoTransaction>>(dAPromo.PromoTransaction(_content));
        }
        [HttpGet]
        [Route("GetPromoDetails")]
        [Authorize]
        public IActionResult GetPromoDetails(long promoid)
        {
            DAPromo dAPromo = new DAPromo();
            return this.OK<ManagePromo>(dAPromo.GetPromoDetails(promoid,_content));
        }
        [HttpPost]
        [Route("AddPromo")]
        [Authorize]
        public IActionResult AddPromo(ManagePromo managePromo)
        {
            DAPromo dAPromo = new DAPromo();
            return this.OK(dAPromo.AddPromo(managePromo, _content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpPut]
        [Route("EditPromo")]
        [Authorize]
        public IActionResult EditPromo(ManagePromo managePromo)
        {
            DAPromo dAPromo = new DAPromo();
            return this.OK(dAPromo.EditPromo(managePromo, _content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpPut]
        [Route("IsActivePromo")]
        [Authorize]
        public IActionResult IsActivePromo(long promoid,bool activestatus)
        {
            DAPromo dAPromo = new DAPromo();
            return this.OK(dAPromo.IsActivePromo(promoid, activestatus,_content) ? "Recored Added Successfully" : "Failed to Add");
        }
        [HttpDelete]
        [Route("IsDeletePromo")]
        [Authorize]
        public IActionResult IsDeletePromo(long promoid)
        {
            DAPromo dAPromo = new DAPromo();
            return this.OK(dAPromo.IsDeletePromo(promoid,  _content) ? "Recored Added Successfully" : "Failed to Add");
        }
    }
}
