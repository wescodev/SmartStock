using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen;

public class ListClientByIdScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de clientes");
        Console.WriteLine("-------------");
        Console.Write("Digite o ID do cliente: ");

        int clientId;

        if (int.TryParse(Console.ReadLine(), out clientId))
        {
            Listar(clientId);
        }
        else
        {
            Console.WriteLine("ID inválido! Tente novamente.");
        }

        Console.ReadKey();
        MenuClientScreen.Load();
    }

    private static void Listar(int id)
    {
        var repository = new ClientRepository(Database.Connection);
        var client = repository.GetById(id);

        if(client is null)
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
