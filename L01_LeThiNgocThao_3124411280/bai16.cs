using System;

namespace Lab01_Bai16
{
    class Program
    {
        // Phương thức sắp xếp mảng họ tên tăng dần (theo bảng chữ cái)
        static void SapXepHoTen(string[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    // a[i].CompareTo(a[j]) > 0 nghĩa là hoTen[i] đứng sau hoTen[j]
                    if (a[i].CompareTo(a[j]) > 0)
                    {
                        // Đổi chỗ 2 chuỗi
                        string temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 16: SAP XEP MANG HO TEN ===");

            // Nhập số lượng người
            Console.Write("Nhap so luong nguoi n: ");
            int n = int.Parse(Console.ReadLine());

            string[] hoTen = new string[n];

            // Nhập danh sách họ tên
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap ho ten nguoi thu {0}: ", i + 1);
                hoTen[i] = Console.ReadLine();
            }

            // Gọi hàm sắp xếp (Hoặc bạn có thể dùng lệnh ngắn gọn: Array.Sort(hoTen);)
            SapXepHoTen(hoTen);

            // In kết quả ra màn hình
            Console.WriteLine("\n--- DANH SACH HO TEN SAU KHI SAP XEP TANG DAN ---");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, hoTen[i]);
            }

            Console.ReadLine();
        }
    }
}