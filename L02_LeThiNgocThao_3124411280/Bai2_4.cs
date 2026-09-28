using System;
using System.Collections;

namespace ThucHanh02_Bai2_4
{
    // Lớp MaTran / Mang2Chieu quản lý mảng 2 chiều kích thước n x m
    class MaTran
    {
        // 1. FIELDS
        private int[,] a;
        private int n; // Số dòng
        private int m; // Số cột

        // 2. PROPERTIES
        public int N => n;
        public int M => m;

        // 3. CONSTRUCTORS
        // Default Constructor: Ma trận rỗng 0x0
        public MaTran()
        {
            n = 0;
            m = 0;
            a = new int[0, 0];
        }

        // Parameterized Constructor 1: Khởi tạo ma trận kích thước n x m
        public MaTran(int n, int m)
        {
            if (n > 0 && m > 0)
            {
                this.n = n;
                this.m = m;
                this.a = new int[n, m];
            }
            else
            {
                this.n = 0;
                this.m = 0;
                this.a = new int[0, 0];
            }
        }

        // Parameterized Constructor 2: Khởi tạo từ mảng 2 chiều có sẵn
        public MaTran(int[,] matrix)
        {
            if (matrix != null)
            {
                this.n = matrix.GetLength(0);
                this.m = matrix.GetLength(1);
                this.a = new int[n, m];
                Array.Copy(matrix, this.a, matrix.Length);
            }
            else
            {
                this.n = 0;
                this.m = 0;
                this.a = new int[0, 0];
            }
        }

        // Copy Constructor: Tạo bản sao ma trận
        public MaTran(MaTran mt)
        {
            if (mt != null)
            {
                this.n = mt.n;
                this.m = mt.m;
                this.a = new int[n, m];
                Array.Copy(mt.a, this.a, mt.a.Length);
            }
            else
            {
                this.n = 0;
                this.m = 0;
                this.a = new int[0, 0];
            }
        }

        // 4. INDEXER 2 CHIỀU: Cho phép truy cập phần tử tại dòng i, cột j dạng matrix[i, j]
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < n && j >= 0 && j < m)
                    return a[i, j];
                throw new IndexOutOfRangeException("Chi so (i, j) nam ngoai pham vi cua ma tran!");
            }
            set
            {
                if (i >= 0 && i < n && j >= 0 && j < m)
                    a[i, j] = value;
                else
                    throw new IndexOutOfRangeException("Chi so (i, j) nam ngoai pham vi cua ma tran!");
            }
        }

        // 5. PHƯƠNG THỨC NHẬP / XUẤT MA TRẬN
        public void Nhap()
        {
            Console.Write("Nhap so dong (n): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("So dong phai la so nguyen duong! Nhap lai n: ");
            }

            Console.Write("Nhap so cot (m): ");
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                Console.Write("So cot phai la so nguyen duong! Nhap lai m: ");
            }

            a = new int[n, m];
            Console.WriteLine($"\n[Nhap {n * m} phan tu cho ma tran {n}x{m}]");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"  a[{i}, {j}] = ");
                    while (!int.TryParse(Console.ReadLine(), out a[i, j]))
                    {
                        Console.Write($"  Gia tri khong hop le! Nhap lai a[{i}, {j}] = ");
                    }
                }
            }
        }

        public void Xuat()
        {
            if (n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,6}", a[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Tĩnh: Hàm kiểm tra 1 số có phải là số nguyên tố hay không
        public static bool KiemTraNT(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // 6. PHƯƠNG THỨC TÌM CÁC SỐ NGUYÊN TỐ TRONG MẢNG 2 CHIỀU
        public ArrayList TimSoNguyenTo()
        {
            ArrayList listNT = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (KiemTraNT(a[i, j]))
                    {
                        listNT.Add(a[i, j]);
                    }
                }
            }
            return listNT;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 2.4: LOP MA TRAN ===");

            // 1. Nhập ma trận
            MaTran mt = new MaTran();
            mt.Nhap();

            // 2. Xuất ma trận vừa nhập
            Console.WriteLine("\n--- MA TRẬN VỪA NHẬP ---");
            mt.Xuat();

            // 3. Tìm và in các số nguyên tố trong ma trận
            ArrayList listNT = mt.TimSoNguyenTo();
            Console.WriteLine($"\n--- CÁC SỐ NGUYÊN TỐ TRONG MA TRẬN ({listNT.Count} số) ---");
            if (listNT.Count == 0)
            {
                Console.WriteLine("Khong co so nguyen to nao trong ma tran.");
            }
            else
            {
                foreach (int item in listNT)
                {
                    Console.Write("{0,6}", item);
                }
                Console.WriteLine();
            }

            // 4. Minh họa thử nghiệm Indexer 2 chiều mt[i, j]
            if (mt.N > 0 && mt.M > 0)
            {
                Console.WriteLine("\n--- THỬ NGHIỆM INDEXER 2 CHIỀU ---");
                Console.WriteLine($"-> Gia tri phan tu dau tien mt[0, 0] = {mt[0, 0]}");

                // Thử cập nhật mt thành 77 qua Indexer
                mt[0, 0] = 77;
                Console.WriteLine("-> Sau khi gan mt = 77, ma tran moi:");
                mt.Xuat();
            }

            Console.ReadLine();
        }
    }
}