using AppVendas.Controller;
using AppVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.View
{
    internal class VendasView
    {
        public static void Main(string[] args)
        {



            string op;

            do
            {
                Console.WriteLine("Seja Bem Vindos \n");
                Console.WriteLine("Escolha uma Opção \n");
                Console.WriteLine("1.Incluir Novo Cliente");
                Console.WriteLine("2.Alterar Dados Do Cliente");
                Console.WriteLine("3.Deletar Cliente");
                Console.WriteLine("4.Select (selecionar a tabela)");

                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)


                {

                    case 1:
                        incluir();
                        break;


                    case 2:
                        alterar();
                        break;


                    case 3:
                        deletar();
                        break;

                    case 4:
                        select();
                        break;

                    default:
                        Console.WriteLine("Operação inválida.");

                        break;
                }

                Console.WriteLine("Deseja continuar \n");
                op = Console.ReadLine();

            } while (op == "s");

        }

        private static void alterar()
        {
            using (var contexto = new DBVendas())
            {

                Console.WriteLine("Digite o ID que deseja alterar: ");
                var busca = contexto.Vendas.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine(busca.Produto);
                Console.WriteLine(busca.Descricao);
                Console.WriteLine("Entre com a corrreção do nome: ");
                busca.Produto = Console.ReadLine();


                contexto.SaveChanges();
                Console.WriteLine("Usuario alterado com sucesso!!");

            }
        }

        public static void incluir()
        {

            string vProduto, vDescricao;
            DateTime vData;
            decimal vValor;

            Console.WriteLine("Digite o produto: ");
            vProduto = Console.ReadLine();
            Console.WriteLine("Descrição: ");
            vDescricao = Console.ReadLine();
            Console.WriteLine("Data: ");
            vData = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Valor: ");
            vValor = decimal.Parse(Console.ReadLine());

            using (var contexto = new DBVendas())
            {
                contexto.Vendas.Add(new Vendas()
                {
                    Produto = vProduto,
                    Descricao = vDescricao,
                    DataVenda = vData,
                    Valor = vValor,

                });
                contexto.SaveChanges();
            }

            Console.ReadKey();
        }
        private static void deletar()
        {

            using (var contexto = new DBVendas())
            {
                Console.WriteLine("Digite ID que deseja apagar: ");
                var busca = contexto.Vendas.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Voçê esta prestes a apagar o usuario:  {busca.Produto}");
                Console.WriteLine("Tem certeza que deseja apagar, digite S para apagar ou qualquer tecla para anular ");
                var apaga = Console.ReadLine();

                if (apaga == "S")

                {

                    contexto.Vendas.Remove(busca);
                    contexto.SaveChanges();
                    Console.WriteLine("Usuario excluido com sucesso");
                }

                else
                {
                    Console.WriteLine("Operação anulada");


                }
            }


        }

        private static void select()
        {

            using (var contexto = new DBVendas())
            {
                // Exemplo de consulta simples para selecionar todos os usuários da agenda
                var cadastros = contexto.Vendas.ToList();

                foreach (var listacadastro in cadastros)
                {
                    Console.WriteLine($"ID: {listacadastro.Id}, Produto: {listacadastro.Produto}," +
                        $" Descrição: {listacadastro.Descricao}, DataVenda: {listacadastro.DataVenda}, Valor: {listacadastro.Valor}");
                }
            }
            Console.ReadKey();

        }
    }
}
