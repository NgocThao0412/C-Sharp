
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ThucHanh05c;

public class FormBai2 : Form
{
    private TreeView trvDanhSach = new TreeView();
    private ComboBox cboLop = new ComboBox();

    private TextBox txtMaSV = new TextBox();
    private TextBox txtHoTen = new TextBox();
    private TextBox txtDiaChi = new TextBox();
    private TextBox txtTenLop = new TextBox();

    private CheckBox chkThemLop = new CheckBox();
    private GroupBox grpThongTinLop = new GroupBox();

    private Button btnCapNhat = new Button();
    private Button btnXoa = new Button();
    private Button btnThemLop = new Button();

    // Luu thong tin sinh vien
    private class SinhVien
    {
        public string MaSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string DiaChi { get; set; } = "";
    }

    public FormBai2()
    {
        Text = "Quan ly sinh vien";
        ClientSize = new Size(850, 520);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 10);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        // TreeView danh sach lop
        trvDanhSach.SetBounds(20, 20, 300, 465);
        trvDanhSach.ShowLines = true;
        trvDanhSach.ShowPlusMinus = true;
        trvDanhSach.ShowRootLines = true;

        TreeNode goc = new TreeNode("Danh sach lop");

        string[] dsLop =
        {
            "05DHTH1", "05DHTH2",
            "05DHTH3", "05DHTH4"
        };

        foreach (string lop in dsLop)
        {
            goc.Nodes.Add(new TreeNode(lop));
            cboLop.Items.Add(lop);
        }

        trvDanhSach.Nodes.Add(goc);
        goc.Expand();
        Controls.Add(trvDanhSach);

        // Chon lop
        TaoNhan("Chon lop:", 345, 35);

        cboLop.SetBounds(470, 30, 340, 28);
        cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLop.SelectedIndex = 0;
        Controls.Add(cboLop);

        // Thong tin sinh vien
        GroupBox grpSinhVien = new GroupBox
        {
            Text = "Thong tin sinh vien",
            Location = new Point(345, 85),
            Size = new Size(475, 250)
        };
        Controls.Add(grpSinhVien);

        TaoNhanTrongNhom(grpSinhVien, "Ma SV:", 20, 40);
        TaoNhanTrongNhom(grpSinhVien, "Ho ten:", 20, 90);
        TaoNhanTrongNhom(grpSinhVien, "Dia chi:", 20, 140);

        txtMaSV.SetBounds(145, 35, 290, 28);
        txtHoTen.SetBounds(145, 85, 290, 28);
        txtDiaChi.SetBounds(145, 135, 290, 28);

        grpSinhVien.Controls.AddRange(new Control[]
        {
            txtMaSV, txtHoTen, txtDiaChi
        });

        btnCapNhat.Text = "Cap nhat";
        btnCapNhat.SetBounds(145, 190, 135, 36);

        btnXoa.Text = "Xoa";
        btnXoa.SetBounds(300, 190, 135, 36);

        grpSinhVien.Controls.Add(btnCapNhat);
        grpSinhVien.Controls.Add(btnXoa);

        // Checkbox them lop
        chkThemLop.Text = "Them lop";
        chkThemLop.SetBounds(345, 350, 150, 28);
        Controls.Add(chkThemLop);

        // Thong tin lop
        grpThongTinLop.Text = "Thong tin lop";
        grpThongTinLop.SetBounds(345, 390, 475, 95);

        TaoNhanTrongNhom(
            grpThongTinLop, "Ten lop:", 20, 40);

        txtTenLop.SetBounds(145, 35, 170, 28);
        grpThongTinLop.Controls.Add(txtTenLop);

        btnThemLop.Text = "Them lop";
        btnThemLop.SetBounds(330, 32, 125, 35);
        grpThongTinLop.Controls.Add(btnThemLop);

        // An groupbox khi khoi dong
        chkThemLop.Checked = false;
        grpThongTinLop.Visible = false;
        Controls.Add(grpThongTinLop);

        // Gan su kien
        chkThemLop.CheckedChanged +=
            ChkThemLop_CheckedChanged;

        btnThemLop.Click += BtnThemLop_Click;
        btnCapNhat.Click += BtnCapNhat_Click;
        btnXoa.Click += BtnXoa_Click;

        trvDanhSach.AfterSelect +=
            TrvDanhSach_AfterSelect;

        FormClosing += XacNhanThoat;

