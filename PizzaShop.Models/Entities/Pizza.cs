using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PizzaShop.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Models.Entities.Enums;

namespace PizzaShop.Models.Entities
{
    [Table("Pizza", Schema = "dbo")]
    public class Pizza : BaseEntity
    {
        
        [Required(ErrorMessage = "You must choose one pizza type for the order!")]
        public PizzaEnum PizzaType { get; set; }

        [Required(ErrorMessage = "You must choose size!")]
        public PizzaSizeEnum PizzaSize { get; set; }

        public PizzaCrustEnum PizzaCrust { get; set; }

        public int OrderId;
        public Order OrderNavigation { get; set; }

        public IEnumerable<Topping> Toppings { get; set; } = new List<Topping>();
    }
}
