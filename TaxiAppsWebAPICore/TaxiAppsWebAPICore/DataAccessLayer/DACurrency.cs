using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DACurrency
    {
        public List<CurrencyList> ListCurrency(TaxiAppzDBContext context)
        {
            List<CurrencyList> currencylist = new List<CurrencyList>();
            var currencyList = context.TabCommonCurrency.Include(t => t.Currencies).Where(t => t.IsDeleted == 0).ToList();
            foreach (var currency in currencyList)
            {
                currencylist.Add(new CurrencyList()
                {
                    IsActive = currency.IsActive == 0 ? false : true,
                    CurrencyId = currency.Currencyid,
                    CurrencyName = currency.Currencyname,
                    StandardName = currency.Currencies.Currency,
                    Symbol = currency.CurrencySymbol
                }); ;
            }
            return currencylist;
        }
        public bool AddCurrency(TaxiAppzDBContext context, CurrencyInfo currencyInfo)
        {
            try
            {
                TabCommonCurrency currency = new TabCommonCurrency();
                currency.Currencyid = currencyInfo.CurrencyID;
                currency.Currencyname = currencyInfo.CurrencyName;
                currency.CurrencySymbol = currencyInfo.CurrencySymbol;
                currency.Currenciesid = currencyInfo.StandardId;
                currency.IsActive = 0;
                currency.IsDeleted = 0;
                currency.CreatedAt = DateTime.UtcNow;
                currency.UpdatedAt = DateTime.UtcNow;
                currency.CreatedBy = "admin";
                currency.UpdatedBy = "admin";
                context.TabCommonCurrency.Add(currency);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddType", context);
                return false;
            }
        }

        public bool EditCurrency(TaxiAppzDBContext context, CurrencyInfo currencyInfo)
        {
            try
            {

                var updatedate = context.TabCommonCurrency.Where(r => r.Currencyid == currencyInfo.CurrencyID && r.IsDeleted == 0).FirstOrDefault();
                if (updatedate != null)
                {

                    updatedate.Currencyname = currencyInfo.CurrencyName;
                    updatedate.CurrencySymbol = currencyInfo.CurrencySymbol;
                    updatedate.Currenciesid = currencyInfo.StandardId;
                    updatedate.IsActive = 0;
                    updatedate.IsDeleted = 0;

                    updatedate.UpdatedAt = DateTime.UtcNow;

                    updatedate.UpdatedBy = "admin";
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditType", context);
                return false;
            }
        }

        public bool DeleteCurrency(TaxiAppzDBContext context, long id)
        {
            try
            {

                var updatedate = context.TabCommonCurrency.Where(r => r.Currencyid == id && r.IsDeleted == 0).FirstOrDefault();
                if (updatedate != null)
                {


                    updatedate.IsDeleted = 1;
                    updatedate.DeletedAt = DateTime.UtcNow;
                    updatedate.DeletedBy = "admin";
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "DeleteType", context);
                return false;
            }
        }

        public CurrencyInfo GetbyCurrencyId(TaxiAppzDBContext context, long id)
        {
            try
            {
                CurrencyInfo currencyInfo = new CurrencyInfo();
                var listService = context.TabCommonCurrency.FirstOrDefault(t => t.Currencyid == id && t.IsDeleted == 0);
                if (listService != null)
                {
                     currencyInfo.CurrencyName= listService.Currencyname;
                     currencyInfo.CurrencySymbol= listService.CurrencySymbol;
                     currencyInfo.StandardId= listService.Currenciesid;

                }

                return currencyInfo != null ? currencyInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyTypeId", context);
                return null;
            }
        }

        public bool StatusType(TaxiAppzDBContext context, long id, bool isStatus)
        {
            try
            {

                var updatedate = context.TabCommonCurrency.Where(r => r.Currencyid == id && r.IsDeleted == 0).FirstOrDefault();
                if (updatedate != null)
                {


                    updatedate.IsActive = isStatus == true ? 1 : 0;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = "admin";
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "StatusType", context);
                return false;
            }
        }

    }
}
