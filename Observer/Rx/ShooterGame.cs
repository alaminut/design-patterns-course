using System;
using System.Collections.Generic;
using static System.Console;

namespace Observer.Rx
{
    public class ShooterGame : IObserver<EnemyFiredEvent>
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        public void AddEnemy(Enemy enemy)
        {
            _subscriptions.Add(enemy.Subscribe(this));
            _enemies.Add(enemy);
        }

        public void RemoveSubscriptions()
        {
            foreach (var subscription in _subscriptions)
            {
                subscription.Dispose();
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(EnemyFiredEvent value)
        {
            WriteLine($"{value.Name} hit player for {value.Damage} damage");
        }
    }
}
