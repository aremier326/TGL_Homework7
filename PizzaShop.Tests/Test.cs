using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;
using PizzaShop.Dal.Repos;
using PizzaShop.Models.Entities.Enums;
using Xunit;

namespace PizzaShop.Tests
{
    public class Test
    {
        public readonly ApplicationDbContext Context;

        public ToppingRepo toppingRepo;

        public Test()
        {
            Context = GetContext();
            toppingRepo = new ToppingRepo(Context);
        }

        public ApplicationDbContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = "Data Source=localhost;Integrated Security=true;TrustServerCertificate=True;Initial Catalog=PizzaShopDB;";
            optionsBuilder.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        [Fact]
        public void ToppingsNotEmpty()
        {
            var toppings = Context.Toppings.ToList();
            Assert.NotEmpty(toppings);
        }

        [Fact]
        public void GetToppingsCount()
        {
            var toppings = Context.Toppings.ToList();
            Assert.Equal(8, toppings.Count);
        }

        [Fact]
        public void IsOnlyOneToppingType()
        {
            var topping = Context.Toppings
                .Where(t => t.ToppingType == PizzaToppingEnum.Cheese);
            Assert.Single(topping);
        }

        [Fact]
        public void ToppingRepoIsNotEmpty()
        {
            var toppings = toppingRepo.GetAll().ToList();
            Assert.NotEmpty(toppings);
        }

        [Fact]
        public void GetToppingsCountFromRepo()
        {
            var toppings = toppingRepo.GetAll().ToList();
            Assert.Equal(8, toppings.Count);
        }

        [Fact]
        public void CustomersIsNotEmpty()
        {
            var customers = Context.Customers.ToList();
            Assert.NotEmpty(customers);
        }
    }
}
