using System;

namespace Lab01_Bai7
{
    // 1. Xây dựng lớp chứa phương thức kiểm tra SNT
    class SoNguyenToChecker
    {
        // Phương thức kiểm tra số nguyên tố, trả về kiểu bool (true / false)
        public bool KiemTraSoNguyenTo(int n)
        {
            // Số nhỏ hơn 2 không phải là số nguyên tố
            if (n < 2)
            {
                return false;
            }

            // Kiểm tra các ước từ 2 đến căn bậc 2 của n
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false; // Nếu chia hết cho số nào khác thì không phải số nguyên tố
                }
            }

            return true; // Ngược lại là số nguyên tố
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KIEM TRA SO NGUYEN TO");

            // Nhập số n từ bàn phím
            Console.Write("Nhap so nguyên n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                // 2. Khởi tạo đối tượng từ lớp SoNguyenToChecker
                SoNguyenToChecker checker = new SoNguyenToChecker();

                // 3. Gọi phương thức và hứng giá trị bool trả về
                bool isPrime = checker.KiemTraSoNguyenTo(n);

                // 4. In KQ
                if (isPrime)
                {
                    Console.WriteLine("-> {0} LA so nguyen to.", n);
                }
                else
                {
                    Console.WriteLine("-> {0} KHONG PHAI la so nguyen to.", n);
                }
            }
            else
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai la so nguyen!");
            }

            Console.ReadLine();
        }
    }
}