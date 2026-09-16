using System;

namespace Lab01_Bai13
{
    // 1. Xây dựng lớp SinhVien
    class SinhVien
    {
        // Các thuộc tính (Properties) để lưu trữ thông tin sinh viên
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int NamThu { get; set; }

        // Constructor không tham số
        public SinhVien() { }

        // Constructor có tham số
        public SinhVien(string maSV, string hoTen, string diaChi, int namThu)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiaChi = diaChi;
            NamThu = namThu;
        }

        // Phương thức thành viên dùng để nhập thông tin sinh viên
        public void NhapThongTin()
        {
            Console.WriteLine("--- NHAP THONG TIN SINH VIEN ---");
            
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();

            Console.Write("Nhap ho va ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();

            Console.Write("Nhap sinh vien nam thu (1, 2, 3, 4...): ");
            while (!int.TryParse(Console.ReadLine(), out int nam) || nam <= 0)
            {
                Console.Write("Gia tri khong hop le! Vui long nhap lai nam thu: ");
            }
            NamThu = nam;
        }

        // Phương thức thành viên dùng để xuất thông tin sinh viên
        public void XuatThongTin()
        {
            Console.WriteLine("\n--- THONG TIN SINH VIEN DA NHAP ---");
            Console.WriteLine("Ma sinh vien      : {0}", MaSV);
            Console.WriteLine("Ho va ten         : {0}", HoTen);
            Console.WriteLine("Dia chi           : {0}", DiaChi);
            Console.WriteLine("Sinh vien nam thu : {0}", NamThu);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 13: QUAN LY 1 SINH VIEN ===");

            // 2. Khởi tạo đối tượng SinhVien
            SinhVien sv = new SinhVien();

            // 3. Gọi phương thức nhập thông tin
            sv.NhapThongTin();

            // 4. Gọi phương thức xuất thông tin
            sv.XuatThongTin();

            Console.ReadLine();
        }
    }
}