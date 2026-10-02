using System;
using System.Text;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Bai2.Run();
            Bai3.Run();
            Bai5.Run();

            Console.WriteLine("\n--> Em đã hoàn thành bài tập. Còn mấy bài khác khó quá em không làm được. Em thoát nha!");
            Console.ReadKey();
        }
    }
}