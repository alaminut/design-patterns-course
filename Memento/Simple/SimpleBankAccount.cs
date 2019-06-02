namespace Memento.Simple
{
    public class SimpleAccountState
    {
        public int Balance { get; }
        public SimpleAccountState(int balance)
        {
            Balance = balance;
        }
    }
    
    public class SimpleBankAccount
    {
        public int Balance { get; private set; }
        public SimpleBankAccount(int balance)
        {
            Balance = balance;
        }

        public SimpleAccountState Deposit(int amount)
        {
            Balance += amount;
            return new SimpleAccountState(Balance);
        }

        public void Restore(SimpleAccountState state)
        {
            Balance = state.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }
}
