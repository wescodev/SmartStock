using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen
{
    public class ListClientByCpfScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de clientes");
            Console.WriteLine("-------------");
            Console.Write("Digite o CPF do cliente: ");

            string clientCpf = Console.ReadLine();

            //string cleanCpf = clientCpf.Replace(".", "").Replace("-", "");

            if (!string.IsNullOrEmpty(clientCpf))
            {
                Listar(clientCpf);
            }
            else
            {
                Console.WriteLine("CPF inválido! Tente novamente.");
            }

            Console.ReadKey();
            MenuClientScreen.Load();

        }

        private static void Listar(string name)
        {
            var repository = new ClientRepository(Database.Connection);
            var client = repository.GetByCpf(name);

            if (client is null)
            {
                Console.WriteLine("Cliente não encontrado!");
            }


            else
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {client.IdClient}");
                Console.WriteLine($"Nome: {client.Name}");
                Console.WriteLine($"Email: {client.EmailClient}");
                Console.WriteLine($"CPF: {client.CpfClient}");
                Console.WriteLine($"Telefone: {client.PhoneClient}");
                Console.WriteLine($"Data de Cadastro: {client.CreateDate?.ToString("dd/MM/yyyy")}");
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}
