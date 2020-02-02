using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStats
{
   
    public class Program
    {
       
        static void Main(string[] args)
        {

            Console.WriteLine("1. ThreadStatus");
            Console.WriteLine("2. PrintNumbers");
            Console.WriteLine("3. An array of ten thread objects");
            Console.Write("Choose a number: ");
            char ch;
            ch = Char.Parse(Console.ReadLine());
            switch (ch)
             {
                 case '1':
                     ThreadStatus();
                  break;
                 case '2':
                    Thread second = new Thread(Printer.PrintNumbers);
                    second.Start();
                 break;
                case '3':
                    //int k = 1;
                    //int[] x = new int[10];
                    //Thread[] myArray = new Thread[10];
                    for (int i = 0; i < 10; i++)
                    {
                        //myArray[i] = new Thread(new ParameterizedThreadStart(Printer.PrintNumbers)); // Use this to print 10 arrays
                        //myArray[i].Name = "ArrayThread" + i;
                        //myArray[i].Start(k);
                        //Console.WriteLine(myArray[i].Name);
                      ThreadPool.QueueUserWorkItem(Printer.printNr2, i);
                    }
                    break;

            }
          
            //   second.IsBackground = true; // This is the secondary thread which behaves as a background thread, when main thread is done second thread is done too.

            for (int i = 0; i < 10; i++) // Threads works paralell at the same time, when one is sleeping the other one is running
            {
                Console.WriteLine("Main thread is working");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name);
               

            }
        }
       
        static void ThreadStatus()
        {
            Thread.CurrentThread.Name = "Main Thread ";  //main thread name
            Console.WriteLine("Current thread name: " + Thread.CurrentThread.Name);
            Console.WriteLine("Current thread priority: " + Thread.CurrentThread.Priority);
            Console.WriteLine("Current thread status: " + Thread.CurrentThread.ThreadState);
            Console.WriteLine("Current thread background: " + Thread.CurrentThread.IsBackground);
        }

       
    }
}


//In the ThreadStats project, use the[Synchronization] 
//    Attribute to synchronize access to shared resources(the console window) in the PrintNumbers() method.