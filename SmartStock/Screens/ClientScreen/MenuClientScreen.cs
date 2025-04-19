using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ClientScreen;

public class MenuClientScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Clientes");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar todos os clientes");
        Console.WriteLine("2 - Listar cliente por ID");
        Console.WriteLine("3 - Listar cliente por Nome");
        Console.WriteLine("4 - Listar cliente por CPF");
        Console.WriteLine("5 - Cadastrar cliente");
        Console.WriteLine("6 - Atualizar cliente");
        Console.WriteLine("7 - Excluir cliente");
        Console.WriteLine();
        Console.WriteLine();

        Console.ReadKey();
        Program.Load();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListAllClientScreen.Load();
                break;
            case 2:
                ListClientByIdScreen.Load();
                break;
            case 3:
                ListClientByNameScreen.Load();
                break;
            case 4:
                ListClientByCpfScreen.Load();
                break;
            case 5:
                RegisterClientScreen.Load();
                break;
            case 6:
                UpdateClientScreen.Load();
                break;
            case 7:
                DeleteClientScreen.Load();
                break;
            case 8:
                break;
            default: Load(); break;
        }
    }
}
