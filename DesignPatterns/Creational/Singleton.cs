namespace DesignPatterns.Creational
{
    public class Singleton
    {
        private static readonly object _locker = new object();
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }

                return _instance;
            }
        }
    }
}
