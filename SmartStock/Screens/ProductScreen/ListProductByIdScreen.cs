using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreen;

public class ListProductByIdScreen
{
    internal static void Load()
    {
        Console.Clear();
        Console.WriteLine("Listar de produtos");
        Console.WriteLine("-------------------");
        Console.Write("Digite o ID do produto: ");

        int productId;

        if(int.TryParse(Console.ReadLine(), out productId))
        {
            Listar(productId);
        }
        else
        {
            Console.WriteLine("ID invalido! Tente novamente.");
        }

        Console.ReadKey();
        MenuProductScreen.Load();
    
    }

    private static void Listar(int id)
    {
        var repository = new ProductRepository(Database.Connection);
        var product = repository.GetById(id);

        if(product is null)
        {
            Console.WriteLine("Cliente não encontrado!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Product Name: {product.Name}");
            Console.WriteLine($"Description: {product.Name}");
            Console.WriteLine($"Price: R${product.Price}");
            Console.WriteLine($"Stock Quantity: {product.StockQuantity}");
            Console.WriteLine($"Create Date: {product.CreateDate}");
        }
    }
}
