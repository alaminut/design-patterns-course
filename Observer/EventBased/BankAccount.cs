using System;
using static System.Console;

namespace Observer.EventBased
{
    public class AccountBalanceChangedEventArgs : EventArgs
    {
        public int NewBalance { get; }
        public AccountBalanceChangedEventArgs(int newBalance)
        {
            NewBalance = newBalance;
        }
    }
    
    public class BankAccount
    {
        public int Balance { get; private set; }
        public event EventHandler<AccountBalanceChangedEventArgs> BalanceChanged;
        
        public BankAccount(int balance)
        {
            Balance = balance;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
            WriteLine($"Deposited {amount}, balance is {Balance}");
            BalanceChanged?.Invoke(this, new AccountBalanceChangedEventArgs(Balance));
        }
    }
}
