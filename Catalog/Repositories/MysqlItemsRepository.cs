using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Repositories
{
    public class MysqlItemsRepository : DbContext, IItemsRepository
    {

        public MysqlItemsRepository(DbContextOptions<MysqlItemsRepository> options) : base(options)
        {

        }

        public DbSet<Item> Catalog { get; set; }

        public async Task CreateItemAsync(Item item)
        {
            await Catalog.AddAsync(item);
            await SaveChangesAsync();
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var foundObj = await Catalog.Where(itm => itm.Id == id).SingleOrDefaultAsync();
            if (foundObj != null)
            {
                Catalog.Remove(foundObj);
                await SaveChangesAsync();
            }
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var foundObj = await Catalog.AsNoTracking().Where(itm => itm.Id == id).SingleOrDefaultAsync();
            return foundObj;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Catalog.ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            Catalog.Update(item);
            await SaveChangesAsync();
        }
    }
}