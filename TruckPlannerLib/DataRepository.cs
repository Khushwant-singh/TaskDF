
namespace TruckPlannerLib
{
    using System.Linq;
    using TruckPlannerLib.Models;
    public class DataRepository
    {
        public IQueryable<TruckPlan> TruckPlans { get; set; }

        public IQueryable<TruckDriver> TruckDrivers { get; set; }  

        public IQueryable<GpsLocationData> GpsLocations { get; set; }

        public IQueryable<Truck> Trucks { get; set; }
    }
}
