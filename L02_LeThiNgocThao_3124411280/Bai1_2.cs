using System;

namespace ThucHanh02_Bai1_2
{
    // Thiết kế lớp Point đại diện cho điểm trong mặt phẳng tọa độ 2D
    class Point
    {
        // 1. FIELDS
        private double x;
        private double y;

        // 2. PROPERTIES
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // 3. CONSTRUCTORS
        // Default constructor khởi tạo x và y bằng 0
        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // 4. METHODS NHẬP / XUẤT
        public void Input()
        {
            Console.Write("  Nhap hoanh do x: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.Write("  Nhap tung do y: ");
            double.TryParse(Console.ReadLine(), out y);
        }

        public void Output()
        {
            Console.WriteLine("Toa do: ({0}, {1})", x, y);
        }

        // Override hàm ToString() để xuất Point dạng (x, y)
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        // 5. ĐA NĂNG TOÁN TỬ (OPERATOR OVERLOADING)
        // Phép cộng 2 điểm: (x1 + x2, y1 + y2)
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        // Phép trừ 2 điểm: (x1 - x2, y1 - y2)
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        // Phép lấy âm (-Point): (-x, -y)
        public static Point operator -(Point p)
        {
            return new Point(-p.x, -p.y);
        }

        // 6. (a) KHOẢNG CÁCH GIỮA 2 ĐIỂM
        // Cách 1: Phương thức thành viên (Instance Method)
        public double TinhKhoangCach(Point b)
        {
            return Math.Sqrt(Math.Pow(this.x - b.x, 2) + Math.Pow(this.y - b.y, 2));
        }

        // Cách 2: Phương thức tĩnh (Static Method)
        public static double TinhKhoangCach(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }

        // 7. (b) TRUNG ĐIỂM CỦA 2 ĐIỂM
        // Cách 1: Phương thức thành viên (Instance Method)
        public Point TimTrungDiem(Point b)
        {
            return new Point((this.x + b.x) / 2.0, (this.y + b.y) / 2.0);
        }

        // Cách 2: Phương thức tĩnh (Static Method)
        public static Point TimTrungDiem(Point a, Point b)
        {
            return new Point((a.x + b.x) / 2.0, (a.y + b.y) / 2.0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 1.2: LOP POINT ===");

            // Nhập tọa độ điểm A và B
            Point A = new Point();
            Console.WriteLine("\n[Nhap toa do diem A]");
            A.Input();

            Point B = new Point();
            Console.WriteLine("\n[Nhap toa do diem B]");
            B.Input();

            // Xuất tọa độ bằng ToString()
            Console.WriteLine($"\n-> Diem A = {A}");
            Console.WriteLine($"-> Diem B = {B}");

            // Thử nghiệm đa năng toán tử +, -, đổi dấu (-)
            Point tong = A + B;
            Point hieu = A - B;
            Point amA = -A;
            Console.WriteLine($"-> A + B = {tong}");
            Console.WriteLine($"-> A - B = {hieu}");
            Console.WriteLine($"-> Am A (-A) = {amA}");

            // (a) Tính khoảng cách theo 2 cách
            double kcThanhVien = A.TinhKhoangCach(B);
            double kcTinh = Point.TinhKhoangCach(A, B);
            Console.WriteLine($"\n-> Khoang cach AB (Phuong thuc thanh vien): {kcThanhVien:F2}");
            Console.WriteLine($"-> Khoang cach AB (Phuong thuc tinh)      : {kcTinh:F2}");

            // (b) Tìm trung điểm I theo 2 cách
            Point I1 = A.TimTrungDiem(B);
            Point I2 = Point.TimTrungDiem(A, B);
            Console.WriteLine($"\n-> Trung diem I (Phuong thuc thanh vien): {I1}");
            Console.WriteLine($"-> Trung diem I (Phuong thuc tinh)      : {I2}");

            Console.ReadLine();
        }
    }
}