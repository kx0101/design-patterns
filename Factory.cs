namespace MyFirstApp
{
    interface IShape
    {
        void Draw();
    }

    interface IShapeFactory
    {
        IShape Create();
    }

    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("drawing a circle...");
        }
    }

    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("drawing a square...");
        }
    }


    class CircleFactory : IShapeFactory
    {
        public IShape Create()
        {
            return new Circle();
        }
    }

    class SquareFactory : IShapeFactory
    {
        public IShape Create()
        {
            return new Square();
        }
    }

    class Client
    {
        public void DrawShape(IShapeFactory shapeFactory)
        {
            IShape shape = shapeFactory.Create();
            shape.Draw();
        }
    }

    class Factory
    {

        // changing name of main to declare an entry point
        static void main()
        {
            Client client = new Client();

            IShapeFactory circleFactory = new CircleFactory();
            client.DrawShape(circleFactory);

            IShapeFactory squareFactory = new SquareFactory();
            client.DrawShape(squareFactory);
        }
    }
}
