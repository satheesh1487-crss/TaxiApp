using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore
{
    public class DAVechile
    {
        public List<VehicleTypeList> ListType(TaxiAppzDBContext context)
        {
            try
            {

                List<VehicleTypeList> vehicleTypeLists = new List<VehicleTypeList>();
                var vechilesTupe = context.TabTypes.Where(t => t.IsDeleted == 0).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var vechiles in vechilesTupe)
                {
                    vehicleTypeLists.Add(new VehicleTypeList()
                    {
                        Id = vechiles.Typeid,
                        Image = vechiles.Imagename,
                        IsActive = vechiles.IsActive == 1 ? true : false,
                        Name = vechiles.Typename
                    });
                }
                return vehicleTypeLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListType", context);
                return null;
            }
        }
        public bool AddType(TaxiAppzDBContext context, VehicleTypeInfo vehicleTypeInfo, LoggedInUser loggedInUser)
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

        public bool EditType(TaxiAppzDBContext context, VehicleTypeInfo vehicleTypeInfo, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabTypes.Where(r => r.Typeid == vehicleTypeInfo.Id && r.IsDeleted == 0).FirstOrDefault();
                if (updatedate != null)
                {

                    updatedate.Imagename = vehicleTypeInfo.Image;
                    updatedate.Typename = vehicleTypeInfo.Name;        

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

        public bool DeleteType(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
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

        public bool StatusType(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabTypes.Where(r => r.Typeid == id && r.IsDeleted == 0).FirstOrDefault();
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
        public List<VehicleTypeList> ListZoneType(TaxiAppzDBContext context)
        {
            List<VehicleTypeList> vehicleTypeLists = new List<VehicleTypeList>();
            var vechilesTupe = context.TabTypes.Where(t => t.IsDeleted == 0).ToList().OrderBy(t => t.UpdatedAt);
            foreach (var vechiles in vechilesTupe)
            {
                vehicleTypeLists.Add(new VehicleTypeList()
                {
                    Id = vechiles.Typeid,
                    Image = vechiles.Imagename,
                    IsActive = vechiles.IsActive == 1 ? true : false,
                    Name = vechiles.Typename
                });
            }
            return vehicleTypeLists;
        }

        public List<VehicleEmerList> ListEmer(TaxiAppzDBContext context)
        {
            try
            {

                List<VehicleEmerList> vehicleEmerList = new List<VehicleEmerList>();
                var vechilesEmer = context.TabSos.Where(t => t.IsDeleted == 0).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var vechi in vechilesEmer)
                {
                    vehicleEmerList.Add(new VehicleEmerList()
                    {
                        Id = vechi.Sosid,
                        Name = vechi.Sosname,
                        Number = vechi.ContactNumber,
                        IsActive = vechi.IsActive == 1 ? true : false
                    });
                }
                return vehicleEmerList;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListEmer", context);
                return null;
            }
        }

        public bool SaveEmer(TaxiAppzDBContext context, VehicleEmerInfo vehicleEmerInfo, LoggedInUser loggedInUser)
        {
            try
            {
                TabSos tabSos = new TabSos();
                tabSos.Sosid = vehicleEmerInfo.Id;
                tabSos.Sosname = vehicleEmerInfo.Name;
                tabSos.ContactNumber = vehicleEmerInfo.Number;
                tabSos.IsActive = 0;
                tabSos.IsDeleted = 0;
                tabSos.CreatedAt = tabSos.UpdatedAt = DateTime.UtcNow;
                tabSos.CreatedBy = tabSos.UpdatedBy = "admin";
                context.TabSos.Add(tabSos);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "SaveEmer", context);
                return false;
            }
        }

        public bool EditEmer(TaxiAppzDBContext context, VehicleEmerInfo vehicleEmerInfo, LoggedInUser loggedInUser)
        {
            try
            {
                var tabSos = context.TabSos.Where(r => r.Sosid == vehicleEmerInfo.Id && r.IsDeleted == 0).FirstOrDefault();
                if (tabSos != null)
                {

                    tabSos.Sosname= vehicleEmerInfo.Name;
                    tabSos.ContactNumber = vehicleEmerInfo.Number;
                  
                    tabSos.UpdatedAt = DateTime.UtcNow;
                    tabSos.UpdatedBy = "admin";
                    context.Update(tabSos);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditEmer", context);
                return false;
            }
        }

        public bool DeleteEmer(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {

                var tabSos = context.TabSos.Where(r => r.Sosid == id && r.IsDeleted == 0).FirstOrDefault();
                if (tabSos != null)
                {


                    tabSos.IsDeleted = 1;
                    tabSos.DeletedAt = DateTime.UtcNow;
                    tabSos.DeletedBy = "admin";
                    context.Update(tabSos);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "DeleteEmer", context);
                return false;
            }
        }

        public VehicleEmerInfo GetbyEmerId(TaxiAppzDBContext context, long id)
        {
            try
            {
                VehicleEmerInfo vehicleEmerInfo = new VehicleEmerInfo();
                var listService = context.TabSos.FirstOrDefault(t => t.Sosid == id && t.IsDeleted == 0);
                if (listService != null)
                {
                    vehicleEmerInfo.Id = listService.Sosid;
                    vehicleEmerInfo.Number = listService.Sosname;
                    vehicleEmerInfo.Name = listService.Sosname;

                }

                return vehicleEmerInfo != null ? vehicleEmerInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyEmerId", context);
                return null;
            }
        }

        public bool StatusEmer(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {
            try
            {

                var tabSos = context.TabSos.Where(r => r.Sosid == id && r.IsDeleted == 0).FirstOrDefault();
                if (tabSos != null)
                {


                    tabSos.IsActive = isStatus == true ? 1 : 0;
                    tabSos.UpdatedAt = DateTime.UtcNow;
                    tabSos.UpdatedBy = "admin";
                    context.Update(tabSos);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "StatusEmer", context);
                return false;
            }
        }

        public List<VehicleTypeZoneList> ListTypeWithZone(TaxiAppzDBContext context)
        {
            try
            {

                List<VehicleTypeZoneList> vehicleTypeLists = new List<VehicleTypeZoneList>();
                var vechilesTupe = context.TabZonetypeRelationship.Include(t=>t.Zone).Include(t => t.Type).Where(t => t.IsDelete == 0&& t.Zone!=null).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var vechiles in vechilesTupe)
                {
                    vehicleTypeLists.Add(new VehicleTypeZoneList()
                    {
                        Id = vechiles.Zonetypeid,
                        Name = vechiles.Zone.Zonename + '-' + vechiles.Type.Typename
                    }); ;
                }
                return vehicleTypeLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListType", context);
                return null;
            }
        }
    }
}
