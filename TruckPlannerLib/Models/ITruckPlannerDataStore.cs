using System.Collections.Generic;
using System.Linq;

namespace TruckPlannerLib.Models
{
    public interface ITruckPlannerDataStore
    {
        IEnumerable<TruckPlan> TruckPlans { get; set; }

        IEnumerable<TruckDriver> TruckDrivers { get; set; }

        IEnumerable<GpsLocationData> GpsLocations { get; set; }

        IEnumerable<Truck> Trucks { get; set; }
    }
}
