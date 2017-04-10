using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar
{
    class ProgressBar
    {
        private bool running = false;
        private int cursorTop = 0;
        private string title;
        private int cursorLeft = 0;

        public ProgressBar() : this("Processing")
        {
            
        }

        public ProgressBar(string title)
        {
            this.title = title;
        }

        public void update(double percent)
        {
            if (!running)
            {
                initDraw();
                running = true;
            }

            int width = Console.WindowWidth;

            ConsoleColor colorBack = Console.BackgroundColor;
            ConsoleColor colorFore = Console.ForegroundColor;

            //绘制进度条进度
            Console.BackgroundColor = ConsoleColor.Yellow; //设置进度条颜色

            int newCursorLeft = (int)((percent * width));
            if (newCursorLeft < cursorLeft)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                for (int cursor = newCursorLeft + 1; cursor <= cursorLeft; cursor++)
                {
                    if (cursor > 0)
                    {
                        Console.SetCursorPosition(cursor - 1, cursorTop + 1);
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                for (int cursor = cursorLeft; cursor <= newCursorLeft; cursor++)
                {
                    if (cursor > 0)
                    {
                        Console.SetCursorPosition(cursor - 1, cursorTop + 1);
                        Console.Write(" ");
                    }
                }
            }
            Console.BackgroundColor = colorBack;    //恢复输出颜色
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, cursorTop + 2);
            Console.Write("          ");
            Console.SetCursorPosition(0, cursorTop + 2);
            Console.Write("{0}%", (int)Math.Round(percent * 100));
            Console.ForegroundColor = colorFore;    //恢复输出颜色

            cursorLeft = newCursorLeft;
        }

        private void initDraw()
        {
            ConsoleColor colorBack = Console.BackgroundColor;
            ConsoleColor colorFore = Console.ForegroundColor;

            cursorTop = Console.CursorTop;

            // 第一行信息 
            Console.WriteLine("********************  " + title + "  ********************");

            // 第二行绘制进度条背景 
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            int width = Console.WindowWidth;
            for (int i = 0; i < width; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = colorBack;

            // 第三行输出进度 
            Console.WriteLine("0%");
        }

    }
}
