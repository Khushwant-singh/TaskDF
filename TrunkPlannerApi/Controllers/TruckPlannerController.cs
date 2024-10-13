using Microsoft.AspNetCore.Mvc;
using TruckPlannerLib;

namespace TrunkPlannerApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TruckPlannerController : ControllerBase
    {

        private ITruckPlannerRepository _truckPlannerRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="truckPlannerRepository"></param>
        public TruckPlannerController(ITruckPlannerRepository truckPlannerRepository)
        {
            _truckPlannerRepository = truckPlannerRepository;
        }

        /// <summary>
        /// Get total distance covered by various input parameters
        /// </summary>
        /// <remarks>Get inputs - driverAge, country, start of date range, end of date range</remarks>
        /// <response code="200">Total distance will be fetched a number will be returned</response>
        [HttpGet("GetTotalDistanceByDriverAndCountry")]
        public async Task<IActionResult> GetTotalDistanceByDriverAndCountry(int driverAge, string country, DateTime startDate, DateTime endDate)
        {
           
            var apikey=  Environment.GetEnvironmentVariable(Properties.Resources.CountryLookUpVariableName);
            double totalDistance;
            try
            {
                totalDistance =await _truckPlannerRepository.GetTotalDistanceCoveredByDriverAgeInCountry(driverAge, country, startDate, endDate, apikey);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok($"Total distance for country {country} driven by drivers over the age of {driverAge} is {totalDistance}");
        }

        /// <summary>
        /// Get total distance covered by Truck plan
        /// </summary>
        /// <remarks>Get inputs - driverAge, country, start of date range, end of date range</remarks>
        /// <response code="200">Total distance will be fetched a number will be returned</response>
        [HttpGet("GetTotalDistanceByTruckPlan")]
        public IActionResult GetTotalDistanceByTruckPlan(int truckPlanId)
        {
            return Ok(_truckPlannerRepository.GetTotalDistanceByTruckPlan(truckPlanId));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTruckPlans")]
        public IActionResult GetAllTruckPlans()
        {
            return Ok(_truckPlannerRepository.GetAllTruckPlans());
        }

    }
}
