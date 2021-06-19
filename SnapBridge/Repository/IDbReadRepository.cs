using SnapBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapBridge.Repository
{
    public interface IDbReadRepository
    {
        object ReadAllItemsFromDB();
        Inventory ReadItemFromDb(int? id);
        IQueryable<byte[]> GetImageFromDb(int id);
    }
}
