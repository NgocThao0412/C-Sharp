
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ThucHanh04c;

public class FormBai1 : Form
{
    // Khai bao cac TextBox
    private TextBox txtA = new TextBox();
    private TextBox txtB = new TextBox();
    private TextBox txtKetQua = new TextBox();

    // Khai bao ErrorProvider
    private ErrorProvider errorProvider1 = new ErrorProvider();

    // Khai bao cac Button
    private Button btnCong = new Button();
    private Button btnTru = new Button();
    private Button btnNhan = new Button();
    private Button btnChia = new Button();

    public FormBai1()
    {
        // Cai dat Form
        Text = "Bai 1 - Bon phep tinh";
        ClientSize = new Size(490, 310);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);

        errorProvider1.ContainerControl = this;

        // Tieu de
        Label lblTieuDe = new Label
        {
            Text = "THUC HIEN CAC PHEP TINH",
            Location = new Point(70, 20),
            Size = new Size(370, 35),
            Font = new Font("Arial", 15, FontStyle.Bold),
            ForeColor = Color.Red
        };
        Controls.Add(lblTieuDe);

        // Nhap so a
        Label lblA = new Label
        {
            Text = "Nhap so a:",
            Location = new Point(40, 85),
            AutoSize = true
        };
        Controls.Add(lblA);

        txtA.Location = new Point(170, 80);
        txtA.Size = new Size(220, 28);
        Controls.Add(txtA);

        // Nhap so b
        Label lblB = new Label
        {
            Text = "Nhap so b:",
            Location = new Point(40, 130),
            AutoSize = true
        };
        Controls.Add(lblB);

        txtB.Location = new Point(170, 125);
        txtB.Size = new Size(220, 28);
        Controls.Add(txtB);

        // Ket qua
        Label lblKetQua = new Label
        {
            Text = "Ket qua:",
            Location = new Point(40, 175),
            AutoSize = true
        };
        Controls.Add(lblKetQua);

        txtKetQua.Location = new Point(170, 170);
        txtKetQua.Size = new Size(220, 28);
        txtKetQua.ReadOnly = true;
        Controls.Add(txtKetQua);

        // Nut Cong
        btnCong.Text = "+";
        btnCong.Location = new Point(55, 230);
        btnCong.Size = new Size(80, 38);
        Controls.Add(btnCong);

        // Nut Tru
        btnTru.Text = "-";
        btnTru.Location = new Point(150, 230);
        btnTru.Size = new Size(80, 38);
        Controls.Add(btnTru);

        // Nut Nhan
        btnNhan.Text = "*";
        btnNhan.Location = new Point(245, 230);
        btnNhan.Size = new Size(80, 38);
        Controls.Add(btnNhan);

        // Nut Chia
        btnChia.Text = "/";
        btnChia.Location = new Point(340, 230);
        btnChia.Size = new Size(80, 38);
        Controls.Add(btnChia);

        // Gan su kien Click
        btnCong.Click += BtnCong_Click;
        btnTru.Click += BtnTru_Click;
        btnNhan.Click += BtnNhan_Click;
        btnChia.Click += BtnChia_Click;

        // Chan nhap ky tu khong hop le
        txtA.KeyPress += KiemTraNhap;
        txtB.KeyPress += KiemTraNhap;

        // Xoa loi va ket qua khi thay doi du lieu
        txtA.TextChanged += DuLieuThayDoi;
        txtB.TextChanged += DuLieuThayDoi;

        // Xac nhan khi dong Form
        FormClosing += FormBai1_FormClosing;

        // Thu tu nhan tieu diem
        txtA.TabIndex = 0;
        txtB.TabIndex = 1;
        btnCong.TabIndex = 2;
        btnTru.TabIndex = 3;
        btnNhan.TabIndex = 4;
        btnChia.TabIndex = 5;

        ActiveControl = txtA;
    }

    // Kiem tra va lay hai so
    private bool LayHaiSo(out double a, out double b)
    {
        errorProvider1.Clear();

        bool hopLeA = double.TryParse(
            txtA.Text,
            NumberStyles.Float,
            CultureInfo.CurrentCulture,
            out a);

        bool hopLeB = double.TryParse(
            txtB.Text,
            NumberStyles.Float,
            CultureInfo.CurrentCulture,
            out b);

        if (!hopLeA)
            errorProvider1.SetError(
                txtA, "So a khong hop le!");

        if (!hopLeB)
            errorProvider1.SetError(
                txtB, "So b khong hop le!");

        if (!hopLeA || !hopLeB)
        {
            txtKetQua.Clear();

            MessageBox.Show(
                "Vui long nhap hai so hop le!",
                "Loi nhap du lieu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        return true;
    }

    // Phep cong
    private void BtnCong_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
            return;

        HienThiKetQua(a + b);
    }

    // Phep tru
    private void BtnTru_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
            return;

        HienThiKetQua(a - b);
    }

    // Phep nhan
    private void BtnNhan_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
            return;

        HienThiKetQua(a * b);
    }

    // Phep chia
    private void BtnChia_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
            return;

        if (b == 0)
        {
            txtKetQua.Clear();

            MessageBox.Show(
                "Khong the chia cho 0!",
                "Loi phep chia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        HienThiKetQua(a / b);
    }

    // Hien thi ket qua va chan tran so
    private void HienThiKetQua(double ketQua)
    {
        if (double.IsNaN(ketQua) ||
            double.IsInfinity(ketQua))
        {
            txtKetQua.Clear();
            MessageBox.Show("Ket qua vuot gioi han!");
            return;
        }

        txtKetQua.Text = ketQua.ToString(
            CultureInfo.CurrentCulture);
    }

    // Kiem tra ky tu nhap
    private void KiemTraNhap(
        object? sender, KeyPressEventArgs e)
    {
        TextBox txt = (TextBox)sender!;

        if (char.IsControl(e.KeyChar))
            return;

        string duLieuMoi =
            txt.Text.Remove(
                txt.SelectionStart,
                txt.SelectionLength)
            .Insert(
                txt.SelectionStart,
                e.KeyChar.ToString());

        // Cho phep so dang nhap do:
        // "", "-", "12", "-12", "12.5"...
        string dau =
            CultureInfo.CurrentCulture
            .NumberFormat.NumberDecimalSeparator;

        bool hopLe =
            duLieuMoi == "-" ||
            duLieuMoi == dau ||
            duLieuMoi == "-" + dau;

        if (!hopLe)
        {
            hopLe = double.TryParse(
                duLieuMoi,
                NumberStyles.Float,
                CultureInfo.CurrentCulture,
                out _);
        }

        e.Handled = !hopLe;
    }

    // Khi du lieu thay doi
    private void DuLieuThayDoi(
        object? sender, EventArgs e)
    {
        txtKetQua.Clear();

        if (sender is TextBox txt)
            errorProvider1.SetError(txt, "");
    }

    // Xac nhan khi dong Form
    private void FormBai1_FormClosing(
        object? sender, FormClosingEventArgs e)
    {
        DialogResult ketQua = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan thoat",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (ketQua == DialogResult.No)
            e.Cancel = true;
    }

    // Giai phong ErrorProvider
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}
