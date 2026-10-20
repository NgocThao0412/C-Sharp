using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c
{
    public class frmBai1_TaiLop : Form
    {
        // 1. Khai báo tất cả các Control
        private Label lblNhapSo;
        private TextBox txtNhapSo;
        private Button btnCapNhat;
        private Label lblSo;
        private ComboBox cboSo;
        private Label lblUocSo;
        private ListBox lstUocSo;
        private Button btnTongUoc;
        private Button btnDemChan;
        private Button btnDemNT;
        private Button btnThoat;

        public frmBai1_TaiLop()
        {
            InitializeComponent();
        }

        // 2. Khởi tạo giao diện hoàn toàn bằng Code
        private void InitializeComponent()
        {
            this.Text = "Bài 1: Xử lý Số & Tìm Ước số";
            this.Size = new Size(520, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Nhập số
            lblNhapSo = new Label() { Text = "Nhập số:", Location = new Point(20, 20), AutoSize = true };
            txtNhapSo = new TextBox() { Location = new Point(90, 17), Size = new Size(120, 23) };
            btnCapNhat = new Button() { Text = "&Cập nhật", Location = new Point(220, 16), Size = new Size(90, 25) };

            // ComboBox Chọn số
            lblSo = new Label() { Text = "Chọn số:", Location = new Point(20, 60), AutoSize = true };
            cboSo = new ComboBox() { Location = new Point(90, 57), Size = new Size(120, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            // ListBox Ước số
            lblUocSo = new Label() { Text = "Danh sách ước số:", Location = new Point(20, 100), AutoSize = true };
            lstUocSo = new ListBox() { Location = new Point(20, 125), Size = new Size(190, 180) };

            // Các nút chức năng bên phải
            btnTongUoc = new Button() { Text = "&Tổng các ước số", Location = new Point(240, 125), Size = new Size(230, 35) };
            btnDemChan = new Button() { Text = "Số lượng ước số &chẵn", Location = new Point(240, 170), Size = new Size(230, 35) };
            btnDemNT = new Button() { Text = "Số lượng ước số &nguyên tố", Location = new Point(240, 215), Size = new Size(230, 35) };
            btnThoat = new Button() { Text = "Thố&at", Location = new Point(240, 260), Size = new Size(230, 35) };

            // Đăng ký Sự kiện (Event Handlers)
            btnCapNhat.Click += BtnCapNhat_Click;
            cboSo.SelectedIndexChanged += CboSo_SelectedIndexChanged;
            btnTongUoc.Click += BtnTongUoc_Click;
            btnDemChan.Click += BtnDemChan_Click;
            btnDemNT.Click += BtnDemNT_Click;
            btnThoat.Click += (s, e) => this.Close();
            this.FormClosing += FrmBai1_TaiLop_FormClosing;

            // Thêm tất cả Control vào Form
            this.Controls.Add(lblNhapSo);
            this.Controls.Add(txtNhapSo);
            this.Controls.Add(btnCapNhat);
            this.Controls.Add(lblSo);
            this.Controls.Add(cboSo);
            this.Controls.Add(lblUocSo);
            this.Controls.Add(lstUocSo);
            this.Controls.Add(btnTongUoc);
            this.Controls.Add(btnDemChan);
            this.Controls.Add(btnDemNT);
            this.Controls.Add(btnThoat);
        }

        // 3. Xử lý Logic nghiệp vụ
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhapSo.Text.Trim(), out int n) && n > 0)
            {
                if (!cboSo.Items.Contains(n))
                {
                    cboSo.Items.Add(n);
                    cboSo.SelectedItem = n;
                    txtNhapSo.Clear();
                    txtNhapSo.Focus();
                }
                else
                {
                    MessageBox.Show("Số này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapSo.Focus();
            }
        }

        private void CboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear();
            if (cboSo.SelectedItem != null)
            {
                int n = Convert.ToInt32(cboSo.SelectedItem);
                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0) lstUocSo.Items.Add(i);
                }
            }
        }

        private void BtnTongUoc_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0) return;
            int tong = 0;
            foreach (var item in lstUocSo.Items) tong += Convert.ToInt32(item);
            MessageBox.Show($"Tổng các ước số = {tong}", "Kết quả");
        }

        private void BtnDemChan_Click(object sender, EventArgs e)
        {
            int dem = 0;
            foreach (var item in lstUocSo.Items)
            {
                if (Convert.ToInt32(item) % 2 == 0) dem++;
            }
            MessageBox.Show($"Số lượng ước số chẵn = {dem}", "Kết quả");
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        private void BtnDemNT_Click(object sender, EventArgs e)
        {
            int dem = 0;
            foreach (var item in lstUocSo.Items)
            {
                if (IsPrime(Convert.ToInt32(item))) dem++;
            }
            MessageBox.Show($"Số lượng ước số nguyên tố = {dem}", "Kết quả");
        }

        private void FrmBai1_TaiLop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}