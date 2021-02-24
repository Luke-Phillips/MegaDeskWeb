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