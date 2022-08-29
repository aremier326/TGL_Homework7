using System;
using System.Collections.Generic;
using System.Linq;
using PizzaShop.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;

namespace PizzaShop.Dal.Initialization
{
    public static class SampleDataInitializer
    {
        public static void DropAndCreateDatabase(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        public static void InitialiseData(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.Orders.Any())
                SeedData(context);
        }

        public static void DropAndInitializeData(ApplicationDbContext context)
        {
            DropAndCreateDatabase(context);
            SeedData(context);
        }

        internal static void SeedData(ApplicationDbContext context)
        {
            context.Toppings.AddRange(SampleData.Toppings);
            context.SaveChanges();
            context.Pizzas.AddRange(SampleData.Pizzas(context.Toppings.ToList()));
            context.SaveChanges();
            context.Customers.AddRange(SampleData.Customers());
            context.SaveChanges();
            context.Orders.AddRange(SampleData.Orders(context.Customers.ToList(), context.Pizzas.ToList()));
            context.SaveChanges();
        }

        
    }
}