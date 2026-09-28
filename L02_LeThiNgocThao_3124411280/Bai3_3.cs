using System;

namespace ThucHanh02_Bai3_3
{
    // 1. Khai báo Delegate tổng quát đại diện cho phương thức so sánh 2 đối tượng kiểu T
    // Trả về > 0 (nếu a > b), < 0 (nếu a < b), == 0 (nếu a == b)
    public delegate int SoSanhDelegate<T>(T a, T b);

    // 2. Lớp chứa thuật toán sắp xếp mảng tổng quát sử dụng Delegate
    class ThuVienSapXep
    {
        // Phương thức sắp xếp tổng quát (Bubble Sort) nhận vào mảng và 1 Delegate so sánh
        public static void Sort<T>(T[] arr, SoSanhDelegate<T> comparer)
        {
            if (arr == null || arr.Length <= 1 || comparer == null) return;

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Thực thi Delegate để quyết định thứ tự sắp xếp
                    if (comparer(arr[j], arr[j + 1]) > 0)
                    {
                        // Hoán vị (Swap)
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }

    // Lớp SinhVien dùng để thử nghiệm sắp xếp
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }

        public SinhVien(string maSV, string hoTen, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        // Các hàm so sánh tiêu chuẩn phù hợp với mẫu SoSanhDelegate<SinhVien>
        public static int SoSanhTheoDiemTBTang(SinhVien a, SinhVien b)
        {
            return a.DiemTB.CompareTo(b.DiemTB);
        }

        public static int SoSanhTheoDiemTBGiam(SinhVien a, SinhVien b)
        {
            return b.DiemTB.CompareTo(a.DiemTB);
        }

        public override string ToString()
        {
            return $"[{MaSV,-6}] Ho ten: {HoTen,-20} | Diem TB: {DiemTB,4:F1}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI 3.3: SẮP XẾP MẢNG TỔNG QUÁT BẰNG DELEGATE ===");

            SinhVien[] dsSV = new SinhVien[]
            {
                new SinhVien("SV01", "Nguyen Van C", 7.5),
                new SinhVien("SV02", "Tran Thi A", 9.2),
                new SinhVien("SV03", "Le Van B", 6.8),
                new SinhVien("SV04", "Pham Thi D", 8.5)
            };

            Console.WriteLine("\n--- DANH SÁCH BAN ĐẦU ---");
            foreach (var sv in dsSV) Console.WriteLine(sv);

            // 1. Sắp xếp tăng dần theo Điểm TB (Truyền Delegate là tên hàm tĩnh)
            ThuVienSapXep.Sort(dsSV, SinhVien.SoSanhTheoDiemTBTang);
            Console.WriteLine("\n--- 1. SẮP XẾP TĂNG DẦN THEO ĐIỂM TB (DELEGATE HÀM TĨNH) ---");
            foreach (var sv in dsSV) Console.WriteLine(sv);

            // 2. Sắp xếp giảm dần theo Điểm TB
            ThuVienSapXep.Sort(dsSV, SinhVien.SoSanhTheoDiemTBGiam);
            Console.WriteLine("\n--- 2. SẮP XẾP GIẢM DẦN THEO ĐIỂM TB ---");
            foreach (var sv in dsSV) Console.WriteLine(sv);

            // 3. Sắp xếp theo Họ tên bằng biểu thức Lambda (Anonymous Delegate)
            ThuVienSapXep.Sort(dsSV, (sv1, sv2) => string.Compare(sv1.HoTen, sv2.HoTen));
            Console.WriteLine("\n--- 3. SẮP XẾP THEO HỌ TÊN (LAMBDA DELEGATE) ---");
            foreach (var sv in dsSV) Console.WriteLine(sv);

            Console.ReadLine();
        }
    }
}