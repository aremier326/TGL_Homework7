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


        public static List<Customer> Customers()
        {
            var customers = new Faker<Customer>()
                .RuleFor(x => x.CustomerName, y => y.Name.FullName())
                .RuleFor(x => x.Address, y => y.Address.FullAddress())
                .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
                .RuleFor(x => x.Email, y => y.Internet.Email());

            return customers.Generate(5);
        }

        public static List<Order> Orders(List<Customer> customers, List<Topping> toppings)
        {
            var f = new Faker();

            var orders = new List<Order>()
            {
                
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                new(){ CustomerNavigation = f.PickRandom(customers), PizzaNavigation = new()
                { PizzaType = f.PickRandom<PizzaEnum>(), PizzaCrust = f.PickRandom<PizzaCrustEnum>(),
                    PizzaSize = f.PickRandom<PizzaSizeEnum>(), Toppings = f.PickRandom(toppings, 2).ToList()}},
                
            };

            return orders;
        }
    }
}
