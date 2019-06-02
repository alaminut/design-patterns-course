using System;

namespace Observer.Exercise
{
    public class Game
    {
        // todo
        // remember - no fields or properties!
        public event EventHandler<int> SwarmSizeUpdated;

        public void SpawnRat()
        {
            Swarm.Instance.Add();
            SwarmSizeUpdated?.Invoke(this, Swarm.Instance.Size);
        }

        public void DespawnRat()
        {
            Swarm.Instance.Remove();
            SwarmSizeUpdated?.Invoke(this, Swarm.Instance.Size);
        }
    }

    public class Swarm
    {
        private static Lazy<Swarm> _instance = new Lazy<Swarm>(() => new Swarm());
        public int Size { get; private set; }

        public static Swarm Instance
        {
            get { return _instance.Value; }
        }

        public void Add()
        {
            lock (Instance)
            {
                ++Size;
            }
        }

        public void Remove()
        {
            lock (Instance)
            {
                --Size;
            }
        }

        private Swarm() { }
    }

    public class Rat : IDisposable
    {
        private readonly Game _game;
        public int Attack = 1;

        public Rat(Game game)
        {
            _game = game;
            _game.SwarmSizeUpdated += UpdateAttackValue;
            _game.SpawnRat();
        }

        private void UpdateAttackValue(object sender, int swarmSize)
        {
            Attack = swarmSize;
        }

        public override string ToString()
        {
            return $"{nameof(Attack)}: {Attack}";
        }

        public void Dispose()
        {
            _game.SwarmSizeUpdated -= UpdateAttackValue;
            _game.DespawnRat();
        }
    }
}
