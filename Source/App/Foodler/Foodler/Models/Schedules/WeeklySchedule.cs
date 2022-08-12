using Foodler.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foodler.Models.Schedules
{
    public class WeeklySchedule
    {
        public int Id { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        public DateTime LocalStartDate { get; set; }
        public DateTime LocalEndDate { get; set; }
    }
}
