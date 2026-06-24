
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

internal class ScreenSound
{
    private static void Main(string[] args)
    {
        string mensagemDeBoasVindas = "Olá, Seja Bem-vindo ao Screen Sound";
        Dictionary<string, List<int>> DicionarioBandas = new Dictionary<string, List<int>>();

        void ExibirLogo()
        {
            Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
            Console.WriteLine(mensagemDeBoasVindas);
        }

        void ExibirOpcoesDoMenu()
        {
            bool exibirMenu = true;

            // O laço while mantém o programa rodando sem estourar a memória
            while (exibirMenu)
            {
                Console.Clear();
                ExibirLogo();
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para exibir todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("Digite -1 para sair");

                Console.Write("\nDigite a sua opção: ");
                string opcaoEscolhida = Console.ReadLine()!;

                // Tratamento simples caso o usuário digite algo que não seja número
                if (!int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica))
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                    Thread.Sleep(1500);
                    continue;
                }

                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        RegistrarBanda();
                        break;
                    case 2:
                        MostrarBandas();
                        break;
                    case 3:
                        AvaliarBandas();
                        break;
                    case 4:
                        MediaDaBanda();
                        break;
                    case -1:
                        Console.WriteLine("\nOPA, VALEU! :)");
                        exibirMenu = false; // Quebra o laço e encerra o programa
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        void RegistrarBanda()
        {
            Console.Clear();
            ExibirtituloDaOpcao("Registros das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (!DicionarioBandas.ContainsKey(nomeDaBanda))
            {
                DicionarioBandas.Add(nomeDaBanda, new List<int>());
                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            }
            else
            {
                Console.WriteLine($"A banda {nomeDaBanda} já está registrada.");
            }

            Thread.Sleep(2000);
        }

        void AvaliarBandas()
        {
            Console.Clear();
            ExibirtituloDaOpcao("Avaliar Banda:");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (DicionarioBandas.ContainsKey(nomeDaBanda))
            {
                Console.Write($"Qual a nota que a banda {nomeDaBanda} merece? ");
                int nota = int.Parse(Console.ReadLine()!);
                DicionarioBandas[nomeDaBanda].Add(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                Thread.Sleep(2500);
            }
            else
            {
                Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
                Console.ReadKey();
            }
        }

        void MostrarBandas()
        {
            Console.Clear(); // Limpa a tela para organizar a listagem
            ExibirtituloDaOpcao("Exibindo todas as bandas registradas: ");

            if (DicionarioBandas.Count == 0)
            {
                Console.WriteLine("Nenhuma banda registrada ainda.");
            }
            else
            {
                foreach (string banda in DicionarioBandas.Keys)
                {
                    Console.WriteLine($"Banda: {banda}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
        }

        void MediaDaBanda()
        {
            Console.Clear();
            ExibirtituloDaOpcao("Exibir média da banda");
            Console.Write("Digite o nome da banda que deseja exibir a média de avaliações: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (DicionarioBandas.ContainsKey(nomeDaBanda))
            {
                List<int> notasDaBanda = DicionarioBandas[nomeDaBanda];

                // Verifica se a banda possui alguma nota para não dar erro de divisão por zero
                if (notasDaBanda.Count > 0)
                {
                    Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average():F1}");
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} ainda não possui avaliações.");
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
                Console.ReadKey();
            }
        }

        void ExibirtituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

        // Inicia o programa chamando o menu principal apenas uma vez
        ExibirOpcoesDoMenu();
    }
}