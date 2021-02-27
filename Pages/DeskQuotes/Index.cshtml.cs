using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuotes { get; set; }
        
        public SelectList Materials { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Material { get; set; }
        
        public async Task OnGetAsync()
        {
            DeskQuotes = await _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.RushOrderOption).ToListAsync();
            
            if (!string.IsNullOrEmpty(Material))
            {
                Console.WriteLine("DeskQuotes is: " + DeskQuotes.ToString());
                DeskQuotes = DeskQuotes.Where(d => d.Desk.DesktopSurfaceMaterial.Name == Material).ToList();
            }

            IQueryable<string> materialQuery = from m in _context.DesktopSurfaceMaterial
                                               select m.Name;
            
            ViewData["DesktopSurfaceMaterialId"] = new SelectList(_context.Set<DesktopSurfaceMaterial>(), "DesktopSurfaceMaterialId", "Name");
            //Materials = new SelectList(await materialQuery.Distinct().ToListAsync());
        }
    }
}
