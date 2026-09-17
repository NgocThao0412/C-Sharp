using System;

namespace Lab01_Bai12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 12: XU LY CHUOI VA DEM SO TU ===");

            // 1. Nhập chuỗi từ bàn phím
            Console.Write("Nhap vao mot chuoi: ");
            string input = Console.ReadLine();

            // Kiểm tra nếu chuỗi rỗng
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Chuoi rong hoac chi chua khoang trang!");
            }
            else
            {
                // 2. Chuyển sang ký tự thường
                string chuoiThuong = input.ToLower();

                // 3. Chuyển sang ký tự hoa
                string chuoiHoa = input.ToUpper();

                // 4. Đếm số từ trong chuỗi
                // Dùng Split để tách các từ qua khoảng trắng
                // StringSplitOptions.RemoveEmptyEntries giúp loại bỏ các khoảng trắng thừa trùng nhau
                string[] cacTu = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int soTu = cacTu.Length;

                // 5. In kết quả ra màn hình
                Console.WriteLine("\n--- KET QUA ---");
                Console.WriteLine("-> Chuoi chu thuong: {0}", chuoiThuong);
                Console.WriteLine("-> Chuoi chu hoa: {0}", chuoiHoa);
                Console.WriteLine("-> So tu trong chuoi: {0}", soTu);
            }

            Console.ReadLine();
        }
    }
}
