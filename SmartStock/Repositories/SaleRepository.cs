using Dapper;
using Microsoft.Data.SqlClient;
using SmartStock.Entities;
using SmartStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Repositories;

public class SaleRepository : ISaleRepository
{

    private readonly SqlConnection _connection;

    public SaleRepository(SqlConnection connection)
    {
        _connection = connection;
    }
    public Sale GetSaleDetails(int saleId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<dynamic> GetSalesByClient(string cpf)
    {
        return _connection.Query(
            "BuscarVendasPorCliente",
            new { CPF = cpf },
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Sale> GetSalesByClient(int clientId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Sale> GetSalesByPeriod(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public int InsertSale(Sale sale)
    {
        var sql = @"INSERT INTO Sale (IdClient, TotalAmount, SaleDate)
                        VALUES (@IdClient, @TotalAmount, @SaleDate);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
        return _connection.QuerySingle<int>(sql, sale);
    }
}
