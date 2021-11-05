using System;
using System.Threading;

namespace Kitchen.Infrastructure.Utils
{
    public class Logger
    {
        public static void Log(string action)
        {
            Console.WriteLine($"{getPrefix()}: {action}");
        }

        private static string getPrefix()
        {
            return $"{DateTime.Now:HH:mm:ss:ffff} (Thread {Thread.CurrentThread.ManagedThreadId})";
        }
    }
}