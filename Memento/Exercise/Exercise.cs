using System.Collections.Generic;
using System.Linq;

namespace Memento.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            Value = value;
        }
    }

    public class Memento
    {
        private List<int> _values;
        public IEnumerable<int> Values
        {
            get { return _values; }
        }
        
        public Memento(List<int> values)
        {
            _values = values;
        }
    }
    
    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));
            return CaptureSnapshot();
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return CaptureSnapshot();
        }

        private Memento CaptureSnapshot()
        {
            return new Memento(Tokens.Select(p => p.Value).ToList());
        }

        public void Revert(Memento m)
        {
            Tokens = m.Values.Select(v => new Token(v)).ToList();
        }

        public override string ToString()
        {
            return string.Join(",", Tokens.Select(t => t.Value));
        }
    }
}
