using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DADriverRequest
    {
        public List<RequestInProgress> DriverRequestInprogress(LoggedInUser loggedInUser,TaxiAppzDBContext context)
        {
            List<RequestInProgress> requestInProgresses = new List<RequestInProgress>();
            var driverdtls = context.TabDrivers.Include(t => t.Serviceloc).Where(t => t.ContactNo == loggedInUser.Contactno && t.IsApproved == true && 
            t.IsAvailable == true &&   t.IsActive == true && t.IsDelete == false).FirstOrDefault();
            var servicelocdetails = context.TabServicelocation.Where(t => t.Servicelocid == driverdtls.Serviceloc.Servicelocid && t.IsActive == 1 && t.IsDeleted == 1).FirstOrDefault();
            if (driverdtls == null && servicelocdetails == null)
                return requestInProgresses;
            Details details = new Details();
            details.Id = driverdtls.Driverid;
            details.Name = driverdtls.FirstName;
            details.Last_name = driverdtls.LastName;
            details.Email = driverdtls.Email;
            details.Mobile = driverdtls.ContactNo;

            details.Profile_picture = "";
            details.Active = driverdtls.IsActive;
            details.Email_confirmed = "0";
            details.Mobile_confirmed = 0;

            details.Last_known_ip = "0";
            details.Last_login_at = null;
            var requestdata = context.TabRequest.Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
            if (requestdata.IsDriverStarted.ToUpper() == "TRUE" || requestdata.IsDriverArrived.ToUpper() == "TRUE" || 
                requestdata.IsTripStart.ToUpper() == "TRUE" || requestdata.IsCompleted.ToUpper() == "FALSE" || requestdata.IsCancelled.ToUpper() == "FALSE")
            {
                //NEED TO WRITE TRIP REQUEST OBJECT
            }
            else
            {
                var requestmeta = context.TabRequestMeta.Where(t => t.DriverId == driverdtls.Driverid).FirstOrDefault();
                var requestdatadtls = context.TabRequest.Where(t => t.RequestId == requestmeta.RequestId.ToString()).FirstOrDefault();
                if (requestdata.IsDriverStarted.ToUpper() == "FALSE" || requestdata.IsDriverArrived.ToUpper() == "FALSE" ||
              requestdata.IsTripStart.ToUpper() == "FALSE" || requestdata.IsCompleted.ToUpper() == "FALSE" || requestdata.IsCancelled.ToUpper() == "FALSE")
                {
                    //NEED TO WRITE META REQUEST OBJECT
                }
            }
            return requestInProgresses;
        }
    }
}
