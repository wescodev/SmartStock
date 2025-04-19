using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.SaleScreen;

public class SaleByPeriod
{
    public static void Load()
    {
        Console.WriteLine("Consulta de Vendas por periodo");
        Console.WriteLine("-------------------------------");
        Console.Write("Digite a data inicial:");
        DateTime inicialDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Digite a data final:");
        DateTime finalDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", null);

        ListarPorPeriodo(inicialDate, finalDate);


    }

    private static void ListarPorPeriodo(DateTime inicialDate, DateTime finalDate)
    {
      var repositorySale = new SaleRepository(Database.Connection);
      var saleDate = repositorySale.GetSalesByPeriod(inicialDate, finalDate);

        if (!saleDate.Any())
        {
            Console.WriteLine("Nenhuma venda foi localizada.");
        }

        Console.WriteLine();
        Console.WriteLine("ID  | Data       | Valor Total  | Nome          | CPF");
        Console.WriteLine("---------------------------------------------------------------");

        foreach (var item in saleDate)
        {
            Console.WriteLine($"{item.IdSale,-3} | {((DateTime)item.SaleDate).ToString("dd/MM/yyyy"),-10} | {item.TotalAmount,12:C} | {item.ClientName,-13} | {item.CpfClient}");
        }
    }
}
