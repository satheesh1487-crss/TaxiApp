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
    public class RequestController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public RequestController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("ManageRequest")]
        [Authorize]
        public IActionResult ManageRequest()
        {
            DARequest dARequest = new DARequest();
            return this.OK<List<ManageRequests>>(dARequest.ListRequest(_content));
        }

        [HttpGet]
        [Route("getbyRequestId")]
        [Authorize]
        public IActionResult GetbyRequestId(long requestId)
        {
            DARequest dARequest = new DARequest();
            return this.OK<ViewRequest>(dARequest.GetbyRequestId(requestId, _content));
        }

        [HttpGet]
        [Route("ManageSchedule")]
        [Authorize]
        public IActionResult ManageSchedule()
        {
            List<Schedule> schedulelist = new List<Schedule>();
            schedulelist.Add(new Schedule() { ID = 1, Date = "2020-07-09", RequestID = "RES_46228", UserName = "Praveen Kumar", Action = "trip Scheduled", Time = "04:51 PM", IsActive = true });
            schedulelist.Add(new Schedule() { ID = 2, Date = "2020-07-09", RequestID = "RES_69229", UserName = "Praveen", Action = "trip cancelled", Time = "10:14 PM", IsActive = true });
            schedulelist.Add(new Schedule() { ID = 3, Date = "2020-07-09", RequestID = "RES_87227", UserName = "Ragu", Action = "trip not cancelled", Time = "11:47 PM", IsActive = true });

            schedulelist.Add(new Schedule() { ID = 4, Date = "2028-03-10", RequestID = "RES_76226", UserName = "Suresh", Action = "trip Scheduled", Time = "09:54 PM", IsActive = true });
            schedulelist.Add(new Schedule() { ID = 5, Date = "2018-02-11", RequestID = "RES_56225", UserName = "Saravanan", Action = "trip cancelled", Time = "10:44 PM", IsActive = true });
            schedulelist.Add(new Schedule() { ID = 6, Date = "2019-01-12", RequestID = "RES_48224", UserName = "Navneeth", Action = "trip not Scheduled", Time = "09:34 PM", IsActive = true });
            return this.OK<List<Schedule>>(schedulelist);
        }
    }
}
