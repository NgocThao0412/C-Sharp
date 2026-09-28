using System;
using System.Collections.Generic;

namespace ThucHanh02_Bai3_5
{
    // Lớp cơ sở trừu tượng NhanVien (Chứa thông tin dùng chung)
    abstract class NhanVien
    {
        // 1. FIELDS / PROPERTIES CHUNG
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        public NhanVien()
        {
            MaNV = "";
            HoTen = "";
        }

        public NhanVien(string maNV, string hoTen)
        {
            MaNV = maNV;
            HoTen = hoTen;
        }

        // 2. PHƯƠNG THỨC TRỪU TƯỢNG (ĐA HÌNH) TÍNH LƯƠNG
        public abstract double TinhLuong();

        // 3. PHƯƠNG THỨC NHẬP / XUẤT ẢO (VIRTUAL)
        public virtual void Nhap()
        {
            Console.Write("  Nhap Ma NV: ");
            MaNV = Console.ReadLine() ?? "";

            Console.Write("  Nhap Ho va ten: ");
            HoTen = Console.ReadLine() ?? "";
        }

        public virtual void Xuat()
        {
            Console.Write($"Ma NV: {MaNV,-8} | Ho ten: {HoTen,-20} ");
        }
    }

    // Lớp con 1: Nhân viên kinh doanh kế thừa từ NhanVien
    class NhanVienKinhDoanh : NhanVien
    {
        public double LuongCoBan { get; set; }
        public int SoHopDong { get; set; }

        public const double TIEN_THUONG_HOP_DONG = 500000; // 500.000 VNĐ / 1 hợp đồng

        public NhanVienKinhDoanh() : base()
        {
            LuongCoBan = 0;
            SoHopDong = 0;
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, int soHopDong)
            : base(maNV, hoTen)
        {
            LuongCoBan = luongCoBan;
            SoHopDong = soHopDong;
        }

        // Ghi đè phương thức TinhLuong() cho Nhân viên kinh doanh
        public override double TinhLuong()
        {
            return LuongCoBan + (SoHopDong * TIEN_THUONG_HOP_DONG);
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("  Nhap Luong co ban (VNĐ): ");
            double.TryParse(Console.ReadLine(), out double lcb);
            LuongCoBan = lcb;

            Console.Write("  Nhap So hop dong da ky: ");
            int.TryParse(Console.ReadLine(), out int shd);
            SoHopDong = shd;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"| Bo phan: Kinh doanh | Luong CB: {LuongCoBan,11:N0} | Hop dong: {SoHopDong,2} | Luong: {TinhLuong(),12:N0} VNĐ");
        }
    }

    // Lớp con 2: Nhân viên sản xuất kế thừa từ NhanVien
    class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public const double DON_GIA_SAN_PHAM = 1000; // 1.000 VNĐ / 1 sản phẩm

        public NhanVienSanXuat() : base()
        {
            SoSanPham = 0;
        }

        public NhanVienSanXuat(string maNV, string hoTen, int soSanPham)
            : base(maNV, hoTen)
        {
            SoSanPham = soSanPham;
        }

        // Ghi đè phương thức TinhLuong() cho Nhân viên sản xuất
        public override double TinhLuong()
        {
            double luongSp = SoSanPham * DON_GIA_SAN_PHAM;
            // Nếu sản xuất trên 3000 sản phẩm thì thưởng thêm 5% lương
            if (SoSanPham > 3000)
            {
                return luongSp * 1.05;
            }
            return luongSp;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("  Nhap So luong san pham: ");
            int.TryParse(Console.ReadLine(), out int ssp);
            SoSanPham = ssp;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"| Bo phan: San xuat  | San pham: {SoSanPham,6:N0} | Luong: {TinhLuong(),12:N0} VNĐ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI 3.5: TÍNH LƯƠNG NHÂN VIÊN (KẾ THỪA & ĐA HÌNH) ===");

            List<NhanVien> dsNV = new List<NhanVien>();

            Console.Write("Nhap so luong nhan vien trong cong ty (n): ");
            int.TryParse(Console.ReadLine(), out int n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n[Nhap thong tin nhan vien thu {i + 1}]");
                Console.WriteLine("  Chon loai nhan vien: 1. Kinh doanh | 2. San xuat");
                Console.Write("  Lua chon (1 hoac 2): ");
                string chon = Console.ReadLine() ?? "1";

                NhanVien nv;
                if (chon == "2")
                {
                    nv = new NhanVienSanXuat();
                }
                else
                {
                    nv = new NhanVienKinhDoanh();
                }

                nv.Nhap();
                dsNV.Add(nv); // Lưu đối tượng lớp con vào danh sách kiểu lớp cha
            }

            Console.WriteLine("\n==================== DANH SÁCH LƯƠNG NHÂN VIÊN ====================");
            double tongLuong = 0;
            for (int i = 0; i < dsNV.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                dsNV[i].Xuat(); // Đa hình: tự động gọi đúng hàm Xuat() và TinhLuong() của lớp con tương ứng
                tongLuong += dsNV[i].TinhLuong();
            }

            Console.WriteLine("==========================================================================");
            Console.WriteLine($"-> TỔNG LƯƠNG CÔNG TY PHẢI TRẢ = {tongLuong:N0} VNĐ");

            Console.ReadLine();
        }
    }
}