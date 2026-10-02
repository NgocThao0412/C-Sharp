using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai5
    {
        public static void Run()
        {
            Console.WriteLine(" BÀI 5.1: TRUY VẤN LIST<MONHOC> ");
            Bai51();

            Console.WriteLine("\nBÀI 5.2: THỐNG KÊ LIST<MONHOC> ");
            Bai52();
        }

        static void Bai51()
        {
            var dsMon = DuLieu.DS_Mon();

            Console.WriteLine("\n5.1a - Tên môn bắt đầu bằng 'Lập trình' ");
            var cauA = dsMon.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon);
            foreach (var item in cauA) Console.WriteLine("  + " + item);

            Console.WriteLine("\n 5.1b - Môn thuộc hệ CD (Tiết giảm dần, Mã tăng dần)");
            var cauB = dsMon.Where(m => m.He == "CD").OrderByDescending(m => m.SoTiet).ThenBy(m => m.MaMon);
            foreach (var item in cauB) Console.WriteLine($"  + [{item.MaMon}] {item.TenMon} ({item.SoTiet} tiết)");

            Console.WriteLine("\n 5.1c - Môn chứa từ 'web'");
            var cauC = dsMon.Where(m => m.TenMon.ToLower().Contains("web"));
            foreach (var item in cauC) Console.WriteLine($"  + {item.TenMon} (Hệ: {item.He})");

            Console.WriteLine("\n5.1d - Môn hệ KTV sắp xếp theo Mã môn ");
            var cauD = dsMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon);
            foreach (var item in cauD) Console.WriteLine($"  + [{item.MaMon}] {item.TenMon}");
        }

        static void Bai52()
        {
            var dsMon = DuLieu.DS_Mon();

            Console.WriteLine("\n 5.2a - Tổng số môn ");
            Console.WriteLine("  Tổng số môn: " + dsMon.Count);

            Console.WriteLine("\n 5.2b - Số môn bắt đầu bằng 'Lập trình'");
            Console.WriteLine("  Số môn: " + dsMon.Count(m => m.TenMon.StartsWith("Lập trình")));

            Console.WriteLine("\n 5.2c - Tổng số tiết hệ KTV ");
            Console.WriteLine("  Tổng số tiết: " + dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet));

            Console.WriteLine("\n 5.2d - Tổng số môn của mỗi hệ ");
            var cauD = dsMon.GroupBy(m => m.He);
            foreach (var g in cauD)
            {
                Console.WriteLine($"  Hệ '{g.Key}': {g.Count()} môn");
            }

            Console.WriteLine("\n 5.2e - Nhóm theo Số tiết (Giảm dần) ");
            var cauE = dsMon.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key);
            foreach (var g in cauE)
            {
                Console.WriteLine($"  {g.Key} tiết: {g.Count()} môn");
            }

            Console.WriteLine("\n 5.2f - Môn học có số tiết cao nhất ");
            byte maxTiet = dsMon.Max(m => m.SoTiet);
            var cauF = dsMon.Where(m => m.SoTiet == maxTiet);
            foreach (var item in cauF) Console.WriteLine($"  + [{item.MaMon}] {item.TenMon} ({item.SoTiet} tiết)");

            Console.WriteLine("\n--- 5.2g - Thống kê chi tiết theo Hệ ---");
            var cauG = dsMon.GroupBy(m => m.He);
            foreach (var g in cauG)
            {
                Console.WriteLine($"  Hệ '{g.Key}': {g.Count()} môn | Tổng tiết: {g.Sum(m => (int)m.SoTiet)} | Max: {g.Max(m => m.SoTiet)} | Min: {g.Min(m => m.SoTiet)}");
            }

            Console.WriteLine("\n--- 5.2h - Phân nhóm môn học theo Hệ ---");
            var cauH = dsMon.GroupBy(m => m.He);
            foreach (var g in cauH)
            {
                Console.WriteLine($"  Hệ '{g.Key}':");
                foreach (var m in g) Console.WriteLine($"    - [{m.MaMon}] {m.TenMon}");
            }

            Console.WriteLine("\n--- 5.2i - Phân nhóm theo Số tiết (Tăng dần) ---");
            var cauI = dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key);
            foreach (var g in cauI)
            {
                Console.WriteLine($"  Số tiết {g.Key}:");
                foreach (var m in g) Console.WriteLine($"    - {m.TenMon}");
            }

            Console.WriteLine("\n--- 5.2j - Hệ KTV nhóm theo Học phần (HP2, HP3...) ---");
            var cauJ = dsMon.Where(m => m.He == "KTV" && m.MaMon.Contains("_"))
                            .GroupBy(m => m.MaMon.Split('_'));
            foreach (var g in cauJ)
            {
                Console.WriteLine($"  Học phần '{g.Key}':");
                foreach (var m in g) Console.WriteLine($"    - [{m.MaMon}] {m.TenMon}");
            }

            Console.WriteLine("\n--- 5.2k - Phân nhóm theo Hệ (Số tiết > 40) ---");
            var cauK = dsMon.Where(m => m.SoTiet > 40).GroupBy(m => m.He);
            foreach (var g in cauK)
            {
                Console.WriteLine($"  Hệ '{g.Key}':");
                foreach (var m in g) Console.WriteLine($"    - {m.TenMon} ({m.SoTiet} tiết)");
            }
        }
    }
}