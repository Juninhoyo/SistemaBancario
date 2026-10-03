using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaBancario.Exceptions;

namespace SistemaBancario.Models
{
    public class ContaBancaria
    {   
        private string senha;
        public decimal Saldo { get; private set; }
        public string Titular { get; private set; }
        public int NumeroConta { get; private set; }       

        public ContaBancaria(int numeroConta, string titular, string senha)
        {   
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
            {
                throw new ArgumentException("A senha deve ter no minimo 6 caracteres.");
            }

            Titular = titular;
            NumeroConta = numeroConta;
            this.senha = senha;
        } 
        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
            else
            {
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }
        
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser maior que zero.");

            if (valor > Saldo)
                throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque.");

            Saldo -= valor;        
        }

        public bool VerificarSenha(string tentativa)
        {
            return senha == tentativa;
        }
    }
}