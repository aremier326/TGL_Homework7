using System.Collections.Generic;
using System.Linq;
using PizzaShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;
using PizzaShop.Dal.Repos.Interfaces;
using PizzaShop.Dal.Repos.Base;

namespace PizzaShop.Dal.Repos
{
    public class CustomerRepo : BaseRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal CustomerRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<Customer> FindAsync(int? id)
        {
            return Table
                .Where(x => x.Id == id)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync();
        }

        public override Task<IEnumerable<Customer>> GetAllAsync()
        {
            return (Task<IEnumerable<Customer>>)Table
                .Include(x => x.Orders);
        }

        public override async Task<int> UpdateAsync(Customer entity, bool persist = true)
        {
            var customer = await Table.FindAsync(entity.Id);

            if (customer == null) return 0;

            customer.CustomerName = entity.CustomerName;
            customer.Address = entity.Address;
            customer.Phone = entity.Phone;
            customer.Email = entity.Phone;

            return await Context.SaveChangesAsync();
        }
    }
}
