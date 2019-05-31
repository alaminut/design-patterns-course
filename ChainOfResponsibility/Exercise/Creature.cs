namespace ChainOfResponsibility.Exercise
{
    public abstract class Creature
    {
        protected Game Game;
        private int _attack, _defense;

        public int Attack
        {
            get
            {
                var q = new Query(this, Attribute.Attack, _attack);
                Game.Query(q);
                return q.Value;
            }
            protected set { _attack = value; }
        }

        public int Defense
        {
            get
            {
                var q = new Query(this, Attribute.Defense, _defense);
                Game.Query(q);
                return q.Value;   
            }
            protected set { _defense = value; }
        }

        protected Creature(Game game)
        {
            Game = game;
        }

        public override string ToString()
        {
            return $"{GetType().Name} has attack: {Attack}, defense: {Defense}";
        }
    }
    
    public class Goblin : Creature
    {
        public Goblin(Game game) : base(game)
        {
            Attack = 1;
            Defense = 1;
        }
    }
    
    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game)
        {
            Attack = 3;
            Defense = 3;
        }
    }
}
