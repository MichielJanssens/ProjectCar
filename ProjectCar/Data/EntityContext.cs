using Microsoft.EntityFrameworkCore;
using ProjectCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Data
{
    public interface IEntityContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<CarType> CarTypes { get; set; }
        DbSet<Owner> Owners { get; set; }
    }
    public class EntityContext : DbContext, IEntityContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
