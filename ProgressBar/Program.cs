using System;
using System.Threading;

namespace ProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgressBar progressBar = new ProgressBar(100);
            progressBar.show();
            Console.WriteLine("Press any key to start the progress bar...");
            Console.ReadKey(true);
            for (int i = 1; i <= 100; i++)
            {
                progressBar.update(i);
                Thread.Sleep(50);
            }
            
            Console.WriteLine("Finished. Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}