        ActiveControl = txtMaSV;
    }

    private void TaoNhan(string text, int x, int y)
    {
        Controls.Add(new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true
        });
    }

    private void TaoNhanTrongNhom(
        GroupBox nhom, string text, int x, int y)
    {
        nhom.Controls.Add(new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true
        });
    }

    private TreeNode NutGoc()
    {
        return trvDanhSach.Nodes[0];
    }

    // Tim node lop theo ten
    private TreeNode? TimNodeLop(string tenLop)
    {
        foreach (TreeNode node in NutGoc().Nodes)
        {
            if (string.Equals(
                node.Text, tenLop,
                StringComparison.OrdinalIgnoreCase))
            {
                return node;
            }
        }

        return null;
    }

    // Kiem tra ma sinh vien trung tren tat ca lop
    private bool MaSVDaTonTai(string maSV)
    {
        foreach (TreeNode lop in NutGoc().Nodes)
        {
            foreach (TreeNode node in lop.Nodes)
            {
                if (node.Tag is SinhVien sv &&
                    string.Equals(
                        sv.MaSV, maSV,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Hien thi / an thong tin them lop
    private void ChkThemLop_CheckedChanged(
        object? sender, EventArgs e)
    {
        grpThongTinLop.Visible = chkThemLop.Checked;

        if (chkThemLop.Checked)
            txtTenLop.Focus();
        else
            txtTenLop.Clear();
    }

    // Them lop moi
    private void BtnThemLop_Click(
        object? sender, EventArgs e)
    {
        string tenLop = txtTenLop.Text.Trim();

        if (string.IsNullOrWhiteSpace(tenLop))
        {
            MessageBox.Show("Vui long nhap ten lop!");
            txtTenLop.Focus();
            return;
        }

        if (TimNodeLop(tenLop) != null)
        {
            MessageBox.Show("Ten lop da ton tai!");
            txtTenLop.SelectAll();
            txtTenLop.Focus();
            return;
        }

        TreeNode nodeMoi = new TreeNode(tenLop);
        NutGoc().Nodes.Add(nodeMoi);

        cboLop.Items.Add(tenLop);
        cboLop.SelectedItem = tenLop;

        NutGoc().Expand();
        trvDanhSach.SelectedNode = nodeMoi;

        txtTenLop.Clear();

        MessageBox.Show("Them lop thanh cong!");
    }

    // Them sinh vien
    private void BtnCapNhat_Click(
        object? sender, EventArgs e)
    {
        string maSV = txtMaSV.Text.Trim();
        string hoTen = txtHoTen.Text.Trim();
        string diaChi = txtDiaChi.Text.Trim();

        if (maSV == "" || hoTen == "" || diaChi == "")
        {
            MessageBox.Show(
                "Khong duoc de trong thong tin sinh vien!");
            return;
        }

        if (MaSVDaTonTai(maSV))
        {
            MessageBox.Show(
                "Ma sinh vien da ton tai!");
            txtMaSV.Focus();
            return;
        }

        if (cboLop.SelectedItem == null)
        {
            MessageBox.Show("Vui long chon lop!");
            return;
        }

        string tenLop = cboLop.SelectedItem.ToString()!;
        TreeNode? nodeLop = TimNodeLop(tenLop);

        if (nodeLop == null)
        {
            MessageBox.Show("Khong tim thay lop!");
            return;
        }

        SinhVien sv = new SinhVien
        {
            MaSV = maSV,
            HoTen = hoTen,
            DiaChi = diaChi
        };

        TreeNode nodeSinhVien =
            new TreeNode(maSV + ", " + hoTen);

        nodeSinhVien.Tag = sv;

        // Node dia chi nam duoi node sinh vien
        nodeSinhVien.Nodes.Add(
            new TreeNode(diaChi));

        nodeLop.Nodes.Add(nodeSinhVien);
        nodeLop.Expand();
        nodeSinhVien.Expand();

        txtMaSV.Clear();
        txtHoTen.Clear();
        txtDiaChi.Clear();
        txtMaSV.Focus();

        MessageBox.Show("Them sinh vien thanh cong!");
    }

    // Xoa node sinh vien
    private void BtnXoa_Click(
        object? sender, EventArgs e)
    {
        TreeNode? node = trvDanhSach.SelectedNode;

        // Chi duoc xoa node sinh vien
        if (node == null || node.Tag is not SinhVien)
        {
            MessageBox.Show(
                "Chi duoc xoa node sinh vien!");
            return;
        }

        DialogResult kq = MessageBox.Show(
            "Ban co chac muon xoa sinh vien nay?",
            "Xac nhan xoa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (kq == DialogResult.No)
            return;

        node.Remove();

        txtMaSV.Clear();
        txtHoTen.Clear();
        txtDiaChi.Clear();
    }

    // Chon sinh vien thi hien thong tin
    private void TrvDanhSach_AfterSelect(
        object? sender, TreeViewEventArgs e)
    {
        TreeNode node = e.Node!;

        // Neu chon node dia chi, tim node cha
        if (node.Parent?.Tag is SinhVien)
            node = node.Parent;

        if (node.Tag is SinhVien sv)
        {
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            txtDiaChi.Text = sv.DiaChi;

            if (node.Parent != null)
                cboLop.SelectedItem = node.Parent.Text;
        }
    }

    // Xac nhan thoat
    private void XacNhanThoat(
        object? sender, FormClosingEventArgs e)
    {
        DialogResult kq = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan thoat",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (kq == DialogResult.No)
            e.Cancel = true;
    }
}
