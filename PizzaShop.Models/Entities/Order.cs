using System;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaShop.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Models.Entities
{
    [Table("Orders", Schema = "dbo")]
    public partial class Order : BaseEntity
    {
        public int CustomerId { get; set; }

        public string? AdditionalOrderInfo { get; set; }

        public Pizza? PizzaNavigation { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.Orders))]
        public Customer? CustomerNavigation { get; set; }
    }
}
