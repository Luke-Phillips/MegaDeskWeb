using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewData["RushOrderOptionId"] = new SelectList(_context.Set<RushOrderOption>(), "RushOrderOptionId", "Option");
            ViewData["DesktopSurfaceMaterialId"] = new SelectList(_context.Set<DesktopSurfaceMaterial>(), "DesktopSurfaceMaterialId", "Name");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Set the Surface Area
            DeskQuote.Desk.setSurfaceArea();

            // Set the Quote Date
            DeskQuote.QuoteDate = DateTime.Now;

            // Set the QuotePrice
            DeskQuote.QuotePrice = DeskQuote.getQuoteTotal(_context);            

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
    }
}
