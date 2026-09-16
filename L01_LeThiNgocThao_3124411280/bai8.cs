using System;

namespace Lab01_Bai8
{
    // 1. Xây dựng lớp chứa phương thức hoán vị
    class Swapper
    {
        // Phương thức hoán vị 2 số thực dùng từ khóa ref
        public void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HOAN VI HAI SO THUC DUNG THAM CHIEU REF");

            // Nhập 2 số thực từ bàn phím
            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc b: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Truoc khi hoan vi ---");
            Console.WriteLine("a = {0}, b = {1}", a, b);

            // 2. Khởi tạo đối tượng từ lớp Swapper
            Swapper swapper = new Swapper();

            // 3. Gọi phương thức HoanVi với từ khóa ref
            swapper.HoanVi(ref a, ref b);

            Console.WriteLine("\n--- Sau khi hoan vi ---");
            Console.WriteLine("a = {0}, b = {1}", a, b);

            Console.ReadLine();
        }
    }
}