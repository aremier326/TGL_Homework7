using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PizzaShop.Models.Entities.Base;

namespace PizzaShop.Models.Entities
{
    [Table("Customers", Schema = "dbo")]
    public partial class Customer : BaseEntity
    {
        [Required(ErrorMessage = "Wrong customer name!")]
        [DisplayName("Customer Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Wrong address!")]
        [DisplayName("Address")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Wrong phone number!")]
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [InverseProperty(nameof(Order.CustomerNavigation))]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
