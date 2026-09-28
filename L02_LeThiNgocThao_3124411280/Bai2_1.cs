using System;
using System.Collections;

namespace ThucHanh02_Bai2_1
{
    // Lớp Point (làm phần tử cho ArrayPoint)
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Input()
        {
            Console.Write("  Nhap hoanh do x: ");
            double.TryParse(Console.ReadLine(), out double x);
            X = x;

            Console.Write("  Nhap tung do y: ");
            double.TryParse(Console.ReadLine(), out double y);
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // Lớp ArrayPoint quản lý danh sách các điểm Point
    class ArrayPoint
    {
        // 1. FIELD: Một ArrayList lưu trữ các đối tượng Point
        private ArrayList listPoint;

        // 2. CONSTRUCTOR
        public ArrayPoint()
        {
            listPoint = new ArrayList();
        }

        // Thuộc tính lấy số lượng phần tử
        public int Count
        {
            get { return listPoint.Count; }
        }

        // 3. INDEXER: Cho phép truy cập phần tử thứ i bằng cú pháp arrayPoint[i]
        public Point this[int index]
        {
            get
            {
                if (index >= 0 && index < listPoint.Count)
                {
                    return (Point)listPoint[index]; // Ép kiểu từ object sang Point
                }
                throw new IndexOutOfRangeException("Chi so index nam ngoai pham vi cua ArrayPoint!");
            }
            set
            {
                if (index >= 0 && index < listPoint.Count)
                {
                    listPoint[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so index nam ngoai pham vi cua ArrayPoint!");
                }
            }
        }

        // 4. PHƯƠNG THỨC THÊM PHẦN TỬ VÀ NHẬP/XUẤT
        public void Add(Point p)
        {
            if (p != null)
            {
                listPoint.Add(p);
            }
        }

        public void Input()
        {
            Console.Write("Nhap so luong diem Point (n): ");
            int.TryParse(Console.ReadLine(), out int n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n[Nhap toa do cho Point thu {i + 1}]");
                Point p = new Point();
                p.Input();
                this.Add(p);
            }
        }

        public void Output()
        {
            Console.WriteLine($"\n--- DANH SÁCH {listPoint.Count} ĐIỂM (DÙNG INDEXER TRUY CẬP) ---");
            for (int i = 0; i < listPoint.Count; i++)
            {
                // Truy cập trực tiếp bằng Indexer this[i]
                Console.WriteLine($"Point[{i}] = {this[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 2.1: LOP ARRAYPOINT VA INDEXER ===");

            ArrayPoint ap = new ArrayPoint();

            // 1. Nhập danh sách các điểm
            ap.Input();

            // 2. In danh sách điểm sử dụng Indexer
            ap.Output();

            // 3. Thử nghiệm minh họa tính năng của Indexer (Get & Set)
            if (ap.Count > 0)
            {
                Console.WriteLine("\n--- THU NGHIEM SU DUNG INDEXER ---");
                Console.WriteLine($"-> Lay phan tu dau tien ap: {ap}");

                // Sửa giá trị phần tử đầu tiên thông qua Indexer set
                ap[0] = new Point(99, 99);
                Console.WriteLine($"-> Sau khi gan ap[0] = (99, 99), gia tri moi ap[0]: {ap[0]}");
            }

            Console.ReadLine();
        }
    }
}
