using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Helper;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DAUserRequest
    {
        public List<CancelRequestModel> CancelList(TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            List<CancelRequestModel> cancelRequestModels = new List<CancelRequestModel>();
            var userexist = context.TabUser.FirstOrDefault(t => t.IsDelete == 0 && t.IsActive == true && t.Id == loggedInUser.id);
            if (userexist == null)
                throw new DataValidationException($"User does not have a permission");
            DARequest dARequest = new DARequest();
            var requestexist = context.TabRequest.Where(t => t.UserId == userexist.Id
            && t.IsTripStart.ToUpper() == "false").OrderBy(t => t.RequestId).FirstOrDefault();
            if (requestexist == null)
                return cancelRequestModels;
            var requestplace = context.TabRequestPlace.Where(t => t.RequestId == requestexist.Id).FirstOrDefault();
            LatLong latLong = new LatLong();
            latLong.Picklatitude = Convert.ToDecimal(requestplace.PickLatitude);
            latLong.Picklongtitude = Convert.ToDecimal(requestplace.PickLongitude);
            long? zoneid = dARequest.GetPolygon(latLong, loggedInUser.Country, context);
            if (zoneid == null)
                return cancelRequestModels;
            var zonetypeid = context.TabZonetypeRelationship.Where(t => t.Zoneid == zoneid && t.Typeid == requestexist.Typeid).Select(t => t.Zoneid).FirstOrDefault();
            if (zonetypeid == null)
                return cancelRequestModels;
          
            var listCancel = context.TabUserCancellation.Where(t => t.IsDelete == false && t.IsActive == true && t.Zonetypeid == zonetypeid).ToList().OrderByDescending(t => t.UpdatedAt);
            foreach (var cancel in listCancel)
            {
                cancelRequestModels.Add(new CancelRequestModel()
                {
                    User_Cancelld = cancel.UserCancelId,
                    Zone_TypeId = cancel.Zonetypeid,
                    Cancellation_Reason_English = cancel.CancellationReasonEnglish
                });
            }
            return cancelRequestModels;
        }
    }
}
