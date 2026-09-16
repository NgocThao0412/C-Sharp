using System;

namespace Lab01_Bai15
{
    class Program
    {
        // 1. Hàm kiểm tra số nguyên tố (dùng vòng lặp for đơn giản)
        static bool KiemTraSoNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false; // Chia hết cho số khác -> Không phải số nguyên tố
                }
            }

            return true; // Là số nguyên tố
        }

        // 2. Hàm nhập mảng n phần tử
        static int[] NhapMang()
        {
            Console.Write("Nhap so luong phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}] = ", i);
                a[i] = int.Parse(Console.ReadLine());
            }

            return a;
        }

        // 3. Hàm in mảng ra màn hình
        static void InMang(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine(); // Xuống dòng
        }

        // 4. Hàm tìm phần tử lớn nhất
        static int TimMax(int[] a)
        {
            int max = a;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
        }

        // 5. Hàm tìm phần tử nhỏ nhất
        static int TimMin(int[] a)
        {
            int min = a;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }
            return min;
        }

        // 6. Hàm lọc và trả về mảng các số nguyên tố (dùng mảng tĩnh 2 bước)
        static int[] LayMangSoNguyenTo(int[] a)
        {
            // Bước 1: Đếm xem có bao nhiêu số nguyên tố trong mảng
            int dem = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (KiemTraSoNguyenTo(a[i]))
                {
                    dem++;
                }
            }

            // Bước 2: Khởi tạo mảng mới chứa đúng số lượng đã đếm
            int[] mangSNT = new int[dem];
            int index = 0;

            // Bước 3: Đưa các số nguyên tố vào mảng mới
            for (int i = 0; i < a.Length; i++)
            {
                if (KiemTraSoNguyenTo(a[i]))
                {
                    mangSNT[index] = a[i];
                    index++;
                }
            }

            return mangSNT;
        }

        // Hàm Main chính chạy chương trình
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI TẬP MẢNG (CƠ BẢN CHƯƠNG 2) ===");

            // Yêu cầu 1: Nhập mảng
            int[] a = NhapMang();

            // Yêu cầu 2: In mảng
            Console.Write("\nMang vua nhap la: ");
            InMang(a);

            // Yêu cầu 3: Tìm Max và Min
            Console.WriteLine("Phan tu lon nhat (Max): " + TimMax(a));
            Console.WriteLine("Phan tu nho nhat (Min): " + TimMin(a));

            // Yêu cầu 4: Trả về và in mảng số nguyên tố
            int[] mangSNT = LayMangSoNguyenTo(a);
            Console.Write("Mang cac so nguyen to: ");
            if (mangSNT.Length > 0)
            {
                InMang(mangSNT);
            }
            else
            {
                Console.WriteLine("Khong co so nguyen to nao!");
            }

            Console.ReadLine();
        }
    }
}