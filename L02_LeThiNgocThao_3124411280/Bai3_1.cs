using System;

namespace ThucHanh02_Bai3_1
{
    // Lớp SinhVien thực thi interface IComparable<SinhVien> để hỗ trợ Array.Sort()
    class SinhVien : IComparable<SinhVien>
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }

        public SinhVien()
        {
            MaSV = "";
            HoTen = "";
            DiemTB = 0;
        }

        public SinhVien(string maSV, string hoTen, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        public void Nhap()
        {
            Console.Write("  Nhap Ma SV: ");
            MaSV = Console.ReadLine() ?? "";

            Console.Write("  Nhap Ho va ten: ");
            HoTen = Console.ReadLine() ?? "";

            Console.Write("  Nhap Diem trung binh: ");
            double.TryParse(Console.ReadLine(), out double dtb);
            DiemTB = dtb;
        }

        public void Xuat()
        {
            Console.WriteLine($"Ma SV: {MaSV,-10} | Ho ten: {HoTen,-20} | Diem TB: {DiemTB,4:F1}");
        }

        // Thực thi phương thức CompareTo để định nghĩa tiêu chuẩn so sánh (Sắp xếp giảm dần theo Điểm TB)
        public int CompareTo(SinhVien? other)
        {
            if (other == null) return 1;
            // Sắp xếp giảm dần theo điểm trung bình
            return other.DiemTB.CompareTo(this.DiemTB);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI 3.1: SẮP XẾP ĐỐI TƯỢNG BẰNG ARRAY.SORT() VỚI ICOMPARABLE ===");

            Console.Write("Nhap so luong sinh vien (n): ");
            int.TryParse(Console.ReadLine(), out int n);

            SinhVien[] ds = new SinhVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n[Nhap thong tin sinh vien thu {i + 1}]");
                ds[i] = new SinhVien();
                ds[i].Nhap();
            }

            Console.WriteLine("\n================ DANH SÁCH BAN ĐẦU ================");
            foreach (var sv in ds) sv.Xuat();

            // Gọi phương thức tĩnh Array.Sort() của C#
            Array.Sort(ds);

            Console.WriteLine("\n======== DANH SÁCH SẮP XẾP GIẢM DẦN THEO ĐIỂM TB (ARRAY.SORT) ========");
            foreach (var sv in ds) sv.Xuat();

            Console.ReadLine();
        }
    }
}
