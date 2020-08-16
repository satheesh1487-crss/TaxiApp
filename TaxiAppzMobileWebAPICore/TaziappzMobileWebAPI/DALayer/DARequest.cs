using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.TaxiModels;
using Microsoft.AspNetCore.Mvc;
namespace TaziappzMobileWebAPI.DALayer
{
    public class DARequest
    {
        public long? GetPolygon(LatLong latLong,long countryid, TaxiAppzDBContext context)
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

        public Zone GetRequest(LatLong latLong,long countryid, TaxiAppzDBContext context)
        {
            List<LatLong> latlonglist = new List<LatLong>();
           Zone zone = new Zone();
            long? zoneid = this.GetPolygon(latLong, countryid, context);
            if (zoneid == 0)
            {
                zone.IsExist = 0;
                return zone;
            }
            else
            {
                var iszoneexist = context.TabZone.Include(x => x.Serviceloc).Where(t => t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
                if(iszoneexist == null)
                {
                    zone.IsExist = 0;
                    return zone;
                }
                var zonelist = context.TabZonetypeRelationship.Include(t => t.Zone).Include(y => y.Type).Where(x => x.Zoneid == zoneid && x.IsActive == 1 && x.IsDelete == 0).ToList();

                if (zonelist.Count == 0)
                {
                    zone.IsExist = 0;
                    return zone;
                }
                List<VehicleType> vehicleTypes = new List<VehicleType>();
                foreach (var _zone in zonelist)
                {
                    var zonetypes = context.TabZonetypeRelationship.Where(t => t.Typeid == _zone.Typeid &&   t.Zoneid == _zone.Zoneid && t.IsActive == 1 && t.IsDelete == 0).ToList();
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
                                PricePerDistance= price.Priceperdistance,
                                Freewaitingtime = price.Freewaitingtime,
                                WaitingCharges= price.Waitingcharges,
                                CancellationFee= price.Cancellationfee,
                                DropFee= price.Dropfee,
                                admincommtype=price.Admincommtype,
                                admincommission=price.Admincommission,
                                Driversavingper=price.Driversavingper,
                                CustomerIdfee=price.Customseldrifee,
                                Modeofpayment=zonetype.Paymentmode
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
                zone.Zoneid = iszoneexist.Zoneid;
                zone.ZoneName = iszoneexist.Zonename;
                zone.Unit = iszoneexist.Unit;
                zone.ServiceLocName = iszoneexist.Serviceloc.Name;
                zone.Vehicletypelist = vehicleTypes;
                var surgepricelist = context.TabSurgeprice.Where(t => t.ZoneId == zoneid).ToList();
                if(surgepricelist.Count  != 0)
                {
                    List<SurgePrice> surgePrices = new List<SurgePrice>();
                    foreach(var surgeprice in surgepricelist)
                    {
                        surgePrices.Add(new SurgePrice()
                        {
                            Surgepricetype = surgeprice.SurgepriceType,
                            Starttime=surgeprice.StartTime,
                            Endtime=surgeprice.EndTime,
                            Peaktype=surgeprice.PeakType,
                            Surgepricevalue=surgeprice.SurgepriceValue
                        });
                    }
                    zone.Surgepricelist = surgePrices;
                }
                zone.Currency = context.TabCommonCurrency.Where(t => t.Currencyid == iszoneexist.Serviceloc.Currencyid).Select(t => t.Currencyname).FirstOrDefault();
                zone.IsExist = 1;
                TabRequestPlace tabRequestPlace = new TabRequestPlace();
                tabRequestPlace.PickLatitude = latLong.Picklatitude;
                tabRequestPlace.PickLongitude = latLong.Picklongtitude;
                tabRequestPlace.DropLatitude = latLong.Droplatitude;
                tabRequestPlace.DropLongitude = latLong.droplongtitude;
                tabRequestPlace.PickLocation = latLong.Pickuplocation;
                tabRequestPlace.DropLocation = latLong.Droplocation;
                tabRequestPlace.IsActive = true;
                tabRequestPlace.CreatedBy = "Admin";
                tabRequestPlace.CreatedAt = DateTime.UtcNow;
                context.TabRequestPlace.Add(tabRequestPlace);
                context.SaveChanges();
                return zone;

            }
        

        }

        public bool Requestprogress(LatLong latLong, TaxiAppzDBContext context)
        {
            return true;
        }
    }
}
