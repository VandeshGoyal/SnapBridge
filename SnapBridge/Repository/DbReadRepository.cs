using SnapBridge.Context;
using SnapBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnapBridge.Repository
{
    public class DbReadRepository :IDbReadRepository
    {
        public readonly SqlDbContext db = new SqlDbContext();
        public object ReadAllItemsFromDB()
        {
            return db.Inventories.ToList();
        }

        public Inventory ReadItemFromDb(int? id)
        {
            return db.Inventories.Find(id);
        }

        public IQueryable<byte[]> GetImageFromDb(int id)
        {
            return from temp in db.Inventories where temp.Id == id select temp.Image;
        }
    }
}