using System;
using System.Threading;

namespace Stopwatch1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Thread.Sleep(3000);

            stopWatch.Stop();

            Console.WriteLine("Duration =" + stopWatch.GetInterval());
            Console.ReadLine();
        }
    }
}
