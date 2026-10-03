using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaBancario.Exceptions;

namespace SistemaBancario.Models
{
    public class Banco
    {
        private List<ContaBancaria> contas = new List<ContaBancaria>();
        private int numeroContaSequencial = 1;
        private int GerarNumeroConta()
        {
            return numeroContaSequencial++;
        }

        public ContaBancaria CadastrarConta(string titular, string senha)
        {     
            int numero = GerarNumeroConta();
            ContaBancaria conta = new ContaBancaria(numero, titular, senha);
            contas.Add(conta);
            return conta;
        }

        public ContaBancaria BuscarConta(int numeroConta)
        {
            ContaBancaria? conta = contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null)
            {
                throw new ContaNaoEncontradaException("Conta não encontrada.");
            }
            return conta;
        }

        public ContaBancaria Login(int numeroConta, string senha)
        {
            ContaBancaria? conta = contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
            if (conta == null || !conta.VerificarSenha(senha))
            {
                throw new CredenciaisInvalidasException("Número da conta ou senha inválidos.");
            }
            return conta;
        }
    }
}