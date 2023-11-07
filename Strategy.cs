namespace MyFirstApp
{
    interface IStrategy
    {
        object doAlgorithm(object data);
    }

    class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");

            var result = this._strategy.doAlgorithm(new List<string> { "a", "b", "c", "d", "e" });
            string resultString = string.Empty;

            foreach (var element in result as List<string>)
            {
                resultString += element + ", ";
            }

            Console.WriteLine(resultString);
        }
    }

    class StrategyA : IStrategy
    {
        public object doAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class StrategyB : IStrategy
    {
        public object doAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Strategy
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy A: ");
            StrategyA strategyA = new StrategyA();

            Context context = new Context(strategyA);
            context.DoBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Strategy B: ");
            StrategyB strategyB = new StrategyB();

            context.SetStrategy(strategyB);
            context.DoBusinessLogic();

        }
    }
}
