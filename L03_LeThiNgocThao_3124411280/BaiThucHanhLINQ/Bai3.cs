using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai3
    {
        public static void Run()
        {
            Console.WriteLine(" BÀI 3.1: THỐNG KÊ MẢNG SỐ");
            Bai31();

            Console.WriteLine("\nBÀI 3.2: THỐNG KÊ MẢNG CHUỖI");
            Bai32();
        }

        static void Bai31()
        {
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            Console.WriteLine("\n 3.1a - Số lượng phần tử chẵn / lẻ ");
            Console.WriteLine("  Tổng số phần tử: " + mangSo.Length);
            Console.WriteLine("  Số phần tử chẵn: " + mangSo.Count(n => n % 2 == 0));
            Console.WriteLine("  Số phần tử lẻ: " + mangSo.Count(n => n % 2 != 0));

            Console.WriteLine("\n3.1b - Tổng, Max, Min ");
            Console.WriteLine("  Tổng giá trị: " + mangSo.Sum());
            Console.WriteLine("  Giá trị lớn nhất: " + mangSo.Max());
            Console.WriteLine("  Giá trị nhỏ nhất: " + mangSo.Min());

            Console.WriteLine("\n 3.1c - Số giá trị khác nhau ");
            Console.WriteLine("  Số giá trị khác nhau: " + mangSo.Distinct().Count());

            Console.WriteLine("\n 3.1d - Phân nhóm theo số dư chia cho 5");
            var cauD = mangSo.GroupBy(n => n % 5);
            foreach (var g in cauD)
            {
                Console.WriteLine($"  Dư {g.Key}: {string.Join(", ", g)}");
            }
        }

        static void Bai32()
        {
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì", "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            Console.WriteLine("\n--- 3.2a - Món ngắn nhất và dài nhất ---");
            int minLen = monAn.Min(m => m.Length);
            int maxLen = monAn.Max(m => m.Length);
            Console.WriteLine("  Ngắn nhất (" + minLen + " ký tự): " + string.Join(", ", monAn.Where(m => m.Length == minLen)));
            Console.WriteLine("  Dài nhất (" + maxLen + " ký tự): " + string.Join(", ", monAn.Where(m => m.Length == maxLen)));

            Console.WriteLine("\n--- 3.2b - Phân nhóm theo từ đầu tiên ---");
            var cauB = monAn.GroupBy(m => m.Split(' '));
            foreach (var g in cauB)
            {
                Console.WriteLine($"  Từ '{g.Key}': {string.Join(", ", g)}");
            }

            Console.WriteLine("\n--- 3.2c - Số món bắt đầu bằng 'Bánh' ---");
            Console.WriteLine("  Số món: " + monAn.Count(m => m.StartsWith("Bánh")));
        }
    }
