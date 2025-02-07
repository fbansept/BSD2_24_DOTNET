using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BSD2_24.Models;

namespace BSD2_24.Data
{
    public class BSD2_24Context : DbContext
    {
        public BSD2_24Context (DbContextOptions<BSD2_24Context> options)
            : base(options)
        {
        }

        public DbSet<BSD2_24.Models.Produit> Produit { get; set; } = default!;
    }
}
