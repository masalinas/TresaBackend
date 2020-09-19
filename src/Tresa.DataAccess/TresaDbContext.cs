using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Tresa.Models;

namespace Tresa.DataAccess
{
    public class TresaDbContext : DbContext
    {
        public DbSet<Device> Cards { get; set; }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Test> Tests { get; set; }

        public TresaDbContext()
        {

        }
        public TresaDbContext(DbContextOptions<TresaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //EFCore por defecto pluraliza las tablas. Con esto deshabilitamos esta opción
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            builder.Entity<Device>().HasData(
                new Device
                {
                    Id = 1,
                    Code = "CD01"
                },
                new Device
                {
                    Id = 2,
                    Code = "CD02"
                }
            );
        }
    }
}
