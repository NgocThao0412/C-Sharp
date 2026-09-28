using System;

namespace ThucHanh02_Bai2_3
{
    // Lớp DaySo quản lý mảng 1 chiều chứa n số nguyên
    class DaySo
    {
        // 1. FIELDS
        private int[] a;
        private int n;

        // 2. PROPERTIES
        public int N
        {
            get { return n; }
        }

        // 3. CONSTRUCTORS
        // Default Constructor: Khởi tạo dãy rỗng
        public DaySo()
        {
            n = 0;
            a = new int[0];
        }

        // Parameterized Constructor 1: Khởi tạo với kích thước n
        public DaySo(int n)
        {
            if (n > 0)
            {
                this.n = n;
                this.a = new int[n];
            }
            else
            {
                this.n = 0;
                this.a = new int[0];
            }
        }

        // Parameterized Constructor 2: Khởi tạo từ một mảng 1 chiều có sẵn
        public DaySo(int[] arr)
        {
            if (arr != null)
            {
                this.n = arr.Length;
                this.a = new int[this.n];
                Array.Copy(arr, this.a, this.n);
            }
            else
            {
                this.n = 0;
                this.a = new int[0];
            }
        }

        // Copy Constructor: Khởi tạo sao chép từ một đối tượng DaySo khác
        public DaySo(DaySo ds)
        {
            if (ds != null)
            {
                this.n = ds.n;
                this.a = new int[this.n];
                Array.Copy(ds.a, this.a, this.n);
            }
            else
            {
                this.n = 0;
                this.a = new int[0];
            }
        }

        // 4. INDEXER: Cho phép truy cập phần tử thứ i dạng ds[i]
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < n)
                    return a[index];
                throw new IndexOutOfRangeException("Chi so index nam ngoai pham vi cua day so!");
            }
            set
            {
                if (index >= 0 && index < n)
                    a[index] = value;
                else
                    throw new IndexOutOfRangeException("Chi so index nam ngoai pham vi cua day so!");
            }
        }

        // 5. PHƯƠNG THỨC NHẬP / XUẤT DÃY SỐ
        public void Nhap()
        {
            Console.Write("Nhap so luong phan tu n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("So luong phan tu phai la so nguyen duong! Nhap lai n: ");
            }

            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"  a[{i}] = ");
                while (!int.TryParse(Console.ReadLine(), out a[i]))
                {
                    Console.Write($"  Gia tri khong hop le! Nhap lai a[{i}] = ");
                }
            }
        }

        public void Xuat()
        {
            if (n == 0)
            {
                Console.WriteLine("Day so rong!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,6}", a[i]);
            }
            Console.WriteLine();
        }

        // 6. PHƯƠNG THỨC TÌM CÁC SỐ CHẴN: TRẢ VỀ MỘT ĐỐI TƯỢNG DaySo MỚI
        public DaySo TimSoChan()
        {
            // Bước 1: Đếm số lượng phần tử chẵn
            int demChan = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                    demChan++;
            }

            // Bước 2: Tạo đối tượng DaySo mới với kích thước đúng bằng số lượng số chẵn
            DaySo dsChan = new DaySo(demChan);
            int idx = 0;

            // Bước 3: Lọc và đưa số chẵn vào dãy mới
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    dsChan[idx] = a[i]; // Dùng Indexer để gán giá trị
                    idx++;
                }
            }

            return dsChan;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 2.3: LOP DAY SO (MANG 1 CHIEU) ===");

            // 1. Nhập dãy số
            DaySo ds = new DaySo();
            Console.WriteLine("\n[Nhap du lieu cho day so]");
            ds.Nhap();

            // 2. Xuất dãy số vừa nhập
            Console.WriteLine("\n--- DAY SO VUA NHAP ---");
            ds.Xuat();

            // 3. Tìm và in các số chẵn
            DaySo dsChan = ds.TimSoChan();
            Console.WriteLine($"\n--- CAC SO CHAN TRONG DAY ({dsChan.N} so) ---");
            dsChan.Xuat();

            // 4. Thử nghiệm minh họa Indexer (Get/Set)
            if (ds.N > 0)
            {
                Console.WriteLine("\n--- THU NGHIEM INDEXER ---");
                Console.WriteLine($"-> Phan tu dau tien ds = {ds}");

                // Thử thay đổi phần tử đầu tiên bằng 100
                ds[0] = 100;
                Console.WriteLine("-> Sau khi gan ds = 100, day so moi:");
                ds.Xuat();
            }

            Console.ReadLine();
        }
    }
}
