using SistemaBancario.Models;
using SistemaBancario.Utils;

ContaBancaria sistemabancario = new ContaBancaria();

bool continuar = true;



while (continuar)
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Banco");
    Console.WriteLine(" 1 - Depositar");
    Console.WriteLine(" 2 - Sacar");
    Console.WriteLine(" 3 - Consultar Saldo");
    Console.WriteLine(" 4 - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();


    switch (opcao)
    {
        case "1":
            Console.WriteLine("Depósito");
            decimal deposito = Entrada.LerDecimal("Digite o valor do depósito: ");
            sistemabancario.Depositar(deposito);
            break;
        case "2":
            Console.WriteLine("Saque");
            decimal saque = Entrada.LerDecimal("Digite o valor do saque: ");
            sistemabancario.Sacar(saque);
            break;
        case "3":
            Console.WriteLine("Consulta de Saldo");
            Console.WriteLine($"Saldo: {sistemabancario.Saldo:C}");

            break;
        case "4":
            continuar = false;
            Console.WriteLine("Saindo do sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

