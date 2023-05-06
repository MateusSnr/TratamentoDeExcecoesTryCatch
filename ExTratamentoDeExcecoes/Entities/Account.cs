using System;
using ExTratamentoDeExcecoes.Entities.Exceptions;

namespace ExTratamentoDeExcecoes.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double withdrawLimit { get; set; }

        public Account()
        {
        }
        
        public Account(int number, string holder, double balance, double withdrawlimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            withdrawLimit = withdrawlimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public double withdraw(double amount)
        {
            if(Balance < amount)
            {
                throw new DomainException("Erro: Saldo insuficiente para saque.");
            }
            else if(amount > withdrawLimit)
            {
                throw new DomainException("Erro: Limite de saque não autorizado.");
            }
            else
            {
                return Balance-= amount;
            }
        }
    }
}
