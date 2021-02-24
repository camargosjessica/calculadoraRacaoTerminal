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
                "4 - Listar gatos\n" +
                "5 - Limpar lista gatos\n" +
                "6 - Calcular duração da ração\n" +
                "7 - Sair");
            string entrada = Console.ReadLine();
            int opcaoSelecionada = 0;
            int.TryParse(entrada, out opcaoSelecionada);

            if (opcaoSelecionada == 7)
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
                adicionarGato();
            } else if (opcaoSelecionada == 4)
            {
                listarGatos();
            }
            else if (opcaoSelecionada == 5)
            {
                gatos.Clear();
                menu();
            }
            else if (opcaoSelecionada == 6)
            {
                calcularDuracaoRacao();
            }
            else
            {
                Console.WriteLine("Opção invalida");
                menu();
            }
        }
        static void adicionarRacao()
        {
            Console.Clear();
            racao.porcoes.Clear();
            Console.WriteLine("Incluindo ração: ");
            Console.WriteLine("Digite a marca da ração: ");
            racao.nome = Console.ReadLine();
            Console.WriteLine("Digite o peso do pacote em quilos: ");
            racao.peso = double.Parse(Console.ReadLine());
            adicionarPorcoes();
            racao.porcoes.Sort((p1, p2) => p1.pesoGato.CompareTo(p2.pesoGato));//Ordenar lista comparando os pesos de gatos das porções

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
            racao.porcoes.Add(porcao);
            Console.WriteLine("Incluir outra porção? (S/N) ");
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

        static void adicionarGato()
        {
            Gato gato = new Gato();
            Console.Clear();
            Console.WriteLine("Incluindo gato: ");
            gato.nome = Console.ReadLine();
            Console.WriteLine("Incluindo peso gato: ");
            gato.peso = double.Parse(Console.ReadLine());
            gatos.Add(gato);
            Console.WriteLine("Incluir outro gato? (S/N) ");
            if(Console.ReadLine().ToLower() == "s")
            {
                adicionarGato();
            }
            menu();
        }

        static void listarGatos()
        {
            Console.Clear();
            Console.WriteLine("Gatos: \n" +
                "-------------------------------------");
            foreach (var gato in gatos)
            {
                Console.WriteLine("Nome do gato: " + gato.nome + "\n" +
                    "Peso do gato: " + gato.peso + "\n" +
                    "-------------------------------------");
            }
            Console.WriteLine("\n\nPressione qualquer tecla para continuar");
            Console.ReadLine();
            menu();
        }

        static void calcularDuracaoRacao()
        {
            Console.Clear();
            double racaoDiaria = 0;
            double pesoRacaoGramas = racao.peso * 1000; //transformando o peso da ração de kg para gramas
            foreach (var gato in gatos)
            {
                var porcaoEncontrada = 0.0;
                foreach (var porcao in racao.porcoes)
                {
                    if(gato.peso <= porcao.pesoGato)
                    {
                        porcaoEncontrada = porcao.quantidadeRacao;
                            break;
                    }
                } racaoDiaria += porcaoEncontrada;
            }
            var mediaRacao = pesoRacaoGramas / racaoDiaria;
            Console.WriteLine("A media da ração é: " + mediaRacao);
            Console.ReadLine();
            menu();
        }

    }
}
