using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
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
                var zonelist = context.TabZone.Include(t => t.Serviceloc).Where(t => t.IsDeleted == 0).ToList();
                foreach (var zone in zonelist)
                {
                    manageZones.Add(new ManageZone()
                    {
                        Zoneid = zone.Zoneid,
                        ZoneName = zone.Zonename,
                        Serviceslocid = zone.Servicelocid,
                        Unit = zone.Unit,
                        ServiceName = zone.Serviceloc.Name,
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
        public ManageZone GetZonedetails(long zoneid, TaxiAppzDBContext context)
        {
            try
            {
                ManageZone manageZones = new ManageZone();
                List<ManageZonePolygon> manageZonePolygon = new List<ManageZonePolygon>();
                var zonedtls = context.TabZone.Where(z => z.Zoneid == zoneid && z.IsDeleted == 0).FirstOrDefault();
                var zonepolygondtls = context.TabZonepolygon.Where(z => z.Zoneid == zoneid && z.IsDeleted == 0).ToList();
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
        public bool AddZone(ManageZoneAdd manageZone, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var serviceExist = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Servicelocid == manageZone.Serviceslocid);
            if (serviceExist == null)
                throw new DataValidationException($"Service location does not already exists.");

            TabZone tabZone = new TabZone();
            tabZone.Zonename = manageZone.ZoneName;
            tabZone.Servicelocid = manageZone.Serviceslocid;
            tabZone.Unit = manageZone.Unit;
            tabZone.IsActive = 1;
            tabZone.IsDeleted = 0;
            tabZone.CreatedBy = tabZone.UpdatedBy = loggedInUser.UserName;
            tabZone.CreatedAt = tabZone.UpdatedAt = Extention.GetDateTime();
            context.TabZone.Add(tabZone);
            context.SaveChanges();

            foreach (var zonepolygon in manageZone.ZonePolygoneList)
            {
                TabZonepolygon tabZonepolygon = new TabZonepolygon();
                tabZonepolygon.Longitudes = zonepolygon.Lng;
                tabZonepolygon.Latitudes = zonepolygon.Lat;
                tabZonepolygon.IsActive = 1;
                tabZonepolygon.CreatedBy = tabZonepolygon.UpdatedBy = loggedInUser.UserName;
                tabZonepolygon.CreatedAt = tabZonepolygon.UpdatedAt = Extention.GetDateTime();
                tabZonepolygon.Zoneid = tabZone.Zoneid;
                context.TabZonepolygon.Add(tabZonepolygon);
            }
            context.SaveChanges();
            return true;
        }

        public bool EditZone(ManageZoneAdd manageZone, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var serviceExist = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Servicelocid == manageZone.Serviceslocid);
            if (serviceExist == null)
                throw new DataValidationException($"Service location does not already exists.");

            var setzone = context.TabZone.Where(z => z.Zoneid == manageZone.Zoneid && z.IsDeleted == 0).FirstOrDefault();
            var deletezonepolyon = context.TabZonepolygon.Where(z => z.Zoneid == manageZone.Zoneid).ToList();
            if (setzone != null)
            {
                setzone.Zonename = manageZone.ZoneName;
                setzone.Servicelocid = manageZone.Serviceslocid;
                setzone.Unit = manageZone.ZoneName;
                context.TabZone.Update(setzone);
                context.TabZonepolygon.RemoveRange(deletezonepolyon);
                context.SaveChanges();
                foreach (var zonepoly in manageZone.ZonePolygoneList)
                {
                    TabZonepolygon tabZonepolygon = new TabZonepolygon();
                    tabZonepolygon.Latitudes = zonepoly.Lat;
                    tabZonepolygon.Longitudes = zonepoly.Lng;
                    tabZonepolygon.Zoneid = setzone.Zoneid;
                    tabZonepolygon.UpdatedBy = tabZonepolygon.CreatedBy = loggedInUser.UserName;
                    tabZonepolygon.UpdatedAt = tabZonepolygon.CreatedAt = DateTime.UtcNow;
                    context.TabZonepolygon.Add(tabZonepolygon);
                }
                context.SaveChanges();
                return true;
            }
            return false;
        }

        internal List<OperationZone> ManageOperation(TaxiAppzDBContext context)
        {
            try
            {
                List<OperationZone> operationZones = new List<OperationZone>();
                var zoneRelation = context.TabZonetypeRelationship.Include(t => t.Type).Include(t => t.Zone).Where(t => t.IsDelete == 0).ToList();
                foreach (var zoneType in zoneRelation)
                {
                    operationZones.Add(new OperationZone() { Id = zoneType.Zonetypeid, vechileType = zoneType.Type.Typename, zoneName = zoneType.Zone.Zonename });
                }
                return operationZones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteZone(long zoneid, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {

            TabZone tabZone = new TabZone();
            var tabzone = context.TabZone.Include(t => t.TabZonepolygon).Where(z => z.Zoneid == zoneid).FirstOrDefault();
            if (tabzone != null)
            {
                tabzone.IsDeleted = 1;
                tabzone.DeletedAt = DateTime.UtcNow;
                tabzone.DeletedBy = loggedInUser.UserName;
                context.TabZone.Update(tabzone);
                foreach (var tabpoly in tabzone.TabZonepolygon.ToList())
                {
                    tabpoly.IsDeleted = 1;
                    tabpoly.DeletedAt = DateTime.UtcNow;
                    tabpoly.DeletedBy = loggedInUser.UserName;
                    context.TabZonepolygon.Update(tabpoly);
                }
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ActiveZone(long zoneid, bool isStatus, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            try
            {

                var tabzone = context.TabZone.Where(z => z.Zoneid == zoneid && z.IsDeleted == 0).FirstOrDefault();
                var tabpolygondtls = context.TabZonepolygon.Where(z => z.Zoneid == zoneid).ToList();
                if (tabzone != null)
                {
                    tabzone.IsActive = isStatus == true ? 1 : 0;
                    tabzone.UpdatedAt = DateTime.UtcNow;
                    tabzone.UpdatedBy = loggedInUser.UserName;
                    context.TabZone.Update(tabzone);
                    foreach (var tabpoly in tabpolygondtls)
                    {
                        tabpoly.IsActive = isStatus ? 1 : 0;
                        tabpoly.UpdatedAt = DateTime.UtcNow;
                        tabpoly.UpdatedBy = loggedInUser.UserName;
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
                        Id = zonetype.Zonetypeid,
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

        public List<ZoneTypeDrop> ZoneType(long zoneId, TaxiAppzDBContext context)
        {
            try
            {
                List<ZoneTypeDrop> zoneTypeLists = new List<ZoneTypeDrop>();
                var typeVechile = context.TabTypes.Where(t => t.IsDeleted == 0 && t.IsActive == 1).ToList();
                var relationTypeZone = context.TabZonetypeRelationship.Where(t => t.IsDelete == 0 && t.IsActive == 1 && t.Zoneid == zoneId).Select(t => t.Typeid);

                foreach (var item in typeVechile)
                {
                    zoneTypeLists.Add(new ZoneTypeDrop()
                    {
                        Id = item.Typeid,
                        Name = item.Typename
                    });

                }
                foreach (var item in relationTypeZone)
                {
                    zoneTypeLists.Remove(zoneTypeLists.FirstOrDefault(t => t.Id == item));
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


            var serviceExist = context.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == zoneTypeRelation.Zoneid);
            if (serviceExist == null)
                throw new DataValidationException($"Zone does not already exists.");

            var typeExist = context.TabTypes.FirstOrDefault(t => t.IsDeleted == 0 && t.Typeid == zoneTypeRelation.Typeid);
            if (typeExist == null)
                throw new DataValidationException($"Vechile type does not already exists.");

            var isrelationshipexist = context.TabZonetypeRelationship.Any(z => z.Zoneid == zoneid && z.IsDelete == 0);
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
        public ZoneTypeRelation GetZoneTypebyid(long zoneid, long zonetypeid, TaxiAppzDBContext context)
        {
            try
            {
                ZoneTypeRelation zoneTypeRelation = new ZoneTypeRelation();
                var zonetype = context.TabZonetypeRelationship.Include(t => t.Zoneid == zoneid && t.Typeid == zonetypeid).FirstOrDefault();
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

            var serviceExist = context.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == zoneTypeRelation.Zoneid);
            if (serviceExist == null)
                throw new DataValidationException($"Zone does not already exists.");

            var typeExist = context.TabTypes.FirstOrDefault(t => t.IsDeleted == 0 && t.Typeid == zoneTypeRelation.Typeid);
            if (typeExist == null)
                throw new DataValidationException($"Vechile type does not already exists.");

            var zonetypeedit = context.TabZonetypeRelationship.Where(z => z.Zoneid == zoneTypeRelation.Zoneid && z.Typeid == zoneTypeRelation.Typeid).FirstOrDefault();
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
        public bool ActiveZoneType(long zoneid, long typeid, bool isactivestatus, TaxiAppzDBContext context, LoggedInUser loggedInUser)
        {
            var serviceExist = context.TabZone.FirstOrDefault(t => t.IsDeleted == 0 && t.Zoneid == zoneid);
            if (serviceExist == null)
                throw new DataValidationException($"Zone does not already exists.");

            var typeExist = context.TabTypes.FirstOrDefault(t => t.IsDeleted == 0 && t.Typeid == typeid);
            if (typeExist == null)
                throw new DataValidationException($"Vechile type does not already exists.");
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

        public List<SetPrice> GetSetprice(long zoneid, long zonetypeid, TaxiAppzDBContext context)
        {
            try
            {
                List<SetPrice> setPrices = new List<SetPrice>();

                var getsetpricelist = context.TabSetpriceZonetype.Where(t => t.Zonetypeid == zonetypeid && t.IsDelete ==  false).ToList();

                foreach (var getprice in getsetpricelist)
                {
                    setPrices.Add(new SetPrice()
                    {
                        SetPriceid = getprice.Setpriceid,
                        ZoneTypeid = getprice.Zonetypeid,
                        BasePrice = getprice.Baseprice,
                        PricePerTime = getprice.Pricepertime,
                        BaseDistance = getprice.Basedistance,
                        PricePerDistance = getprice.Priceperdistance,
                        Freewaitingtime = getprice.Freewaitingtime,
                        WaitingCharges = getprice.Waitingcharges,
                        CancellationFee = getprice.Cancellationfee,
                        DropFee = getprice.Dropfee,
                        admincommtype = getprice.Admincommtype,
                        admincommission = getprice.Admincommission,
                        CustomerIdfee = getprice.Customseldrifee,
                        Driversavingper = getprice.Driversavingper,
                        RideType = getprice.RideType
                    });

                }
                return setPrices;


            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditSetPrice", context);
                return null;
            }

        }

        public bool EditSetprice(List<SetPrice> setPrice, TaxiAppzDBContext context)
        {
            try
            {
                foreach (var setprice in setPrice)
                {
                    var tabSetpriceZonetype = context.TabSetpriceZonetype.Where(t => t.Zonetypeid == setprice.ZoneTypeid && t.RideType == setprice.RideType && t.IsDelete == false).FirstOrDefault();
                    if (tabSetpriceZonetype != null)
                    {
                        tabSetpriceZonetype.Zonetypeid = setprice.ZoneTypeid;
                        tabSetpriceZonetype.Baseprice = setprice.BasePrice;
                        tabSetpriceZonetype.Pricepertime = setprice.PricePerTime;
                        tabSetpriceZonetype.Basedistance = setprice.BaseDistance;
                        tabSetpriceZonetype.Priceperdistance = setprice.PricePerDistance;
                        tabSetpriceZonetype.Customseldrifee = setprice.CustomerIdfee;
                        tabSetpriceZonetype.Freewaitingtime = setprice.Freewaitingtime;
                        tabSetpriceZonetype.Waitingcharges = setprice.WaitingCharges;
                        tabSetpriceZonetype.Cancellationfee = setprice.CancellationFee;
                        tabSetpriceZonetype.Dropfee = setprice.DropFee;
                        tabSetpriceZonetype.Admincommtype = setprice.admincommtype;
                        tabSetpriceZonetype.Admincommission = setprice.admincommission;
                        tabSetpriceZonetype.Driversavingper = setprice.Driversavingper;
                        tabSetpriceZonetype.RideType = setprice.RideType;
                        context.TabSetpriceZonetype.Update(tabSetpriceZonetype);
                    }
                    else
                    {
                        TabSetpriceZonetype tabSetprice = new TabSetpriceZonetype();
                        tabSetprice.Zonetypeid = setprice.ZoneTypeid;
                        tabSetprice.Baseprice = setprice.BasePrice;
                        tabSetprice.Pricepertime = setprice.PricePerTime;
                        tabSetprice.Basedistance = setprice.BaseDistance;
                        tabSetprice.Priceperdistance = setprice.PricePerDistance;
                        tabSetprice.Freewaitingtime = setprice.Freewaitingtime;
                        tabSetprice.Waitingcharges = setprice.WaitingCharges;
                        tabSetprice.Customseldrifee = setprice.CustomerIdfee == null ? 0 : setprice.CustomerIdfee;
                        tabSetprice.Cancellationfee = setprice.CancellationFee;
                        tabSetprice.Dropfee = setprice.DropFee;
                        tabSetprice.Admincommtype = setprice.admincommtype;
                        tabSetprice.Admincommission = setprice.admincommission;
                        tabSetprice.Driversavingper = setprice.Driversavingper;
                        tabSetprice.RideType = setprice.RideType;
                        context.TabSetpriceZonetype.Add(tabSetprice);
                    }
                    context.SaveChanges();

                }
                return true;


            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditSetPrice", context);
                return false;
            }

        }

        public List<TypeList> ListTypesDuringAddZone(long zoneid, TaxiAppzDBContext context)
        {
            try
            {
                List<TypeList> typeLists = new List<TypeList>();
                var typelist = context.TabZonetypeRelationship.Where(t => t.Zoneid == zoneid).Select(t => t.Typeid).ToList();
                var types = context.TabTypes.Where(x => !typelist.Contains(x.Typeid) && x.IsActive == 1 && x.IsDeleted == 0).ToList();
                foreach (var type in types)
                {
                    typeLists.Add(new TypeList()
                    {
                        Id = type.Typeid,
                        Name = type.Typename
                    });
                }
                return typeLists == null ? null : typeLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "ListZoneType", context);
                return null;
            }

        }

        public List<ManageZone> ListServiceBasedZone(long zoneid, TaxiAppzDBContext context)
        {
            try
            {
                List<ManageZone> typeLists = new List<ManageZone>();
                var typelist = context.TabZone.Where(t => t.Servicelocid == zoneid && t.IsDeleted == 0).ToList();
                foreach (var type in typelist)
                {
                    typeLists.Add(new ManageZone()
                    {
                        Zoneid = type.Zoneid,
                        ZoneName = type.Zonename
                    });
                }
                return typeLists == null ? null : typeLists;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message.ToString(), "Admin", "ListZoneType", context);
                return null;
            }

        }

    }
}
