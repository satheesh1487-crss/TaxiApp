using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DARequest
    {
        public List<ManageRequests> ListRequest(TaxiAppzDBContext context)
        {
            try
            {
                List<ManageRequests> requestlist = new List<ManageRequests>();
                var listRequest = context.TabRequest.Include(t=>t.User).Include(t=>t.Driver).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var request in listRequest)
                {
                    requestlist.Add(new ManageRequests()
                    {
                        ID = request.Id,
                        RequestID = request.RequestId,
                        DateTime = request.TripStartTime.ToString(),
                        UserName = request.User.Firstname + ' ' + request.User.Lastname,
                        Paymentmode = request.PaymentOpt,
                        DriverName = request.Driver==null ?"":request.Driver.FirstName + ' ' + request.Driver.LastName,
                        TripStatus = request.IsDriverStarted == true && request.IsDriverArrived == true && request.IsTripStart == false && request.IsCancelled == false ? "Trip not yet started" : (request.IsCancelled == true ? "Trip cancelled" : "Trip completed")
                    });
                }
                return requestlist != null ? requestlist : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListService", context);
                return null;
            }
        }

        public ViewRequest GetbyRequestId(long requestId, TaxiAppzDBContext context)
        {
            try
            {
                ViewRequest viewRequest = new ViewRequest();
                viewRequest.Request = new List<RequestInfo>();
                viewRequest.DriverDetails = new List<RequestDriverInfo>();
                var views = context.TabRequest.Include(t => t.Driver).Include(t=>t.Type).Where(u => u.Id == requestId).FirstOrDefault();
               
                if (views != null)
                {
                    viewRequest.Id = views.Id;
                    viewRequest.StartTime = views.TripStartTime.ToString();
                    
                    viewRequest.DriverRated = views.DriverRated;
                    viewRequest.UserRated = views.UserRated;
                    viewRequest.DriverName = views.Driver == null ? "" : views.Driver.FirstName + ' ' + views.Driver.LastName;
                    viewRequest.DriverEmail = views.Driver.Email;
                    viewRequest.DriverContactNo = views.Driver.ContactNo;                   
                    var typelist = context.TabZonetypeRelationship.Include(t => t.Zone).Where(t => t.Typeid == views.Typeid).ToList();
                    foreach (var type in typelist)
                    {
                        RequestInfo requestInfo = new RequestInfo();
                        requestInfo.DriverRate = views.DriverRated;
                        requestInfo.UserRate = views.UserRated;
                        requestInfo.TypeName = type.Type.Typename;
                        requestInfo.ZoneName = type.Zone.Zonename;
                        viewRequest.Request.Add(requestInfo);
                        viewRequest.Type = type.Type.Typename;
                        viewRequest.Zone = type.Zone.Zonename;
                    }
                }
                return viewRequest == null ? null : viewRequest;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyRequestId", context);
                return null;
            }
        }
    }
}
