using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;
using PizzaShop.Dal.Repos.Base;
using PizzaShop.Dal.Repos.Interfaces;
using PizzaShop.Models.Entities;

namespace PizzaShop.Dal.Repos
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        public OrderRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal OrderRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<Order> FindAsync(int? id)
        {
            return Table
                .Where(x => x.Id == id)
                .Include(x => x.CustomerNavigation)
                .Include(x => x.PizzaNavigation)
                .FirstOrDefaultAsync();
        }

        public override Task<IEnumerable<Order>> GetAllAsync()
        {
            return (Task<IEnumerable<Order>>)Table
                .Include(x => x.CustomerNavigation)
                .OrderBy(x => x.Id);
        }

        public override async Task<int> UpdateAsync(Order entity, bool persist = true)
        {
            var order = await Table.FindAsync(entity.Id);

            if (order == null) return 0;

            order.AdditionalOrderInfo = entity.AdditionalOrderInfo;
            order.CustomerNavigation.CustomerName = entity.CustomerNavigation.CustomerName;
            order.CustomerNavigation.Address = entity.CustomerNavigation.Address;
            order.CustomerNavigation.Phone = entity.CustomerNavigation.Phone;
            order.CustomerNavigation.Email = entity.CustomerNavigation.Email;
            order.PizzaNavigation.PizzaSize = entity.PizzaNavigation.PizzaSize;
            order.PizzaNavigation.PizzaCrust = entity.PizzaNavigation.PizzaCrust;
            order.PizzaNavigation.PizzaType = entity.PizzaNavigation.PizzaType;

            return await Context.SaveChangesAsync();
        }
    }
}
