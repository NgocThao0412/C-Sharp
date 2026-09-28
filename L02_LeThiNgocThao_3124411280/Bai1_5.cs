using System;

namespace ThucHanh02_Bai1_5
{
    // Lớp DonThuc biểu diễn đơn thức P(x) = a * x^n
    class DonThuc
    {
        // 1. FIELDS
        private double a; // Hệ số
        private int n;    // Số mũ (số nguyên không âm)

        // 2. PROPERTIES
        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public int N
        {
            get { return n; }
            set
            {
                if (value >= 0)
                    n = value;
                else
                    n = 0; // Đảm bảo số mũ n >= 0 theo đề bài
            }
        }

        // 3. CONSTRUCTORS
        // Default Constructor: P(x) = 0
        public DonThuc()
        {
            a = 0;
            n = 0;
        }

        // Parameterized Constructor: P(x) = a * x^n
        public DonThuc(double a, int n)
        {
            this.a = a;
            this.N = n;
        }

        // Copy Constructor
        public DonThuc(DonThuc dt)
        {
            if (dt != null)
            {
                this.a = dt.a;
                this.n = dt.n;
            }
        }

        // 4. OVERRIDE HÀM TOSTRING() ĐỂ IN ĐƠN THỨC BẰNG ĐỊNH DẠNG ĐẸP
        public override string ToString()
        {
            if (a == 0) return "0";
            if (n == 0) return $"{a}";
            if (n == 1) return $"{a}x";
            return $"{a}x^{n}";
        }

        // 5. PHƯƠNG THỨC NHẬP DỮ LIỆU
        public void Nhap()
        {
            Console.Write("  Nhap he so a: ");
            double.TryParse(Console.ReadLine(), out a);

            Console.Write("  Nhap so mu n (n >= 0): ");
            int mu;
            while (!int.TryParse(Console.ReadLine(), out mu) || mu < 0)
            {
                Console.Write("  So mu n phai la so nguyen khong am! Nhap lai n: ");
            }
            N = mu;
        }

        // 6. (a) TÍNH GIÁ TRỊ ĐƠN THỨC P(x) = a * x^n
        public double TinhGiaTri(double x)
        {
            return a * Math.Pow(x, n);
        }

        // 7. (b) TÍNH ĐẠO HÀM ĐƠN THỨC Q(x) = P'(x) = a * n * x^(n-1)
        public DonThuc DaoHam()
        {
            if (n == 0)
            {
                // Đạo hàm của hằng số bằng 0
                return new DonThuc(0, 0);
            }
            double heSoMoi = a * n;
            int soMuMoi = n - 1;
            return new DonThuc(heSoMoi, soMuMoi);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 1.5: LOP DON THUC ===");

            // Nhập đơn thức P(x)
            DonThuc P = new DonThuc();
            Console.WriteLine("\n[Nhap don thuc P(x)]");
            P.Nhap();

            Console.WriteLine($"\n-> Don thuc ban dau P(x) = {P}");

            // (a) Tính giá trị P(x) với x cho trước
            Console.Write("\n-> Nhap gia tri x: ");
            double.TryParse(Console.ReadLine(), out double x);
            double giaTri = P.TinhGiaTri(x);
            Console.WriteLine($"-> Gia tri P({x}) = {giaTri}");

            // (b) Tính đơn thức đạo hàm Q(x) = P'(x)
            DonThuc Q = P.DaoHam();
            Console.WriteLine($"\n-> Dao ham Q(x) = P'(x) = {Q}");
            Console.WriteLine($"-> Gia tri dao ham Q({x}) = {Q.TinhGiaTri(x)}");

            Console.ReadLine();
        }
    }
}