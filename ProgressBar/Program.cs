using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    ProgressBar bar = new ProgressBar();
        //    bar.update(0.1);
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            ProgressBar bar = new ProgressBar();
            bar.show();
            Console.ReadKey(true);
            bar.update(0.0);
            Console.ReadKey(true);
            bar.update(0.18);
            Console.WriteLine("hahaahhahaahhaahha");
            Console.ReadKey(true);
            bar.update(1);
            Console.ReadKey(true);
            bar.update(0.5);
            Console.ReadKey(true);
            bar.update(0.1);
            Console.ReadKey(true);

            Console.WriteLine();
            Console.WriteLine();

            ProgressBar bar2 = new ProgressBar();
            bar2.show();
            bar2.update(0.70);
            Console.WriteLine();
            Console.WriteLine();

            ProgressBar bar3 = new ProgressBar();
            bar3.show();
            bar3.update(1);

            // 等待退出 
            Console.ReadKey(true);
        }
    }
}
