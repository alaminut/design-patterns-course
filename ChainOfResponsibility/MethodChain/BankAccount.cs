using System;

namespace ChainOfResponsibility.MethodChain
{
    public class BankAccount
    {
        public string Owner { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string owner, decimal balance)
        {
            Owner = owner;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount}");
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount}");
        }

        public override string ToString()
        {
            return $"{nameof(Owner)}: {Owner}, {nameof(Balance)}: {Balance}";
        }
    }
}
