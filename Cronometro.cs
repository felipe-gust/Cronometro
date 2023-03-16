using System;
using System.Threading;

namespace Cronometro
{
    public class Cronometro
    {

        public void Start(int tempo)
        {
            int minutoAtual = 0;

            while(minutoAtual != tempo)
            {
                Console.Clear();
                minutoAtual++;
                Console.WriteLine(minutoAtual);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Cronometro finalizado");
            Thread.Sleep(2000);

            Menu();
        }

        public void PreStart(int tempo)
        {
            Console.Clear();
            Console.WriteLine("Preparar...");
            Thread.Sleep(900);
            Console.WriteLine("Apontar...");
            Thread.Sleep(900);
            Console.WriteLine("Fogo...");
            Thread.Sleep(1000);

            Start(tempo);
        }

        public void Menu()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Quanto tempo deseja contar?");
                Console.WriteLine("Digite o tempo mais a letra desejada: ");
                Console.WriteLine("Ex: 10s => 10 segundos");
                Console.WriteLine("Ex: 10m => 10 minutos");
                Console.WriteLine("Ctrl+ C => Sair");

                string data = Console.ReadLine().ToLower();
                char tipo = char.Parse(data.Substring(data.Length - 1, 1));
                int tempo = int.Parse(data.Substring(0, data.Length - 1));
                int multiplicador = 1;

                if (tipo == 'm')
                    multiplicador = 60;

                else if (tempo == 0)
                    System.Environment.Exit(0);

                PreStart(tempo * multiplicador);
            
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Valor ou formato inválido, tente novamente.");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops, ocorreu algum erro.");
            }
            finally
            {
                Console.WriteLine("\nDigite qualquer tecla para continuar");
                Console.ReadKey();

                Menu();
            }
            
        }
    }
}
