using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Models
{
    /// <summary>
    /// Represents shipping options
    /// </summary>
    public class RushOrderOption
    {
        public int RushOrderOptionId { get; set; }
        public string Option { get; set; }
        public decimal CostSmall { get; set; } // Cost for desk less than 1000 square inches
        public decimal CostMedium { get; set; } // Cost for desk between 1000 and 2000 square inches
        public decimal CostLarge { get; set; } // Cost for desk greater than 2000 square inches
    }
}
/*    public enum Shipping
    {
        [Description("14 days (no rush)")]
        NoRush,

        [Description("7 days")]
        Rush7Days,

        [Description("5 days")]
        Rush5Days,

        [Description("3 days")]
        Rush3Days
    }*/