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

        public IList<Utilaj> Utilaj { get;set; } = default!;

        public UtilajData UtilajD { get; set; }
        public int UtilajID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            UtilajD = new UtilajData();

            UtilajD.Utilaje = await _context.Utilaj
            .Include(b => b.Marca)
            .Include(b => b.Sofer)
            .Include(b => b.UtilajCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.NumeUtilaj)
            .ToListAsync();
            if (id != null)
            {
                UtilajID = id.Value;
                Utilaj utilaj = UtilajD.Utilaje
                .Where(i => i.ID == id.Value).Single();
                UtilajD.Categories = utilaj.UtilajCategories.Select(s => s.Category);
            }
        }
    }
}
