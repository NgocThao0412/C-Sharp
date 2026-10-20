using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c
{
    public class frmBai2_TaiLop : Form
    {
        // 1. Khai báo các Control trên giao diện
        private CheckBox chkThemLop;
        private GroupBox grpThongTinLop;
        private Label lblTenLop;
        private TextBox txtTenLop;
        private Button btnThemLop;

        private Label lblChonLop;
        private ComboBox cboChonLop;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Button btnCapNhatSV;
        private Button btnXoa;

        private Label lblDanhSach;
        private TreeView trvDanhSach;

        public frmBai2_TaiLop()
        {
            InitializeComponent();
        }

        // 2. Tự thiết kế và dựng Giao diện hoàn toàn bằng Code
        private void InitializeComponent()
        {
            this.Text = "Bài 2: Quản lý Lớp & Sinh viên";
            this.Size = new Size(720, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // --- CheckBox Thêm Lớp ---
            chkThemLop = new CheckBox()
            {
                Text = "Thêm lớp mới",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            // --- GroupBox Thông tin lớp (Ẩn/Hiện theo CheckBox) ---
            grpThongTinLop = new GroupBox()
            {
                Text = "Thông tin lớp",
                Location = new Point(20, 40),
                Size = new Size(340, 80),
                Visible = false // Mặc định ẩn theo đề bài
            };

            lblTenLop = new Label() { Text = "Tên lớp:", Location = new Point(15, 30), AutoSize = true };
            txtTenLop = new TextBox() { Location = new Point(80, 27), Size = new Size(130, 23) };
            btnThemLop = new Button() { Text = "Thêm lớp", Location = new Point(220, 25), Size = new Size(100, 28) };

            grpThongTinLop.Controls.Add(lblTenLop);
            grpThongTinLop.Controls.Add(txtTenLop);
            grpThongTinLop.Controls.Add(btnThemLop);

            // --- Nhập thông tin Sinh viên ---
            int startY = 130;

            lblChonLop = new Label() { Text = "Chọn lớp:", Location = new Point(20, startY), AutoSize = true };
            cboChonLop = new ComboBox() { Location = new Point(100, startY - 3), Size = new Size(260, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            lblMaSV = new Label() { Text = "Mã SV:", Location = new Point(20, startY + 35), AutoSize = true };
            txtMaSV = new TextBox() { Location = new Point(100, startY + 32), Size = new Size(260, 23) };

            lblHoTen = new Label() { Text = "Họ tên:", Location = new Point(20, startY + 70), AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(100, startY + 67), Size = new Size(260, 23) };

            lblDiaChi = new Label() { Text = "Địa chỉ:", Location = new Point(20, startY + 105), AutoSize = true };
            txtDiaChi = new TextBox() { Location = new Point(100, startY + 102), Size = new Size(260, 23) };

            btnCapNhatSV = new Button() { Text = "Cập nhật SV", Location = new Point(100, startY + 145), Size = new Size(120, 32) };
            btnXoa = new Button() { Text = "Xóa SV", Location = new Point(240, startY + 145), Size = new Size(120, 32) };

            // --- TreeView Danh sách ---
            lblDanhSach = new Label() { Text = "Danh sách Lớp - Sinh viên:", Location = new Point(380, 15), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            trvDanhSach = new TreeView() { Location = new Point(380, 40), Size = new Size(300, 420) };

            // --- Đăng ký Sự kiện (Event Handlers) ---
            this.Load += FrmBai2_TaiLop_Load;
            chkThemLop.CheckedChanged += ChkThemLop_CheckedChanged;
            btnThemLop.Click += BtnThemLop_Click;
            btnCapNhatSV.Click += BtnCapNhatSV_Click;
            btnXoa.Click += BtnXoa_Click;
            trvDanhSach.AfterSelect += TrvDanhSach_AfterSelect;

            // --- Thêm tất cả vào Form ---
            this.Controls.Add(chkThemLop);
            this.Controls.Add(grpThongTinLop);
            this.Controls.Add(lblChonLop);
            this.Controls.Add(cboChonLop);
            this.Controls.Add(lblMaSV);
            this.Controls.Add(txtMaSV);
            this.Controls.Add(lblHoTen);
            this.Controls.Add(txtHoTen);
            this.Controls.Add(lblDiaChi);
            this.Controls.Add(txtDiaChi);
            this.Controls.Add(btnCapNhatSV);
            this.Controls.Add(btnXoa);
            this.Controls.Add(lblDanhSach);
            this.Controls.Add(trvDanhSach);
        }

        // 3. Xử lý Logic Nghiệp vụ

        // 3.1. Form Load: Khởi tạo dữ liệu lớp ban đầu [1]
        private void FrmBai2_TaiLop_Load(object sender, EventArgs e)
        {
            string[] dsLopBanDau = { "CD21CT1", "CD21CT2", "CD21CT3" };
            foreach (string lop in dsLopBanDau)
            {
                trvDanhSach.Nodes.Add(lop, lop);
                cboChonLop.Items.Add(lop);
            }
            if (cboChonLop.Items.Count > 0)
                cboChonLop.SelectedIndex = 0;
        }

        // 3.2. Ẩn/Hiện GroupBox nhập lớp theo CheckBox [1]
        private void ChkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            grpThongTinLop.Visible = chkThemLop.Checked;
        }

        // 3.3. Thêm Lớp mới (Có kiểm tra trùng) [1]
        private void BtnThemLop_Click(object sender, EventArgs e)
        {
            string tenLop = txtTenLop.Text.Trim();
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }

            // Kiểm tra trùng tên lớp không phân biệt hoa thường [3]
            foreach (TreeNode node in trvDanhSach.Nodes)
            {
                if (string.Compare(node.Text, tenLop, true) == 0)
                {
                    MessageBox.Show("Lớp này đã tồn tại trong danh sách!", "Lỗi trùng lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenLop.Focus();
                    return;
                }
            }

            // Thêm lớp mới vào TreeView và ComboBox [1]
            trvDanhSach.Nodes.Add(tenLop, tenLop);
            cboChonLop.Items.Add(tenLop);
            cboChonLop.SelectedItem = tenLop;

            txtTenLop.Clear();
            chkThemLop.Checked = false; // Tự động ẩn khung nhập lớp sau khi thêm thành công
        }

        // 3.4. Cập nhật (Thêm Sinh viên vào lớp đang chọn) [2]
        private void BtnCapNhatSV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // Kiểm tra rỗng [2]
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã SV, Họ tên và Địa chỉ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboChonLop.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần thêm sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenLopChon = cboChonLop.SelectedItem.ToString();

            // Tìm node lớp tương ứng trên TreeView
            TreeNode[] targetNodes = trvDanhSach.Nodes.Find(tenLopChon, false);
            if (targetNodes.Length > 0)
            {
                TreeNode nodeLop = targetNodes[0];

                // Kiểm tra trùng Mã SV trong lớp đó [2]
                foreach (TreeNode svNode in nodeLop.Nodes)
                {
                    if (svNode.Name == maSV)
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại trong lớp!", "Lỗi trùng Mã SV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaSV.Focus();
                        return;
                    }
                }

                // Thêm Node Sinh viên và Node con Địa chỉ [2]
                TreeNode nodeSV = nodeLop.Nodes.Add(maSV, $"{hoTen} ({maSV})");
                nodeSV.Nodes.Add("Địa chỉ: " + diaChi);

                nodeLop.Expand(); // Mở rộng danh sách lớp [4]

                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                txtMaSV.Focus();
            }
        }

        // 3.5. Nút Xóa: Chỉ cho phép xóa Node Sinh viên (Có xác nhận) [2]
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = trvDanhSach.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trên cây để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu người dùng chọn Node gốc (Node Lớp) -> Không cho phép xóa [2]
            if (selectedNode.Parent == null)
            {
                MessageBox.Show("Chỉ được phép xóa Sinh viên, không thể xóa Node Lớp tại đây!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm Node Sinh viên (Cấp 1)
            TreeNode nodeSV = (selectedNode.Parent.Parent == null) ? selectedNode : selectedNode.Parent;

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên '{nodeSV.Text}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                nodeSV.Remove();
            }
        }

        // 3.6. Hiển thị thông tin Sinh viên lên Textbox khi chọn Node trên TreeView [2]
        private void TrvDanhSach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;

            // Kiểm tra xem node chọn có phải là Node Sinh viên (cấp 1) hay không
            if (node.Parent != null && node.Parent.Parent == null)
            {
                txtMaSV.Text = node.Name;

                // Tách lấy Họ tên từ định dạng "Họ tên (MãSV)"
                string fullText = node.Text;
                int lastIdx = fullText.LastIndexOf('(');
                if (lastIdx > 0)
                {
                    txtHoTen.Text = fullText.Substring(0, lastIdx).Trim();
                }

                // Lấy Địa chỉ từ Node con
                if (node.Nodes.Count > 0)
                {
                    txtDiaChi.Text = node.Nodes[0].Text.Replace("Địa chỉ: ", "");
                }

                cboChonLop.SelectedItem = node.Parent.Text;
            }
        }
    }
}