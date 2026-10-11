
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThucHanh05c;

public class FormDanhBa : Form
{
    private TreeView trvDanhBa = new TreeView();
    private TextBox txtTen = new TextBox();
    private TextBox txtHoTenDem = new TextBox();

    private Button btnThem = new Button();
    private Button btnThoat = new Button();

    public FormDanhBa()
    {
        Text = "Bai ve nha 3 - Danh ba";
        ClientSize = new Size(760, 550);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);

        // TreeView
        trvDanhBa.SetBounds(20, 20, 300, 495);
        trvDanhBa.HideSelection = false;
        Controls.Add(trvDanhBa);

        // Tao 26 node A - Z
        for (char c = 'A'; c <= 'Z'; c++)
        {
            trvDanhBa.Nodes.Add(c.ToString());
        }

        // Nhom nhap thong tin
        GroupBox grpNhap = new GroupBox
        {
            Text = "Thong tin danh ba",
            Location = new Point(345, 30),
            Size = new Size(385, 245)
        };

        Controls.Add(grpNhap);

        Label lblTen = new Label
        {
            Text = "First Name:",
            Location = new Point(20, 45),
            AutoSize = true
        };

        Label lblHoTenDem = new Label
        {
            Text = "Last Name:",
            Location = new Point(20, 100),
            AutoSize = true
        };

        txtTen.SetBounds(155, 40, 200, 30);
        txtHoTenDem.SetBounds(155, 95, 200, 30);

        btnThem.Text = "&Add";
        btnThem.SetBounds(220, 160, 135, 40);

        grpNhap.Controls.AddRange(new Control[]
        {
            lblTen, lblHoTenDem,
            txtTen, txtHoTenDem, btnThem
        });

        // Nut thoat
        btnThoat.Text = "E&xit";
        btnThoat.SetBounds(570, 315, 135, 40);
        Controls.Add(btnThoat);

        // Gan su kien
        btnThem.Click += BtnThem_Click;
        btnThoat.Click += (s, e) => Close();

        txtTen.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnThem_Click(s, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        };

        FormClosing += XacNhanThoat;

        ActiveControl = txtTen;
    }

    // Chuyen chu tieng Viet ve A - Z
    private string BoDau(string chuoi)
    {
        chuoi = chuoi.Replace('Đ', 'D')
                     .Replace('đ', 'd');

        string normalized =
            chuoi.Normalize(NormalizationForm.FormD);

        StringBuilder ketQua = new StringBuilder();

        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c)
                != UnicodeCategory.NonSpacingMark)
            {
                ketQua.Append(c);
            }
        }

        return ketQua.ToString()
            .Normalize(NormalizationForm.FormC);
    }

    // Xac dinh chu cai dau
    private char LayChuCaiDau(string ten)
    {
        string tenKhongDau = BoDau(ten.Trim());

        if (tenKhongDau.Length == 0)
            return '\0';

        return char.ToUpperInvariant(tenKhongDau[0]);
    }

    // Kiem tra lien he trung
    private bool DaTonTai(
        TreeNode nodeChuCai, string hoTen)
    {
        foreach (TreeNode node in nodeChuCai.Nodes)
        {
            if (string.Equals(
                node.Text,
                hoTen,
                StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    // Them nguoi vao danh ba
    private void BtnThem_Click(
        object? sender, EventArgs e)
    {
        string ten = txtTen.Text.Trim();
        string hoTenDem = txtHoTenDem.Text.Trim();

        if (string.IsNullOrWhiteSpace(ten) ||
            string.IsNullOrWhiteSpace(hoTenDem))
        {
            MessageBox.Show(
                "Vui long nhap day du ho va ten!",
                "Thong bao",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        char chuCai = LayChuCaiDau(ten);

        if (chuCai < 'A' || chuCai > 'Z')
        {
            MessageBox.Show(
                "Ten phai bat dau bang chu cai A - Z!");
            return;
        }

        // Ten day du theo mau cua de
        string hoTen = ten + ", " + hoTenDem;

        TreeNode? nodeChuCai = null;

        foreach (TreeNode node in trvDanhBa.Nodes)
        {
            if (node.Text == chuCai.ToString())
            {
                nodeChuCai = node;
                break;
            }
        }

        if (nodeChuCai == null)
            return;

        if (DaTonTai(nodeChuCai, hoTen))
        {
            MessageBox.Show(
                "Nguoi nay da ton tai trong danh ba!");
            return;
        }

        TreeNode nodeMoi = new TreeNode(hoTen);

        nodeChuCai.Nodes.Add(nodeMoi);

        // Sap xep danh sach trong tung nhom
        var danhSach = nodeChuCai.Nodes
            .Cast<TreeNode>()
            .OrderBy(n => BoDau(n.Text),
                StringComparer.CurrentCultureIgnoreCase)
            .ToList();

        nodeChuCai.Nodes.Clear();

        foreach (TreeNode node in danhSach)
        {
            nodeChuCai.Nodes.Add(node);
        }

        nodeChuCai.Expand();
        trvDanhBa.SelectedNode = nodeMoi;
        nodeMoi.EnsureVisible();

        txtTen.Clear();
        txtHoTenDem.Clear();
        txtTen.Focus();
    }

    // Xac nhan khi thoat
    private void XacNhanThoat(
        object? sender, FormClosingEventArgs e)
    {
        DialogResult kq = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (kq == DialogResult.No)
            e.Cancel = true;
    }
}
