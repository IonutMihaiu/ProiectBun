using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Soferi
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public DeleteModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Sofer Sofer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sofer == null)
            {
                return NotFound();
            }

            var sofer = await _context.Sofer.FirstOrDefaultAsync(m => m.ID == id);

            if (sofer == null)
            {
                return NotFound();
            }
            else 
            {
                Sofer = sofer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sofer == null)
            {
                return NotFound();
            }
            var sofer = await _context.Sofer.FindAsync(id);

            if (sofer != null)
            {
                Sofer = sofer;
                _context.Sofer.Remove(Sofer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
