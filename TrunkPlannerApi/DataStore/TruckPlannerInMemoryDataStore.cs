using TruckPlannerLib.Models;

namespace TrunkPlannerApi.DataStore
{
    /// <summary>
    /// 
    /// </summary>
    public class TruckPlannerInMemoryDataStore : ITruckPlannerDataStore
    {
        /// <summary>
        /// 
        /// </summary>
        public TruckPlannerInMemoryDataStore()
        {
            TruckDrivers = new List<TruckDriver>
            {
                new TruckDriver
                {
                    BirthDate = DateTime.Now.AddYears(-55),
                    DriverId =1,
                    Name  ="Test Driver 1"
                },
                new TruckDriver
                {
                    BirthDate = DateTime.Now.AddYears(-45),
                    DriverId =2,
                    Name  ="Test Driver 2"
                },
            };

            Trucks = new List<Truck>
            {
                new Truck
                {
                    TruckId = 1,
                },
                new Truck
                {
                    TruckId = 2,
                }
            };

            //All the GPS locations are for Denmark
            GpsLocations = new List<GpsLocationData>
            {
                new GpsLocationData
                {
                    GpsLocationDataId=1,
                    Truck= Trucks.First(truck=> truck.TruckId==1),
                    Latitude =55.70359474538186,
                    Longitude= 12.595923797345852,
                    Timestamp = DateTime.Now.AddDays(-1).AddMinutes(-15),
                },
                new GpsLocationData
                {
                    GpsLocationDataId=2,
                    Truck= Trucks.First(truck=> truck.TruckId==1),
                    Latitude =55.701301805618414,
                    Longitude= 12.531170412689127,
                    Timestamp = DateTime.Now.AddDays(-1).AddMinutes(-10),
                },
                new GpsLocationData
                {
                    GpsLocationDataId=3,
                    Truck= Trucks.First(truck=> truck.TruckId==1),
                    Latitude =55.609716282292624,
                    Longitude= 12.635477166896314,
                    Timestamp = DateTime.Now.AddDays(-1).AddMinutes(-5),
                },
                new GpsLocationData
                {
                    GpsLocationDataId=4,
                    Truck= Trucks.First(truck=> truck.TruckId==2),
                    Latitude =55.701301805618414,
                    Longitude= 12.531170412689127,
                    Timestamp = DateTime.Now.AddDays(-2).AddMinutes(-5),
                },
                new GpsLocationData
                {
                    GpsLocationDataId=5,
                    Truck= Trucks.First(truck=> truck.TruckId==2),
                    Latitude =55.609716282292624,
                    Longitude= 12.635477166896314,
                    Timestamp = DateTime.Now.AddDays(-2)
                }
            };


            TruckPlans = new List<TruckPlan>{ 
                new TruckPlan 
                {
                    TrunkPlanId = 1,
                    StartDate = DateTime.Now.AddDays(-1).AddHours(-1),
                    EndDate = DateTime.Now.AddDays(-1),
                    Truck=  Trucks.First(truck=> truck.TruckId==1),
                    TruckDriver = TruckDrivers.First(truckDriver => truckDriver.DriverId==1),
                },
                new TruckPlan
                {
                    TrunkPlanId = 2,
                    StartDate = DateTime.Now.AddDays(-2).AddHours(-1),
                    EndDate = DateTime.Now.AddDays(-2),
                    Truck=  Trucks.First(truck=> truck.TruckId==2),
                    TruckDriver = TruckDrivers.First(truckDriver => truckDriver.DriverId==2),
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<TruckPlan> TruckPlans { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<TruckDriver> TruckDrivers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<GpsLocationData> GpsLocations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Truck> Trucks { get; set; }
    }
}
