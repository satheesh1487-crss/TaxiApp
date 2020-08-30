using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;
using TaziappzMobileWebAPI.Models;

namespace TaxiAppsWebAPICore
{
    public class DAVechile
    {
        public List<VehicleTypeList> ListType(TaxiAppzDBContext context)
        {
            try
            {
                var filesStorage = StorageFactory.GetStorage();
                List<VehicleTypeList> vehicleTypeLists = new List<VehicleTypeList>();
                var vechilesTupe = context.TabTypes.Where(t => t.IsDeleted == 0).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var vechiles in vechilesTupe)
                {
                    var files= File.ReadAllBytes(filesStorage.GetDownloadFile(vechiles.Imagename, vechiles.Typeid.ToString(), "VechileTypes").FullName);
                    vehicleTypeLists.Add(new VehicleTypeList()
                    {
                        Id = vechiles.Typeid,
                        Image =Convert.ToBase64String(files),
                        IsActive = vechiles.IsActive == 1 ? true : false,
                        Name = vechiles.Typename
                    }); 
                }
                return vehicleTypeLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
                return null;
            }
        }
        public bool AddType(TaxiAppzDBContext context, VehicleTypeInfo vehicleTypeInfo, LoggedInUser loggedInUser)
        {
            var filesStorage = StorageFactory.GetStorage();
            bool isFileMoved = false;
            var file = context.TabUploadfiledetails.FirstOrDefault(t => t.Fileid == long.Parse(vehicleTypeInfo.Image));
            if (file == null)
                throw new DataValidationException("File does not exist");

            try
            {
                var fileName = file.Filename;
                isFileMoved = fileName == "" ? false : true;
                TabTypes tabTypes = new TabTypes();
                tabTypes.Imagename = fileName;
                tabTypes.Typename = vehicleTypeInfo.Name;
                tabTypes.IsActive = 1;
                tabTypes.IsDeleted = 0;
                tabTypes.CreatedAt = DateTime.UtcNow;
                tabTypes.UpdatedAt = DateTime.UtcNow;
                tabTypes.UpdatedBy = tabTypes.CreatedBy = loggedInUser.UserName;

                context.TabTypes.Add(tabTypes);
                context.SaveChanges();

                filesStorage.MoveToPersistant(file.Filename, tabTypes.Typeid.ToString(), "VechileTypes");
                isFileMoved=true;

                return true;
            }
            catch (Exception ex)
            {
                if (!isFileMoved)
                    filesStorage.MoveToTemp(file.Filename, vehicleTypeInfo.Image, "VechileTypes");
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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

                    updatedate.UpdatedBy = loggedInUser.UserName;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.UserName, System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                    updatedate.DeletedBy = loggedInUser.UserName;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                    updatedate.UpdatedBy = loggedInUser.UserName;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                tabSos.IsActive = 1;
                tabSos.IsDeleted = 0;
                tabSos.CreatedAt = tabSos.UpdatedAt = DateTime.UtcNow;
                tabSos.CreatedBy = tabSos.UpdatedBy = loggedInUser.UserName;
                context.TabSos.Add(tabSos);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.UserName, System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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

                    tabSos.Sosname = vehicleEmerInfo.Name;
                    tabSos.ContactNumber = vehicleEmerInfo.Number;

                    tabSos.UpdatedAt = DateTime.UtcNow;
                    tabSos.UpdatedBy = loggedInUser.UserName;
                    context.Update(tabSos);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, loggedInUser.UserName, System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                    tabSos.DeletedBy = loggedInUser.UserName;
                    context.Update(tabSos);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                    vehicleEmerInfo.Number = listService.ContactNumber;
                    vehicleEmerInfo.Name = listService.Sosname;

                }

                return vehicleEmerInfo != null ? vehicleEmerInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
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
                    tabSos.UpdatedBy = loggedInUser.UserName;
                    context.Update(tabSos);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
                return false;
            }
        }

        public List<VehicleTypeZoneList> ListTypeWithZone(TaxiAppzDBContext context)
        {
            try
            {

                List<VehicleTypeZoneList> vehicleTypeLists = new List<VehicleTypeZoneList>();
                var vechilesTupe = context.TabZonetypeRelationship.Include(t => t.Zone).Include(t => t.Type).Where(t => t.IsDelete == 0 && t.Zone != null).ToList().OrderByDescending(t => t.UpdatedAt);
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
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
                return null;
            }
        }

        public SurgePrice GetSurgePrice(TaxiAppzDBContext context, long zoneId)
        {
            try
            {
                SurgePrice surgePrice = new SurgePrice();
                var listSurgePrice = context.TabSurgeprice.FirstOrDefault(t => t.ZoneId == zoneId);
                if (listSurgePrice != null)
                {
                    surgePrice.Id = listSurgePrice.SurgepriceId;
                    surgePrice.Starttime = listSurgePrice.StartTime;
                    surgePrice.Endtime = listSurgePrice.EndTime;
                    surgePrice.Peaktype = listSurgePrice.PeakType;
                    surgePrice.Surgepricetype = listSurgePrice.SurgepriceType;
                    surgePrice.Surgepricevalue = listSurgePrice.SurgepriceValue;
                }
                return surgePrice != null ? surgePrice : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", System.Reflection.MethodBase.GetCurrentMethod().Name, context);
                return null;
            }
        }

        public bool SaveSurgePrice(SurgePrice surgePrice, TaxiAppzDBContext content, LoggedInUser loggedIn)
        {
            var existZone = content.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == surgePrice.Zoneid);
            if (existZone == null)
                throw new DataValidationException("Zone name does not exist");

            var exist = content.TabSurgeprice.FirstOrDefault(t => t.IsDelete == false && t.ZoneId == surgePrice.Zoneid);
            if (exist == null)
            {
                TabSurgeprice tabSurgeprice = new TabSurgeprice();
                tabSurgeprice.PeakType = surgePrice.Peaktype;
                tabSurgeprice.StartTime = surgePrice.Starttime;
                tabSurgeprice.ZoneId = surgePrice.Zoneid;
                tabSurgeprice.EndTime = surgePrice.Endtime;
                tabSurgeprice.SurgepriceType = surgePrice.Surgepricetype;
                tabSurgeprice.SurgepriceValue = surgePrice.Surgepricevalue;
                tabSurgeprice.IsActive = true;
                tabSurgeprice.UpdatedAt = tabSurgeprice.CreatedAt = Extention.GetDateTime();
                tabSurgeprice.UpdatedBy = tabSurgeprice.CreatedBy = loggedIn.UserName;
                content.TabSurgeprice.Add(tabSurgeprice);
                content.SaveChanges();
                return true;
            }
            else
            {
                exist.PeakType = surgePrice.Peaktype;
                exist.StartTime = surgePrice.Starttime;
                exist.EndTime = surgePrice.Endtime;
                exist.SurgepriceType = surgePrice.Surgepricetype;
                exist.SurgepriceValue = surgePrice.Surgepricevalue;

                exist.UpdatedAt = Extention.GetDateTime();
                exist.UpdatedBy = loggedIn.UserName;
                content.TabSurgeprice.Update(exist);
                content.SaveChanges();
                return true;
            }

        }
    }
}
