﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DAZone
    {
        public List<LatLong> GetPolygon(LatLong latLong, long servicelocationid, TaxiAppzDBContext context)
        {
            var zonelist = context.TabZone.Where(x => x.Servicelocid == servicelocationid && x.IsActive == 1 && x.IsDeleted == 0).ToList();
            if (zonelist.Count > 0)
            {
                foreach (var zone in zonelist)
                {
                    var zonepolygon = context.TabZonepolygon.Where(t => t.Zoneid == zone.Zoneid && t.IsActive == 1 && t.IsDeleted == 0).ToList();
                    List<LatLong> listlatlong = new List<LatLong>();
                    foreach (var zonepoly in zonepolygon)
                    {
                        listlatlong.Add(new LatLong()
                        {
                            Latitude = zonepoly.Latitudes,
                            Longtitude = zonepoly.Longitudes
                        });
                    }
                    if (listlatlong.Count > 0)
                    {
                        int i, k;
                        int nvert = listlatlong.Count;
                        bool result = false;
                        for (i = 0, k = nvert - 1; i < nvert; k = i++)
                        {
                            if (((listlatlong[i].Longtitude > latLong.Longtitude) != (listlatlong[k].Longtitude > latLong.Longtitude)) &&
                             (latLong.Latitude < (listlatlong[k].Latitude - listlatlong[i].Latitude) * (latLong.Longtitude - listlatlong[i].Longtitude) / (listlatlong[k].Longtitude - listlatlong[i].Longtitude) + listlatlong[i].Latitude))
                                result = !result;
                        }
                        if (result)
                            return listlatlong;
                    }
                }
            }
            return null;
        }
       
    }
}
