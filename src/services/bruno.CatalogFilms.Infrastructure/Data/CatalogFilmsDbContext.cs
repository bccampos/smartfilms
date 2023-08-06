using bruno.CatalogFilms.Core.Data;
using bruno.CatalogFilms.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bruno.CatalogFilms.Infrastructure.Data
{
    public class CatalogFilmsDbContext : DbContext, IUnitOfWork
    {
        public CatalogFilmsDbContext(DbContextOptions<CatalogFilmsDbContext> options)
           : base(options) { }

        public DbSet<Domain.CatalogFilms> CatalogFilms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogFilmsDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
