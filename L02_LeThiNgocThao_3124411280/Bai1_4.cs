using System;

namespace ThucHanh02_Bai1_4
{
    // Lớp PhanSo biểu diễn và xử lý các phép toán trên phân số
    class PhanSo
    {
        // 1. FIELDS
        private int tuSo;
        private int mauSo;

        // 2. PROPERTIES
        public int TuSo
        {
            get { return tuSo; }
            set { tuSo = value; }
        }

        public int MauSo
        {
            get { return mauSo; }
            set
            {
                if (value != 0)
                    mauSo = value;
                else
                    mauSo = 1; // Mặc định mẫu số bằng 1 nếu lỡ gán 0
            }
        }

        // 3. CONSTRUCTORS
        // Default Constructor: Phân số mặc định = 0/1
        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }

        // Parameterized Constructor: Khởi tạo với tử số và mẫu số
        public PhanSo(int tuSo, int mauSo = 1)
        {
            this.tuSo = tuSo;
            this.MauSo = mauSo; // Gọi Property để kiểm tra mẫu số khác 0
            RutGon();
        }

        // Copy Constructor: Khởi tạo sao chép từ một phân số khác
        public PhanSo(PhanSo ps)
        {
            if (ps != null)
            {
                this.tuSo = ps.tuSo;
                this.mauSo = ps.mauSo;
            }
        }

        // 4. HÀM PHỤ HỖ TRỢ: TÌM UCLN VÀ RÚT GỌN PHÂN SỐ
        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public void RutGon()
        {
            int ucln = UCLN(tuSo, mauSo);
            if (ucln > 1)
            {
                tuSo /= ucln;
                mauSo /= ucln;
            }

            // Đưa dấu âm lên tử số nếu mẫu số âm
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }

        // 5. OVERRIDE HÀM TOSTRING() ĐỂ XUẤT PHÂN SỐ
        public override string ToString()
        {
            if (mauSo == 1)
                return $"{tuSo}";
            if (tuSo == 0)
                return "0";
            return $"{tuSo}/{mauSo}";
        }

        // 6. ĐA NĂNG TOÁN TỬ MỘT NGÔI (+, -)
        public static PhanSo operator +(PhanSo ps)
        {
            return new PhanSo(ps);
        }

        public static PhanSo operator -(PhanSo ps)
        {
            return new PhanSo(-ps.tuSo, ps.mauSo);
        }

        // 7. ĐA NĂNG TOÁN TỬ HAI NGÔI (+, -, *, /)
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tu = a.tuSo * b.mauSo + b.tuSo * a.mauSo;
            int mau = a.mauSo * b.mauSo;
            return new PhanSo(tu, mau);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int tu = a.tuSo * b.mauSo - b.tuSo * a.mauSo;
            int mau = a.mauSo * b.mauSo;
            return new PhanSo(tu, mau);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int tu = a.tuSo * b.tuSo;
            int mau = a.mauSo * b.mauSo;
            return new PhanSo(tu, mau);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            int tu = a.tuSo * b.mauSo;
            int mau = a.mauSo * b.tuSo;
            return new PhanSo(tu, mau);
        }

        // 8. ĐA NĂNG TOÁN TỬ SO SÁNH (>, <, >=, <=, ==, !=)
        public static bool operator ==(PhanSo a, PhanSo b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.tuSo * b.mauSo == b.tuSo * a.mauSo;
        }

        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.tuSo * b.mauSo > b.tuSo * a.mauSo;
        }

        public static bool operator <(PhanSo a, PhanSo b)
        {
            return a.tuSo * b.mauSo < b.tuSo * a.mauSo;
        }

        public static bool operator >=(PhanSo a, PhanSo b)
        {
            return a.tuSo * b.mauSo >= b.tuSo * a.mauSo;
        }

        public static bool operator <=(PhanSo a, PhanSo b)
        {
            return a.tuSo * b.mauSo <= b.tuSo * a.mauSo;
        }

        public override bool Equals(object obj)
        {
            if (obj is PhanSo ps)
                return this == ps;
            return false;
        }

        public override int GetHashCode()
        {
            return (tuSo, mauSo).GetHashCode();
        }

        // 9. PHƯƠNG THỨC NHẬP DỮ LIỆU
        public void Nhap()
        {
            Console.Write("  Nhap tu so: ");
            int.TryParse(Console.ReadLine(), out tuSo);

            Console.Write("  Nhap mau so (khac 0): ");
            int m;
            while (!int.TryParse(Console.ReadLine(), out m) || m == 0)
            {
                Console.Write("  Mau so phai khac 0! Nhap lai mau so: ");
            }
            MauSo = m;
            RutGon();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 1.4: LOP PHAN SO ===");

            // Nhập 2 phân số A và B
            PhanSo A = new PhanSo();
            Console.WriteLine("\n[Nhap phan so A]");
            A.Nhap();

            PhanSo B = new PhanSo();
            Console.WriteLine("\n[Nhap phan so B]");
            B.Nhap();

            // Hiển thị phân số ban đầu đã rút gọn
            Console.WriteLine($"\n-> Phan so A = {A}");
            Console.WriteLine($"-> Phan so B = {B}");

            // Thử nghiệm toán tử một ngôi
            Console.WriteLine($"\n-> Lay am phan so A (-A) = {-A}");

            // Thử nghiệm toán tử hai ngôi
            Console.WriteLine("\n--- PHEP TOAN HAI NGOI ---");
            Console.WriteLine($"-> A + B = {A + B}");
            Console.WriteLine($"-> A - B = {A - B}");
            Console.WriteLine($"-> A * B = {A * B}");
            Console.WriteLine($"-> A / B = {A / B}");

            // Thử nghiệm toán tử so sánh
            Console.WriteLine("\n--- SO SANH PHAN SO ---");
            Console.WriteLine($"-> A == B : {A == B}");
            Console.WriteLine($"-> A != B : {A != B}");
            Console.WriteLine($"-> A > B  : {A > B}");
            Console.WriteLine($"-> A < B  : {A < B}");
            Console.WriteLine($"-> A >= B : {A >= B}");
            Console.WriteLine($"-> A <= B : {A <= B}");

            Console.ReadLine();
        }
    }
}