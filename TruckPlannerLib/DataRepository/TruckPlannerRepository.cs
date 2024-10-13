namespace TruckPlannerLib.DataRepository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TruckPlannerLib.Models;

    /// <summary>
    /// 
    /// </summary>
    public class TruckPlannerRepository : ITruckPlannerRepository
    {
        private ITruckPlannerDataStore _dataStore;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataStore"></param>
        public TruckPlannerRepository(ITruckPlannerDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="truckPlanId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public double GetTotalDistanceByTruckPlan(int truckPlanId)
        {
            //Get Truck plan by the Id of the Truck plan
            var truckPlan = _dataStore.TruckPlans?.FirstOrDefault(item => item.TrunkPlanId == truckPlanId);
            if (truckPlan == null)
                throw new Exception("Invalid truck plan id specified");

            var truck = truckPlan.Truck;

            //Get GPS location data for the given Truck plan
            var gpsLocationData = _dataStore.GpsLocations.Where(gpsItem => gpsItem.GpsDeviceId == truck.GpsDeviceId
            && gpsItem.Timestamp >= truckPlan.StartDate && gpsItem.Timestamp <= truckPlan.EndDate).ToArray();

            double totalDistance = 0;
            for (int counter = 1; counter < gpsLocationData.Length; counter++)
            {
                totalDistance += Utils.DistanceCalculator.CalculateDistance(gpsLocationData[counter - 1], gpsLocationData[counter]);
            }

            return totalDistance;
        }


        /// <summary>
        /// Get Total distance convered by Truck drivers elder than given age and for a particular country within given date range
        /// </summary>
        /// <param name="driverAge">The age of the driver</param>
        /// <param name="country">Country travelled by the drivers</param>
        /// <param name="startDate">Start date-range</param>
        /// <param name="endDate">End date-range></param>
        /// <returns>return total distance</returns>
        public async Task<double> GetTotalDistanceCoveredByDriverAgeInCountry(int driverAge, string country, DateTime startDate, DateTime endDate)
        {
            double totalDistance = 0;
            var truckPlans = _dataStore.TruckPlans.Where(truckPlan => truckPlan.TruckDriver.Age == driverAge && truckPlan.StartDate >= startDate && truckPlan.StartDate <= endDate);

            GpsLocationData startGpsLocationData = null;
            foreach (var truckPlan in truckPlans)
            {
                startGpsLocationData = null;

                //Get all GPS locations for a particular truck between given dates
                var gpsLocations = _dataStore.GpsLocations.Where(gpsLocationItem => gpsLocationItem.Timestamp >= startDate && gpsLocationItem.Timestamp <= endDate && gpsLocationItem.GpsDeviceId == truckPlan.Truck.GpsDeviceId);

                foreach (var gpsLocation in gpsLocations)
                {
                    //Get country from the coordinates
                    var countryByGps = await Utils.CountryLookup.GetCountryFromCoordinates(gpsLocation.Latitude, gpsLocation.Longitude);
                    if (string.Equals(countryByGps, country, StringComparison.OrdinalIgnoreCase))
                    {
                        //In order to calculate distance, we need to have two coordinates
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
