using System;
using System.Threading.Tasks;

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
        /// <returns></returns>
        Task<double> GetTotalDistanceCoveredByDriverAgeInCountry(int driverAge, string country, DateTime startDate, DateTime endDate);
    }
}
