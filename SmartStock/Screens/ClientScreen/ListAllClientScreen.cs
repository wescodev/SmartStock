using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen
{
    public class ListAllClientScreen 
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de clientes");
            Console.WriteLine("-------------");
            Listar();
            Console.ReadKey();
            MenuClientScreen.Load();

        }

        private static void Listar()
        {
            var repository = new ClientRepository(Database.Connection);
            var client = repository.GetAll();

            foreach(var item in client)
            {
                Console.WriteLine($"ID: {item.IdClient}");
                Console.WriteLine($"Nome: {item.Name}");
                Console.WriteLine($"Email: {item.EmailClient}");
                Console.WriteLine($"CPF: {item.CpfClient}");
                Console.WriteLine($"Telefone: {item.PhoneClient}");
                Console.WriteLine($"Data de Cadastro: {item.CreateDate?.ToString("dd/MM/yyyy")}");
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}
