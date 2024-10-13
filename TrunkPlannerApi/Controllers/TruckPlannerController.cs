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
        public IActionResult GetTotalDistanceByDriverAndCountry()
        {
            return Ok(0);
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
