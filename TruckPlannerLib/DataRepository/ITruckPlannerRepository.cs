using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckPlannerLib.Models;

namespace TruckPlannerLib
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITruckPlannerRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="truckPlanId"></param>
        /// <returns></returns>
        double GetTotalDistanceByTruckPlan(int truckPlanId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverAge"></param>
        /// <param name="country"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<double> GetTotalDistanceCoveredByDriverAgeInCountry(int driverAge, string country, DateTime startDate, DateTime endDate, string apiKey);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TruckPlan> GetAllTruckPlans();
    
    }
}
