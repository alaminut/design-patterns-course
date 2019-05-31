using System.Collections.Generic;

namespace ChainOfResponsibility.Exercise
{
    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();

        public void Query(Query q)
        {
            var attackModifier = 0;
            var defenseModifier = 0;
            foreach (var creature in Creatures)
            {
                if (creature.GetType() == typeof(GoblinKing) && !ReferenceEquals(creature, q.Sender))
                    attackModifier++;

                if (creature is Goblin && !ReferenceEquals(creature, q.Sender))
                    defenseModifier++;
            }

            q.Value += q.Attribute == Attribute.Attack ? attackModifier : defenseModifier;
        }
    }
}
