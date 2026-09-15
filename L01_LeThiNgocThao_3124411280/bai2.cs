using System;

namespace Lab01_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. In câu lệnh yêu cầu nhập 
            Console.Write("Nhap ho ten cua ban: ");
            
            // 2. Nhập họ tên từ bàn phím
            string hoTen = Console.ReadLine();
            
            // 3. Xuất kết quả 
            Console.WriteLine("Chao ban " + hoTen + "!");
            
            Console.ReadLine();
        }
    }
}