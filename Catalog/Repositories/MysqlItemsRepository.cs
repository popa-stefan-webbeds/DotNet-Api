using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateItem(Item item)
        {
            Catalog.Add(item);
            SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            var foundObj = Catalog.Where(itm => itm.Id == id).SingleOrDefault();
            if (foundObj != null)
            {
                Catalog.Remove(foundObj);
                SaveChanges();
            }
        }

        public Item GetItem(Guid id)
        {
            var foundObj = Catalog.AsNoTracking().Where(itm => itm.Id == id).SingleOrDefault();
            return foundObj;
        }

        public IEnumerable<Item> GetItems()
        {
            return Catalog.ToList();
        }

        public void UpdateItem(Item item)
        {
            Catalog.Update(item);
            SaveChanges();
        }
    }
}