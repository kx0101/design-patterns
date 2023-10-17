namespace MyFirstApp
{
    interface ISubject
    {
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void NotifySubscribers();
    }

    interface ISubscriber
    {
        void Update(ISubject subject);
    }

    class Subscriber : ISubscriber
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void Update(ISubject subject)
        {
            Console.WriteLine($"{name} got notified by {subject}");
        }
    }

    class YoutubeChannel : ISubject
    {
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void NotifySubscribers()
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(this);
            }
        }

        public void UploadVideo()
        {
            Console.WriteLine("Uploading video...");
            NotifySubscribers();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            YoutubeChannel channel = new YoutubeChannel();

            Subscriber liakos = new Subscriber("Liakos");
            Subscriber hixx = new Subscriber("Hixx");

            channel.AddSubscriber(liakos);
            channel.AddSubscriber(hixx);

            channel.UploadVideo();

            channel.RemoveSubscriber(hixx);

            channel.UploadVideo();
        }
    }
}
