using System;

namespace TruckPlannerLib.Models
{
    public class TruckPlan
    {
        public int TrunkPlanId { get; set; }
        public TruckDriver TruckDriver { get; set; }
        public  Truck Truck { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
