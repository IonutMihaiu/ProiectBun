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

namespace ProiectBun.Pages.Borrowings
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
            var utilajList = _context.Utilaj
            .Include(b => b.Sofer)
            .Select(x => new
            {
            x.ID,
                UtilajFullName = x.NumeUtilaj + " - " + x.Sofer.SoferName
 });
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "SoferName");
        ViewData["UtilajID"] = new SelectList(_context.Utilaj, "utilajList", "ID", "UtilajFullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
