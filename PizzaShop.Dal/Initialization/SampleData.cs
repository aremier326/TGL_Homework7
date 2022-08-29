using System.Collections.Generic;
using PizzaShop.Models.Entities;
using Bogus;
using PizzaShop.Models.Entities.Enums;

namespace PizzaShop.Dal.Initialization
{
    public static class SampleData
    {
        public static List<Topping> Toppings => new()
        {
            new() {ToppingType = PizzaToppingEnum.Pinapples},
            new() {ToppingType = PizzaToppingEnum.Pickles},
            new() {ToppingType = PizzaToppingEnum.Vegetables},
            new() {ToppingType = PizzaToppingEnum.DoubleCheese},
            new() {ToppingType = PizzaToppingEnum.Cheese},
            new() {ToppingType = PizzaToppingEnum.Meat},
            new() {ToppingType = PizzaToppingEnum.Onions},
            new() {ToppingType = PizzaToppingEnum.CornSeeds}
        };

        public static List<Pizza> Pizzas(List<Topping> toppings)
        {
            var f = new Faker();
            var pizzas = new List<Pizza>()
            {
                new(){Id = 1, OrderId = 1, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 2, OrderId = 2, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 3, OrderId = 3, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 4, OrderId = 4, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 5, OrderId = 5, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 6, OrderId = 6, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 7, OrderId = 7, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 8, OrderId = 8, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 9, OrderId = 9, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
                new(){Id = 10, OrderId = 10, PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()},
            };
            return pizzas;
        }


        public static List<Customer> Customers()
        {
            var customers = new Faker<Customer>()
                .RuleFor(x => x.CustomerName, y => y.Name.FullName())
                .RuleFor(x => x.Address, y => y.Address.FullAddress())
                .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
                .RuleFor(x => x.Email, y => y.Internet.Email());

            return customers.Generate(5);
        }

        public static List<Order> Orders(List<Customer> customers, List<Pizza> pizzas)
        {
            var orders = new List<Order>()
            {
                new(){ Id = 1, CustomerId = 1, CustomerNavigation = customers[1], PizzaNavigation = pizzas[1]},
                new(){ Id = 2, CustomerId = 1, CustomerNavigation = customers[1], PizzaNavigation = pizzas[2]},
                new(){ Id = 3, CustomerId = 2, CustomerNavigation = customers[2], PizzaNavigation = pizzas[3]},
                new(){ Id = 4, CustomerId = 2, CustomerNavigation = customers[2], PizzaNavigation = pizzas[4]},
                new(){ Id = 5, CustomerId = 3, CustomerNavigation = customers[3], PizzaNavigation = pizzas[5]},
                new(){ Id = 6, CustomerId = 3, CustomerNavigation = customers[3], PizzaNavigation = pizzas[6]},
                new(){ Id = 7, CustomerId = 4, CustomerNavigation = customers[4], PizzaNavigation = pizzas[7]},
                new(){ Id = 8, CustomerId = 4, CustomerNavigation = customers[4], PizzaNavigation = pizzas[8]},
                new(){ Id = 9, CustomerId = 5, CustomerNavigation = customers[5], PizzaNavigation = pizzas[9]},
                new(){ Id = 10, CustomerId = 5, CustomerNavigation = customers[5], PizzaNavigation = pizzas[10]},
            };

            return orders;
        }
    }
}
