using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Common.Dto
{

    public class GeoLocation
    {

        public double lon { get; set; }

        public double lat { get; set; }

        public GeoLocation()
        {

        }

        public GeoLocation(double lon, double lat)
        {
            this.lat = lat;
            this.lon = lon;
        }

    }

}
