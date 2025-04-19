using SmartStock.Repositories;
using SmartStock.Screens.ClientScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreen
{
    internal class RemoveProductScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Produto");
            Console.WriteLine("-------------");
            Console.Write("Digite o ID do produto a ser excluido: ");

            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuClientScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new ProductRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Produto excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o produto");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
