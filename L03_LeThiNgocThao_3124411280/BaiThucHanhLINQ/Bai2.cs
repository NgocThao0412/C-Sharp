using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai2
    {
        public static void Run()
        {
            Console.WriteLine(" BÀI 2.1: MẢNG SỐ NGUYÊN ");
            Bai21();

            Console.WriteLine("\n BÀI 2.2: MẢNG CHUỖI ");
            Bai22();
        }

        static void Bai21()
        {
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            Console.WriteLine("\n 2.1a - Chia hết cho 4 và 3 ");
            var cauA = mangSo.Where(n => n % 4 == 0 && n % 3 == 0);
            foreach (var item in cauA) Console.WriteLine("  " + item);

            Console.WriteLine("\n 2.1b - Nhỏ hơn hoặc bằng 3 ");
            var cauB = mangSo.Where(n => n <= 3);
            foreach (var item in cauB) Console.WriteLine("  " + item);

            Console.WriteLine("\n 2.1c - Số chẵn chia đôi, số lẻ giữ nguyên ");
            var cauC = mangSo.Select(n => n % 2 == 0 ? n / 2 : n);
            foreach (var item in cauC) Console.WriteLine("  " + item);
        }

        static void Bai22()
        {
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            Console.WriteLine("\n 2.2a - Có 4 ký tự, sắp xếp tăng dần ");
            var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s);
            foreach (var item in cauA) Console.WriteLine("  " + item);

            Console.WriteLine("\n 2.2b - Dạng <chữ thường> - <CHỮ HOA> ");
            var cauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
            foreach (var item in cauB) Console.WriteLine("  " + item);

            Console.WriteLine("\n 2.2c - Chứa ký tự 'u' ");
            var cauC = mangChuoi.Where(s => s.ToLower().Contains("u"));
            foreach (var item in cauC) Console.WriteLine("  " + item);
        }
    }
}