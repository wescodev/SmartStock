using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen
{
    public class RegisterClientScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Cliente");
            Console.WriteLine("-------------");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("CPF: ");
            var cpf = Console.ReadLine();

            Console.Write("Telefone: ");
            var phone = Console.ReadLine();

            Create(new Client
            {
                Name = name,
                EmailClient = email,
                CpfClient = cpf,
                PhoneClient = phone,
                CreateDate = DateTime.Now
            });

            Console.ReadKey();
            MenuClientScreen.Load();

        }

        private static void Create(Client client)
        {
            try
            {
                var repository = new ClientRepository(Database.Connection);
                repository.Insert(client);
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a cliente");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
