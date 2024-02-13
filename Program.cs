using System.Runtime.InteropServices;

namespace ConsoleAppClasswork1Progranmm
{
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBox")]
        public static extern int MyMessageBox(IntPtr hWnd, String text, String caption, uint type);
        static void Main()
        {
            string summary = "Резюме.Обязанности: поддержка полного жизненного цикла информационной системы, проектирование и внедрение автоматизации сети";
            int messageCount = 3;
            string[] parts = new string[messageCount];
            int partLength = summary.Length / messageCount;
            for (int i = 0; i < messageCount; i++)
            {
                int start = partLength * i;
                int end = (i == messageCount - 1) ? summary.Length : start + partLength;
                parts[i] = summary.Substring(start, end - start);
            }
            int averageCharsPerPage = summary.Length / messageCount;
            for (int i = 0; i < messageCount - 1; i++)
            {
                MyMessageBox(IntPtr.Zero, parts[i], $"Часть {i + 1} из {messageCount}", 0);
            }
            string lastCaption = $"Среднее кол-во символов: {averageCharsPerPage}";
            MyMessageBox(IntPtr.Zero, parts[messageCount - 1], lastCaption, 0);
        }
    }
}