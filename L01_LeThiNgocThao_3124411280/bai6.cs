using System;

namespace Lab01_Bai6
{
    // 1. Xây dựng lớp chứa phương thức tìm giá trị lớn nhất
    class TimMaxHelper
    {
        // Phương thức nhận 3 số nguyên và trả về max
        public int TimMax(int a, int b, int c)
        {
            int max = a;

            if (b > max)
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            }

            return max; // Trả về giá trị lớn nhất cho nơi gọi hàm
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 6: TIM GIATRI LON NHAT CUA 3 SO NGUYEN ===");

            // Nhập 3 số nguyên từ bàn phím
            Console.Write("Nhap so thu nhat (a): ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Nhap so thu hai (b): ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Nhap so thu ba (c): ");
            int c = int.Parse(Console.ReadLine());

            // Khởi tạo đối tượng của lớp TimMaxHelper
            TimMaxHelper helper = new TimMaxHelper();

            // Gọi phương thức 
            int giaTriLonNhat = helper.TimMax(a, b, c);

            // In KQ
            Console.WriteLine("\n-> Gia tri lon nhat trong 3 so ({0}, {1}, {2}) la: {3}", a, b, c, giaTriLonNhat);

            Console.ReadLine();
        }
    }
}