using System;

namespace Lab01_Bai14
{
    // 1. Xây dựng lớp NhanVien
    class NhanVien
    {
        // Các thuộc tính lưu trữ thông tin nhân viên
        public string HoTen { get; set; }
        public double MucLuong { get; set; }      // Mức lương cơ bản (VNĐ)
        public int SoNgayVang { get; set; }        // Số ngày vắng

        // Const định mức phạt cho 1 ngày vắng
        private const double TIEN_PHAT_NGAY_VANG = 100000;

        // Constructor
        public NhanVien() { }

        public NhanVien(string hoTen, double mucLuong, int soNgayVang)
        {
            HoTen = hoTen;
            MucLuong = mucLuong;
            SoNgayVang = soNgayVang;
        }

        // Phương thức tính lương thực nhận
        public double TinhLuongThucNhan()
        {
            double luongThucNhan = MucLuong - (SoNgayVang * TIEN_PHAT_NGAY_VANG);
            
            // Nếu phạt nhiều hơn lương thì lương nhận = 0
            return luongThucNhan > 0 ? luongThucNhan : 0;
        }

        // Phương thức nhập thông tin nhân viên
        public void NhapThongTin()
        {
            Console.WriteLine("--- NHAP THONG TIN NHAN VIEN ---");

            Console.Write("Nhap ho va ten: ");
            HoTen = Console.ReadLine();

            // Nhập mức lương và kiểm tra hợp lệ
            Console.Write("Nhap muc luong (VND): ");
            double luong;
            while (!double.TryParse(Console.ReadLine(), out luong) || luong < 0)
            {
                Console.Write("Gia tri khong hop le! Nhap lai muc luong: ");
            }
            MucLuong = luong;

            // Nhập số ngày vắng và kiểm tra hợp lệ
            Console.Write("Nhap so ngay vang: ");
            int ngayVang;
            while (!int.TryParse(Console.ReadLine(), out ngayVang) || ngayVang < 0)
            {
                Console.Write("Gia tri khong hop le! Nhap lai so ngay vang: ");
            }
            SoNgayVang = ngayVang;
        }

        // Phương thức xuất thông tin và bảng lương
        public void XuatThongTin()
        {
            Console.WriteLine("\n--- BANG LUONG NHAN VIEN ---");
            Console.WriteLine("Ho va ten        : {0}", HoTen);
            Console.WriteLine("Muc luong co ban : {0:N0} VNĐ", MucLuong);
            Console.WriteLine("So ngay vang     : {0} ngay", SoNgayVang);
            Console.WriteLine("Tien bị tru      : {0:N0} VNĐ", SoNgayVang * TIEN_PHAT_NGAY_VANG);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("LUONG THUC NHAN  : {0:N0} VNĐ", TinhLuongThucNhan());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 14: TINH LUONG NHAN VIEN ===");

            // Khởi tạo đối tượng NhanVien
            NhanVien nv = new NhanVien();

            // Nhập và xuất thông tin
            nv.NhapThongTin();
            nv.XuatThongTin();

            Console.ReadLine();
        }
    }
}