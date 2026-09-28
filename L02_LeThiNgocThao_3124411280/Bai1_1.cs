using System;

namespace ThucHanh02_Bai1_1
{
    // Lớp SinhVien đầy đủ: Field, Property, Constructor, Method
    class SinhVien
    {
        // 1. FIELDS (Trường dữ liệu private)
        private string hoTen;
        private int namSinh;

        // 2. PROPERTIES (Thuộc tính đóng gói)
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set
            {
                int namHienTai = DateTime.Now.Year;
                if (value > 0 && value <= namHienTai)
                    namSinh = value;
                else
                    namSinh = namHienTai;
            }
        }

        // 3. CONSTRUCTORS (Hàm khởi tạo)
        // Default Constructor
        public SinhVien()
        {
            hoTen = "";
            namSinh = DateTime.Now.Year;
        }

        // Parameterized Constructor (Có tham số)
        public SinhVien(string hoTen, int namSinh)
        {
            this.hoTen = hoTen;
            this.NamSinh = namSinh;
        }

        // Copy Constructor (Sao chép)
        public SinhVien(SinhVien sv)
        {
            if (sv != null)
            {
                this.hoTen = sv.hoTen;
                this.namSinh = sv.namSinh;
            }
        }

        // 4. METHODS (Phương thức)
        // Phương thức tính tuổi
        public int TinhTuoi()
        {
            return DateTime.Now.Year - namSinh;
        }

        // Phương thức nhập thông tin
        public void Nhap()
        {
            Console.Write("Nhap ho va ten sinh vien: ");
            hoTen = Console.ReadLine();

            Console.Write("Nhap nam sinh: ");
            int namHienTai = DateTime.Now.Year;
            while (!int.TryParse(Console.ReadLine(), out namSinh) || namSinh <= 0 || namSinh > namHienTai)
            {
                Console.Write("Nam sinh khong hop le! Nhap lai nam sinh (1 - {0}): ", namHienTai);
            }
        }

        // Phương thức xuất thông tin
        public void Xuat()
        {
            Console.WriteLine("Ho va ten : {0}", hoTen);
            Console.WriteLine("Nam sinh  : {0}", namSinh);
            Console.WriteLine("Tuoi      : {0} tuoi", TinhTuoi());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 1.1: TINH TUOI SINH VIEN ===");

            SinhVien sv = new SinhVien();
            sv.Nhap();

            Console.WriteLine("\n--- THONG TIN SINH VIEN ---");
            sv.Xuat();

            Console.ReadLine();
        }
    }
}