namespace TruckPlannerLib.DataRepository
{
    using System;
    using System.Collections.Generic;
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
            double totalDistance = 0;
            //Get Truck plan by the Id of the Truck plan
            var truckPlan = _dataStore.TruckPlans?.FirstOrDefault(item => item.TrunkPlanId == truckPlanId);
            if (truckPlan == null)
                throw new Exception("Invalid truck plan id specified");

           //If we want to know the distance between Start point and End point, then we could use below code.
           /*
            var startGpsLocationData = _dataStore.GpsLocations.Where(gpsLocation => gpsLocation.GpsDeviceId == truckPlan.Truck.GpsDeviceId && gpsLocation.Timestamp >= truckPlan.StartDate && gpsLocation.Timestamp <= truckPlan.EndDate).OrderBy(item => item.Timestamp).FirstOrDefault();
            var endGpsLocationData = _dataStore.GpsLocations.Where(gpsLocation => gpsLocation.GpsDeviceId == truckPlan.Truck.GpsDeviceId && gpsLocation.Timestamp >= truckPlan.StartDate && gpsLocation.Timestamp <= truckPlan.EndDate).OrderByDescending(item => item.Timestamp).FirstOrDefault();
            if (startGpsLocationData != null && endGpsLocationData != null)
                totalDistance = Utils.DistanceCalculator.CalculateDistance(startGpsLocationData, endGpsLocationData);
           */
            
            //If we want to know the real distance a Truck has travelled, then we need to go through each of the GPS location
            var gpsLocationData = _dataStore.GpsLocations.Where(gpsItem => gpsItem.GpsDeviceId == truckPlan.Truck.GpsDeviceId
           && gpsItem.Timestamp >= truckPlan.StartDate && gpsItem.Timestamp <= truckPlan.EndDate).ToArray();
            totalDistance = 0;
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
        /// <param name="apiKey"></param>
        /// <returns>return total distance</returns>
        public async Task<double> GetTotalDistanceCoveredByDriverAgeInCountry(int driverAge, string country, DateTime startDate, DateTime endDate, string apiKey)
        {
            double totalDistance = 0;
            var truckPlans = _dataStore.TruckPlans.Where(truckPlan => truckPlan.TruckDriver.Age == driverAge && truckPlan.StartDate >= startDate && truckPlan.StartDate <= endDate);

            GpsLocationData startGpsLocationData = null;
            //GpsLocationData endGpsLocationData = null;

            foreach (var truckPlan in truckPlans)
            {
                startGpsLocationData = null;
                //endGpsLocationData = null;
                
                var gpsLocations = _dataStore.GpsLocations.Where(gpsLocationItem => gpsLocationItem.Timestamp >= startDate && gpsLocationItem.Timestamp <= endDate.AddDays(1).AddSeconds(-1) && gpsLocationItem.GpsDeviceId == truckPlan.Truck.GpsDeviceId);

                foreach (var gpsLocation in gpsLocations)
                {
                    //Get country from the coordinates
                    var countryByGps = await Utils.CountryLookup.GetCountryFromCoordinates(gpsLocation.Latitude, gpsLocation.Longitude, apiKey);
                    if (string.Equals(countryByGps, country, StringComparison.OrdinalIgnoreCase))
                    {
                        if (startGpsLocationData == null)
                        {
                            startGpsLocationData = gpsLocation;
                            continue;
                        }

                        totalDistance += Utils.DistanceCalculator.CalculateDistance(startGpsLocationData, gpsLocation);
                        startGpsLocationData = gpsLocation;
                        
                        //endGpsLocationData = gpsLocation;
                    }
                }
                
                //If we want to calculate distance between start and end point only
                /*
                if (startGpsLocationData != null && endGpsLocationData != null)
                {
                    totalDistance += Utils.DistanceCalculator.CalculateDistance(startGpsLocationData, endGpsLocationData);
                }
                */
            }

            return totalDistance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TruckPlan> GetAllTruckPlans()
        {
            return _dataStore.TruckPlans.ToList();
        }
    }
}
