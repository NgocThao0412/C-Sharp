
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04d;

public class FormBai1 : Form
{
    private RadioButton rdoBacNhat = new RadioButton();
    private RadioButton rdoBacHai = new RadioButton();

    private TextBox txtA = new TextBox();
    private TextBox txtB = new TextBox();
    private TextBox txtC = new TextBox();
    private TextBox txtKetQua = new TextBox();

    private Button btnGiai = new Button();
    private Button btnThoat = new Button();

    private ErrorProvider errorProvider1 = new ErrorProvider();

    private bool daGiai = false;

    public FormBai1()
    {
        Text = "Giai phuong trinh bac 1 - 2";
        ClientSize = new Size(480, 440);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        errorProvider1.ContainerControl = this;

        Label tieuDe = new Label
        {
            Text = "GIAI PHUONG TRINH",
            Location = new Point(65, 20),
            Size = new Size(365, 40),
            Font = new Font("Arial", 19, FontStyle.Bold),
            ForeColor = Color.Red
        };
        Controls.Add(tieuDe);

        GroupBox nhom = new GroupBox
        {
            Text = "Ban vui long chon",
            Location = new Point(35, 70),
            Size = new Size(410, 105)
        };

        rdoBacNhat.Text = "Phuong trinh bac nhat";
        rdoBacNhat.SetBounds(20, 28, 320, 28);

        rdoBacHai.Text = "Phuong trinh bac hai";
        rdoBacHai.SetBounds(20, 62, 320, 28);

        nhom.Controls.Add(rdoBacNhat);
        nhom.Controls.Add(rdoBacHai);
        Controls.Add(nhom);

        ThemNhan("Nhap a:", 35, 200);
        ThemNhan("Nhap b:", 35, 245);
        ThemNhan("Nhap c:", 35, 290);
        ThemNhan("Ket qua:", 35, 345);

        txtA.SetBounds(140, 195, 170, 28);
        txtB.SetBounds(140, 240, 170, 28);
        txtC.SetBounds(140, 285, 170, 28);

        txtKetQua.SetBounds(140, 335, 300, 65);
        txtKetQua.Multiline = true;
        txtKetQua.ReadOnly = true;
        txtKetQua.ScrollBars = ScrollBars.Vertical;

        Controls.AddRange(new Control[]
        {
            txtA, txtB, txtC, txtKetQua
        });

        btnGiai.Text = "Giai";
        btnGiai.SetBounds(330, 205, 105, 45);

        btnThoat.Text = "Thoat";
        btnThoat.SetBounds(330, 270, 105, 45);

        Controls.Add(btnGiai);
        Controls.Add(btnThoat);

        rdoBacNhat.CheckedChanged += ThayDoiLoai;
        rdoBacHai.CheckedChanged += ThayDoiLoai;

        txtA.TextChanged += ThayDoiDuLieu;
        txtB.TextChanged += ThayDoiDuLieu;
        txtC.TextChanged += ThayDoiDuLieu;

        btnGiai.Click += BtnGiai_Click;
        btnThoat.Click += (s, e) => Close();

        FormClosing += FormBai1_FormClosing;

        // Trang thai ban dau
        btnGiai.Enabled = false;
        txtC.Enabled = false;
        rdoBacNhat.Checked = true;

        ActiveControl = txtA;
    }

    private void ThemNhan(string text, int x, int y)
    {
        Label lbl = new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true
        };

        Controls.Add(lbl);
    }

    // Khi doi loai phuong trinh
    private void ThayDoiLoai(object? sender, EventArgs e)
    {
        txtC.Enabled = rdoBacHai.Checked;

        txtC.Clear();
        txtKetQua.Clear();
        errorProvider1.Clear();

        daGiai = false;
        KiemTraNutGiai();
    }

    // Khi nhap hoac sua he so
    private void ThayDoiDuLieu(object? sender, EventArgs e)
    {
        txtKetQua.Clear();
        daGiai = false;

        if (sender is Control ctr)
            errorProvider1.SetError(ctr, "");

        KiemTraNutGiai();
    }

    // Kiem tra du lieu de bat nut Giai
    private void KiemTraNutGiai()
    {
        bool hopLeA = double.TryParse(txtA.Text, out _);
        bool hopLeB = double.TryParse(txtB.Text, out _);

        bool hopLeC = !rdoBacHai.Checked ||
            double.TryParse(txtC.Text, out _);

        btnGiai.Enabled =
            !daGiai && hopLeA && hopLeB && hopLeC;
    }

    // Xu ly nut Giai
    private void BtnGiai_Click(object? sender, EventArgs e)
    {
        errorProvider1.Clear();

        bool hopLeA = double.TryParse(txtA.Text, out double a);
        bool hopLeB = double.TryParse(txtB.Text, out double b);

        bool hopLeC = true;
        double c = 0;

        if (rdoBacHai.Checked)
            hopLeC = double.TryParse(txtC.Text, out c);

        if (!hopLeA)
            errorProvider1.SetError(txtA, "He so a khong hop le");

        if (!hopLeB)
            errorProvider1.SetError(txtB, "He so b khong hop le");

        if (!hopLeC)
            errorProvider1.SetError(txtC, "He so c khong hop le");

        if (!hopLeA || !hopLeB || !hopLeC)
        {
            MessageBox.Show("Vui long nhap he so hop le!");
            KiemTraNutGiai();
            return;
        }

        PhuongTrinhBacHai pt =
            new PhuongTrinhBacHai(a, b, c);

        if (rdoBacNhat.Checked)
            txtKetQua.Text = pt.GiaiBacNhat();
        else
            txtKetQua.Text = pt.GiaiBacHai();

        // Sau khi giai, nut Giai mo di
        daGiai = true;
        btnGiai.Enabled = false;
    }

    // Hoi xac nhan truoc khi thoat
    private void FormBai1_FormClosing(
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}
