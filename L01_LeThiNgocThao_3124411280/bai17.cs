using System;

namespace Lab01_Bai17
{
    // Lớp chứa các phương thức thành viên xử lý ma trận
    class MatrixHelper
    {
        // 1. Phương thức sinh ngẫu nhiên mảng A[n x m] trong đoạn [3]
        public int[,] SinhMangNgauNhien(int n, int m)
        {
            int[,] A = new int[n, m];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // rand.Next(10, 101) sẽ sinh số ngẫu nhiên từ 10 đến 100
                    A[i, j] = rand.Next(10, 101);
                }
            }

            return A;
        }

        // 2. Phương thức in mảng 2 chiều ra màn hình
        public void InMang(int[,] A)
        {
            int n = A.GetLength(0); // Lấy số dòng
            int m = A.GetLength(1); // Lấy số cột

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,6}", A[i, j]); // In canh lề 6 khoảng trống
                }
                Console.WriteLine(); // Sau mỗi dòng thì xuống hàng
            }
        }

        // 3. Phương thức trả về hai mảng: mảng chẵn và mảng lẻ (sử dụng tham chiếu out)
        public void TachChanLe(int[,] A, out int[] mangChan, out int[] mangLe)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1);

            int demChan = 0;
            int demLe = 0;

            // Bước 1: Đếm số lượng phần tử chẵn và lẻ
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i, j] % 2 == 0)
                        demChan++;
                    else
                        demLe++;
                }
            }

            // Bước 2: Cấp phát bộ nhớ cho mảng chẵn và mảng lẻ
            mangChan = new int[demChan];
            mangLe = new int[demLe];

            int idxChan = 0;
            int idxLe = 0;

            // Bước 3: Đưa giá trị vào mảng tương ứng
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i, j] % 2 == 0)
                    {
                        mangChan[idxChan] = A[i, j];
                        idxChan++;
                    }
                    else
                    {
                        mangLe[idxLe] = A[i, j];
                        idxLe++;
                    }
                }
            }
        }
    }

    class Program
    {
        // Hàm phụ hỗ trợ in mảng 1 chiều
        static void InMang1Chieu(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 17: MANG 2 CHIEU VA PHUONG THUC THANH VIEN ===");

            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());

            // Khởi tạo đối tượng
            MatrixHelper helper = new MatrixHelper();

            // 1. Sinh mảng ngẫu nhiên
            int[,] A = helper.SinhMangNgauNhien(n, m);

            // 2. In mảng 2 chiều
            Console.WriteLine("\n--- MANG A[{0}x{1}] SINH NGAU NHIEN [3] ---", n, m);
            helper.InMang(A);

            // 3. Tách mảng số chẵn và số lẻ
            helper.TachChanLe(A, out int[] mangChan, out int[] mangLe);

            Console.WriteLine("\n--- MANG CAC SO CHAN ({0} so) ---", mangChan.Length);
            InMang1Chieu(mangChan);

            Console.WriteLine("\n--- MANG CAC SO LE ({0} so) ---", mangLe.Length);
            InMang1Chieu(mangLe);

            Console.ReadLine();
        }
    }
}