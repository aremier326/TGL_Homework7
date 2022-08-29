using System.Collections.Generic;
using System.Data;
using System.Linq;
using PizzaShop.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Data;
using PizzaShop.Dal.Repos.Interfaces;
using PizzaShop.Dal.Repos.Base;

namespace PizzaShop.Dal.Repos
{
    public class PizzaRepo : BaseRepo<Pizza>, IPizzaRepo
    {
        public PizzaRepo(ApplicationDbContext context) : base(context)
        {
        }

        internal PizzaRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<Pizza> FindAsync(int? id)
        {
            return Table
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override Task<IEnumerable<Pizza>> GetAllAsync()
        {
            return (Task<IEnumerable<Pizza>>)Table.OrderBy(x => x.Id);
        }

        public override async Task<int> UpdateAsync(Pizza entity, bool persist = true)
        {
            var pizza = await Table.FindAsync(entity.Id);

            if (pizza == null) return 0;

            pizza.PizzaType = entity.PizzaType;
            pizza.PizzaSize = entity.PizzaSize;
            pizza.PizzaCrust = entity.PizzaCrust;

            return await Context.SaveChangesAsync();
        }
    }
}
