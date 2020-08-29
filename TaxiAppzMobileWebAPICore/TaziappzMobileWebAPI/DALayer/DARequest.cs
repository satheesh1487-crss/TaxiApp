using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.TaxiModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.ComponentModel;
using Microsoft.VisualBasic;
using TaziappzMobileWebAPI.Models;
using Microsoft.Extensions.Options;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DARequest
    {
        public readonly SettingModel settingModel;
        public DARequest(IOptions<SettingModel> _settingmodel)
        {
            settingModel = _settingmodel.Value;
        }
        //TO find polygon
        public long? GetPolygon(LatLong latLong, long countryid, TaxiAppzDBContext context)
        {
            var sericelocationlist = context.TabServicelocation.Include(t => t.TabZone).Where(x => x.Countryid == countryid && x.IsActive == 1 && x.IsDeleted == 0).ToList();
            if (sericelocationlist.Count == 0)
                return 0;
            foreach (var zonelist in sericelocationlist)
            {
                foreach (var zone in zonelist.TabZone)
                {
                    var zonepolygon = context.TabZonepolygon.Where(t => t.Zoneid == zone.Zoneid && t.IsActive == 1 && t.IsDeleted == 0).ToList();
                    List<LatLong> listlatlong = new List<LatLong>();
                    foreach (var zonepoly in zonepolygon)
                    {
                        listlatlong.Add(new LatLong()
                        {
                            Picklatitude = zonepoly.Latitudes,
                            Picklongtitude = zonepoly.Longitudes
                        });
                    }
                    if (listlatlong.Count > 0)
                    {
                        int i, k;
                        int nvert = listlatlong.Count;
                        bool result = false;
                        for (i = 0, k = nvert - 1; i < nvert; k = i++)
                        {
                            if (((listlatlong[i].Picklongtitude > latLong.Picklongtitude) != (listlatlong[k].Picklongtitude > latLong.Picklongtitude)) &&
                             (latLong.Picklatitude < (listlatlong[k].Picklatitude - listlatlong[i].Picklatitude) * (latLong.Picklongtitude - listlatlong[i].Picklongtitude) / (listlatlong[k].Picklongtitude - listlatlong[i].Picklongtitude) + listlatlong[i].Picklatitude))
                                result = !result;
                        }
                        if (result)
                            return zone.Zoneid;
                        //}
                    }
                }
                //var zonepolygon = context.TabZonepolygon.Where(t => t.Zoneid == zone.TabZone && t.IsActive == 1 && t.IsDeleted == 0).ToList();
                //// var zonepolygon = context.TabZonepolygon.Where(t =>  t.IsActive == 1 && t.IsDeleted == 0).ToList();

            }
            // }
            //}
            //  }
            return 0;
        }

        public List<Zone> GetRequest(LatLong latLong, LoggedInUser loggedInUser, TaxiAppzDBContext context)
        {
            List<LatLong> latlonglist = new List<LatLong>();
            List<Zone> zone = new List<Zone>();
            long? zoneid = this.GetPolygon(latLong, loggedInUser.Country, context);
            if (zoneid == 0)
                return zone;
            else
            {
                var iszoneexist = context.TabZone.Include(x => x.Serviceloc).Where(t => t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
                if (iszoneexist == null)
                    return zone;
                var zonelist = context.TabZonetypeRelationship.Include(t => t.Zone).Include(y => y.Type).Where(x => x.Zoneid == zoneid && x.IsActive == 1 && x.IsDelete == 0).ToList();
                if (zonelist.Count == 0)
                    return zone;
                List<VehicleType> vehicleTypes = new List<VehicleType>();
                foreach (var _zone in zonelist)
                {
                    var zonetypes = context.TabZonetypeRelationship.Where(t => t.Typeid == _zone.Typeid && t.Zoneid == _zone.Zoneid && t.IsActive == 1 && t.IsDelete == 0).ToList();
                    foreach (var zonetype in zonetypes)
                    {
                        List<SetPrice> setPrices = new List<SetPrice>();
                        var pricelist = context.TabSetpriceZonetype.Where(x => x.Zonetypeid == zonetype.Zonetypeid).ToList();
                        foreach (var price in pricelist)
                        {
                            setPrices.Add(new SetPrice()
                            {
                                RideType = price.RideType,
                                BasePrice = price.Baseprice,
                                PricePerTime = price.Pricepertime,
                                BaseDistance = price.Basedistance,
                                PricePerDistance = price.Priceperdistance,
                                Freewaitingtime = price.Freewaitingtime,
                                WaitingCharges = price.Waitingcharges,
                                CancellationFee = price.Cancellationfee,
                                DropFee = price.Dropfee,
                                admincommtype = price.Admincommtype,
                                admincommission = price.Admincommission,
                                Driversavingper = price.Driversavingper,
                                CustomerIdfee = price.Customseldrifee,
                                Modeofpayment = zonetype.Paymentmode
                            });
                        }
                        var vehicletype = context.TabTypes.Where(t => t.Typeid == zonetype.Typeid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
                        if (vehicletype != null)
                        {
                            vehicleTypes.Add(new VehicleType()
                            {
                                TypeId = vehicletype.Typeid,
                                TypeName = vehicletype.Typename,
                                SetpriceList = setPrices
                            });

                        }
                    }
                }
                zone[0].Zoneid = iszoneexist.Zoneid;
                zone[0].ZoneName = iszoneexist.Zonename;
                zone[0].Unit = iszoneexist.Unit;
                zone[0].ServiceLocName = iszoneexist.Serviceloc.Name;
                zone[0].Vehicletypelist = vehicleTypes;
                var surgepricelist = context.TabSurgeprice.Where(t => t.ZoneId == zoneid).ToList();
                if (surgepricelist.Count != 0)
                {
                    List<SurgePrice> surgePrices = new List<SurgePrice>();
                    foreach (var surgeprice in surgepricelist)
                    {
                        surgePrices.Add(new SurgePrice()
                        {
                            Surgepricetype = surgeprice.SurgepriceType,
                            Starttime = surgeprice.StartTime,
                            Endtime = surgeprice.EndTime,
                            Peaktype = surgeprice.PeakType,
                            Surgepricevalue = surgeprice.SurgepriceValue
                        });
                    }
                    zone[0].Surgepricelist = surgePrices;
                }
                zone[0].Currency = context.TabCommonCurrency.Where(t => t.Currencyid == iszoneexist.Serviceloc.Currencyid).Select(t => t.Currencyname).FirstOrDefault();
                return zone;
            }
        }
        //test
        public bool Requestprogress(RequestVehicleType requestVehicleType, LoggedInUser loggedInUser, TaxiAppzDBContext context)
        {
            TabUser tabUser = new TabUser();
            var userid = context.TabUser.Where(t => t.PhoneNumber.Contains(loggedInUser.Contactno) && t.IsActive == true && t.IsDelete == 0).Select(t => t.Id).FirstOrDefault();
            if (userid == null)
                return false;
            Random random = new Random();
            var reqid = random.Next(001, 9999);
            TabRequest tabRequest = new TabRequest();
            tabRequest.RequestId = "REQ_" + reqid;
            tabRequest.RequestOtp = random.Next(1000, 9999);
            tabRequest.UserId = userid;
            tabRequest.IsCancelled = false;
            tabRequest.IsCompleted = false;
            tabRequest.IsDriverArrived = false;
            tabRequest.IsDriverStarted = false;
            tabRequest.IsTripStart = false;
            context.TabRequest.Add(tabRequest);
            context.SaveChanges();

            TabRequestPlace tabRequestPlace = new TabRequestPlace();
            tabRequestPlace.PickLatitude = requestVehicleType.Picklatitude;
            tabRequestPlace.PickLongitude = requestVehicleType.Picklongtitude;
            tabRequestPlace.DropLatitude = requestVehicleType.Droplatitude;
            tabRequestPlace.DropLongitude = requestVehicleType.droplongtitude;
            tabRequestPlace.PickLocation = requestVehicleType.Pickuplocation;
            tabRequestPlace.DropLocation = requestVehicleType.Droplocation;
            tabRequestPlace.RequestId = tabRequest.Id;
            tabRequestPlace.IsActive = true;
            tabRequestPlace.CreatedBy = loggedInUser.Contactno;
            tabRequestPlace.CreatedAt = DateTime.UtcNow;
            context.TabRequestPlace.Add(tabRequestPlace);

            List<DriversListwithDistance> driversListwithDistance = new List<DriversListwithDistance>();
            //  driversListwithDistance = SortLocation(requestVehicleType).OrderBy(t => t.Distance).ToList();
            driversListwithDistance = driversListwithDistance.OrderBy(t => t.Distance).ToList();
            int index = 0;
            foreach (var driver in driversListwithDistance)
            {
                TabRequestMeta tabRequestMeta = new TabRequestMeta();
                tabRequestMeta.RequestId = tabRequest.Id;
                tabRequestMeta.UserId = userid;
                tabRequestMeta.DriverId = driver.Driverid;
                tabRequestMeta.IsActive = index == 0;
                tabRequestMeta.AssignMethod = "OnebyOne";
                tabRequestMeta.Notification = "Normal Request";
                tabRequestMeta.CreatedAt = DateTime.UtcNow;
                index++;
                context.TabRequestMeta.Add(tabRequestMeta);
            }
            context.SaveChanges();

            return true;
        }

        public bool DeleteMetaDriver(LoggedInUser loggedInUser, TaxiAppzDBContext context)
        {
            TabUser tabUser = new TabUser();

            var userid = context.TabRequestMeta.Where(t => t.CreatedAt> DateTime.Now.AddMinutes(settingModel.Seconds)).ToList();
            foreach(var user in userid)

            {
                context.TabRequestMeta.Remove(user);
            }
            context.SaveChanges();
            return true;
        }

        public bool RequestCancel(DriversCancel requestVehicleType, LoggedInUser loggedInUser, TaxiAppzDBContext context)
        {



            return true;
        }
        public List<DriversListwithDistance> SortLocation(RequestVehicleType requestVehicleType)
        {
            double baselat = Convert.ToDouble(requestVehicleType.Picklatitude);
            double baselng = Convert.ToDouble(requestVehicleType.Picklongtitude);

            List<DriversListwithDistance> driversListwithDistance = new List<DriversListwithDistance>();
            foreach (DriversList driversList in requestVehicleType.DriversLists)
            {
                double designlat = Convert.ToDouble(driversList.Driverlatitude);
                double designlong = Convert.ToDouble(driversList.Driverlongtitude);
                var R = 6372.8; // In kilometers
                var dLat = toRadians(designlat - baselat);
                var dLon = toRadians(designlong - baselng);
                baselat = toRadians(baselat);
                designlat = toRadians(designlat);

                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(baselat) * Math.Cos(designlat);
                var c = 2 * Math.Asin(Math.Sqrt(a));
                driversListwithDistance.Add(new DriversListwithDistance()
                {
                    Driverid = driversList.Driverid,
                    Driverlatitude = driversList.Driverlatitude,
                    Driverlongtitude = driversList.Driverlongtitude,
                    Distance = R * c
                });
            }
            return driversListwithDistance;


        }
        public static double toRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }

}
