using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAReferral
    {
        public ManageReferral GetActiveReferral(TaxiAppzDBContext context)
        {
            try
            {
                ManageReferral manageReferrals = new ManageReferral();
                var listManageRef = context.TabManageReferral.Where(t => t.IsActive == true).ToList().FirstOrDefault();
                if (listManageRef != null)
                {
                    manageReferrals.Id = listManageRef.Managereferral;
                    manageReferrals.ReferralGain_Amount_PerPerson = listManageRef.ReferralGainAmountPerPerson;
                    manageReferrals.ReferralWorth_Amount = listManageRef.ReferralWorthAmount;
                    manageReferrals.Trip_to_completed_toearn_refferalAmount = listManageRef.TripToCompletedToearnRefferalAmount;
                    manageReferrals.Trip_to_completed_torefer = listManageRef.TripToCompletedToearnRefferalAmount;

                }
                return manageReferrals != null ? manageReferrals : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListService", context);
                return null;
            }

        }

        public bool AddPromo(ManageReferral manageReferral, TaxiAppzDBContext content, LoggedInUser loggedIn)
        {
            try
            {
                if (content.TabManageReferral.Any(t => t.IsActive == true && t.ReferralGainAmountPerPerson == manageReferral.ReferralGain_Amount_PerPerson && t.ReferralWorthAmount == manageReferral.ReferralWorth_Amount && t.TripToCompletedToearnRefferalAmount == manageReferral.Trip_to_completed_toearn_refferalAmount && t.TripToCompletedTorefer == manageReferral.Trip_to_completed_torefer))
                    return true;
                    TabManageReferral tabManageReferral = new TabManageReferral();

                tabManageReferral.ReferralGainAmountPerPerson= manageReferral.ReferralGain_Amount_PerPerson;
                tabManageReferral.ReferralWorthAmount = manageReferral.ReferralWorth_Amount;
                tabManageReferral.TripToCompletedToearnRefferalAmount = manageReferral.Trip_to_completed_toearn_refferalAmount;
                tabManageReferral.TripToCompletedToearnRefferalAmount = manageReferral.Trip_to_completed_torefer;
                tabManageReferral.IsActive = true;
                tabManageReferral.UpdatedAt = tabManageReferral.CreatedAt = Extention.GetDateTime();
                tabManageReferral.UpdatedBy = tabManageReferral.CreatedBy = loggedIn.UserName;
                content.TabManageReferral.Add(tabManageReferral);
                foreach(var referral in content.TabManageReferral.Where(t => t.IsActive == true).ToList())
                {
                    referral.IsActive = false;
                    referral.UpdatedAt = Extention.GetDateTime();
                    referral.UpdatedBy = loggedIn.UserName;
                }
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "PromoTransaction", content);
                return false;
            }
        }
    }
}
