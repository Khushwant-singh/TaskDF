using System;
namespace TruckPlannerLib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GpsLocationData
    {
        /// <summary>
        /// 
        /// </summary>
        public int GpsDeviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }
    }
}
