using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MegaDeskWeb.Models
{
    /// <summary>
    /// DeskQuote class will hold the data and information
    /// for quote as well the values of it and the Desk type
    /// </summary>
    public class DeskQuote
    {
        // Requirement-based prices
        public const decimal BASE_PRICE = 200;
        public const decimal DRAWER_PRICE = 50;
        public const decimal MAX_FREE_SURFACE_AREA = 1000;

        // Database Key Properties
        public int DeskQuoteId { get; set; }
        public int DeskId { get; set; }
        public int RushOrderOptionId { get; set; }

        // Standard Properties
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }
        
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Price")]
        [DataType(DataType.Currency)]
        public decimal QuotePrice { get; set; }

        // Navigation Properties
        public Desk Desk { get; set; }

        [Display(Name = "Rush Order Option")]
        public RushOrderOption RushOrderOption { get; set; }

        // Determine the surface price
        private decimal getSurfacePrice(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            // Access the RushOrderData to get the data
            IQueryable<DesktopSurfaceMaterial> material = from m in context.DesktopSurfaceMaterial
                                                          where m.DesktopSurfaceMaterialId == Desk.DesktopSurfaceMaterialId
                                                          select m;
            // Save result
            decimal materialCost = material.ToList<DesktopSurfaceMaterial>()[0].Cost;

            // On the top of that + surface are for 1 dollar for every over 1000
            decimal extraCost = Desk.SurfaceArea > DeskQuote.MAX_FREE_SURFACE_AREA ?
                Desk.SurfaceArea - DeskQuote.MAX_FREE_SURFACE_AREA : 0;

            return materialCost + extraCost;
        }

        // Determine the rush order Price
        private decimal getRushOrderPrice(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            // Access the RushOrderData to get the data
            IQueryable<RushOrderOption> rushOrderQuery = from m in context.RushOrderOption
                                                         where m.RushOrderOptionId == RushOrderOptionId
                                                         select m;
            // Save the result to a list
            RushOrderOption rushOrderResult = rushOrderQuery.ToList<RushOrderOption>()[0];

            // By default to the smallest value
            decimal rushPrice = rushOrderResult.CostSmall;

            // Get the aread to determine the cost based size
            if (Desk.SurfaceArea > 1000 && Desk.SurfaceArea <= 2000)
            {
                rushPrice = rushOrderResult.CostMedium;
            }
            else if (Desk.SurfaceArea > 2000)
            {
                rushPrice = rushOrderResult.CostSmall;
            }

            return rushPrice;
        }

        // Determine the quote price of the quoteCreated
        public decimal getQuoteTotal(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            // Set some base prices to use in the quote
            decimal basePrice = BASE_PRICE;
            decimal drawerPrice = Desk.NumberOfDrawers * DRAWER_PRICE;
            decimal surfacePrice = getSurfacePrice(context);
            decimal rushOrderPrice = getRushOrderPrice(context);

            return basePrice + drawerPrice + surfacePrice + rushOrderPrice;
        }
    }
}