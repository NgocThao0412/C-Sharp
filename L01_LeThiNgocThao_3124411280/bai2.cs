using System;

namespace Lab01_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. In câu lệnh yêu cầu nhập (dùng Console.Write để con trỏ nằm cùng dòng)
            Console.Write("Nhap ho ten cua ban: ");
            
            // 2. Nhập họ tên từ bàn phím
            string hoTen = Console.ReadLine();
            
            // 3. Xuất kết quả theo đúng định dạng đề bài
            Console.WriteLine("Chao ban " + hoTen + "!");
            
            // Dừng màn hình xem kết quả
            Console.ReadLine();
        }
    }
}