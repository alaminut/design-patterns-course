using System.Collections.Generic;

namespace Proxy.CompositeProxy
{
    /*
     * In this example we are actually using a similar pattern to
     * the composite pattern itself. GameObjects class will store the
     * data in a more memory efficient manner (ignoring the compiler and cpu optimizations)
     * and then give access to a proxy with the same interface as the original object.
     * This can be called as Composite Proxy as we are leveraging both patterns.
     */
    public class GameObjects
    {
        private readonly int _size;
        private readonly byte[] _age;
        private readonly int[] _x, _y;

        public GameObjects(int size)
        {
            _size = size;
            _age = new byte[size];
            _x = new int[size];
            _y = new int[size];
        }

        public struct GameObjectProxy
        {
            private readonly GameObjects _gameObjects;
            private readonly int _position;

            public GameObjectProxy(GameObjects gameObjects, int position)
            {
                _gameObjects = gameObjects;
                _position = position;
            }

            public ref byte Age => ref _gameObjects._age[_position];
            public ref int X => ref _gameObjects._x[_position];
            public ref int Y => ref _gameObjects._y[_position];

            public override string ToString()
            {
                return $"{nameof(X)}: {X}";
            }
        }

        public IEnumerator<GameObjectProxy> GetEnumerator()
        {
            for (var i = 0; i < _size; ++i)
                yield return new GameObjectProxy(this, i);
        }
    }
}
