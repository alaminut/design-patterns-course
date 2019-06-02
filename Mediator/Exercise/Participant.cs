namespace Mediator.Exercise
{
    public class Participant
    {
        private readonly Mediator _mediator;
        private readonly string _id;
        public int Value { get; set; } = 0;

        public Participant(Mediator mediator)
        {
            _mediator = mediator;
            _id = _mediator.Register(this);
        }

        public void Say(int n)
        {
            _mediator.AnnounceValue(_id, n);
        }

        public void ReceiveValue(int n)
        {
            Value += n;
        }

        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, {nameof(Value)}: {Value}";
        }
    }
}
