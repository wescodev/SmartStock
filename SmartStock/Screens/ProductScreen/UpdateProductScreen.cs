using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreen
{
    internal class UpdateProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar produto");
            Console.WriteLine("-------------");
            Console.Write("Digite o ID do cliente: ");

            int productId;

            if(int.TryParse(Console.ReadLine(), out productId))
            {
                Listar(productId);

                Console.WriteLine("\nDigite os novos dados para o produto\n");

                Console.Write("ID category: ");
                int idCategory = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Stock Quantity: ");
                int stockQuantity = int.Parse(Console.ReadLine());

                var updateProduct = new Product
                {
                    IdProduct = productId,
                    Name = name,
                    Description = description,
                    Price = price,
                    StockQuantity = stockQuantity,
                    CreateDate = DateTime.Now, 
                    Category = new Category { IdCategory = idCategory }
                };

                Atualizar(updateProduct);


            }
        }

        private static void Atualizar(Product product)
        {

            try
            {
                var repository = new ProductRepository(Database.Connection);
                repository.Update(product);
                Console.WriteLine("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o cliente");
                Console.WriteLine(ex.Message);
            }
        }

        private static void Listar(int id)
        {
            var repository = new ProductRepository(Database.Connection);
            var product = repository.GetById(id);

            if (product is null)
            {
                Console.WriteLine("Produto não encontrado!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {product.IdProduct}");
                Console.WriteLine($"Nome: {product.Name}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Stock Quantity: {product.StockQuantity}");
                Console.WriteLine($"Data de Cadastro: {product.CreateDate.ToString("dd/MM/yyyy")}");
                Console.WriteLine("--------------------------------------");
            }

        }
    }
}
