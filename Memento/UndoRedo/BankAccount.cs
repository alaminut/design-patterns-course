using System.Collections.Generic;

namespace Memento.UndoRedo
{
    public class AccountState
    {
        public int Balance { get; }

        public AccountState(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        private readonly List<AccountState> _history = new List<AccountState>();
        private int _currentHistoryIndex;
        public int Balance { get; private set; }

        public BankAccount(int balance)
        {
            Balance = balance;
            _history.Add(new AccountState(Balance));
        }

        public AccountState Deposit(int amount)
        {
            Balance += amount;
            var s = new AccountState(Balance);
            _history.Add(s);
            ++_currentHistoryIndex;
            return s;
        }

        /*
         * For this example we implement restore operation as another "forward action" in time.
         * This way we never lose previous history after a restore operation and can even
         * undo redo those operations as well if necessary.
         */
        public AccountState Restore(AccountState state)
        {
            if (state == null) return null;
            Balance = state.Balance;
            _history.Add(state);
            ++_currentHistoryIndex;
            return state;
        }

        public AccountState Undo()
        {
            if (_currentHistoryIndex <= 0) return null;

            var s = _history[--_currentHistoryIndex];
            Balance = s.Balance;
            return s;
        }

        public AccountState Redo()
        {
            if (_currentHistoryIndex + 1 > _history.Count) return null;

            var s = _history[++_currentHistoryIndex];
            Balance = s.Balance;
            return s;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }
}
