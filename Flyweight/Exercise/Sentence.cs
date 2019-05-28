#region Namespace Imports

using System;
using System.Text;

#endregion

namespace Flyweight.Exercise
{
    /*
     * This sentence class is an example of not using Flyweight pattern
     * class' purpose is to process a given string, and capitalize a word in
     * it at the given index. (we assume words are found by space characters)
     *
     * This naive approach splits the sentence into words and initializes a
     * boolean array that will hold the flags for a word at index to check if it
     * will be capitalized or not.
     *
     * The problem is, the larger our text becomes, the larger our _shouldCapitalize array becomes
     * and it is misuse of memory also SplitWords() method called twice in our app once in the ctor
     * and once in ToString() override. Since the _plainText does not change during the lifetime
     * of this object, it is inefficient to create a new array each time SplitWords called.
     *
     * Our better implementation will try to avoid these misusing of memory situations by
     * using Flyweight pattern.
     */
    public class Sentence
    {
        private readonly string _plainText;
        private readonly bool[] _shouldCapitalize;

        public Sentence(string plainText)
        {
            _plainText = plainText;
            var words = SplitWords();
            _shouldCapitalize = new bool[words.Length];
        }

        public void CapitalizeWord(int index) { _shouldCapitalize[index] = true; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var words = SplitWords();
            for (var i = 0; i < _shouldCapitalize.Length; i++)
            {
                var b = _shouldCapitalize[i];
                sb.Append(b ? words[i].ToUpperInvariant() : words[i]);
                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }

        private string[] SplitWords() { return _plainText.Split(' ', StringSplitOptions.RemoveEmptyEntries); }
    }
}