using System;
using System.Collections;

namespace ThucHanh02_Bai2_5_PhongBan
{
    // 1. LỚP NHÂN VIÊN
    class NhanVien
    {
        private string hoTen;
        private double mucLuong;
        private int soNgayVang;

        public const double TIEN_PHAT_NGAY_VANG = 100000; // 100.000 VNĐ / ngày vắng

        public string HoTen { get => hoTen; set => hoTen = value; }
        public double MucLuong { get => mucLuong; set => mucLuong = value; }
        public int SoNgayVang { get => soNgayVang; set => soNgayVang = value; }

        public NhanVien()
        {
            hoTen = "";
            mucLuong = 0;
            soNgayVang = 0;
        }

        public NhanVien(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen;
            this.mucLuong = mucLuong;
            this.soNgayVang = soNgayVang;
        }

        // Phương thức tính lương thực nhận
        public double TinhLuongThucNhan()
        {
            double luong = mucLuong - (soNgayVang * TIEN_PHAT_NGAY_VANG);
            return luong > 0 ? luong : 0; // Đảm bảo lương không bị âm
        }

        public void Nhap()
        {
            Console.Write("    Nhap ho va ten: ");
            hoTen = Console.ReadLine() ?? "";

            Console.Write("    Nhap muc luong co ban (VNĐ): ");
            double.TryParse(Console.ReadLine(), out mucLuong);

            Console.Write("    Nhap so ngay vang: ");
            int.TryParse(Console.ReadLine(), out soNgayVang);
        }

        public void Xuat()
        {
            Console.WriteLine($"Ho ten: {hoTen,-20} | Muc luong: {mucLuong,12:N0} | Ngay vang: {soNgayVang,2} | Luong thuc nhan: {TinhLuongThucNhan(),12:N0} VNĐ");
        }
    }

    // 2. LỚP PHÒNG BÀN (CHỨA N NHÂN VIÊN)
    class PhongBan
    {
        private string tenPhongBan;
        private ArrayList dsNhanVien;

        public PhongBan()
        {
            tenPhongBan = "Phong Ke Toan";
            dsNhanVien = new ArrayList();
        }

        public int SoLuong => dsNhanVien.Count;

        public void Nhap()
        {
            Console.Write("Nhap ten phong ban: ");
            tenPhongBan = Console.ReadLine() ?? "Phong Ban";

            Console.Write("Nhap so luong nhan vien (n): ");
            int.TryParse(Console.ReadLine(), out int n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n  [Nhap thong tin nhan vien thu {i + 1}]");
                NhanVien nv = new NhanVien();
                nv.Nhap();
                dsNhanVien.Add(nv);
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"\n================ DANH SÁCH LƯƠNG {tenPhongBan.ToUpper()} ================");
            if (dsNhanVien.Count == 0)
            {
                Console.WriteLine("Phong ban chua co nhan vien.");
                return;
            }

            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                ((NhanVien)dsNhanVien[i]).Xuat();
            }
        }

        // TÍNH TỔNG LƯƠNG CỦA TOÀN PHÒNG BÀN
        public double TinhTongLuongPhongBan()
        {
            double tongLuong = 0;
            foreach (NhanVien nv in dsNhanVien)
            {
                tongLuong += nv.TinhLuongThucNhan();
            }
            return tongLuong;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI 2.5: TÍNH TỔNG LƯƠNG NHÂN VIÊN PHÒNG BÀN ===");

            PhongBan pb = new PhongBan();
            pb.Nhap();
            pb.Xuat();

            double tongLuong = pb.TinhTongLuongPhongBan();
            Console.WriteLine($"\n=======================================================");
            Console.WriteLine($"-> TỔNG LƯƠNG PHÒNG BÀN PHẢI TRẢ = {tongLuong:N0} VNĐ");

            Console.ReadLine();
        }
    }
}