using SmartStock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Interfaces
{
    public interface ISaleItemRepository
    {
        void Insert(SaleItem item);
    }
}
