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
            DeskQuote.Desk.SurfaceArea = 300; // fix me
            DeskQuote.QuoteDate = DateTime.Now;
            DeskQuote.RushOrderPrice = 0;
            DeskQuote.QuotePrice = 0;

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
