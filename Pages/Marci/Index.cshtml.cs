using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Data;
using ProiectBun.Models;
using ProiectBun.Models.ViewModels;

namespace ProiectBun.Pages.Marci
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly ProiectBun.Data.ProiectBunContext _context;

        public IndexModel(ProiectBun.Data.ProiectBunContext context)
        {
            _context = context;
        }

        public IList<Marca> Marca { get; set; } = default!;

        public MarcaIndexData MarcaData { get; set; }
        public int MarcaID { get; set; }
        public int UtilajID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            MarcaData = new MarcaIndexData();
            MarcaData.Marci = await _context.Marca
            .Include(i => i.Utilaje)
            .ThenInclude(c => c.Sofer)
            .OrderBy(i => i.MarcaName)
            .ToListAsync();
            if (id != null)
            {
                MarcaID = id.Value;
                Marca marca = MarcaData.Marci
                .Where(i => i.ID == id.Value).Single();
                MarcaData.Utilaje = marca.Utilaje;
            }
        }
    }
}
