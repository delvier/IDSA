using System;

namespace IDSA
{
    public delegate void DbUpdateDelegate();

    public class EventDbUpdate
    {
        public event DbUpdateDelegate DbUpdateDone;

        public void RaiseEventDbUpdate()
        {
            FireUpdateEvent();
        }

        private void FireUpdateEvent()
        {
            if (null != DbUpdateDone)
            {
                DbUpdateDone();
            }
        }
    }

    public delegate void DbCreateDelegate();

    public class EventDbCreate
    {
        public event DbCreateDelegate DbCreateDone;

        public void RaiseEventDbCreate()
        {
            FireCreationEvent();
        }

        private void FireCreationEvent()
        {
            if (null != DbCreateDone)
            {
                DbCreateDone();
            }
        }
    }

    public delegate void DbInitializationDelegate(object sender, EventArgs e);

    public class DbInitialization : EventArgs
    {
        public bool IsDbInitialized { get; private set; }

        public DbInitialization(bool isDbInitialized)
        {
            this.IsDbInitialized = IsDbInitialized;
        }
    }

    public class EventHandlerClass
    {
        public void DbInitializationComplete(object sender, EventArgs e)
        {
            DbInitialization dbInitialization = e as DbInitialization;
            Console.WriteLine("DbInitialization state is " + dbInitialization.IsDbInitialized.ToString());
        }
    }

    public class Initialization
    {
        public event DbInitializationDelegate InitializationDone;

        public void Initialize(bool isInitialized)
        {
            DbInitialization dbInitialization = new DbInitialization(isInitialized);
            FireInitializationEvent(dbInitialization);
        }

        private void FireInitializationEvent(EventArgs e)
        {
            if (null != InitializationDone)
            {
                InitializationDone(this, e);
            }
        }
    }

    //public class DbInitializationEventArgs
    //{
    //    public delegate void MyDelegate(string str);

    //    private static MyDelegate myDelegate = null;

    //    public static void PrintLower(string str)
    //    {
    //        Console.WriteLine(str.ToLower());
    //    }

    //    public static void PrintUpper(string str)
    //    {
    //        Console.WriteLine(str.ToUpper());
    //    }

    //    public DbInitializationEventArgs()
    //    {
    //        myDelegate += PrintLower;
    //        myDelegate += new MyDelegate(PrintUpper);

    //        myDelegate.Invoke("Hello world!");
    //        myDelegate("Hello world!");
    //    }
    //}
}
