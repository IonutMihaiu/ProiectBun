using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Utilaje
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public DeleteModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Utilaj == null)
            {
                return NotFound();
            }
            var utilaj = await _context.Utilaj.FindAsync(id);

            if (utilaj != null)
            {
                Utilaj = utilaj;
                _context.Utilaj.Remove(Utilaj);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
