using System;

namespace Lab01_Bai9
{
    // 1. Xây dựng lớp c
    class MinMaxFinder
    {
        // Phương thức nhận 3 số thực và xuất ra max, min qua 2 tham số out
        public void TimMinMax(double a, double b, double c, out double max, out double min)
        {
            // 1. Tìm giá trị lớn nhất
            max = a;
            if (b > max) max = b;
            if (c > max) max = c;

            // 2. Tìm giá trị nhỏ nhất
            min = a;
            if (b < min) min = b;
            if (c < min) min = c;
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TIM MAX VA MIN DUNG THAM CHIEU OUT");

            // Nhập 3 số thực từ bàn phím
            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc c: ");
            double c = double.Parse(Console.ReadLine());

            // Khai báo 2 biến để hứng kết quả out
            double maxResult, minResult;

            // Khởi tạo đối tượng từ lớp MinMaxFinder
            MinMaxFinder finder = new MinMaxFinder();

            // Gọi phương thức TimMinMax truyền vào từ khóa out
            finder.TimMinMax(a, b, c, out maxResult, out minResult);

            // In kết quả
            Console.WriteLine("\n--- KET QUA ---");
            Console.WriteLine("Gia tri lon nhat (Max) la: {0}", maxResult);
            Console.WriteLine("Gia tri nho nhat (Min) la: {0}", minResult);

            Console.ReadLine();
        }
    }
}