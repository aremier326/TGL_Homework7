using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaShop.MVC.Models.Base;

namespace PizzaShop.MVC.Models.Domain
{
    public class Order : BaseItem
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

        public string? AdditionalOrderInfo { get; set; }
    }
}
