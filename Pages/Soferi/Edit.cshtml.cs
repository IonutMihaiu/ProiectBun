using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Soferi
{
    public class EditModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public EditModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sofer Sofer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sofer == null)
            {
                return NotFound();
            }

            var sofer =  await _context.Sofer.FirstOrDefaultAsync(m => m.ID == id);
            if (sofer == null)
            {
                return NotFound();
            }
            Sofer = sofer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sofer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoferExists(Sofer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SoferExists(int id)
        {
          return _context.Sofer.Any(e => e.ID == id);
        }
    }
}
