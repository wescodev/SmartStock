using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen
{
    public class DeleteClientScreen 
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Cliente");
            Console.WriteLine("-------------");
            Console.Write("Digite o ID do cliente a ser excluido: ");

            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuClientScreen.Load();

        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new ClientRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Cliente excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o cliente");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
