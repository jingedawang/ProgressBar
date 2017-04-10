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
            bool isBreak = false;
            ConsoleColor colorBack = Console.BackgroundColor;
            ConsoleColor colorFore = Console.ForegroundColor;

            Console.WriteLine("111");

            int cursorTop = Console.CursorTop;
            // 第一行信息 
            Console.WriteLine(" *********** jinjazz now working...****** ");

            // 第二行绘制进度条背景 
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            int width = Console.WindowWidth;
            for (int i = 0; i < width; i++)
            {
                Console.Write(" ");
            }
            //Console.WriteLine(" ");
            Console.BackgroundColor = colorBack;

            // 第三行输出进度 
            Console.WriteLine(" 0% ");

            // -----------------------上面绘制了一个完整的工作区域,下面开始工作

            // 开始控制进度条和进度变化 
            for (int i = 0; i < width - 1; i++)
            {
                // 绘制进度条进度 
                Console.BackgroundColor = ConsoleColor.Yellow; // 设置进度条颜色 
                Console.SetCursorPosition(i, cursorTop + 1); // 设置光标位置,参数为第几列和第几行 
                Console.Write(" "); // 移动进度条 
                Console.BackgroundColor = colorBack; // 恢复输出颜色
                                                     // 更新进度百分比,原理同上. 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, cursorTop + 2);
                Console.Write(" {0}% ", i);
                Console.ForegroundColor = colorFore;
                // 模拟实际工作中的延迟,否则进度太快 
                System.Threading.Thread.Sleep(10);
            }
            // 工作完成,根据实际情况输出信息,而且清楚提示退出的信息 
            Console.SetCursorPosition(0, cursorTop + 3);
            Console.Write(isBreak ? " break!!! " : " finished. ");
            Console.WriteLine("                        ");
            

            Console.WriteLine("------------------------------------------");
            ProgressBar bar = new ProgressBar();
            //for (int i=0; i<=1; i++)
            //{
            //    double percent = i / 100.0;
            //    bar.update(percent);
            //    System.Threading.Thread.Sleep(10);
            //}
            bar.update(0.0);
            Console.ReadKey(true);
            bar.update(0.99);
            Console.ReadKey(true);
            bar.update(1);
            Console.ReadKey(true);
            bar.update(0.5);
            Console.ReadKey(true);
            bar.update(0.1);
            Console.ReadKey(true);

            // 等待退出 
            Console.ReadKey(true);
        }
    }
}
