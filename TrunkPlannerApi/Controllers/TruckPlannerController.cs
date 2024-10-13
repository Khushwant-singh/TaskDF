using Microsoft.AspNetCore.Mvc;

namespace TrunkPlannerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TruckPlannerController : ControllerBase
    {


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
            return Ok(0);
        }

    }
}
