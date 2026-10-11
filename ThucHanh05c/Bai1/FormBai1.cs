
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ThucHanh05c;

public class FormBai1 : Form
{
    private TextBox txtNhapSo = new TextBox();
    private ComboBox cboSo = new ComboBox();
    private ListBox lstUocSo = new ListBox();

    private Button btnCapNhat = new Button();
    private Button btnTong = new Button();
    private Button btnChan = new Button();
    private Button btnNguyenTo = new Button();
    private Button btnThoat = new Button();

    public FormBai1()
    {
        Text = "Bai 1 - ComboBox va ListBox";
        ClientSize = new Size(650, 360);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        // Nhom nhap so
        GroupBox grpNhap = new GroupBox
        {
            Text = "Nhap so",
            Location = new Point(25, 25),
            Size = new Size(290, 190)
        };
        Controls.Add(grpNhap);

        Label lblNhap = new Label
        {
            Text = "Nhap so:",
            Location = new Point(15, 40),
            AutoSize = true
        };
        grpNhap.Controls.Add(lblNhap);

        txtNhapSo.SetBounds(105, 35, 85, 28);
        txtNhapSo.MaxLength = 10;
        grpNhap.Controls.Add(txtNhapSo);

        btnCapNhat.Text = "&Cap nhat";
        btnCapNhat.SetBounds(195, 35, 85, 30);
        grpNhap.Controls.Add(btnCapNhat);

        cboSo.SetBounds(20, 105, 250, 30);
        cboSo.DropDownStyle = ComboBoxStyle.DropDownList;
        grpNhap.Controls.Add(cboSo);

        // Nhom danh sach uoc so
        GroupBox grpUoc = new GroupBox
        {
            Text = "Danh sach cac uoc so",
            Location = new Point(335, 25),
            Size = new Size(285, 190)
        };
        Controls.Add(grpUoc);

        lstUocSo.SetBounds(15, 30, 255, 145);
        grpUoc.Controls.Add(lstUocSo);

        // Cac nut tinh
        btnTong.Text = "&Tong cac uoc so";
        btnTong.SetBounds(335, 230, 285, 32);
        Controls.Add(btnTong);

        btnChan.Text = "So luong uoc so &chan";
        btnChan.SetBounds(335, 267, 285, 32);
        Controls.Add(btnChan);

        btnNguyenTo.Text = "So luong uoc so &nguyen to";
        btnNguyenTo.SetBounds(335, 304, 285, 32);
        Controls.Add(btnNguyenTo);

        // Nut thoat
        btnThoat.Text = "T&hoat";
        btnThoat.SetBounds(160, 275, 110, 38);
        Controls.Add(btnThoat);

        // Gan su kien
        btnCapNhat.Click += BtnCapNhat_Click;
        cboSo.SelectedIndexChanged += CboSo_SelectedIndexChanged;

        btnTong.Click += BtnTong_Click;
        btnChan.Click += BtnChan_Click;
        btnNguyenTo.Click += BtnNguyenTo_Click;

        btnThoat.Click += (s, e) => Close();

        txtNhapSo.KeyPress += TxtNhapSo_KeyPress;
        FormClosing += FormBai1_FormClosing;

        // Trang thai ban dau
        btnTong.Enabled = false;
        btnChan.Enabled = false;
        btnNguyenTo.Enabled = false;

        AcceptButton = btnCapNhat;
        ActiveControl = txtNhapSo;
    }

    // Chi cho nhap chu so
    private void TxtNhapSo_KeyPress(
        object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    // Them so vao ComboBox
    private void BtnCapNhat_Click(
        object? sender, EventArgs e)
    {
        if (!int.TryParse(txtNhapSo.Text.Trim(), out int so)
            || so <= 0)
        {
            MessageBox.Show(
                "Vui long nhap so nguyen duong!",
                "Loi nhap du lieu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNhapSo.Focus();
            return;
        }

        // Kiem tra trung
        if (cboSo.Items.Contains(so))
        {
            MessageBox.Show(
                "So nay da ton tai trong ComboBox!",
                "Thong bao");

            txtNhapSo.SelectAll();
            txtNhapSo.Focus();
            return;
        }

        cboSo.Items.Add(so);
        cboSo.SelectedItem = so;

        txtNhapSo.Clear();
        txtNhapSo.Focus();
    }

    // Chon so se hien thi danh sach uoc
    private void CboSo_SelectedIndexChanged(
        object? sender, EventArgs e)
    {
        lstUocSo.Items.Clear();

        if (cboSo.SelectedItem is not int so)
        {
            CapNhatNutTinh();
            return;
        }

        // Tim cac uoc so va sap xep tang dan
        SortedSet<int> dsUoc = new SortedSet<int>();

        for (int i = 1; i <= so / i; i++)
        {
            if (so % i == 0)
            {
                dsUoc.Add(i);
                dsUoc.Add(so / i);
            }
        }

        foreach (int uoc in dsUoc)
        {
            lstUocSo.Items.Add(uoc);
        }

        CapNhatNutTinh();
    }

    // Bat/tat cac nut tinh
    private void CapNhatNutTinh()
    {
        bool coDuLieu = lstUocSo.Items.Count > 0;

        btnTong.Enabled = coDuLieu;
        btnChan.Enabled = coDuLieu;
        btnNguyenTo.Enabled = coDuLieu;
    }

    // Tong cac uoc so
    private void BtnTong_Click(object? sender, EventArgs e)
    {
        long tong = 0;

        foreach (int uoc in lstUocSo.Items)
        {
            tong += uoc;
        }

        MessageBox.Show(
            "Tong cac uoc so la: " + tong,
            "Ket qua");
    }

    // Dem so luong uoc so chan
    private void BtnChan_Click(object? sender, EventArgs e)
    {
        int dem = 0;

        foreach (int uoc in lstUocSo.Items)
        {
            if (uoc % 2 == 0)
                dem++;
        }

        MessageBox.Show(
            "So luong uoc so chan la: " + dem,
            "Ket qua");
    }

    // Kiem tra so nguyen to
    private bool LaSoNguyenTo(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= n / i; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    // Dem uoc so nguyen to
    private void BtnNguyenTo_Click(
        object? sender, EventArgs e)
    {
        int dem = 0;

        foreach (int uoc in lstUocSo.Items)
        {
            if (LaSoNguyenTo(uoc))
                dem++;
        }

        MessageBox.Show(
            "So luong uoc so nguyen to la: " + dem,
            "Ket qua");
    }

    // Xac nhan truoc khi thoat
    private void FormBai1_FormClosing(
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
