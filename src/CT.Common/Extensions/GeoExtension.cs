using CT.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Common.Extensions
{
    public static class GeoExtension
    {
        private static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }

        public static double GetDistance(this GeoLocation source, GeoLocation target)
        {
            if (source == null)
                throw new AppException("Argument source is null");

            if (target == null)
                throw new AppException("Argument target is null");

            //Calculate radius of earth
            var R = 3960;
            var lat = (source.lat - target.lat).ToRadians();
            var lng = (source.lon - target.lon).ToRadians();

            //Denominator part of the function
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) + Math.Cos(source.lat.ToRadians()) * Math.Cos(target.lat.ToRadians()) * Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));

            //Calaculate distance in miles.
            return R * h2;
        }
    }
}
