using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Botas.Models;

namespace BotasApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Botas.Models.Bota> Bota { get; set; } = default!;
        public DbSet<Botas.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Botas.Models.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<Botas.Models.Venda> Venda { get; set; } = default!;
    }
}
