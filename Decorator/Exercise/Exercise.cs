namespace Decorator.Exercise
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly() { return Age < 10 ? "flying" : "too old"; }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl() { return Age > 1 ? "crawling" : "too young"; }
    }

    public class Dragon // no need for interfaces
    {
        private readonly Bird _bird = new Bird();
        private readonly Lizard _lizard = new Lizard();
        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                _lizard.Age = _bird.Age = _age;
            }
        }

        public string Fly() { return _bird.Fly(); }

        public string Crawl() { return _lizard.Crawl(); }
    }
}