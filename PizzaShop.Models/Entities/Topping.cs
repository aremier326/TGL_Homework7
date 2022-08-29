using System.ComponentModel.DataAnnotations.Schema;
using PizzaShop.Models.Entities.Base;
using PizzaShop.Models.Entities.Enums;

namespace PizzaShop.Models.Entities
{
    [Table("Topping", Schema = "dbo")]
    public class Topping : BaseEntity
    {
        public PizzaToppingEnum ToppingType { get; set; }

        public IEnumerable<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
