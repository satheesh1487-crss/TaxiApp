using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAReferral
    {
        public List<ManageReferral> ListService(TaxiAppzDBContext context)
        {
            try
            {
                List<ManageReferral> manageReferrals = new List<ManageReferral>();
                var listManageRef = context.TabManageReferral.Where(t => t.IsActive == false).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var manageref in listManageRef)
                {
                    manageReferrals.Add(new ManageReferral()
                    {
                       Id=manageref.Managereferral,
                       ReferralGain_Amount_PerPerson=manageref.ReferralGainAmountPerPerson,
                       ReferralWorth_Amount=manageref.ReferralGainAmountPerPerson,
                       Trip_to_completed_toearn_refferalAmount=manageref.TripToCompletedToearnRefferalAmount,
                       Trip_to_completed_torefer=manageref.TripToCompletedToearnRefferalAmount
                    });
                }
                return manageReferrals != null ? manageReferrals : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListService", context);
                return null;
            }

        }
    }
}
