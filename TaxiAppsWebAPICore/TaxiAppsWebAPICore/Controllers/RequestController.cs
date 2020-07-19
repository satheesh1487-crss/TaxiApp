using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            List<Requests> requestlist = new List<Requests>();
            requestlist.Add(new Requests() { ID = 1, DateTime  = "2020-07-09 17:54:55", RequestID = "RES_46228", UserName = "Praveen Kumar", DriverName = "Kumar", TripStatus = "trip completed", Paymentmode  = "Cash",  IsActive = true });
            requestlist.Add(new Requests() { ID = 2, DateTime = "2020-07-09 17:53:12", RequestID = "RES_69229", UserName = "Praveen", DriverName = "Dinesh", TripStatus = "trip cancelled", Paymentmode = "Card", IsActive = true });
            requestlist.Add(new Requests() { ID = 3, DateTime = "2020-07-09 17:52:04", RequestID = "RES_87227", UserName = "Ragu", DriverName = "Ramu", TripStatus = "trip not started", Paymentmode = "Cash", IsActive = true });

            requestlist.Add(new Requests() { ID = 4, DateTime = "2028-03-10 17:54:55", RequestID = "RES_76226", UserName = "Suresh", DriverName = "Kumar", TripStatus = "trip completed", Paymentmode = "Cash", IsActive = true });
            requestlist.Add(new Requests() { ID = 5, DateTime = "2018-02-11 17:53:12", RequestID = "RES_56225", UserName = "Saravanan", DriverName = "Dinesh", TripStatus = "trip cancelled", Paymentmode = "Card", IsActive = true });
            requestlist.Add(new Requests() { ID = 6, DateTime = "2019-01-12 17:52:04", RequestID = "RES_48224", UserName = "Navneeth", DriverName = "Ramu", TripStatus = "trip not started", Paymentmode = "Cash", IsActive = true });


            requestlist.Add(new Requests() { ID = 7, DateTime = "2018-11-30 17:54:55", RequestID = "RES_49223", UserName = "Sarathi", DriverName = "Kumar", TripStatus = "trip completed", Paymentmode = "Cash", IsActive = true });
            requestlist.Add(new Requests() { ID = 8, DateTime = "2019-12-12 17:53:12", RequestID = "RES_61221", UserName = "Narayana", DriverName = "Dinesh", TripStatus = "trip cancelled", Paymentmode = "Card", IsActive = true });
            requestlist.Add(new Requests() { ID = 9, DateTime = "2020-03-02 17:52:04", RequestID = "RES_39222", UserName = "Alex", DriverName = "Ramu", TripStatus = "trip not started", Paymentmode = "Cash", IsActive = true });

            requestlist.Add(new Requests() { ID = 10, DateTime = "2015-04-10 17:54:55", RequestID = "RES_25220", UserName = "Jhon", DriverName = "Kumar", TripStatus = "trip completed", Paymentmode = "Cash", IsActive = true });
            requestlist.Add(new Requests() { ID = 11, DateTime = "2015-02-11 17:53:12", RequestID = "RES_25221", UserName = "Jude", DriverName = "Dinesh", TripStatus = "trip cancelled", Paymentmode = "Card", IsActive = true });
            requestlist.Add(new Requests() { ID = 12, DateTime = "2014-01-12 17:52:04", RequestID = "RES_25222", UserName = "Mani", DriverName = "Ramu", TripStatus = "trip not started", Paymentmode = "Cash", IsActive = true });
            return this.OK<List<Requests>>(requestlist);
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
