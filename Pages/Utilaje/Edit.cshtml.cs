using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Utilaje
{
    public class EditModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public EditModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Utilaj Utilaj { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Utilaj == null)
            {
                return NotFound();
            }

            var utilaj =  await _context.Utilaj.FirstOrDefaultAsync(m => m.ID == id);
            if (utilaj == null)
            {
                return NotFound();
            }
            Utilaj = utilaj;
            ViewData["MarcaID"] = new SelectList(_context.Set<Marca>(), "ID",
"MarcaName");
            ViewData["SoferID"] = new SelectList(_context.Set<Sofer>(), "ID",
"SoferName");
           

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

            _context.Attach(Utilaj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilajExists(Utilaj.ID))
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

        private bool UtilajExists(int id)
        {
          return _context.Utilaj.Any(e => e.ID == id);
        }
    }
}
