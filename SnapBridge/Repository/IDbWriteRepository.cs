using SnapBridge.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapBridge.Repository
{
    public interface IDbWriteRepository
    {
        int InsertInDataBase(InventoryDto inventoryDto);
        void DeleteItemFromDb(int? id);
    }
}
