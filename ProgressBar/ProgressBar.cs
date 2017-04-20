using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar
{
    /// <summary>
    /// 控制台进度条
    /// 使用方式：
    /// <code>
    ///     ProgressBar bar = new ProgressBar();
    ///     bar.show();
    ///     bar.update(0.2);
    /// </code>
    /// </summary>
    class ProgressBar
    {
        private bool enable = false;
        private int cursorTop = 0;
        private string title;
        private int cursorLeft = 0;
        private double percent;

        /// <summary>
        /// 创建默认标题的进度条
        /// </summary>
        public ProgressBar() : this("Processing")
        {
            
        }

        /// <summary>
        /// 创建指定标题的进度条
        /// </summary>
        /// <param name="title"></param>
        public ProgressBar(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// 显示进度条
        /// </summary>
        public void show()
        {
            if (enable == false)
            {
                enable = true;
                initDraw();
            }
            update(0.0);
        }

        /// <summary>
        /// 更新进度条。请确保已经调用过show，否则无效
        /// </summary>
        /// <param name="percent"></param>
        public void update(double percent)
        {
            if (enable == false)
            {
                return;
            }
            //更新量不到1%，不必重画进度条
            if ((int) (percent * 100) == (int) (this.percent * 100))
            {
                return;
            }
            int originCursorTop = Console.CursorTop;
            int originCursorLeft = Console.CursorLeft;

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
            Console.CursorTop = originCursorTop;    //恢复光标位置
            Console.CursorLeft = originCursorLeft;

            cursorLeft = newCursorLeft;
            this.percent = percent;
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
