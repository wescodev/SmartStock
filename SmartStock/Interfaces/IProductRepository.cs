using SmartStock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
       void UpdateAmount(int id, decimal price);
       void UpdateQtdStock(int id, int stockQuantity);

        IEnumerable<Product> GetByCategoryId(int idCategory);
    }
}
