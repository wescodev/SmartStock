using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreen
{
    internal class CreateProductScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("New Product");
            Console.WriteLine("--------------");

            Console.Write("ID category: ");
            var idCategory = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Description: ");
            var description = Console.ReadLine();

            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine());

            Console.Write("Stock Quantity: ");
            var stockQuantity = int.Parse(Console.ReadLine());
            
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                StockQuantity = stockQuantity,
                CreateDate = DateTime.Now,
                Category = new Category { IdCategory = idCategory }
            };

            Create(product);

        }

        private static void Create(Product product)
        {
            try
            {
                var repository = new ProductRepository(Database.Connection);
                repository.Insert(product);
                Console.WriteLine("Produto cadastrado com sucesso!");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a cliente");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
