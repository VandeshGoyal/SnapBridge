using SnapBridge.Context;
using SnapBridge.Dtos;
using SnapBridge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SnapBridge.Repository
{
    public class DbWriteRepository : IDbWriteRepository
    {
        public readonly SqlDbContext db = new SqlDbContext();
        public int InsertInDataBase(InventoryDto inventoryDto)
        {
            var image = ConvertToBytes(inventoryDto.Image);
            var inventoryContent = new Inventory
            {
                Name = inventoryDto.Name,
                Discription = inventoryDto.Discription,
                Price = inventoryDto.Price,
                Image = image
            };
            db.Inventories.Add(inventoryContent);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public void DeleteItemFromDb(int? id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
        }
    }
}