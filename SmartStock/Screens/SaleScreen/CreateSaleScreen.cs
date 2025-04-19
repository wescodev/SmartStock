using SmartStock.Entities;
using SmartStock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Screens.SaleScreen
{
    public class CreateSaleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Registrar nova venda");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Console.WriteLine("Digite os dados do cliente: ");
            Console.WriteLine();
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();
            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            var clientRepository = new ClientRepository(Database.Connection);
            var cliente = ValidaCliente(cpf, nome, clientRepository);

            if (cliente is null)
            {
                Console.WriteLine("Cliente não encontrado. Verifique o CPF e tente novamente.");
                Console.ReadKey();
                Load();
                return;
            }
            Console.WriteLine("Cliente validado com sucesso.");
            Console.ReadKey();
            ExibirCategorias(cliente.IdClient);
       

        }


        private static Client ValidaCliente(string cpf, string nome, ClientRepository clientRepository)
        {
           
            var cliente = clientRepository.GetByCpf(cpf);

            if (cliente is null)
            {
                return null;
            }

            if (cliente.Name.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return cliente;
            }
            Console.WriteLine("O nome informado não corresponde ao CPF.");
            return null;
        }

        private static void ExibirCategorias(int idClient)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma categoria de produto:");
            Console.WriteLine("-------------------------------");

            var categoryRepository = new CategoryRepository(Database.Connection);
            var categories = categoryRepository.GetAll();

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.IdCategory} - {category.Name}");
            }

            Console.Write("\nEscolha uma categoria (ID): ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int idEscolhido))
            {
                Console.WriteLine("Entrada inválida. Digite um número.");
                Console.ReadKey();
                ExibirCategorias(idClient);
                return;
            }

            var categoriaSelecionada = categories.FirstOrDefault(c => c.IdCategory == idEscolhido);

            if(categoriaSelecionada != null)
            {
                Console.WriteLine($"Você escolheu a categoria: {categoriaSelecionada.Name}");
                ListarProdutosPorCategoria(categoriaSelecionada.IdCategory, categoriaSelecionada.Name, idClient);
            }
            else
            {
                Console.WriteLine("Categoria inválida. Tente novamente.");
                Console.ReadKey();
                ExibirCategorias(idClient);
            }
        }

        private static void ListarProdutosPorCategoria(int idCategory, string name, int idClient)
        {
            Console.Clear();
            Console.WriteLine($"Produtos disponíveis da categoria {name}");
            Console.WriteLine("-------------------------------");

            var productRepository = new ProductRepository(Database.Connection);
            var produtos = productRepository.GetByCategoryId(idCategory).ToList(); ;

            if (!produtos.Any())
            {
                Console.WriteLine("Nenhum produto encontrado nesta categoria.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.IdProduct} | Nome: {produto.Name} | Preço: R${produto.Price:F2} | Estoque: {produto.StockQuantity}");
            }

            AdicionarProdutosVenda(produtos, idClient);
        }


        private static void AdicionarProdutosVenda(List<Product> produtos, int idClient)
        {
            var vendaItems = new List<SaleItem>();
            decimal totalVenda = 0;

            while (true)
            {
                Console.Write("\nDigite o ID do produto para registrar a venda ou '0' para finalizar: ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int idProduto) || idProduto == 0)
                {
                    break;  
                }


                var produtoSelecionado = produtos.FirstOrDefault(p => p.IdProduct == idProduto);


                if (produtoSelecionado == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    continue;
                }

                Console.WriteLine($"Produto selecionado: {produtoSelecionado.Name}");
                Console.WriteLine($"Preço unitário: R${produtoSelecionado.Price:F2}");
                Console.Write("Informe a quantidade:");

                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Quantidade inválida.");
                    continue;
                }

                if (quantidade > produtoSelecionado.StockQuantity)
                {
                    Console.WriteLine("Estoque insuficiente.");
                    continue;
                }

                var totalItem = produtoSelecionado.Price * quantidade;
                totalVenda += totalItem;

                // Adiciona um SaleItem para cada unidade
                for (int i = 0; i < quantidade; i++)
                {
                    vendaItems.Add(new SaleItem
                    {
                        IdProduct = produtoSelecionado.IdProduct,
                        UnitPrice = produtoSelecionado.Price
                    });
                }

                produtoSelecionado.StockQuantity -= quantidade;
                var productRepository = new ProductRepository(Database.Connection);
                productRepository.Update(produtoSelecionado);

                Console.WriteLine($"Produto adicionado. Total da venda até agora: R${totalVenda:F2}");
                Console.WriteLine("Deseja adicionar mais produtos? (s/n)");        

                if (Console.ReadLine()?.ToLower() != "s")
                    break;
            }

            FinalizarVenda(vendaItems, totalVenda, idClient);

        }

        private static void FinalizarVenda(List<SaleItem> vendaItems, decimal totalVenda, int idClient)
        {
            var sale = new Sale
            {
                IdClient = idClient,
                TotalAmount = totalVenda,
                SaleDate = DateTime.Now,
                SaleItems = vendaItems
            };

            var saleRepository = new SaleRepository(Database.Connection);
            var saleId = saleRepository.InsertSale(sale);

            Console.Write($"\nVenda registrada com sucesso! ID da venda: {saleId}");

            var saleItemRepository = new SaleItemRepository(Database.Connection);

            foreach (var item in vendaItems)
            {
                item.IdSale = saleId;
                saleItemRepository.Insert(item);
            }

            Console.WriteLine("Itens da venda registrados com sucesso!");
            Console.WriteLine("Estoque dos produtos atualizado.");
            Console.ReadKey();
        }
    }
}
