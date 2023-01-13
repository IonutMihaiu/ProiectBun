using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectBun.Data;
using ProiectBun.Models;

namespace ProiectBun.Pages.Soferi
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
            return Page();
        }

        [BindProperty]
        public Sofer Sofer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sofer.Add(Sofer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
