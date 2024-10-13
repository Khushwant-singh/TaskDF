using System;

namespace TruckPlannerLib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TruckPlan
    {
        /// <summary>
        /// 
        /// </summary>
        public int TrunkPlanId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TruckDriver TruckDriver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Truck Truck { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
