
using Microsoft.Data.SqlClient;
using SmartStock;
using SmartStock.Screens.ClientScreen;
using SmartStock.Screens.ProductScreen;
using SmartStock.Screens.ReportScreen;
using SmartStock.Screens.SaleScreen;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=SmartStock; User ID=sa; Password=Smartwatch2#; TrustServerCertificate=True";

    public static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);

        Database.Connection.Open();

        Load();

        Console.ReadKey();
        Database.Connection.Close();
    }

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Smart Stock");
        Console.WriteLine("-----------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de clientes");
        Console.WriteLine("2 - Gestão de produtos");
        Console.WriteLine("3 - Gestão de vendas");
        Console.WriteLine("4 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine()!);

        switch(option)
        {
            case 1:
                MenuClientScreen.Load();
                break;
            case 2:
                MenuProductScreen.Load();
                break;                
            case 3:
                MenuSaleScreen.Load();
                break;               
            case 4:
                MenuReportScreen.Load();
                break;
            default: Load(); break;
        }
    }
    

}

