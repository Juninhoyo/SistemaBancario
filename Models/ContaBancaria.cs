using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ContaBancaria
    {
        public decimal Saldo { get; private set; }
        
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

    }
}