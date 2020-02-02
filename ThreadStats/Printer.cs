using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStats
{
    [Synchronization()]

    public class Printer
    {
        static bool done;
        static readonly object locker = new object();
        public static void PrintNumbers(object input)
        {

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                int mseconds = random.Next(1000, 10000);
                Console.WriteLine(i);
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(mseconds);
                Monitor.Enter(random);
                Console.WriteLine("Monitor");
            }
        }

       public static void printNr2(object data)
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Done" + Thread.CurrentThread.Name);
                    done = true;
                }

            }
            //Console.WriteLine("Done" + Thread.CurrentThread.Name); // This can be used to test if the Synchronization attribute works, to test it you must comment out the locker function
            //done = true;
            Console.WriteLine("Hello from the thread pool! " + data + " by " + "thread " + Thread.CurrentThread.ManagedThreadId);
        }

    }
}
