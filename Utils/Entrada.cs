using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Utils
{
    public class Entrada
    {
       public static decimal LerDecimal(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número decimal válido.");
                }
            }

        }

        public static string LerTexto(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada.Trim();
                }
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}