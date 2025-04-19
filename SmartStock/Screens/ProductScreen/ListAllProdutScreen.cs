using SmartStock.Repositories;
using SmartStock.Screens.ClientScreen;
using SmartStock.Screens.ProductScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.ProductScreenp;

public class ListAllProdutScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Produtos");
        Console.WriteLine("-------------");
        Listar();
        Console.ReadKey();
        MenuProductScreen.Load();
    }

    private static void Listar()
    {
        var repository = new ProductRepository(Database.Connection);
        var products = repository.GetAll();

        foreach (var item in products)
        {
            Console.WriteLine($"ID: {item.IdProduct}");
            Console.WriteLine($"Nome: {item.Name}");
            Console.WriteLine($"Descrição: {item.Description}");
            Console.WriteLine($"Preço: R${item.Price}");
            Console.WriteLine($"Quantidade em Estoque: {item.StockQuantity}");
            Console.WriteLine($"Data de Cadastro: {item.CreateDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Categoria: {item.Category?.Name}");
            Console.WriteLine("--------------------------------------");
        }
    }
}
