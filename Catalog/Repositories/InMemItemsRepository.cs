using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(x => x.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var indexElement = items.FindIndex(ind => ind.Id == item.Id);
            items[indexElement] = item;
        }

        public void DeleteItem(Guid id)
        {
            var existingItem = GetItem(id);
            items.Remove(existingItem);
        }
    }
}