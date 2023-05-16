using Microsoft.EntityFrameworkCore;
using PS6.Areas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Areas.YearDb
{
    public class YearDbContext : DbContext
    {
        public YearDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<YearValidationResult>().HasKey(x => x.Id);
        }

        public DbSet<PS6.Areas.Data.Models.YearValidationResult>? YearValidationResult { get; set; }
    }
}
