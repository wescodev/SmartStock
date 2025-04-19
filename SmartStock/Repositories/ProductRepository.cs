using Dapper;
using Microsoft.Data.SqlClient;
using SmartStock.Entities;
using SmartStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlConnection _connection;

        public ProductRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAll()
        {
            var sql = @"SELECT 
                    P.IdProduct, P.Name, P.Description, P.Price, 
                    P.StockQuantity, P.CreateDate,
                    C.IdCategory, C.Name 
                FROM Product P
                JOIN Category C ON P.IdCategory = C.IdCategory";

            var products = _connection.Query<Product, Category, Product>(
                sql,
                (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                splitOn: "IdCategory" // importante: esse campo indica onde começa o segundo objeto
            );

            return products;
        }


        public Product GetById(int id)
        {
            var sql = @"SELECT 
                    P.IdProduct, P.Name, P.Description, P.Price, 
                    P.StockQuantity, P.CreateDate,
                    C.IdCategory, C.Name 
                FROM Product P
                JOIN Category C ON P.IdCategory = C.IdCategory
                WHERE P.IdProduct = @IdProduct";

            var product = _connection.Query<Product, Category, Product>(sql,
                (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                new { IdProduct = id },
                splitOn: "IdCategory"
            ).FirstOrDefault(); ;

            return product;
        }

        public void Insert(Product product)
        {
            var sql = @"INSERT INTO Product (IdCategory, Name, Description, Price, StockQuantity, CreateDate)" +
                        "VALUES (@IdCategory, @Name, @Description, @Price, @StockQuantity, @CreateDate)";
            _connection.Execute(sql, new
            {
                IdCategory = product.Category.IdCategory,
                product.Name,
                product.Description,
                product.Price,
                product.StockQuantity,
                product.CreateDate
            });
        }

        public void Update(Product product)
        {
            var sql = @"UPDATE Product
                        SET IdCategory = @IdCategory, Name = @Name,  Description = @Description ,Price = @Price, StockQuantity = @StockQuantity, CreateDate = @CreateDate
                        WHERE IdProduct = @IdProduct";

            _connection.Execute(sql, new
            {
                IdCategory = product.Category.IdCategory,
                product.Name,
                product.Description,
                product.Price,
                product.StockQuantity,
                product.CreateDate,
                product.IdProduct
            });
        }

        public void UpdateAmount(int idProduct, decimal price)
        {
            var sql = @"UPDATE Product SET Price = @Price WHERE IdProduct = @IdProduct";
            _connection.Execute(sql, new { IdProduct = idProduct, Price = price });
        }

        public void UpdateQtdStock(int idProduct, int stockQuantity)
        {
            var sql = @"UPDATE Product SET StockQuantity = @StockQuantity WHERE IdProduct = @IdProduct";
            _connection.Execute(sql, new { IdProduct = idProduct, StockQuantity = stockQuantity });
        }
        public void Delete(int id)
        {
            var sql = @"
                   DELETE FROM SaleItem WHERE IdProduct = @IdProduct;
                   DELETE FROM Product WHERE IdProduct = @IdProduct;
                    ";

            _connection.Execute(sql, new { IdProduct = id });
        }

        public IEnumerable<Product> GetByCategoryId(int idCategory)
        {
            var sql = @"SELECT 
                   P.IdProduct, P.Name, P.Description, P.Price, 
                   P.StockQuantity, P.CreateDate,
                   C.IdCategory, C.Name 
               FROM Product P
               JOIN Category C ON P.IdCategory = C.IdCategory
               WHERE C.IdCategory = @IdCategory";

            var products = _connection.Query<Product, Category, Product>(
                sql,
                (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                new { IdCategory = idCategory },
                splitOn: "IdCategory"
            );

            return products;  
        }


    }

}
