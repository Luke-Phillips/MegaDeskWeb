using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public CreateModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //IList<DeskQuote> queryResult = _context.DeskQuote.Include()
            ViewData["RushOrderOptionId"] = new SelectList(_context.Set<RushOrderOption>(), "RushOrderOptionId", "Option");
            ViewData["DesktopSurfaceMaterialId"] = new SelectList(_context.Set<DesktopSurfaceMaterial>(), "DesktopSurfaceMaterialId", "Name");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Set the Surface Area
            DeskQuote.Desk.setSurfaceArea();

            //Set the Quote Date
            DeskQuote.QuoteDate = DateTime.Now;

            //Get Rush Order Price
            DeskQuote.RushOrderPrice = getRushOrderPrice();

            //Set the QuotePrice
            DeskQuote.QuotePrice = getQuoteTotal();

            Console.WriteLine("on post");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("model state is not valid");
                return Page();
            }

            Console.WriteLine("model state is valid");
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /// Determine the rush order Price
        private decimal getRushOrderPrice()
        {
            //Access the RushOrderData to get the data
            IQueryable<RushOrderOption> rushOrderQuery = from m in _context.RushOrderOption
                                                         where m.RushOrderOptionId == DeskQuote.RushOrderOptionId
                                                         select m;
            //Save the result to a list
            RushOrderOption rushOrderResult = rushOrderQuery.ToList<RushOrderOption>()[0];

            //By default to the smallest value
            decimal rushPrice = rushOrderResult.CostSmall;

            //Get the aread to determine the cost based size
            if (DeskQuote.Desk.SurfaceArea > 1000 && DeskQuote.Desk.SurfaceArea <= 2000)
            {
                rushPrice = rushOrderResult.CostMedium;
            }
            else if(DeskQuote.Desk.SurfaceArea > 2000)
            {
                rushPrice = rushOrderResult.CostSmall;
            }

            return rushPrice;
        }

        //Determine the quote price of the quoteCreated
        private decimal getQuoteTotal()
        {
            decimal basePrice = DeskQuote.

        }



    }
}
