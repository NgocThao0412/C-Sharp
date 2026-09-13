using System;

namespace Lab01_Bai4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhập dữ liệu
            Console.Write("Nhap so nguyen x: ");
            bool isX = int.TryParse(Console.ReadLine(), out int x);

            Console.Write("Nhap so nguyen y: ");
            bool isY = int.TryParse(Console.ReadLine(), out int y);

            // Dùng câu lệnh if đơn giản kiểm tra cả x và y [1]
            if (isX && isY)
            {
                long ketQua = (long)Math.Pow(x, y);
                Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
            }
            else
            {
                Console.WriteLine("Loi: x hoac y khong phai la so nguyen hop le!");
            }

            Console.ReadLine();
        }
    }
}