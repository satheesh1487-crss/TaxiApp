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
        public List<CancelRequestModel> CancelList(TaxiAppzDBContext context, UserCancelTripModel userCancelTripModel, LoggedInUser loggedInUser)
        {
            var userexist = context.TabUser.FirstOrDefault(t => t.IsDelete == 0 && t.IsActive == true && t.Id == userCancelTripModel.Id);
            if (userexist != null)
                throw new DataValidationException($"User does not have a permission");

            List<CancelRequestModel> cancelRequestModels = new List<CancelRequestModel>();
            var listCancel = context.TabUserCancellation.Where(t => t.IsDelete == false && t.IsActive == true && t.UserCancelId == userCancelTripModel.Id).ToList().OrderByDescending(t => t.UpdatedAt);
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
