using System;
namespace TruckPlannerLib.Models
{
    public class GpsLocationData
    {
        public int GpsDeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
