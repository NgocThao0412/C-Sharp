using System;
using System.Windows.Forms;

namespace ThucHanh05c
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Khởi chạy Menu chính làm màn hình đầu tiên
            Application.Run(new frmMenu());
        }
    }
}