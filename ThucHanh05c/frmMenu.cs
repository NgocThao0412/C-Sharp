using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "MENU BÀI THỰC HÀNH 05C - WINFORM NÂNG CAO";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Label lblTitle = new Label()
            {
                Text = "DANH SÁCH BÀI TẬP THỰC HÀNH 05C",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Navy,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };

            // GroupBox Bài tập tại lớp
            GroupBox grpTaiLop = new GroupBox()
            {
                Text = "BÀI TẬP TẠI LỚP",
                Location = new Point(30, 60),
                Size = new Size(420, 130),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button btnBai1TL = new Button()
            {
                Text = "Bài 1: Xử lý Số & Tìm Ước số",
                Location = new Point(20, 30),
                Size = new Size(380, 35),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            btnBai1TL.Click += (s, e) => new frmBai1_TaiLop().ShowDialog();

            Button btnBai2TL = new Button()
            {
                Text = "Bài 2: Quản lý Lớp & Sinh viên (TreeView)",
                Location = new Point(20, 75),
                Size = new Size(380, 35),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            btnBai2TL.Click += (s, e) => new frmBai2_TaiLop().ShowDialog();

            grpTaiLop.Controls.Add(btnBai1TL);
            grpTaiLop.Controls.Add(btnBai2TL);

            // GroupBox Bài tập về nhà
            GroupBox grpVeNha = new GroupBox()
            {
                Text = "BÀI TẬP VỀ NHÀ",
                Location = new Point(30, 200),
                Size = new Size(420, 170),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button btnBai1VN = new Button()
            {
                Text = "Bài 1: Từ điển Anh - Việt (ComboBox AutoComplete)",
                Location = new Point(20, 30),
                Size = new Size(380, 35),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            btnBai1VN.Click += (s, e) => new frmBai1_VeNha().ShowDialog();

            Button btnBai2VN = new Button()
            {
                Text = "Bài 2: Thao tác ListBox Đa chọn (Số tự nhiên)",
                Location = new Point(20, 75),
                Size = new Size(380, 35),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            btnBai2VN.Click += (s, e) => new frmBai2_VeNha().ShowDialog();

            Button btnBai3VN = new Button()
            {
                Text = "Bài 3: Quản lý Danh bạ A-Z (TreeView Phân cấp)",
                Location = new Point(20, 120),
                Size = new Size(380, 35),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            btnBai3VN.Click += (s, e) => new frmBai3_VeNha().ShowDialog();

            grpVeNha.Controls.Add(btnBai1VN);
            grpVeNha.Controls.Add(btnBai2VN);
            grpVeNha.Controls.Add(btnBai3VN);

            this.Controls.Add(lblTitle);
            this.Controls.Add(grpTaiLop);
            this.Controls.Add(grpVeNha);
        }
    }
}