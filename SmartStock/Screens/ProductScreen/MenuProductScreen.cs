using SmartStock.Screens.ClientScreen;
using SmartStock.Screens.ProductScreenp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreen;

public class MenuProductScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Produtos");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar todos os produtos"); //ok
        Console.WriteLine("2 - Listar produtos por ID");
        Console.WriteLine("3 - Cadastrar produto");
        Console.WriteLine("4 - Editar produto");
        Console.WriteLine("5 - Atualizar preco");
        Console.WriteLine("6 - Atualizar quantidade no estoque");
        Console.WriteLine("7 - Excluir produto");
        Console.WriteLine();
        Console.WriteLine();

        Console.ReadKey();
        Program.Load();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListAllProdutScreen.Load(); 
                break;
            case 2:
                ListProductByIdScreen.Load(); 
                break;
            case 3:
                CreateProductScreen.Load();
                break;
            case 4:
                UpdateProductScreen.Load();
                break;
            case 5:
                UpdateAmountProductScreen.Load();
                break;
            case 6:
                UpdateProductQtdScreen.Load();
                break;
            case 7:
                RemoveProductScreen.Load();
                break;
            case 8:
                break;
            default: Load(); break;
        }
    }
}
