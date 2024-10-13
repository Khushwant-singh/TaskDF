
namespace TruckPlannerLib
{
    using System.Linq;
    using TruckPlannerLib.Models;
    public interface IDataRepository
    {
        IQueryable<TruckPlan> TruckPlans { get; set; }

        IQueryable<TruckDriver> TruckDrivers { get; set; }  

        IQueryable<GpsLocationData> GpsLocations { get; set; }

        IQueryable<Truck> Trucks { get; set; }
    }
}
