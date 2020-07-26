using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;
using TaxiAppsWebAPICore.Helper;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAService
    {
        public List<ServiceListModel> ListService(TaxiAppzDBContext context)
        {
            try
            {
                List<ServiceListModel> rolelist = new List<ServiceListModel>();
                var listService = context.TabServicelocation.Include(t => t.Country).Include(t => t.Timezone).Include(t => t.Currency).Where(t => t.IsDeleted == 0).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var service in listService)
                {
                    rolelist.Add(new ServiceListModel()
                    {
                        Country = service.Country.Name,
                        CurrencyCode = service.Currency.Code,
                        CurrencySymbol = service.Currency.Symbol,
                        ServiceId = service.Servicelocid,
                        ServiceName = service.Name,
                        TimeZone = service.Timezone.Zonedescription
                    });
                }
                return rolelist != null ? rolelist : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListService", context);
                return null;
            }

        }

        public bool AddService(TaxiAppzDBContext context, ServiceInfo serviceInfo)
        {
            try
            {
                TabServicelocation tabServicelocation = new TabServicelocation();
                tabServicelocation.Countryid = serviceInfo.CountryId;
                tabServicelocation.Timezoneid = serviceInfo.TimezoneId;
                tabServicelocation.Currencyid = serviceInfo.CurrencyId;
                tabServicelocation.Name = serviceInfo.ServiceName;
                
                tabServicelocation.CreatedAt = DateTime.UtcNow;
                tabServicelocation.UpdatedAt = DateTime.UtcNow;
                tabServicelocation.CreatedBy = "admin";
                tabServicelocation.UpdatedBy = "admin";
                context.TabServicelocation.Add(tabServicelocation);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddService", context);
                return false;
            }
        }

        public bool EditService(TaxiAppzDBContext context, ServiceInfo serviceInfo)
        {
            try
            {
                 
                var updatedate = context.TabServicelocation.Where(r => r.Servicelocid == serviceInfo.ServiceId && r.IsDeleted==0).FirstOrDefault();
                if (updatedate != null)
                {

                    updatedate.Countryid = serviceInfo.CountryId;
                    updatedate.Timezoneid = serviceInfo.TimezoneId;
                    updatedate.Currencyid = serviceInfo.CurrencyId;
                    updatedate.Name = serviceInfo.ServiceName;
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
                Extention.insertlog(ex.Message, "Admin", "EditService", context);
                return false;
            }
        }

        public bool DeleteService(TaxiAppzDBContext context, long id)
        {
            try
            {
                 
                var updatedate = context.TabServicelocation.Where(r => r.Servicelocid == id && r.IsDeleted == 0).FirstOrDefault();
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
                Extention.insertlog(ex.Message, "Admin", "DeleteService", context);
                return false;
            }
        }

        public ServiceInfo GetbyServiceId(TaxiAppzDBContext context,long id)
        {
            try
            {
                ServiceInfo serviceInfo = new ServiceInfo();
                var listService = context.TabServicelocation.FirstOrDefault(t => t.Servicelocid == id && t.IsDeleted == 0);
                if (listService != null)
                {
                    serviceInfo.CountryId = listService.Countryid;
                    serviceInfo.CurrencyId = listService.Currencyid;
                    serviceInfo.SymbolCurrencyId = listService.Countryid;
                    serviceInfo.TimezoneId = listService.Timezoneid;
                    serviceInfo.ServiceId = listService.Servicelocid;
                    serviceInfo.ServiceName = listService.Name;
                }
                
                return serviceInfo != null ? serviceInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyServiceId", context);
                return null;
            }
        }
    }
}
