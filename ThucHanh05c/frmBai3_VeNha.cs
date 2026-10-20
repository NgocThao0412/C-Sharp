using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c
{
    public class frmBai3_VeNha : Form
    {
        // Khai báo các Control
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Button btnThem;

        private Label lblDanhBa;
        private TreeView trvDanhBa;

        public frmBai3_VeNha()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Bài 3 Về nhà: Quản lý Danh bạ A - Z (TreeView Phân cấp)";
            this.Size = new Size(650, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Khung nhập thông tin bên trái
            lblHoTen = new Label() { Text = "Họ và tên:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtHoTen = new TextBox() { Location = new Point(20, 45), Size = new Size(240, 23) };

            lblSDT = new Label() { Text = "Số điện thoại:", Location = new Point(20, 85), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtSDT = new TextBox() { Location = new Point(20, 110), Size = new Size(240, 23) };

            lblDiaChi = new Label() { Text = "Địa chỉ:", Location = new Point(20, 150), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtDiaChi = new TextBox() { Location = new Point(20, 175), Size = new Size(240, 23) };

            btnThem = new Button() { Text = "Thêm vào Danh bạ", Location = new Point(20, 220), Size = new Size(240, 35), Font = new Font("Arial", 9, FontStyle.Bold) };

            // TreeView Danh bạ bên phải
            lblDanhBa = new Label() { Text = "Danh bạ phân cấp A - Z:", Location = new Point(290, 20), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            trvDanhBa = new TreeView() { Location = new Point(290, 45), Size = new Size(320, 370), Font = new Font("Arial", 10, FontStyle.Regular) };

            // Đăng ký Sự kiện
            this.Load += FrmBai3_VeNha_Load;
            btnThem.Click += BtnThem_Click;

            // Thêm Control vào Form
            this.Controls.Add(lblHoTen);
            this.Controls.Add(txtHoTen);
            this.Controls.Add(lblSDT);
            this.Controls.Add(txtSDT);
            this.Controls.Add(lblDiaChi);
            this.Controls.Add(txtDiaChi);
            this.Controls.Add(btnThem);
            this.Controls.Add(lblDanhBa);
            this.Controls.Add(trvDanhBa);
        }

        // 1. Form Load: Tạo sẵn 26 chữ cái A -> Z làm các Node gốc
        private void FrmBai3_VeNha_Load(object sender, EventArgs e)
        {
            trvDanhBa.Nodes.Clear();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                // Thêm Node gốc với Key = c.ToString() để dễ tìm kiếm sau này
                trvDanhBa.Nodes.Add(c.ToString(), c.ToString());
            }
        }

        // 2. Thêm người dùng vào Node ký tự tương ứng
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ký tự đầu tiên của Họ tên làm Key tra cứu Node gốc
            char firstChar = char.ToUpper(hoTen[0]);

            if (firstChar >= 'A' && firstChar <= 'Z')
            {
                // Tìm Node gốc tương ứng với ký tự đầu
                TreeNode rootNode = trvDanhBa.Nodes[firstChar.ToString()];
                if (rootNode != null)
                {
                    // Thêm Node liên hệ mới
                    TreeNode personNode = rootNode.Nodes.Add($"{hoTen} - {sdt}");
                    if (!string.IsNullOrEmpty(diaChi))
                    {
                        personNode.Nodes.Add("Địa chỉ: " + diaChi);
                    }

                    rootNode.Expand(); // Mở rộng danh sách ở chữ cái đó
                    trvDanhBa.SelectedNode = personNode; // Focus vào người vừa thêm

                    txtHoTen.Clear();
                    txtSDT.Clear();
                    txtDiaChi.Clear();
                    txtHoTen.Focus();
                }
            }
            else
            {
                MessageBox.Show("Tên liên hệ phải bắt đầu bằng chữ cái Tiếng Anh (A - Z)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
            }
        }
    }
}