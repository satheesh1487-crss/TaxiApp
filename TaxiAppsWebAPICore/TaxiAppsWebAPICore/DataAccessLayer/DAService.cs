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
                        CurrencyCode = service.Country.Currency,
                        CurrencySymbol = service.Currency.CurrencySymbol,
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

        public bool AddService(TaxiAppzDBContext context, ServiceInfo serviceInfo, LoggedInUser loggedInUser)
        {
            var serviceExists = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Name.ToLower() == serviceInfo.ServiceName.ToLower() && t.Servicelocid != serviceInfo.ServiceId);
            if (serviceExists != null)
                throw new DataValidationException($"Service with name '{serviceExists.Name}' already exists.");

            TabServicelocation tabServicelocation = new TabServicelocation();
            tabServicelocation.Countryid = serviceInfo.CountryId;
            tabServicelocation.Timezoneid = serviceInfo.TimezoneId;
            tabServicelocation.Currencyid = serviceInfo.CurrencyId;
            tabServicelocation.Name = serviceInfo.ServiceName;

            tabServicelocation.CreatedAt = DateTime.UtcNow;
            tabServicelocation.UpdatedAt = DateTime.UtcNow;
            tabServicelocation.UpdatedBy = tabServicelocation.CreatedBy = loggedInUser.Email;

            context.TabServicelocation.Add(tabServicelocation);
            context.SaveChanges();
            return true;
        }

        public bool EditService(TaxiAppzDBContext context, ServiceInfo serviceInfo, LoggedInUser loggedInUser)
        {
            var serviceExists = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Name.ToLower() == serviceInfo.ServiceName.ToLower() && t.Servicelocid != serviceInfo.ServiceId);
            if (serviceExists != null)
                throw new DataValidationException($"Service with name '{serviceExists.Name}' already exists.");

            var updatedate = context.TabServicelocation.Where(r => r.Servicelocid == serviceInfo.ServiceId && r.IsDeleted == 0).FirstOrDefault();
            if (updatedate != null)
            {

                updatedate.Countryid = serviceInfo.CountryId;
                updatedate.Timezoneid = serviceInfo.TimezoneId;
                updatedate.Currencyid = serviceInfo.CurrencyId;
                updatedate.Name = serviceInfo.ServiceName;
                updatedate.UpdatedAt = DateTime.UtcNow;
                updatedate.UpdatedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DeleteService(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            var serviceExists = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Servicelocid == id);
            if (serviceExists != null)
                throw new DataValidationException($"Service with name '{serviceExists.Name}' already exists.");

            var updatedate = context.TabServicelocation.Where(r => r.Servicelocid == id && r.IsDeleted == 0).FirstOrDefault();
            if (updatedate != null)
            {

                updatedate.IsDeleted = 1;
                updatedate.DeletedAt = DateTime.UtcNow;
                updatedate.DeletedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public ServiceInfo GetbyServiceId(TaxiAppzDBContext context, long id)
        {
            try
            {
                ServiceInfo serviceInfo = new ServiceInfo();
                var listService = context.TabServicelocation.FirstOrDefault(t => t.Servicelocid == id && t.IsDeleted == 0);
                if (listService != null)
                {
                    serviceInfo.CountryId = listService.Countryid;
                    serviceInfo.CurrencyId = listService.Currencyid;
                    serviceInfo.SymbolCurrencyId = listService.Currencyid;
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

        public List<ServiceListModel> GetCountrybyId(TaxiAppzDBContext context, long id)
        {
            try
            {
                List<ServiceListModel> serviceInfo = new List<ServiceListModel>();
                var listService = context.TabServicelocation.Where(t => t.Countryid == id && t.IsDeleted == 0);
                foreach (var service in listService)
                {
                    serviceInfo.Add(new ServiceListModel()
                    {
                        ServiceId = service.Servicelocid,
                        ServiceName = service.Name,
                    });
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
