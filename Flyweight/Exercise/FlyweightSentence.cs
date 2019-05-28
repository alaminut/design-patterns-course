#region Namespace Imports

using System.Collections.Generic;
using System.Text;

#endregion

namespace Flyweight.Exercise
{
    /*
     * In this implementation of FlyweightSentence class we are
     * using methods to address memory misuses in the other Sentence class
     *
     * First we split the plain text to it's sentence in the ctor and save words
     * directly instead of plain string. This removes the need for a SplitWords method.
     *
     * Next improvement is delegating capitalization information to an inner class
     * this way we only keep a list of WordTokens for any given index to check if that
     * index needs to be capitalized. Furthermore, we implement a private cache to avoid
     * creating new WordTokens for the same indexes more than once.
     */
    public class FlyweightSentence
    {
        private readonly string[] _words;
        private readonly Dictionary<int, WordToken> _wordTokens = new Dictionary<int, WordToken>();

        public WordToken this[int index] => GetOrAddTokenFromCache(index);

        public FlyweightSentence(string plainText) { _words = plainText.Split(' '); }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _words.Length; i++)
            {
                var word = _words[i];
                sb.Append(ShouldCapitalize(i) ? word.ToUpperInvariant() : word);
                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }

        private WordToken GetOrAddTokenFromCache(int index)
        {
            if (_wordTokens.ContainsKey(index))
                return _wordTokens[index];

            var t = new WordToken();
            _wordTokens.Add(index, t);
            return t;
        }

        private bool ShouldCapitalize(int index)
        {
            return _wordTokens.ContainsKey(index) && _wordTokens[index].Capitalize;
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}