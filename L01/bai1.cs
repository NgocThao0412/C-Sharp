using System;

namespace Lab01_Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Yêu cầu người dùng nhập họ tên
            Console.Write("Nhap ho va ten cua ban: ");
            
            // Đọc chuỗi họ tên vừa nhập từ bàn phím
            string hoTen = Console.ReadLine();
            
            // Xuất họ tên ra màn hình console
            Console.WriteLine("Xin chao: " + hoTen);
            
            // Tạm dừng màn hình để xem kết quả
            Console.WriteLine("Nhan pham Enter de thoat...");
            Console.ReadLine();
        }
    }
}