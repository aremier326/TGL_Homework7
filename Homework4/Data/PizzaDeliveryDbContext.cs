using Microsoft.EntityFrameworkCore;
using PizzaShop.MVC.Models.Domain;

namespace PizzaShop.MVC.Data
{
    public class PizzaDeliveryDbContext : DbContext
    {
        public PizzaDeliveryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
