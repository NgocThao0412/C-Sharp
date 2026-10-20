using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c
{
    public class frmBai2_VeNha : Form
    {
        // Khai báo các Control
        private Label lblNhap;
        private TextBox txtNhapN;
        private Button btnNhap;
        private ListBox lstSo;

        private Button btnTong;
        private Button btnXoaDauCuoi;
        private Button btnXoaChon;
        private Button btnTang2;
        private Button btnBinhPhuong;
        private Button btnChonChan;
        private Button btnChonLe;

        public frmBai2_VeNha()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Bài 2 Về nhà: Thao tác ListBox Đa chọn (Số tự nhiên)";
            this.Size = new Size(580, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // --- Nhập số N ---
            lblNhap:
            lblNhap = new Label() { Text = "Nhập số N:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtNhapN = new TextBox() { Location = new Point(100, 17), Size = new Size(120, 23) };
            btnNhap = new Button() { Text = "Nhập vào danh sách", Location = new Point(230, 15), Size = new Size(130, 28) };

            // --- ListBox cho phép chọn nhiều phần tử (MultiExtended) ---
            lstSo = new ListBox()
            {
                Location = new Point(20, 60),
                Size = new Size(200, 300),
                SelectionMode = SelectionMode.MultiExtended, // Cho phép giữ Ctrl/Shift chọn nhiều dòng
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            // --- Các Button chức năng bên phải ---
            int startX = 240;
            int btnWidth = 300;
            int btnHeight = 35;
            int gap = 43;

            btnTong = new Button() { Text = "1. Tính tổng các phần tử", Location = new Point(startX, 60), Size = new Size(btnWidth, btnHeight) };
            btnXoaDauCuoi = new Button() { Text = "2. Xóa phần tử đầu & cuối", Location = new Point(startX, 60 + gap), Size = new Size(btnWidth, btnHeight) };
            btnXoaChon = new Button() { Text = "3. Xóa các phần tử đang chọn", Location = new Point(startX, 60 + gap * 2), Size = new Size(btnWidth, btnHeight) };
            btnTang2 = new Button() { Text = "4. Tăng mỗi phần tử lên 2", Location = new Point(startX, 60 + gap * 3), Size = new Size(btnWidth, btnHeight) };
            btnBinhPhuong = new Button() { Text = "5. Bình phương các phần tử", Location = new Point(startX, 60 + gap * 4), Size = new Size(btnWidth, btnHeight) };
            btnChonChan = new Button() { Text = "6. Chọn tất cả các số chẵn", Location = new Point(startX, 60 + gap * 5), Size = new Size(btnWidth, btnHeight) };
            btnChonLe = new Button() { Text = "7. Chọn tất cả các số lẻ", Location = new Point(startX, 60 + gap * 6), Size = new Size(btnWidth, btnHeight) };

            // --- Đăng ký Sự kiện (Events) ---
            btnNhap.Click += BtnNhap_Click;
            btnTong.Click += BtnTong_Click;
            btnXoaDauCuoi.Click += BtnXoaDauCuoi_Click;
            btnXoaChon.Click += BtnXoaChon_Click;
            btnTang2.Click += BtnTang2_Click;
            btnBinhPhuong.Click += BtnBinhPhuong_Click;
            btnChonChan.Click += BtnChonChan_Click;
            btnChonLe.Click += BtnChonLe_Click;

            // --- Thêm Control vào Form ---
            this.Controls.Add(lblNhap);
            this.Controls.Add(txtNhapN);
            this.Controls.Add(btnNhap);
            this.Controls.Add(lstSo);

            this.Controls.Add(btnTong);
            this.Controls.Add(btnXoaDauCuoi);
            this.Controls.Add(btnXoaChon);
            this.Controls.Add(btnTang2);
            this.Controls.Add(btnBinhPhuong);
            this.Controls.Add(btnChonChan);
            this.Controls.Add(btnChonLe);
        }

        // --- Nút Nhập số ---
        private void BtnNhap_Click(object sender, EventArgs e)
        {
            if (long.TryParse(txtNhapN.Text.Trim(), out long n) && n >= 0)
            {
                lstSo.Items.Add(n);
                txtNhapN.Clear();
                txtNhapN.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số tự nhiên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapN.Focus();
            }
        }

        // 1. Tính tổng các phần tử
        private void BtnTong_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0)
            {
                MessageBox.Show("Danh sách đang rỗng!", "Thông báo");
                return;
            }

            long tong = 0;
            foreach (var item in lstSo.Items)
            {
                tong += Convert.ToInt64(item);
            }
            MessageBox.Show($"Tổng các phần tử trong ListBox = {tong:N0}", "Kết quả");
        }

        // 2. Xóa phần tử đầu và cuối
        private void BtnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0) return;

            // Xóa phần tử đầu tiên
            lstSo.Items.RemoveAt(0);

            // Nếu vẫn còn phần tử thì xóa tiếp phần tử cuối cùng
            if (lstSo.Items.Count > 0)
            {
                lstSo.Items.RemoveAt(lstSo.Items.Count - 1);
            }
        }

        // 3. Xóa các phần tử đang chọn
        private void BtnXoaChon_Click(object sender, EventArgs e)
        {
            // Duyệt ngược từ cuối danh sách chọn lên đầu để tránh lỗi thay đổi chỉ số
            for (int i = lstSo.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstSo.Items.RemoveAt(lstSo.SelectedIndices[i]);
            }
        }

        // 4. Tăng mỗi phần tử lên 2
        private void BtnTang2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long val = Convert.ToInt64(lstSo.Items[i]);
                lstSo.Items[i] = val + 2;
            }
        }

        // 5. Thay bằng bình phương của chính nó
        private void BtnBinhPhuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long val = Convert.ToInt64(lstSo.Items[i]);
                lstSo.Items[i] = val * val;
            }
        }

        // 6. Chọn tất cả số chẵn
        private void BtnChonChan_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if (Convert.ToInt64(lstSo.Items[i]) % 2 == 0)
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        // 7. Chọn tất cả số lẻ
        private void BtnChonLe_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if (Convert.ToInt64(lstSo.Items[i]) % 2 != 0)
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }
    }
}