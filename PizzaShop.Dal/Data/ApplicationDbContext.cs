using System;
using System.Collections;
using System.Collections.Generic;
using PizzaShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PizzaShop.Dal.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Topping>? Toppings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(p => p.PizzaNavigation)
                .WithOne(o => o.OrderNavigation)
                .HasForeignKey<Pizza>(o => o.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasMany(t => t.Toppings)
                .WithMany(p => p.Pizzas)
                .UsingEntity<Dictionary<string, object>>(
                "PizzaTopping",
                j => j
                    .HasOne<Topping>()
                    .WithMany()
                    .HasForeignKey("ToppingId")
                    .HasConstraintName("FK_PizzaTopping_Topping_ToppingId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Pizza>()
                    .WithMany()
                    .HasForeignKey("PizzaId")
                    .HasConstraintName("FK_PizzaTopping_Pizza_PizzaId")
                    .OnDelete(DeleteBehavior.Cascade)
                );

        }
    }
}
