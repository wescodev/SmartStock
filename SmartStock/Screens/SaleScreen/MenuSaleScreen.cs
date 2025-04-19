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
        Console.WriteLine("1 - Registrar nova venda"); //ok
        Console.WriteLine("2 - Consultar vendas por cliente");
        Console.WriteLine("3 - Consultar vendas por período");
        Console.WriteLine("4 - Detalhar uma venda");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                CreateSaleScreen.Load(); //ok
                break;
            case 2:
                SaleByCustomer.Load();
                break;
            case 3:
                SaleByPeriod.Load();
                break;
            case 4:
                SaleDetail.Load();
                break;
            default: Load(); break;
        }

        Console.ReadKey();
        Program.Load();
    }
}
