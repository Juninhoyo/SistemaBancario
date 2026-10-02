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
                Console.WriteLine($"Depósito de R${valor} realizado com sucesso. Novo saldo: R${Saldo}");
            }
            else
            {
                Console.WriteLine("Valor de depósito inválido. O valor deve ser maior que zero.");
            }
        
        }

        public void Sacar(decimal valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de R${valor} realizado com sucesso. Novo saldo: R${Saldo}");
            }
            else
            {
                Console.WriteLine("Valor de saque inválido. O valor deve ser menor ou igual a quantidade de saldo disponível.");
            }
        }

    }
}