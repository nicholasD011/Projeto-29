using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
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
                        //alterar();
                        break;


                    case 3:
                        //deletar();
                        break;

                    case 4:
                        //  select();
                        break;

                    default:
                        Console.WriteLine("Operação inválida.");

                        break;
                }

                Console.WriteLine("Deseja continuar \n");
                op = Console.ReadLine().ToLower();

            } while (op == "s");

        }
    }
}
