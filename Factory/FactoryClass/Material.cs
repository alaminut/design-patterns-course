namespace Factory.FactoryClass
{
    public class Material
    {
        public bool Soft, Hard, Opaque, Shiny;

        private Material(bool soft, bool hard, bool opaque, bool shiny)
        {
            Soft = soft;
            Hard = hard;
            Opaque = opaque;
            Shiny = shiny;
        }

        public override string ToString()
        {
            return $"{nameof(Soft)}: {Soft}, {nameof(Hard)}: {Hard}, {nameof(Opaque)}: {Opaque}, {nameof(Shiny)}: {Shiny}";
        }

        // this is an inner class factory.
        // extracting this factory class outside of Material class is perfectly ok
        // however in that case you risk yourself exposing Material's ctor as public
        // unless you are developing a pure library in that case ctor can be internal
        public static class Factory
        {
            public static Material CreateSilk()
            {
                return new Material(true, false, false, false);
            }

            public static Material CreateMetal()
            {
                return new Material(false, true, true, true);
            }
        }
    }
}
