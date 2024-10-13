using System;

namespace TruckPlannerLib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TruckDriver
    {
        /// <summary>
        /// 
        /// </summary>
        public int DriverId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
    }
}
