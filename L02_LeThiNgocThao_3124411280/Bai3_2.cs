using System;

namespace ThucHanh02_Bai3_2
{
    // Lớp chứa phương thức sắp xếp tổng quát mô phỏng Array.Sort()
    class ThuVienSapXep
    {
        // Phương thức sắp xếp tổng quát Generic Sort sử dụng Interface IComparable<T>
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr == null || arr.Length <= 1) return;

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Gọi phương thức CompareTo() thuộc Interface IComparable<T>
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // Hoán vị 2 phần tử
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }

    // Lớp PhanSo thực thi IComparable<PhanSo>
    class PhanSo : IComparable<PhanSo>
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo(int tu = 0, int mau = 1)
        {
            TuSo = tu;
            MauSo = (mau != 0) ? mau : 1;
        }

        public double GiaTri => (double)TuSo / MauSo;

        public int CompareTo(PhanSo? other)
        {
            if (other == null) return 1;
            return this.GiaTri.CompareTo(other.GiaTri);
        }

        public override string ToString() => $"{TuSo}/{MauSo}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI 3.2: VIẾT PHƯƠNG THỨC SẮP XẾP TỔNG QUÁT BẰNG INTERFACE ===");

            PhanSo[] dsPS = new PhanSo[]
            {
                new PhanSo(3, 4),
                new PhanSo(1, 2),
                new PhanSo(5, 6),
                new PhanSo(1, 4)
            };

            Console.WriteLine("\n--- DÃY PHÂN SỐ BAN ĐẦU ---");
            Console.WriteLine(string.Join(", ", (object[])dsPS));

            // Gọi phương thức sắp xếp tổng quát tự viết
            ThuVienSapXep.Sort(dsPS);

            Console.WriteLine("\n--- DÃY PHÂN SỐ SẮP XẾP TĂNG DẦN (MÔ PHỎNG ARRAY.SORT) ---");
            Console.WriteLine(string.Join(", ", (object[])dsPS));

            Console.ReadLine();
        }
    }
}