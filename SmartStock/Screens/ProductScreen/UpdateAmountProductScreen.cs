using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreen
{
    internal class UpdateAmountProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar valor do produto");
            Console.WriteLine("-------------");
            Console.Write("Digite o ID do produto: ");

            int productId;

            if(int.TryParse(Console.ReadLine(), out productId))
            {
                Listar(productId);

                Console.WriteLine("\nDigite o novo valor do produto\n");

                Console.Write("New price: ");
                decimal price = decimal.Parse(Console.ReadLine());


                Atualizar(productId, price);
            }


        }

        private static void Atualizar(int idProduct, decimal price)
        {

            try
            {
                var repository = new ProductRepository(Database.Connection);
                repository.UpdateAmount(idProduct, price);
                Console.WriteLine("Valor atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o valor");
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
