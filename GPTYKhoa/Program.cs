using GPTYKhoa.Views;
using System;
using System.Windows.Forms;

namespace GPTYKhoa
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new GPTlog());
        }
    }
}
