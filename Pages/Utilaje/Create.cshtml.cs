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
    public class CreateModel : UtilajCategoriesPageModel

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

            var utilaj = new Utilaj();
            utilaj.UtilajCategories = new List<UtilajCategory>();
            PopulateAssignedCategoryData(_context, utilaj);
            return Page();

        }

        [BindProperty]
        public Utilaj Utilaj { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newUtilaj = new Utilaj();
            if (selectedCategories != null)
            {
                newUtilaj.UtilajCategories = new List<UtilajCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new UtilajCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newUtilaj.UtilajCategories.Add(catToAdd);
                }
            }
            Utilaj.UtilajCategories = newUtilaj.UtilajCategories;
            _context.Utilaj.Add(Utilaj);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        

           
        }
    }
