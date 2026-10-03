using SistemaBancario.Models;
using SistemaBancario.Utils;
using SistemaBancario.Exceptions;

Banco banco = new Banco();
ContaBancaria? contaLogada = null;
bool continuar = true;

while (continuar)
{
    try
    {
        if (contaLogada == null)
        {
            ExibirMenuDeslogado();
            string opcao = Entrada.LerTexto("Escolha uma opção: ");

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Cadastro de Conta");
                    string titular = Entrada.LerTexto("Digite o nome do titular: ");
                    string senha = Entrada.LerSenha("Digite a senha (mínimo 6 caracteres): ");
                    ContaBancaria novaConta = banco.CadastrarConta(titular, senha);
                    Console.WriteLine($"Conta cadastrada com sucesso! Número da conta: {novaConta.NumeroConta}");
                    break;
                case "2":
                    Console.WriteLine("Login");
                    int numeroConta = Entrada.LerInteiro("Digite o número da conta: ");
                    string senhaLogin = Entrada.LerSenha("Digite a senha: ");
                    contaLogada = banco.Login(numeroConta, senhaLogin);
                    Console.WriteLine($"Login realizado com sucesso! Bem-vindo, {contaLogada.Titular}.");
                    break;
                case "3":
                    continuar = false;
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        else
        {
            ExibirMenuLogado();
            string opcao = Entrada.LerTexto("Escolha uma opção: ");
        
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Depósito");
                    decimal deposito = Entrada.LerDecimal("Digite o valor do depósito: ");
                    contaLogada.Depositar(deposito);
                    Console.WriteLine($"Depósito de {deposito:C} realizado com sucesso. Novo saldo: {contaLogada.Saldo:C}");
                    break;
                case "2":
                    Console.WriteLine("Saque");
                    decimal saque = Entrada.LerDecimal("Digite o valor do saque: ");
                    contaLogada.Sacar(saque);
                    Console.WriteLine($"Saque de {saque:C} realizado com sucesso. Novo saldo: {contaLogada.Saldo:C}");
                    break;
                case "3":
                    Console.WriteLine("Consulta de Saldo");
                    Console.WriteLine($"Saldo: {contaLogada.Saldo:C}");

                    break;
                case "4":
                    contaLogada = null;
                    Console.WriteLine("Logout realizado com sucesso.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    catch (SaldoInsuficienteException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    catch (ContaNaoEncontradaException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    catch (CredenciaisInvalidasException ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
    }
}


static void ExibirMenuLogado()
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Banco");
    Console.WriteLine(" 1 - Depositar");
    Console.WriteLine(" 2 - Sacar");
    Console.WriteLine(" 3 - Consultar Saldo");
    Console.WriteLine(" 4 - Sair da Conta");
    Console.WriteLine("---------------------------------");
}

static void ExibirMenuDeslogado()
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Banco");
    Console.WriteLine(" 1 - Cadastrar Conta");
    Console.WriteLine(" 2 - Login");
    Console.WriteLine(" 3 - Sair");
    Console.WriteLine("---------------------------------");
}