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
        public int GpsLocationDataId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Truck Truck { get; set; }

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
