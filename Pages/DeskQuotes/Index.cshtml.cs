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

            //Populate the list of material in the user search
            IQueryable<string> materialQuery = from m in _context.DesktopSurfaceMaterial
                                               select m.Name;

            Materials = new SelectList(await materialQuery.Distinct().ToListAsync());

            //Create a Queryble for the list material TB
            IQueryable<DesktopSurfaceMaterial> materialDB = from m in _context.DesktopSurfaceMaterial
                                                            select m;

            //Create a Queryble for the list of DeskQuotes
            IQueryable<DeskQuote> deskQuoteDB = from m in _context.DeskQuote
                                                            select m;

            //Find the searched material
            if (!string.IsNullOrEmpty(Material))
            {
                //Get the material searched id
                var surfaceMaterial = materialDB.Where(p => p.Name == Material).ToList<DesktopSurfaceMaterial>();
                int searched = surfaceMaterial[0].DesktopSurfaceMaterialId;

                DeskQuotes = deskQuoteDB.Where(p => p.Desk.DesktopSurfaceMaterialId == searched).ToList<DeskQuote>();

            }

            
        }
    }
}
