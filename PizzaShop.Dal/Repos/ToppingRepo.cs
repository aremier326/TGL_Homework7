using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;
using PizzaShop.Dal.Repos.Base;
using PizzaShop.Dal.Repos.Interfaces;
using PizzaShop.Models.Entities;

namespace PizzaShop.Dal.Repos
{
    public class ToppingRepo : BaseRepo<Topping>, IToppingRepo
    {
        public ToppingRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal ToppingRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override async Task<Topping> FindAsync(int? id)
        {
            return await Table.FindAsync(id);
        }

        public override Task<IEnumerable<Topping>> GetAllAsync()
        {
            return (Task<IEnumerable<Topping>>)Table.OrderBy(x => x.Id);
        }

        public override Task<int> UpdateAsync(Topping entity, bool persist = true)
        {
            throw new NotImplementedException();
        }
    }
}
