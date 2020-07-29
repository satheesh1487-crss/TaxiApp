using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore 
{
    public class DAZone
    {
        public List<ManageZone> ListZone(TaxiAppzDBContext context)
        {
            try
            {
                List<ManageZone> manageZones = new List<ManageZone>();
                var zonelist = context.TabZone.Where(t => t.IsDeleted == 0).ToList();
                foreach (var zone in zonelist)
                {
                    manageZones.Add(new ManageZone()
                    {
                        Zoneid = zone.Zoneid,
                        ZoneName = zone.Zonename,
                        IsActive = zone.IsActive == 0 ? false : true

                    });
                }
                return manageZones;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "ListZone", context);
                return null;
            }
          
        }
        public ManageZone  GetZonedetails(long zoneid,TaxiAppzDBContext context)
        {
            try
            {
                ManageZone manageZones = new ManageZone();
                List<ManageZonePolygon> manageZonePolygon = new List<ManageZonePolygon>();
                var zonedtls = context.TabZone.Where(z => z.Zoneid == zoneid).FirstOrDefault();
                var zonepolygondtls = context.TabZonepolygon.Where(z => z.Zoneid == zoneid).ToList();
                manageZones.Zoneid = zonedtls.Zoneid;
                manageZones.ZoneName = zonedtls.Zonename;
                manageZones.Unit = zonedtls.Unit;
                manageZones.Serviceslocid = zonedtls.Servicelocid;
                foreach (var zonepolygon in zonepolygondtls)
                {
                    manageZonePolygon.Add(new ManageZonePolygon()
                    {
                        Lat = zonepolygon.Latitudes,
                        Lng = zonepolygon.Longitudes
                    });
                }
                manageZones.ZonePolygoneList = manageZonePolygon;

                return manageZones == null ? null : manageZones;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "GetZonedetails", context);
                return null;
            }
           
        }
        public bool AddZone(ManageZoneAdd manageZone,TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                TabZone tabZone = new TabZone();
                tabZone.Zonename = manageZone.ZoneName;
                tabZone.Servicelocid = manageZone.Serviceslocid;
                tabZone.Unit = manageZone.Unit;
                context.TabZone.Add(tabZone);
                context.SaveChanges();
             
                foreach (var zonepolygon in manageZone.ZonePolygoneList)
                {
                    TabZonepolygon tabZonepolygon = new TabZonepolygon();
                    tabZonepolygon.Longitudes = zonepolygon.Lng;
                    tabZonepolygon.Latitudes = zonepolygon.Lat;
                    tabZonepolygon.IsActive = 1;
                    tabZonepolygon.CreatedBy = "Admin";
                    tabZonepolygon.CreatedAt = DateTime.UtcNow;
                    tabZonepolygon.Zoneid = tabZone.Zoneid;
                    context.TabZonepolygon.Add(tabZonepolygon);
                  
                }
                 context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "AddZone", context);
                return false;
            }
           

        }

        public bool EditZone(ManageZoneAdd manageZone, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                var setzone = context.TabZone.Where(z => z.Zoneid == manageZone.Zoneid).FirstOrDefault();
                var deletezonepolyon = context.TabZonepolygon.Where(z => z.Zoneid == manageZone.Zoneid).ToList();
                setzone.Zonename = manageZone.ZoneName;
                setzone.Servicelocid = manageZone.Serviceslocid;
                setzone.Unit = manageZone.ZoneName;
                context.TabZone.Update(setzone);
               context.TabZonepolygon.RemoveRange(deletezonepolyon);
                context.SaveChanges();
                foreach (var zonepoly in manageZone.ZonePolygoneList)
                {
                     TabZonepolygon  tabZonepolygon = new TabZonepolygon();
                    tabZonepolygon.Latitudes = zonepoly.Lat;
                    tabZonepolygon.Longitudes = zonepoly.Lng;
                    tabZonepolygon.Zoneid = setzone.Zoneid;
                    tabZonepolygon.CreatedBy = "Admin";
                    tabZonepolygon.CreatedAt = DateTime.UtcNow;
                    tabZonepolygon.UpdatedBy = "Admin";
                    tabZonepolygon.UpdatedAt = DateTime.UtcNow;
                    context.TabZonepolygon.Add(tabZonepolygon);
                   
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "AddZone", context);
                return false;
            }


        }

        public bool DeleteZone(long zoneid, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                TabZone tabZone = new TabZone();
                var tabzone = context.TabZone.Where(z => z.Zoneid == zoneid).FirstOrDefault();
                var tabpolygondtls = context.TabZonepolygon.Where(z => z.Zoneid == zoneid).ToList();
                tabzone.IsDeleted = 1;
                tabzone.DeletedAt = DateTime.UtcNow;
                tabzone.DeletedBy = "Admin";
                context.TabZone.Update(tabzone);
                foreach (var tabpoly in tabpolygondtls)
                {
                    tabpoly.IsDeleted = 1;
                    tabpoly.DeletedAt = DateTime.UtcNow;
                    tabpoly.DeletedBy = "Admin";
                    context.TabZonepolygon.Update(tabpoly);
                }
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "DeleteZone", context);
                return false;
            }
            
        }

        public bool ActiveZone(long zoneid,bool isStatus, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
               
                var tabzone = context.TabZone.Where(z => z.Zoneid == zoneid && z.IsDeleted ==0).FirstOrDefault();
                var tabpolygondtls = context.TabZonepolygon.Where(z => z.Zoneid == zoneid).ToList();
                if (tabzone != null)
                {
                    tabzone.IsActive = isStatus==true ? 1 : 0;
                    tabzone.UpdatedAt = DateTime.UtcNow;
                    tabzone.UpdatedBy = "Admin";
                    context.TabZone.Update(tabzone);
                    foreach (var tabpoly in tabpolygondtls)
                    {
                        tabpoly.IsActive = isStatus ? 1 : 0;
                        tabpoly.UpdatedAt = DateTime.UtcNow;
                        tabpoly.UpdatedBy = "Admin";
                        context.TabZonepolygon.Update(tabpoly);
                    }
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "DeleteZone", context);
                return false;
            }

        }
        public List<ZoneTypeList> ListZoneType(long zoneid, TaxiAppzDBContext context)
        {
            try
            {
                List<ZoneTypeList> zoneTypeLists = new List<ZoneTypeList>();
                var zonetypelist = context.TabZonetypeRelationship.Include(t => t.Type).Where(z => z.Zoneid == zoneid && z.IsDelete == 0).ToList();
                foreach (var zonetype in zonetypelist)
                {
                    zoneTypeLists.Add(new ZoneTypeList()
                    {
                        Id = zonetype.Typeid,
                        Name = zonetype.Type.Typename,
                        IsDefault = zonetype.IsDefault,
                        IsActive = zonetype.IsActive == 0 ? false : true

                    });
                }
                return zoneTypeLists == null ? null : zoneTypeLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "ListZoneType", context);
                return null;
            }

        }
        public bool AddZoneType(long zoneid, ZoneTypeRelation zoneTypeRelation, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                var isrelationshipexist = context.TabZonetypeRelationship.Any(z => z.Zoneid == zoneid);
                TabZonetypeRelationship tabZonetypeRelationship = new TabZonetypeRelationship();
                tabZonetypeRelationship.Zoneid = zoneTypeRelation.Zoneid;
                tabZonetypeRelationship.Typeid = zoneTypeRelation.Typeid;
                tabZonetypeRelationship.Paymentmode = zoneTypeRelation.Paymentmode;
                tabZonetypeRelationship.Showbill = zoneTypeRelation.Showbill.ToUpper() == "YES" ? true : false;
                tabZonetypeRelationship.IsActive = 1;
                tabZonetypeRelationship.IsDefault = isrelationshipexist ? 0 : 1;
                context.TabZonetypeRelationship.Add(tabZonetypeRelationship);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "AddZoneType", context);
                return false;
            }

        }
        public ZoneTypeRelation GetZoneTypebyid(long zoneid, long typeid, TaxiAppzDBContext context)
        {
            try
            {
                ZoneTypeRelation zoneTypeRelation = new ZoneTypeRelation();
                var zonetype = context.TabZonetypeRelationship.Include(t => t.Zoneid == zoneid && t.Typeid == typeid).FirstOrDefault();
                if (zonetype != null)
                {
                    zoneTypeRelation.Typeid = zonetype.Typeid;
                    zoneTypeRelation.Paymentmode = zonetype.Paymentmode;
                    zoneTypeRelation.Showbill = zonetype.Showbill == true ? "YES" : "NO";
                    return zoneTypeRelation != null ? zoneTypeRelation : null;
                }
                return null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "GetZoneTypebyid", context);
                return null;
            }
        }
        public bool EditZoneType(ZoneTypeRelation zoneTypeRelation, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                var zonetypeedit = context.TabZonetypeRelationship.Where(z => z.Zoneid == zoneTypeRelation.Zoneid).FirstOrDefault();
                if (zonetypeedit != null)
                {
                    zonetypeedit.Zoneid = zoneTypeRelation.Zoneid;
                    zonetypeedit.Typeid = zoneTypeRelation.Typeid;
                    zonetypeedit.Paymentmode = zoneTypeRelation.Paymentmode;
                    zonetypeedit.Showbill = zoneTypeRelation.Showbill.ToUpper() == "YES" ? true : false;
                    zonetypeedit.IsActive = 1;
                    context.TabZonetypeRelationship.Update(zonetypeedit);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "EditZoneType", context);
                return false;
            }

        }
        public bool ActiveZoneType(long zoneid, long typeid, bool isactivestatus, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                var zonetypeedit = context.TabZonetypeRelationship.Where(z => z.Zoneid == zoneid && z.Typeid == typeid).FirstOrDefault();
                if (zonetypeedit != null)
                {
                    zonetypeedit.IsActive = isactivestatus ? 1 : 0;
                    context.TabZonetypeRelationship.Update(zonetypeedit);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "EditZoneType", context);
                return false;
            }
        }
        public bool IsDefaultZoneType(long zoneid, long typeid, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {
                var zonetypeexist = context.TabZonetypeRelationship.Where(z => z.Zoneid == zoneid && z.IsDefault == 1).FirstOrDefault();
                if (zonetypeexist != null)
                {
                    zonetypeexist.IsDefault = 0;
                    context.TabZonetypeRelationship.Update(zonetypeexist);
                    var zonetype = context.TabZonetypeRelationship.Where(z => z.Zoneid == zoneid && z.Typeid == typeid).FirstOrDefault();
                    zonetype.IsDefault = 1;
                    context.TabZonetypeRelationship.Update(zonetype);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    var zonetype = context.TabZonetypeRelationship.Where(z => z.Zoneid == zoneid && z.Typeid == typeid).FirstOrDefault();
                    zonetype.IsDefault = 1;
                    context.TabZonetypeRelationship.Update(zonetype);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "IsDefaultZoneType", context);
                return false;
            }
        }

    }
}
