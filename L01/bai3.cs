using System;

namespace Lab01_Bai3
{
    class Program
    {
        static void Main(String[] args)
        {
            //1. Nhập số nguyên x
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());

            //2. Nhập số nguyên y
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            //3. Tính x mũ y bằng hàm Math.Pow
            double ketQua = Math.Pow(x, y);

            //4. Xuất kết quả ra màn hình
            Console.WriteLine("Ket qua " + x + " mũ " + y + " = " + ketQua);

            // Dừng màn hình xem kết quả
            Console.ReadLine();
        }
    }
}