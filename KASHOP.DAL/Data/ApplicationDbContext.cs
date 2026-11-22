using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace KASHOP.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpcontextAccessor)
    : base(options)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryTranslation>().ToTable("CategoriesTranslations");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price).HasPrecision(9, 2);
                entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<ProductTranslation>(entity =>
            {
                entity.Property(t => t.Name).HasMaxLength(200);
                entity.Property(t => t.Language).HasMaxLength(200);
            });

        }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = _httpcontextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.CreatedById = userId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                    entry.Entity.UpdatedAtId = userId;

                    entry.Property(e=>e.CreatedById).IsModified = false;
                    entry.Property(e => e.CreatedAt).IsModified = false;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}