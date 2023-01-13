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
using ProiectBun.Models;

namespace ProiectBun.Pages.Utilaje
{
    public class EditModel : UtilajCategoriesPageModel
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
            Utilaj = await _context.Utilaj
            .Include(b => b.Sofer)
            .Include(b => b.UtilajCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            var utilaj = await _context.Utilaj.FirstOrDefaultAsync(m => m.ID == id);
            if (utilaj == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Utilaj);

            Utilaj = utilaj;
            ViewData["MarcaID"] = new SelectList(_context.Set<Marca>(), "ID",
"MarcaName");
            ViewData["SoferID"] = new SelectList(_context.Set<Sofer>(), "ID",
"SoferName");


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilajToUpdate = await _context.Utilaj
            .Include(i => i.Sofer)
            .Include(i => i.UtilajCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (utilajToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Utilaj>(
            utilajToUpdate,
            "Utilaj",
            i => i.NumeUtilaj, i => i.SoferID,
            i => i.Pret, i => i.StartDate, i => i.FinishDate, i => i.Marca))
            {
                UpdateUtilajCategories(_context, selectedCategories, utilajToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateUtilajCategories(_context, selectedCategories, utilajToUpdate);
            PopulateAssignedCategoryData(_context, utilajToUpdate);
            return Page();
        }
    }
}


            
