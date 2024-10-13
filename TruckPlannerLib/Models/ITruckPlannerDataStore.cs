using System.Collections.Generic;

namespace TruckPlannerLib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITruckPlannerDataStore
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TruckPlan> TruckPlans { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TruckDriver> TruckDrivers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<GpsLocationData> GpsLocations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Truck> Trucks { get; set; }
    }
}
