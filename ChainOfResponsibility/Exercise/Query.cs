namespace ChainOfResponsibility.Exercise
{
    public enum Attribute
    {
        Attack,
        Defense
    }
    
    public class Query
    {
        public Creature Sender { get; }
        public Attribute Attribute { get; }
        public int Value { get; set; }

        public Query(Creature sender, Attribute attribute, int value)
        {
            Sender = sender;
            Attribute = attribute;
            Value = value;
        }
    }
}
