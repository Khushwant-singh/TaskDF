using System;
using System.Linq;
using System.Threading.Tasks;
using TruckPlannerLib.Models;
namespace TruckPlannerLib
{
    public class TruckingService
    {
        private DataRepository _dataRepository;
        public TruckingService(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public double GetTotalDistanceByTruckPlan(int truckPlanId)
        {
            //Repository
            var truckPlan = _dataRepository.TruckPlans.FirstOrDefault(item => item.TrunkPlanId == truckPlanId);
            if (truckPlan == null)
                throw new Exception("Invalid truck plan id specified");

            var truck = truckPlan.Truck;

            var gpsLocationData = _dataRepository.GpsLocations.Where(gpsItem => gpsItem.GpsDeviceId == truck.GpsDeviceId
            && gpsItem.Timestamp >= truckPlan.StartDate && gpsItem.Timestamp <= truckPlan.EndDate).ToArray();

            double totalDistance = 0;
            for (int counter = 1; counter < gpsLocationData.Length; counter++)
            {
                totalDistance += Utils.DistanceCalculator.CalculateDistance(gpsLocationData[counter - 1], gpsLocationData[counter]);
            }

            return totalDistance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverAge"></param>
        /// <param name="country"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<double> GetTotalDistanceCoveredByCountryAndDriverAge(int driverAge, string country, DateTime startDate, DateTime endDate)
        {
            double totalDistance = 0;

            /*
             * Identify all the Truck plans for driver age over a certain age and start date between given dates
             * Identify all the GPSLocations involved per Truck Plan
             * Identify GpsLocation for the given country
             * Identify distance between two gps locations from the given TruckPlan
             */
            var truckPlans = _dataRepository.TruckPlans.Where(truckPlan => truckPlan.TruckDriver.Age == driverAge && truckPlan.StartDate >= startDate && truckPlan.StartDate <= endDate);

            GpsLocationData startGpsLocationData = null;
            foreach (var truckPlan in truckPlans)
            {
                startGpsLocationData = null;

                var gpsLocations = _dataRepository.GpsLocations.Where(gpsLocationItem => gpsLocationItem.Timestamp >= startDate && gpsLocationItem.Timestamp <= endDate && gpsLocationItem.GpsDeviceId == truckPlan.Truck.GpsDeviceId);

                foreach (var gpsLocation in gpsLocations)
                {
                    var countryByGps = await Utils.CountryLookup.GetCountryFromCoordinates(gpsLocation.Latitude, gpsLocation.Longitude);
                    if (string.Equals(countryByGps, country, StringComparison.OrdinalIgnoreCase))
                    {
                        if (startGpsLocationData == null)
                        {
                            startGpsLocationData = gpsLocation;
                            continue;
                        }

                        totalDistance += Utils.DistanceCalculator.CalculateDistance(startGpsLocationData, gpsLocation);
                        startGpsLocationData = gpsLocation;

                    }
                }
            }

            return totalDistance;
        }
    }
}
