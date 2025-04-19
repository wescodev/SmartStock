using SmartStock.Screens.ClientScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.SaleScreen;

public class MenuSaleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Vendas");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Registrar nova venda"); 
        Console.WriteLine("2 - Consultar vendas por cliente");
        Console.WriteLine("3 - Consultar vendas por período");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                CreateSaleScreen.Load(); 
                break;
            case 2:
                SaleByCustomer.Load();
                break;
            case 3:
                SaleByPeriod.Load();
                break;
            default: Load(); break;
        }

        Console.ReadKey();
        Program.Load();
    }
}
