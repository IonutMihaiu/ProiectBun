using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Utilaje
{
    public class CreateModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public CreateModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MarcaID"] = new SelectList(_context.Set<Marca>(), "ID",
"MarcaName");
            ViewData["SoferID"] = new SelectList(_context.Set<Sofer>(), "ID",
"SoferName");
            
            return Page();
        }

        [BindProperty]
        public Utilaj Utilaj { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Utilaj.Add(Utilaj);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
