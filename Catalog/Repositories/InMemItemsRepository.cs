using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            // new Item { Id = Guid.NewGuid(), Name = "Small Health Potion", Price = 1, CreatedDate = DateTimeOffset.UtcNow },
            // new Item { Id = Guid.NewGuid(), Name = "Full Moon Sword", Price = 30, CreatedDate = DateTimeOffset.UtcNow },
            // new Item { Id = Guid.NewGuid(), Name = "Monk Plate Armour", Price = 3, CreatedDate = DateTimeOffset.UtcNow }
        };
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var myItem = items.Where(x => x.Id == id).SingleOrDefault();
            return await Task.FromResult(myItem);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var indexElement = items.FindIndex(ind => ind.Id == item.Id);
            items[indexElement] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var existingItem = await GetItemAsync(id);
            items.Remove(existingItem);
            await Task.CompletedTask;
        }
    }
}