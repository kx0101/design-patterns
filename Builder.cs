namespace MyFirstApp
{
    class Product
    {
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Part A: {PartA}");
            Console.WriteLine($"Part B: {PartB}");
            Console.WriteLine($"Part C: {PartC}");
        }
    }

    interface IBuilder
    {
        void BuilderPartA();
        void BuilderPartB();
        void BuilderPartC();
        Product GetResult();
    }

    class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public void BuilderPartA()
        {
            _product.PartA = "Part A";
        }

        public void BuilderPartB()
        {
            _product.PartB = "Part B";
        }

        public void BuilderPartC()
        {
            _product.PartC = "Part C";
        }

        public Product GetResult()
        {
            return _product;
        }
    }

    class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.BuilderPartA();
            builder.BuilderPartB();
            builder.BuilderPartC();
        }
    }

    class Builder
    {
        static void Main(string[] args)
        {
            IBuilder builder = new ConcreteBuilder();
            Director director = new Director();

            director.Construct(builder);

            Product product = builder.GetResult();

            product.ShowInfo();
        }
    }
}
