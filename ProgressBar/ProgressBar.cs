using System;

namespace ProgressBar
{
    /// <summary>
    /// A simple console progress bar.
    /// </summary>
    /// <example>
    /// There are three modes can be used.
    /// Mode 1: Percentage mode
    /// <code>
    ///     ProgressBar progressBar = new ProgressBar();
    ///     progressBar.Show();
    ///     progressBar.Update(0.01);
    /// </code>
    /// Mode 2: Item count mode
    /// <code>
    ///     ProgressBar progressBar = new ProgressBar(100);
    ///     progressBar.Show();
    ///     progressBar.Update(1);
    /// </code>
    /// Mode 3: Increase mode
    /// <code>
    ///     ProgressBar progressBar = new ProgressBar(100);
    ///     progressBar.Show();
    ///     progressBar.UpdateOnce();
    /// </code>
    /// </example>
    public class ProgressBar
    {
        /// <summary>
        /// Create a default progress bar.
        /// </summary>
        /// <remarks>
        /// The progress bar created this way can only updated by percent.
        /// </remarks>
        public ProgressBar()
        {
        }

        /// <summary>
        /// Create a progress bar with specified total number.
        /// </summary>
        /// <param name="total">Total number which indicates the 100% progress.</param>
        public ProgressBar(int total)
        {
            this.total = total;
        }

        /// <summary>
        /// Show the progress bar.
        /// </summary>
        public void Show()
        {
            if (enabled == false)
            {
                enabled = true;
                cursorTop = Console.CursorTop;
                Console.WriteLine("0%");
            }
        }

        /// <summary>
        /// Update the progress by one item.
        /// </summary>
        public void UpdateOnce()
        {
            Update(++count * 1.0 / total);
        }

        /// <summary>
        /// Update the progress bar by count.
        /// </summary>
        /// <param name="count">The processed item count.</param>
        public void Update(int count)
        {
            this.count = count;
            Update(count * 1.0 / total);
        }

        /// <summary>
        /// Update the progress by percent.
        /// </summary>
        /// <param name="percent">The processed percentage.</param>
        public void Update(double percent)
        {
            if (enabled == false)
            {
                return;
            }
            // Update only when percentage reaches a higher integer.
            if (Math.Round(percent * 100) <= this.percentage)
            {
                return;
            }
            int originCursorTop = Console.CursorTop;
            int originCursorLeft = Console.CursorLeft;
            ConsoleColor originBackgroundColor = Console.BackgroundColor;
            ConsoleColor originForegroundColor = Console.ForegroundColor;

            int width = Console.WindowWidth - textWidth;
            percentage = (int)Math.Round(percent * 100);

            // Write percentage text.
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', textWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write($"{percentage}%");

            // Print progress bar.
            Console.BackgroundColor = originForegroundColor;
            int newCursorLeft = (int)Math.Round(percent * width);
            for (int cursor = cursorLeft; cursor < newCursorLeft; cursor++)
            {
                Console.SetCursorPosition(textWidth + cursor, cursorTop);
                Console.Write(' ');
            }

            // Restore original color and cursor position.
            Console.BackgroundColor = originBackgroundColor;
            Console.ForegroundColor = originForegroundColor;
            Console.CursorTop = originCursorTop;
            Console.CursorLeft = originCursorLeft;

            // Record the drawn position.
            cursorLeft = newCursorLeft;
        }

        // A flag used for preventing multiple initialization.
        private bool enabled = false;
        // The row index of the progress bar.
        private int cursorTop = 0;
        // The column index of the progress bar.
        private int cursorLeft = 0;
        // The percentage of the progress.
        private int percentage = 0;
        // The current count of the progress.
        private int count = 0;
        // Total item number that to be processed.
        private int total = 0;
        // The text width on the left side of the progress bar.
        private const int textWidth = 6;
    }
}