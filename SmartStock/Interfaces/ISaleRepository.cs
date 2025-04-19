using SmartStock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<dynamic> GetSalesByClient(string cpf);
        IEnumerable<dynamic> GetSalesByPeriod(DateTime startDate, DateTime endDate);
        int InsertSale(Sale sale);
    }

}
