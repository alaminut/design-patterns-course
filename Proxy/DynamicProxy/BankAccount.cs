using System;

namespace Proxy.DynamicProxy
{
    class BankAccount : IBankAccount
    {
        private int _balance;

        public BankAccount(int balance)
        {
            _balance = balance;
        }

        public void Deposit(int amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposited {amount}");
        }

        public void Withdraw(int amount)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrawn {amount}");
        }

        public override string ToString()
        {
            return $"Balance: {_balance}";
        }
    }
}
