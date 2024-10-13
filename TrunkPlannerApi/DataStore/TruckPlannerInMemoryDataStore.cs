using TruckPlannerLib.Models;

namespace TrunkPlannerApi.DataStore
{
    public class TruckPlannerInMemoryDataStore : ITruckPlannerDataStore
    {
        /// <summary>
        /// 
        /// </summary>
        public TruckPlannerInMemoryDataStore()
        {
            TruckPlans = new List<TruckPlan>{ new TruckPlan {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(5),
            Truck= new Truck
            {
                 GpsDeviceId= 1
            },
            TruckDriver = new TruckDriver
            {
                BirthDate= DateTime.Now.AddYears(-51),
                DriverId=1,
                Name = "TestName1",

            }
            } };
        }
        public IEnumerable<TruckPlan> TruckPlans { get; set; }

        public IEnumerable<TruckDriver> TruckDrivers { get; set; }

        public IEnumerable<GpsLocationData> GpsLocations { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }
    }
}
