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
    public class DetailsModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public DetailsModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

      public Utilaj Utilaj { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Utilaj == null)
            {
                return NotFound();
            }

            var utilaj = await _context.Utilaj.FirstOrDefaultAsync(m => m.ID == id);
            if (utilaj == null)
            {
                return NotFound();
            }
            else 
            {
                Utilaj = utilaj;
            }
            return Page();
        }
    }
}
