using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c
{
    // Lớp đối tượng lưu trữ thông tin Từ vựng
    public class TuVung
    {
        public string TuTiengAnh { get; set; }
        public string NghiaTiengViet { get; set; }

        public TuVung(string anh, string viet)
        {
            TuTiengAnh = anh;
            NghiaTiengViet = viet;
        }
    }

    public class frmBai1_VeNha : Form
    {
        // 1. Khai báo danh sách từ lưu bằng List<TuVung> theo yêu cầu đề bài
        private List<TuVung> dsTuDien = new List<TuVung>();

        // 2. Khai báo các Control trên giao diện
        private GroupBox grpCheDo;
        private RadioButton radAnhViet;
        private RadioButton radVietAnh;

        private Label lblTuKhoa;
        private ComboBox cboTuKhoa;
        private Label lblNghia;
        private TextBox txtNghia;
        private Button btnTraTu;

        public frmBai1_VeNha()
        {
            InitializeComponent();
        }

        // 3. Khởi tạo Giao diện hoàn toàn bằng Code
        private void InitializeComponent()
        {
            this.Text = "Bài 1 Về nhà: Từ điển Anh - Việt & Việt - Anh";
            this.Size = new Size(580, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // GroupBox Chọn chế độ dịch
            grpCheDo = new GroupBox()
            {
                Text = "Chế độ từ điển",
                Location = new Point(20, 15),
                Size = new Size(520, 60),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            radAnhViet = new RadioButton()
            {
                Text = "Anh - Việt",
                Location = new Point(30, 25),
                AutoSize = true,
                Checked = true,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            radVietAnh = new RadioButton()
            {
                Text = "Việt - Anh",
                Location = new Point(180, 25),
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            grpCheDo.Controls.Add(radAnhViet);
            grpCheDo.Controls.Add(radVietAnh);

            // Từ cần tra (ComboBox AutoComplete)
            lblTuKhoa = new Label()
            {
                Text = "Từ cần tra:",
                Location = new Point(20, 95),
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            cboTuKhoa = new ComboBox()
            {
                Location = new Point(20, 120),
                Size = new Size(230, 25),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            // Nghĩa tương ứng (TextBox)
            lblNghia = new Label()
            {
                Text = "Nghĩa của từ:",
                Location = new Point(280, 95),
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            txtNghia = new TextBox()
            {
                Location = new Point(280, 120),
                Size = new Size(260, 110),
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            // Nút Tra từ
            btnTraTu = new Button()
            {
                Text = "Tra từ (Enter)",
                Location = new Point(20, 160),
                Size = new Size(230, 35),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            // Đăng ký Sự kiện (Event Handlers)
            this.Load += FrmBai1_VeNha_Load;
            radAnhViet.CheckedChanged += RadCheDo_CheckedChanged;
            radVietAnh.CheckedChanged += RadCheDo_CheckedChanged;
            btnTraTu.Click += BtnTraTu_Click;
            cboTuKhoa.SelectedIndexChanged += CboTuKhoa_SelectedIndexChanged;
            cboTuKhoa.KeyDown += CboTuKhoa_KeyDown;

            // Thêm tất cả Control vào Form
            this.Controls.Add(grpCheDo);
            this.Controls.Add(lblTuKhoa);
            this.Controls.Add(cboTuKhoa);
            this.Controls.Add(lblNghia);
            this.Controls.Add(txtNghia);
            this.Controls.Add(btnTraTu);
        }

        // 4. Xử lý Logic Nghiệp vụ

        // 4.1. Form Load: Khởi tạo dữ liệu từ điển vào List<TuVung>
        private void FrmBai1_VeNha_Load(object sender, EventArgs e)
        {
            // Kho từ vựng mẫu
            dsTuDien.Add(new TuVung("Hello", "Xin chào"));
            dsTuDien.Add(new TuVung("Computer", "Máy tính cá nhân"));
            dsTuDien.Add(new TuVung("Software", "Phần mềm máy tính"));
            dsTuDien.Add(new TuVung("Hardware", "Phần cứng máy tính"));
            dsTuDien.Add(new TuVung("Developer", "Lập trình viên / Nhà phát triển"));
            dsTuDien.Add(new TuVung("Database", "Cơ sở dữ liệu"));
            dsTuDien.Add(new TuVung("Network", "Mạng máy tính"));
            dsTuDien.Add(new TuVung("Keyboard", "Bàn phím máy tính"));

            NapDataToComboBox();
        }

        // 4.2. Cấu hình ComboBox AutoComplete gợi ý từ khớp nhất khi gõ
        private void NapDataToComboBox()
        {
            cboTuKhoa.Items.Clear();
            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();

            bool isAnhViet = radAnhViet.Checked;

            foreach (var item in dsTuDien)
            {
                string key = isAnhViet ? item.TuTiengAnh : item.NghiaTiengViet;
                cboTuKhoa.Items.Add(key);
                autoSource.Add(key);
            }

            // Thiết lập chế độ gợi ý gõ phím khớp với ký tự gần nhất theo đề bài
            cboTuKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTuKhoa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTuKhoa.AutoCompleteCustomSource = autoSource;
        }

        // 4.3. Đổi chế độ Anh - Việt <-> Việt - Anh
        private void RadCheDo_CheckedChanged(object sender, EventArgs e)
        {
            NapDataToComboBox();
            cboTuKhoa.Text = "";
            txtNghia.Clear();
        }

        // 4.4. Hàm thực hiện Tra từ
        private void ThucHienTraTu()
        {
            string tuCanTra = cboTuKhoa.Text.Trim();
            if (string.IsNullOrEmpty(tuCanTra)) return;

            bool isAnhViet = radAnhViet.Checked;

            // Tìm kiếm trong List<TuVung>
            TuVung ketQua = dsTuDien.Find(x => 
                string.Compare(isAnhViet ? x.TuTiengAnh : x.NghiaTiengViet, tuCanTra, true) == 0);

            if (ketQua != null)
            {
                txtNghia.Text = isAnhViet ? ketQua.NghiaTiengViet : ketQua.TuTiengAnh;
            }
            else
            {
                txtNghia.Text = "Không tìm thấy từ này trong từ điển!";
            }
        }

        private void BtnTraTu_Click(object sender, EventArgs e)
        {
            ThucHienTraTu();
        }

        // Tự động dịch khi chọn từ trong danh sách xổ xuống của ComboBox
        private void CboTuKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienTraTu();
        }

        // Nhấn phím Enter trong ComboBox để tra nghĩa theo đúng yêu cầu đề bài
        private void CboTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienTraTu();
                e.Handled = true;
                e.SuppressKeyPress = true; // Tránh tiếng 'beep' của hệ thống khi bấm Enter
            }
        }
    }
}