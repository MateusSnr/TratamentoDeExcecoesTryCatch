using System;
using ExTratamentoDeExcecoes.Entities;
using System.Globalization;
using ExTratamentoDeExcecoes.Entities.Exceptions;

namespace ExTratamentoDeExcecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data:");

                Console.Write("Number: ");
                int n = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                string holder = Console.ReadLine();

                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Withdraw limit: ");
                double withdrawlimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(n, holder, balance,withdrawlimit);

                Console.WriteLine();

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("New balance: " + account.withdraw(amount).ToString("F2", CultureInfo.InvariantCulture));
            }
            catch(DomainException e)// Tratamento para exceções exclusivas
            {
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch (Exception e)// Tratamento para exceções gerais
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
