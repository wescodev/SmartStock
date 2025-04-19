using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.SaleScreen;

public class SaleByCustomer
{
    public static void Load()
    {
        Console.WriteLine("Consulta de Vendas por Cliente");
        Console.WriteLine("-------------------------------");
        Console.Write("Digite o CPF do cliente para buscar as vendas:");
        var cpf = Console.ReadLine();
        

        ListarVenda(cpf);

    }

    private static void ListarVenda(string cpf)
    {
        
        var repositoryClient = new ClientRepository(Database.Connection);
        var client = repositoryClient.GetByCpf(cpf);

        if (client is null)
        {
            Console.WriteLine("Cliente não encontrado! Tente novamente");
            Load();
        }
        else
        {

            var repositorySale = new SaleRepository(Database.Connection);
            var saleClient = repositorySale.GetSalesByClient(cpf);

            if (!saleClient.Any())
            {
                Console.WriteLine("Nenhuma venda encontrada para este CPF.");
            }
            Console.WriteLine();
            Console.WriteLine("ID  | Data       | Valor  | Nome         | CPF");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var item in saleClient)
            {
                Console.WriteLine($"{item.IdSale}   | {item.SaleDate.ToString("dd/MM/yyyy"), -10} | {item.TotalAmount} | {item.ClientName} | {item.CpfClient}");
            }
        }
    }
}
