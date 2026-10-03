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
                Console.WriteLine("Entrada inválida. Por favor, digite um número decimal válido.");
            }

        }

        public static string LerTexto(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada.Trim();
                }
                Console.WriteLine("Entrada inválida.");
            }
        }

        public static int LerInteiro(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
            }
        }

        public static string LerSenha(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string senha = "";
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (senha.Length > 0)
                        {
                            senha = senha.Substring(0, senha.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        senha += key.KeyChar;
                        Console.Write("*");
                    }
                }
                Console.WriteLine();

                if (!string.IsNullOrWhiteSpace(senha) && senha.Length >= 6)
                    return senha;

                Console.WriteLine("Senha inválida. A senha não pode estar vazia e deve ter no mínimo 6 caracteres.");
            }
        }
    }
}