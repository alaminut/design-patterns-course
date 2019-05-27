#region Namespace Imports

using System.Collections.Generic;

#endregion

namespace Facade.Exercise
{
    public class MagicSquareGenerator
    {
        private readonly Generator _generator;
        private readonly Splitter _splitter;
        private readonly Verifier _verifier;

        public MagicSquareGenerator()
        {
            _generator = new Generator();
            _splitter = new Splitter();
            _verifier = new Verifier();
        }

        public List<List<int>> Generate(int size)
        {
            List<List<int>> internals;
            List<List<int>> matrix;
            do
            {
                var nums = _generator.Generate(size * size);
                matrix = CreateMatrix(size, nums);
                internals = _splitter.Split(matrix);
            } while (!_verifier.Verify(internals));

            return matrix;
        }

        private static List<List<int>> CreateMatrix(int size, IReadOnlyList<int> numbers)
        {
            var matrix = new List<List<int>>(size);
            for (var row = 0; row < size; row++)
            {
                var rowList = new List<int>();
                for (var col = 0; col < size; col++) rowList.Add(numbers[row * size + col]);
                matrix.Add(rowList);
            }

            return matrix;
        }
    }
}