using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Utilaje
{
    public class IndexModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public IndexModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        public IList<Utilaj> Utilaj { get; set; } = default!;

        public UtilajData UtilajD { get; set; }
        public int UtilajID { get; set; }
        public int CategoryID { get; set; }
        public string NumeUtilajSort { get; set; }
        public string SoferSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string
searchString)
        {
            UtilajD = new UtilajData();

            NumeUtilajSort = String.IsNullOrEmpty(sortOrder) ? "numeutilaj_desc" : "";
            SoferSort = String.IsNullOrEmpty(sortOrder) ? "sofer_desc" : "";

            CurrentFilter = searchString;

            UtilajD.Utilaje = await _context.Utilaj
            .Include(b => b.Marca)
            .Include(b => b.Sofer)
            .Include(b => b.UtilajCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.NumeUtilaj)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                UtilajD.Utilaje = UtilajD.Utilaje.Where(s => s.Sofer.SoferName.Contains(searchString)

               || s.Sofer.SoferName.Contains(searchString)
               || s.NumeUtilaj.Contains(searchString));
            }
                if (id != null)
                    
            {
                UtilajID = id.Value;
                Utilaj utilaj = UtilajD.Utilaje
                .Where(i => i.ID == id.Value).Single();
                UtilajD.Categories = utilaj.UtilajCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "numeutilaj_desc":
                    UtilajD.Utilaje = UtilajD.Utilaje.OrderByDescending(s =>
                   s.NumeUtilaj);
                    break;
                case "sofer_desc":
                    UtilajD.Utilaje = UtilajD.Utilaje.OrderByDescending(s =>
                   s.Sofer);
                    break;
            }
        }
    }
}
