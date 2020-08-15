using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DARequest
    {
        public long? GetPolygon(LatLong latLong, TaxiAppzDBContext context)
        {
            //var zonelist = context.TabZone.Where(x => x.Servicelocid == servicelocationid && x.IsActive == 1 && x.IsDeleted == 0).ToList();
            //if (zonelist.Count > 0)
            //{
            //    foreach (var zone in zonelist)
            //    {
            //var zonepolygon = context.TabZonepolygon.Where(t => t.Zoneid == zone.Zoneid && t.IsActive == 1 && t.IsDeleted == 0).ToList();
                    var zonepolygon = context.TabZonepolygon.Where(t =>  t.IsActive == 1 && t.IsDeleted == 0).ToList();
                    List<LatLong> listlatlong = new List<LatLong>();
                    foreach (var zonepoly in zonepolygon)
                    {
                        listlatlong.Add(new LatLong()
                        {
                            Picklatitude = zonepoly.Latitudes,
                            Picklongtitude = zonepoly.Longitudes,
                            Zoneid= zonepoly.Zoneid
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
                    return listlatlong[k].Zoneid;
            }
                //}
          //  }
            return 0;
        }

        public Zone GetRequest(LatLong latLong, TaxiAppzDBContext context)
        {
            List<LatLong> latlonglist = new List<LatLong>();
            List<VehicleType> vehicleTypes = new List<VehicleType>();
            Zone zone = new Zone();
            //var serviceloc = context.TabServicelocation.Where(t => t.Servicelocid == servicelocationid && t.IsActive == 1 && t.IsDeleted == 0).FirstOrDefault();
            //if (serviceloc == null)
            //{
            //    zone.IsExist = 0;
            //    return zone;
            //}
            long? zoneid = this.GetPolygon(latLong, context);
            if (zoneid == 0)
            {
                zone.IsExist = 0;
                return zone;
            }
            else
            {
                var zonelist = context.TabZonetypeRelationship.Include(t => t.Zone.IsActive == 1 && t.Zone.IsDeleted == 0).Include(y => y.Type.IsActive == 1 && y.Type.IsDeleted == 0).Where(x => x.Zoneid == latlonglist[0].Zoneid && x.IsActive == 1 && x.IsDelete == 0).ToList();
                zone.IsExist = 1;
                return zone;
                //if (zonelist.count == 0)
                //{
                //    zone.IsExist = 0;
                //    return zone;
                //}
                //foreach(var _zone in zonelist)
                //{
                //    vehicleTypes.Add(new VehicleType()
                //    {
                //        TypeId= _zone.type
                //    });

                //}
            }
           return null;

        }
    }
}
