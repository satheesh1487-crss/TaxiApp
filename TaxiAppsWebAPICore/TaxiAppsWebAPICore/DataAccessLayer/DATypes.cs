using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore
{
    public class DATypes
    {
        public List<VehicleTypeList> ListType(TaxiAppzDBContext context)
        {
            List<VehicleTypeList> vehicleTypeLists = new List<VehicleTypeList>();
            var vechilesTupe = context.TabTypes.Where(t => t.IsDeleted == 0).ToList();
            foreach (var vechiles in vechilesTupe)
            {
                vehicleTypeLists.Add(new VehicleTypeList()
                {
                    Id = vechiles.Typeid,
                    Image = vechiles.Imagename,
                    IsActive = vechiles.IsActive==1?false:true,
                    Name = vechiles.Typename
                });
            }
            return vehicleTypeLists;
        }
        public bool AddType(TaxiAppzDBContext context, VehicleTypeInfo vehicleTypeInfo)
        {
            try
            {
                TabTypes tabTypes = new TabTypes();
                tabTypes.Typeid = vehicleTypeInfo.Id;
                tabTypes.Imagename = vehicleTypeInfo.Image;
                tabTypes.Typename = vehicleTypeInfo.Name;
                tabTypes.IsActive = 0;
                tabTypes.IsDeleted = 0;
                tabTypes.CreatedAt = DateTime.UtcNow;
                tabTypes.UpdatedAt = DateTime.UtcNow;
                tabTypes.CreatedBy = "admin";
                tabTypes.UpdatedBy = "admin";
                context.TabTypes.Add(tabTypes);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddType", context);
                return false;
            }
        }

        public bool EditType(TaxiAppzDBContext context, VehicleTypeInfo vehicleTypeInfo)
        {
            try
            {

                var updatedate = context.TabTypes.Where(r => r.Typeid == vehicleTypeInfo.Id && r.IsDeleted == 0).FirstOrDefault();
                if (updatedate != null)
                {
                  
                    updatedate.Imagename = vehicleTypeInfo.Image;
                    updatedate.Typename = vehicleTypeInfo.Name;
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

        public bool DeleteType(TaxiAppzDBContext context, long id)
        {
            try
            {

                var updatedate = context.TabTypes.Where(r => r.Typeid == id && r.IsDeleted == 0).FirstOrDefault();
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

        public VehicleTypeInfo GetbyTypeId(TaxiAppzDBContext context, long id)
        {
            try
            {
                VehicleTypeInfo vehicleTypeInfo = new VehicleTypeInfo();
                var listService = context.TabTypes.FirstOrDefault(t => t.Typeid == id && t.IsDeleted == 0);
                if (listService != null)
                {
                    vehicleTypeInfo.Id = listService.Typeid;
                    vehicleTypeInfo.Image = listService.Imagename;
                    vehicleTypeInfo.Name = listService.Typename;
                    
                }

                return vehicleTypeInfo != null ? vehicleTypeInfo : null;
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

                var updatedate = context.TabTypes.Where(r => r.Typeid == id && r.IsDeleted == 0).FirstOrDefault();
                if (updatedate != null)
                {


                    updatedate.IsActive = isStatus==true?1:0;
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
