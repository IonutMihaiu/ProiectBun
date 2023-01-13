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

        public async Task OnGetAsync()
        {
            {
                Utilaj = await _context.Utilaj
                .Include(b => b.Marca)
                .Include(b => b.Sofer)
                .ToListAsync();
            }
        }
    }
}
