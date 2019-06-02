using System.Collections.Generic;
using System.Linq;

namespace State.Exercise
{
    public class CombinationLock
    {
        public const string Locked = "LOCKED";
        public const string Error = "ERROR";
        public const string Open = "OPEN";
        
        private readonly int[] _combination;
        private readonly List<int> _userInput;
        
        public CombinationLock(int [] combination)
        {
            _combination = combination;
            _userInput = new List<int>();
            Status = Locked;
        }

        // you need to be changing this on user input
        public string Status;

        public void EnterDigit(int digit)
        {
            // save the user input
            _userInput.Add(digit);
            
            // check if input and combination sizes are equal and input is valid.
            if (_userInput.Count == _combination.Length && _userInput.SequenceEqual(_combination))
            {
                Status = Open;
            }
            else if(_userInput.Count < _combination.Length)
            {
                Status = string.Join(string.Empty, _userInput);
            }
            else
            {
                _userInput.Clear();
                Status = Error;
            }
        }
    }
}
