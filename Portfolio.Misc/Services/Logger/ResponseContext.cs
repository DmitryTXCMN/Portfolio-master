using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Misc.Services.Logger
{
    public class ResponseContext : DbContext
    {
        public DbSet<Response> Responses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5444;Database=postgres;Username=postgres;Password=1");
    }
}
