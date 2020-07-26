using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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
        public bool AddZone(ManageZoneAdd manageZone,TaxiAppzDBContext context)
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

        public bool EditZone(ManageZoneAdd manageZone, TaxiAppzDBContext context)
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

        public bool DeleteZone(long zoneid, TaxiAppzDBContext context)
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

        public bool ActiveZone(long zoneid,bool isStatus, TaxiAppzDBContext context)
        {
            try
            {
                TabZone tabZone = new TabZone();
                var tabzone = context.TabZone.Where(z => z.Zoneid == zoneid).FirstOrDefault();
                var tabpolygondtls = context.TabZonepolygon.Where(z => z.Zoneid == zoneid).ToList();
                tabzone.IsActive = isStatus ? 1 : 0;
                tabzone.UpdatedAt = DateTime.UtcNow;
                tabzone.UpdatedBy = "Admin";
                context.TabZone.Update(tabzone);
                foreach (var tabpoly in tabpolygondtls)
                {
                    tabpoly.IsActive = isStatus  ? 1  : 0;
                    tabpoly.UpdatedAt = DateTime.UtcNow;
                    tabpoly.UpdatedBy = "Admin";
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
    }
}
