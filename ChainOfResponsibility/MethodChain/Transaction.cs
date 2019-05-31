using System;

namespace ChainOfResponsibility.MethodChain
{
    public class Transaction
    {
        protected BankAccount Account;
        private Transaction _next;

        public Transaction(BankAccount account)
        {
            Account = account;
        }

        public void AddTransaction(Transaction transaction)
        {
            if (_next != null)
            {
                _next.AddTransaction(transaction);
            }
            else
            {
                _next = transaction;
            }
        }

        public virtual void Handle()
        {
            if (_next != null)
                _next.Handle();
            else
            {
                Console.WriteLine($"All transactions handled: {Account}");
            }
        }
    }

    public class SafeWithdrawTransaction : Transaction
    {
        private readonly decimal _amount;

        public SafeWithdrawTransaction(BankAccount account, decimal amount) : base(account)
        {
            _amount = amount;
        }

        public override void Handle()
        {
            Console.WriteLine($"Attempting to withdraw {_amount} from account {Account}");
            var nextBalance = Account.Balance - _amount;
            if (nextBalance < 1)
                Console.WriteLine("You can't withdraw that amount from your balance");
            else
                Account.Withdraw(_amount);
            base.Handle();
        }
    }

    public class SafeDepositTransaction : Transaction
    {
        private readonly decimal _amount;

        public SafeDepositTransaction(BankAccount account, decimal amount) : base(account)
        {
            _amount = amount;
        }

        public override void Handle()
        {
            Console.WriteLine($"Doing security checks before depositing {_amount}");
            Account.Deposit(_amount);
            base.Handle();
        }
    }
}
