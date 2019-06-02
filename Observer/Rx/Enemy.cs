using System;
using System.Reactive.Subjects;
using static System.Console;

namespace Observer.Rx
{
    public class EnemyFiredEvent
    {
        public int Damage { get; }
        public string Name { get; }

        public EnemyFiredEvent(int damage, string name)
        {
            Damage = damage;
            Name = name;
        }
    }

    public class Enemy : IObservable<EnemyFiredEvent>
    {
        private Subject<EnemyFiredEvent> _subject = new Subject<EnemyFiredEvent>();
        public string Name { get; }

        public Enemy(string name)
        {
            Name = name;
        }

        public IDisposable Subscribe(IObserver<EnemyFiredEvent> observer)
        {
            return _subject.Subscribe(observer);
        }

        public void Fire()
        {
            WriteLine($"Enemy is firing.");
            _subject.OnNext(new EnemyFiredEvent(100, Name));
        }
    }
}
