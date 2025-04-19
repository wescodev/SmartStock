using Dapper;
using Microsoft.Data.SqlClient;
using SmartStock.Entities;
using SmartStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly SqlConnection _connection;

        public SaleItemRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Insert(SaleItem sale)
        {
            var sql = @"
            INSERT INTO SaleItem (IdSale, IdProduct, UnitPrice)
            VALUES (@IdSale, @IdProduct, @UnitPrice);
                ";
            _connection.Execute(sql, new
            {
                sale.IdSale,
                sale.IdProduct,
                sale.UnitPrice,
            });
        }
    }
}
