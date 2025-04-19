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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Category> GetAll()
        {
            var sql = "SELECT * FROM Category";
            return _connection.Query<Category>(sql);
        }
        public Category GetById(int id)
        {
            var sql = "SELECT * FROM Category WHERE IdCategory = @IdCategory";
            return _connection.QueryFirstOrDefault<Category>(sql, new { IdCategory = id });
        }

        public Category GetByName(string name)
        {
            var sql = "SELECT * FROM Category WHERE Name LIKE @Name";
            return _connection.QueryFirstOrDefault<Category>(sql, new { Name = $"%{name}%" });
        }
    }
}
