<Query Kind="Program" />

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    Console.WriteLine("================ BÀI 3.1: THỐNG KÊ MẢNG SỐ ==================");
    Bai31();

    Console.WriteLine("\n================ BÀI 3.2: THỐNG KÊ MẢNG CHUỖI ==============");
    Bai32();
}

// Bài 3.1: Thống kê mảng số
void Bai31()
{
    int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

    // a. Tổng số phần tử, số phần tử chẵn và lẻ
    // Giải thích: Length/Count() đếm tổng số, Count(điều_kiện) đếm theo điều kiện
    var cauA = new
    {
        TongSoPhanTu = mangSo.Length,
        SoPhanTuChan = mangSo.Count(n => n % 2 == 0),
        SoPhanTuLe = mangSo.Count(n => n % 2 != 0)
    };
    cauA.Dump("3.1a - Số lượng phần tử chẵn / lẻ");

    // b. Tổng các giá trị, giá trị lớn nhất và giá trị nhỏ nhất
    // Giải thích: Dùng các phương thức Sum(), Max(), Min()
    var cauB = new
    {
        TongGiaTri = mangSo.Sum(),
        GiaTriLonNhat = mangSo.Max(),
        GiaTriNhoNhat = mangSo.Min()
    };
    cauB.Dump("3.1b - Tổng, Giá trị Lớn nhất, Nhỏ nhất");

    // c. Số giá trị khác nhau trong mảng
    // Giải thích: Distinct() loại bỏ các phần tử trùng lặp, sau đó Count() đếm số lượng
    int cauC = mangSo.Distinct().Count();
    cauC.Dump("3.1c - Số giá trị khác nhau trong mảng");

    // d. Phân nhóm theo số dư khi chia cho 5
    // Giải thích: GroupBy(n => n % 5) nhóm các số có cùng số dư lại với nhau
    var cauD = mangSo.GroupBy(n => n % 5)
                     .Select(g => new { SoDu = g.Key, CacPhanTu = string.Join(", ", g) });
    cauD.Dump("3.1d - Phân nhóm theo số dư khi chia cho 5");
}

// Bài 3.2: Thống kê mảng chuỗi (món ăn)
void Bai32()
{
    string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì", "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

    // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
    // Giải thích: Lấy độ dài Min/Max trước, sau đó lọc ra các món có độ dài bằng Min/Max đó
    int minLen = monAn.Min(m => m.Length);
    int maxLen = monAn.Max(m => m.Length);
    var cauA = new
    {
        DoDaiNganNhat = minLen,
        MonNganNhat = monAn.Where(m => m.Length == minLen),
        DoDaiDaiNhat = maxLen,
        MonDaiNhat = monAn.Where(m => m.Length == maxLen)
    };
    cauA.Dump("3.2a - Món có chiều dài ngắn nhất và dài nhất");

    // b. Phân nhóm theo từ đầu tiên của tên món
    // Giải thích: Split(' ') lấy từ đầu tiên để làm khóa nhóm (Key) cho GroupBy
    var cauB = monAn.GroupBy(m => m.Split(' '))
                    .Select(g => new { TuDauTien = g.Key, DanhSachMon = string.Join(", ", g) });
    cauB.Dump("3.2b - Phân nhóm theo từ đầu tiên");

    // c. Đếm số phần tử có từ đầu tiên là "Bánh"
    // Giải thích: Count() kết hợp StartsWith("Bánh") để đếm các món bắt đầu bằng từ "Bánh"
    int cauC = monAn.Count(m => m.StartsWith("Bánh"));
    cauC.Dump("3.2c - Số món có từ đầu tiên là 'Bánh'");
}
