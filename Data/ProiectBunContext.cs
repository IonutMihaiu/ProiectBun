using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectBun.Models;

namespace ProiectBun.Data
{
    public class ProiectBunContext : DbContext
    {
        public ProiectBunContext (DbContextOptions<ProiectBunContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectBun.Models.Utilaj> Utilaj { get; set; } = default!;

        public DbSet<ProiectBun.Models.Marca> Marca { get; set; }

        public DbSet<ProiectBun.Models.Sofer> Sofer { get; set; }
    }
}
