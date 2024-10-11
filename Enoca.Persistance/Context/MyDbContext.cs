using Enoca.ApplicationLayer.Exceptions;
using Enoca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistance.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Carriers> Carriers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CarrierReports> CarrierReports { get; set; }
        public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carriers>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CarrierName)
                    .IsRequired();

                entity.Property(e => e.CarrierPlusDesiCost)
                    .IsRequired(); 

                entity.Property(e => e.CarrierIsActive)
                    .IsRequired();


            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Id); 

                entity.Property(e => e.OrderDesi)
                    .IsRequired();

                entity.Property(e => e.OrderDate)
                    .IsRequired();

                entity.Property(e => e.OrderCarrierCost)
                    .IsRequired();


            });


            modelBuilder.Entity<CarrierConfigurations>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CarrierMaxDesi)
                    .IsRequired();

                entity.Property(e => e.CarrierMinDesi)
                    .IsRequired();

                entity.Property(e => e.CarrierCost)
                    .IsRequired();

                entity.Property(e => e.CarrierId)
                    .IsRequired();


            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var datas = ChangeTracker
               .Entries<BaseEntity>();

                foreach (var data in datas)
                {
                    switch (data.State)
                    {
                        case EntityState.Added:
                            data.Entity.CreatedDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            data.Entity.UpdatedDate = DateTime.UtcNow;
                            break;
                    };
                }

                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw;            
            }

        }
    }

}
