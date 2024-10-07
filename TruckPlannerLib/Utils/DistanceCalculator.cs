
namespace TruckPlannerLib.Utils
{
    using System;
    using Models;
    public static class DistanceCalculator
    {
        private const double EarthRadiusKm = 6371.0;

        public static double CalculateDistance(GpsLocationData startLocation, GpsLocationData endLocation)
        {
            var lat1 = ToRadians(startLocation.Latitude);
            var lon1 = ToRadians(startLocation.Longitude);
            var lat2 = ToRadians(endLocation.Latitude);
            var lon2 = ToRadians(endLocation.Longitude);

            var dlon = lon2 - lon1;
            var dlat = lat2 - lat1;

            var a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        private static double ToRadians(double angle)
        {
            return angle * (Math.PI / 180.0);
        }
    }
}
