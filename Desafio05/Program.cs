using System;
using System.Collections.Generic;

namespace Desafio05
{
    class Program
    {
        static Racao racao;
        static List<Gato> gatos;
        static void Main(string[] args)
        {
            racao = new Racao();
            gatos = new List<Gato>();
            
            menu();
        }

        static void menu()
        {
            Console.Clear();
            Console.WriteLine("Calcudora duração de ração\n" +
                "1 - Adicionar ração\n" +
                "2 - Visualizar ração\n" +
                "3 - Adicionar gato\n" +
                "2 - Listar gatos\n" +
                "5 - Calcular duração da ração\n" +
                "6 - Sair");
            string entrada = Console.ReadLine();
            int opcaoSelecionada = 0;
            int.TryParse(entrada, out opcaoSelecionada);

            if (opcaoSelecionada == 6)
            {
                Environment.Exit(0);
            } else if (opcaoSelecionada == 1)
            {
                adicionarRacao();
            } else if (opcaoSelecionada == 2)
            {
                visualizarRacao();
            } else if (opcaoSelecionada == 3)
            {
                adiconarGato();
            } else if (opcaoSelecionada == 4)
            {
                listarGatos();
            } else if (opcaoSelecionada == 5)
            {
                calcularDuracaoRacao();
            } else
            {
                Console.WriteLine("Opção invalida");
                menu();
            }
        }
        static void adicionarRacao()
        {
            Console.Clear();
            Console.WriteLine("Incluindo ração: ");
            Console.WriteLine("Digite a marca da ração: ");
            racao.nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade em quilos: ");
            racao.peso = double.Parse(Console.ReadLine());
            adicionarPorcoes();

            menu();
        }

        static void adicionarPorcoes()
        {
            Porcao porcao = new Porcao();
            Console.WriteLine("Incluindo porções: ");
            Console.WriteLine("Peso do gato: ");
            porcao.pesoGato = double.Parse(Console.ReadLine());
            Console.WriteLine("Porção ração: ");
            porcao.quantidadeRacao = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Incluir outra porção? (S/N) ");
            racao.porcoes.Add(porcao);
            if(Console.ReadLine().ToLower() == "s")
            {
                adicionarPorcoes();
            }
        }


        static void visualizarRacao()
        {
            Console.Clear();
            Console.WriteLine("Ração adicionada\n" +
                "Marca: " + racao.nome + "\n" +
                "Peso ração: " + racao.peso + "\n" +
                "Porções: \n" +
                "-------------------------------------");
            foreach (var porcao in racao.porcoes)
            {
                Console.WriteLine("peso gato: " + porcao.pesoGato + " KG \n" +
                    "quantidade ração: "+porcao.quantidadeRacao + " GR\n" +
                    "-------------------------------------");
            }
            Console.WriteLine("\n\nPressione qualquer tecla para continuar");
            Console.ReadLine();
            menu();
        }

        static void adiconarGato()
        {

            menu();
        }

        static void listarGatos()
        {

            menu();
        }

        static void calcularDuracaoRacao()
        {

            menu();
        }

    }
}
