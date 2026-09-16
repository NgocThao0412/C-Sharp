using System;

namespace Lab01_Bai11
{
    // 1. Xây dựng lớp chứa phương thức xử lý chuỗi
    class StringHelper
    {
        // Phương thức thành viên nhận vào 1 chuỗi và trả về chuỗi đảo ngược

        // Dùng vòng lặp chạy từ cuối chuỗi về đầu chuỗi
        public string DaoChuoi(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            string ketQua = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                ketQua += str[i];
            }
            return ketQua;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 11: DAO NGUOC CHUOI ===");

            // Nhập chuỗi từ bàn phím
            Console.Write("Nhap vao chuoi can dao nguoc: ");
            string input = Console.ReadLine();

            // 2. Khởi tạo đối tượng từ lớp StringHelper
            StringHelper helper = new StringHelper();

            // 3. Gọi phương thức DaoChuoi và nhận giá trị trả về
            string chuoiDao = helper.DaoChuoi(input);

            // 4. In kết quả ra màn hình
            Console.WriteLine("-> Chuoi ban dau: {0}", input);
            Console.WriteLine("-> Chuoi sau khi dao: {0}", chuoiDao);

            Console.ReadLine();
        }
    }
}