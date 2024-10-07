using System;

namespace TruckPlannerLib.Models
{
    public class TruckDriver 
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
    }
}
