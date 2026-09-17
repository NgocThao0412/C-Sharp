using System;

namespace Lab01_Bai10
{
    // 1. Xây dựng lớp chứa phương thức thành viên kiểm tra chuỗi đối xứng
    class StringChecker
    {
        // Phương thức thành viên nhận vào 1 chuỗi và trả về bool (true nếu đối xứng, false nếu không)
        public bool KiemTraDoiXung(string str)
        {
            // Kiểm tra nếu chuỗi rỗng hoặc null
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            int left = 0;
            int right = str.Length - 1;

            // Dùng 2 con trỏ duyệt từ 2 đầu tiến vào giữa
            while (left < right)
            {
                // So sánh ký tự ở đầu và cuối tương ứng
                if (str[left] != str[right])
                {
                    return false; // Nếu thấy 2 ký tự khác nhau -> Không đối xứng
                }
                left++;
                right--;
            }

            return true; // Nếu tất cả các cặp ký tự đều giống nhau -> Chuỗi đối xứng
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 10: KIEM TRA CHUOI DOI XUNG ===");

            // Nhập chuỗi từ bàn phím
            Console.Write("Nhap vao chuoi can kiem tra: ");
            string input = Console.ReadLine();

            // 2. Khởi tạo đối tượng từ lớp StringChecker
            StringChecker checker = new StringChecker();

            // 3. Gọi phương thức thành viên KiemTraDoiXung
            bool isSymmetric = checker.KiemTraDoiXung(input);

            // 4. In kết quả ra màn hình
            if (isSymmetric)
            {
                Console.WriteLine("-> Chuoi \"{0}\" LA chuoi doi xung.", input);
            }
            else
            {
                Console.WriteLine("-> Chuoi \"{0}\" KHONG PHAI la chuoi doi xung.", input);
            }

            Console.ReadLine();
        }
    }
}