using Azure;
using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen;

public class UpdateClientScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualizar cliente");
        Console.WriteLine("-------------");
        Console.Write("Digite o ID do cliente: ");

        int clientId;

        if (int.TryParse(Console.ReadLine(), out clientId))
        {
            Listar(clientId);
            Console.WriteLine("\nDigite os novos dados para o cliente:");

            var updatedClient = new Client();

            updatedClient.IdClient = clientId;

            Console.Write("Nome: ");
            updatedClient.Name = Console.ReadLine();

            Console.Write("Email: ");
            updatedClient.EmailClient = Console.ReadLine();

            Console.Write("CPF: ");
            updatedClient.CpfClient = Console.ReadLine();

            Console.Write("Telefone: ");
            updatedClient.PhoneClient = Console.ReadLine();

            updatedClient.CreateDate = DateTime.Now;

             Console.Write("\nConfirmar atualização? (S/N): ");
            var confirmacao = Console.ReadLine();

            if (confirmacao?.ToUpper() == "S")
            {
                Atualizar(updatedClient);
            }

        }
        else
        {
            Console.WriteLine("ID inválido! Tente novamente.");
        }

        Console.ReadKey();
        MenuClientScreen.Load();

    }

    private static void Atualizar(Client client)
    {

        try
        {
            var repository = new ClientRepository(Database.Connection);
            repository.Update(client);
            Console.WriteLine("Cliente atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar o cliente");
            Console.WriteLine(ex.Message);
        }
    }

    private static void Listar(int id)
    {
        var repository = new ClientRepository(Database.Connection);
        var client = repository.GetById(id);

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
