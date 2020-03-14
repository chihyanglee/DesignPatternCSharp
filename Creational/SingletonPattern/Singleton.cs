namespace SingletonPattern.NonThreadSafe
{
    /*
    * 1. Not thread-safe
    * 2. 當兩個thread同時走到if (instance == null)時，可能會造成產生兩個instance
    * 3. 也有可能當某一thread走到if (instance == null)時是false，但return instance時該instance當為建立完畢
    */
    sealed class Singleton
    {
        private Singleton()
        {

        }

        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}

namespace SingletonPattern.ThreadSafe
{
    /*
    * 1. thread-safe
    * 2. 利用一個共用的object來確定instance是否已被建立
    * 3. 缺點是當multi-thread要取用此instance時，是否lock的判斷會造成效能問題
    */
    sealed class Singleton
    {
        Singleton()
        {

        }
        private static readonly object padlock = new object();
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}

namespace SingletonPattern.ThreadSafeDoubleCheckLocking
{
    /*
    * 由於lock會影響performance，故在lock物件前先確認物件是否已被instantiated
    * 以提升效能
    */
    sealed class Singleton
    {
        Singleton()
        {

        }
        private static readonly object padlock = new object();
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}

namespace SingletonPattern.ThreadSafeWithoutLock
{
    /*
    * 利用static constructor來完成singleton
    * 唯一缺點是instance在app啟動時就會intantiated而佔據記憶體
    */
    sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
        private Singleton()
        {

        }
        static Singleton()
        {

        }
    }
}

namespace SingletonPattern.Lazy
{
    /*
    * 藉由System.Lazy組件來達到只有在第一次取用instance時才會呼叫constructor，
    * 相比static constructor，可以延後佔據記憶體的時間點
    */
    sealed class Singleton
    {
        private static readonly System.Lazy<Singleton> instance = new System.Lazy<Singleton>();
        // private static readonly System.Lazy<Singleton> instance = new System.Lazy<Singleton>(() => new Singleton());

        private Singleton()
        {

        }
        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}