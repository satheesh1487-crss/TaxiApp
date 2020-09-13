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
    public class ReviewManagementController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public ReviewManagementController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("UsertoDriver")]
        [Authorize]
        public IActionResult UsertoDriver()
        {
            DAReview dAReview = new DAReview();
            return this.OK<List<UsertoDriver>>(dAReview.ListUserRating(_content));
        }

        [HttpGet]
        [Route("DrivertoUser")]
        [Authorize]
        public IActionResult DrivertoUser()
        {
            DAReview dAReview = new DAReview();
            return this.OK<List<DrivertoUser>>(dAReview.ListDriverRating(_content));
        }

        [HttpPut]
        [Route("UpdateReview")]
        [Authorize]
        public IActionResult UpdateReview(long id,bool activestatus)
        {
            return this.OK((true) ? activestatus ? "Active Successfully" : "InActive Successfully" : "Status Failed");
        }
    }
}
