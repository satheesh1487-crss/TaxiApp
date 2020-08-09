using Microsoft.AspNetCore.JsonPatch.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAPromo
    {
        public List<ManagePromo> ManageOption(TaxiAppzDBContext content)
        {
            try
            {
                List<ManagePromo> managePromos = new List<ManagePromo>();
                var promolist = content.TabPromo.Where(t => t.IsDelete == false).ToList();
                if (promolist.Count > 0)
                {
                    foreach (var promo in promolist)
                    {
                        managePromos.Add(new ManagePromo()
                        {
                            PromoID = promo.Promoid,
                            CoupenCode = promo.CouponCode,
                            EstimateAmount = promo.PromoEstimateAmount,
                            Value = promo.PromoValue,
                            Zoneid = promo.Zoneid,
                            
                            Uses = promo.PromoUses,
                            RepeatedlyUse = promo.PromoUsersRepeateduse,
                            StartDate = promo.StartDate,
                            ExpiryDate = promo.EndDate,
                            IsActive = promo.IsActive
                        });
                    }
                }
                return managePromos == null ? null : managePromos;
            }
            catch(Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ManageOption", content);
                return null;
            }
           
        }

        public List<PromoTransaction> PromoTransaction(TaxiAppzDBContext content)
        {
            try
            {
                List<PromoTransaction> promoTransactions = new List<PromoTransaction>();
                var promolist = content.TabPromo.Where(t => t.IsDelete == false).ToList();
                if (promolist.Count > 0)
                {
                    foreach (var promo in promolist)
                    {
                        promoTransactions.Add(new PromoTransaction()
                        {
                            PromoID = promo.Promoid,
                            CoupenCode = promo.CouponCode,
                            Value = promo.PromoValue,
                            Type = promo.PromoType,
                            Uses = promo.PromoUses
                        });
                    }
                }
                return promoTransactions == null ? null : promoTransactions;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "PromoTransaction", content);
                return null;
            }

        }

        public bool AddPromo(ManagePromo managePromo, TaxiAppzDBContext content,LoggedInUser loggedIn)
        {
            try
            {
               
                if(!content.TabZone.Any(t => t.Zoneid == managePromo.Zoneid && t.IsActive == 1 && t.IsDeleted == 0))
                    return  false;

                TabPromo tabPromo = new TabPromo();
                tabPromo.CouponCode = managePromo.CoupenCode;
                tabPromo.PromoEstimateAmount = managePromo.EstimateAmount;
                tabPromo.PromoValue = managePromo.Value;
                tabPromo.Zoneid = managePromo.Zoneid;
                tabPromo.PromoType = managePromo.CoupenCode;
                tabPromo.PromoUses = managePromo.Uses;
                tabPromo.PromoUsersRepeateduse = managePromo.Value;
                tabPromo.StartDate = managePromo.StartDate;
                tabPromo.EndDate = managePromo.ExpiryDate;
                tabPromo.IsActive = true;
                tabPromo.IsDelete = true;
                tabPromo.UpdatedAt = tabPromo.CreatedAt = DateTime.UtcNow;
                tabPromo.UpdatedBy = tabPromo.CreatedBy = loggedIn.UserName;
                content.TabPromo.Add(tabPromo);
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "PromoTransaction", content);
                return false;
            }
        }
        public ManagePromo GetPromoDetails(long promoid, TaxiAppzDBContext content)
        {
            try
            {
                ManagePromo managepromo = new ManagePromo();
                var promodetails = content.TabPromo.Where(t => t.Promoid == promoid).FirstOrDefault();
                if (promodetails != null)
                {
                    managepromo.CoupenCode = promodetails.CouponCode;
                    managepromo.EstimateAmount = promodetails.PromoEstimateAmount;
                    managepromo.Value = promodetails.PromoValue;
                    managepromo.Zoneid = promodetails.Zoneid;
     
                    managepromo.Uses = promodetails.PromoUses;
                    managepromo.RepeatedlyUse = promodetails.PromoUsersRepeateduse;
                    managepromo.StartDate = promodetails.StartDate;
                    managepromo.ExpiryDate = promodetails.EndDate;
                    return managepromo;
                }
                return null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetPromoDetails", content);
                return null;
            }
        }
        public bool EditPromo(ManagePromo managePromo, TaxiAppzDBContext content)
        {
            try
            {
                var promodetails = content.TabPromo.Where(t => t.Promoid == managePromo.PromoID).FirstOrDefault();
                promodetails.CouponCode = managePromo.CoupenCode;
                promodetails.PromoEstimateAmount = managePromo.EstimateAmount;
                promodetails.PromoValue = managePromo.Value;
                promodetails.Zoneid = managePromo.Zoneid;
                promodetails.PromoType = managePromo.CoupenCode;
                promodetails.PromoUses = managePromo.Uses;
                promodetails.PromoUsersRepeateduse = managePromo.Value;
                promodetails.StartDate = managePromo.StartDate;
                promodetails.EndDate = managePromo.ExpiryDate;
                promodetails.IsActive = true;
                promodetails.UpdatedAt = DateTime.UtcNow;
                promodetails.UpdatedBy = "Admin";
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditPromo", content);
                return false;
            }
        }
        public bool IsActivePromo(long promoid, bool activestatus,TaxiAppzDBContext content)
        {
            try
            {
                var promodetails = content.TabPromo.Where(t => t.Promoid == promoid).FirstOrDefault();
                promodetails.IsActive = activestatus;
                promodetails.UpdatedAt = DateTime.UtcNow;
                promodetails.UpdatedBy = "Admin";
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "InActivePromo", content);
                return false;
            }
        }
        public bool IsDeletePromo(long promoid, TaxiAppzDBContext content)
        {
            try
            {
                var promodetails = content.TabPromo.Where(t => t.Promoid == promoid).FirstOrDefault();
                promodetails.IsDelete = true;
                promodetails.DeletedAt = DateTime.UtcNow;
                promodetails.DeletedBy = "Admin";
                content.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "InActivePromo", content);
                return false;
            }
        }
    }
}
