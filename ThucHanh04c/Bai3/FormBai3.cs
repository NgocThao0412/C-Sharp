
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04c;

public class FormBai3 : Form
{
    private TextBox txtA = new TextBox();
    private TextBox txtB = new TextBox();
    private TextBox txtUCLN = new TextBox();
    private TextBox txtBCNN = new TextBox();

    private Button btnThucHien = new Button();
    private Button btnTiepTuc = new Button();
    private Button btnThoat = new Button();

    private ErrorProvider errorProvider1 = new ErrorProvider();

    public FormBai3()
    {
        Text = "Uoc So - Boi So";
        ClientSize = new Size(470, 370);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        errorProvider1.ContainerControl = this;

        Label tieuDe = new Label
        {
            Text = "UOC SO CHUNG - BOI SO CHUNG",
            Location = new Point(35, 25),
            Size = new Size(420, 35),
            Font = new Font("Arial", 15, FontStyle.Bold),
            ForeColor = Color.Red
        };
        Controls.Add(tieuDe);

        ThemNhan("Nhap so a:", 45, 90);
        ThemNhan("Nhap so b:", 45, 135);
        ThemNhan("Uoc so chung lon nhat:", 45, 180);
        ThemNhan("Boi so chung nho nhat:", 45, 225);

        txtA.SetBounds(265, 85, 155, 28);
        txtB.SetBounds(265, 130, 155, 28);
        txtUCLN.SetBounds(265, 175, 155, 28);
        txtBCNN.SetBounds(265, 220, 155, 28);

        txtUCLN.ReadOnly = true;
        txtBCNN.ReadOnly = true;

        Controls.AddRange(new Control[]
        {
            txtA, txtB, txtUCLN, txtBCNN
        });

        btnThucHien.Text = "Thuc Hien";
        btnThucHien.SetBounds(35, 290, 120, 40);

        btnTiepTuc.Text = "Tiep Tuc";
        btnTiepTuc.SetBounds(175, 290, 120, 40);

        btnThoat.Text = "Thoat";
        btnThoat.SetBounds(315, 290, 120, 40);

        Controls.AddRange(new Control[]
        {
            btnThucHien, btnTiepTuc, btnThoat
        });

        btnThucHien.Click += BtnThucHien_Click;
        btnTiepTuc.Click += BtnTiepTuc_Click;
        btnThoat.Click += BtnThoat_Click;

        txtA.TextChanged += XoaKetQua;
        txtB.TextChanged += XoaKetQua;

        AcceptButton = btnThucHien;
        ActiveControl = txtA;
    }

    private void ThemNhan(string noiDung, int x, int y)
    {
        Label lbl = new Label
        {
            Text = noiDung,
            Location = new Point(x, y),
            AutoSize = true
        };

        Controls.Add(lbl);
    }

    // Tinh UCLN bang thuat toan Euclid
    private long TinhUCLN(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            long du = a % b;
            a = b;
            b = du;
        }

        return a;
    }

    // Xu ly nut Thuc hien
    private void BtnThucHien_Click(
        object? sender, EventArgs e)
    {
        errorProvider1.Clear();

        bool hopLeA = int.TryParse(txtA.Text, out int a);
        bool hopLeB = int.TryParse(txtB.Text, out int b);

        if (!hopLeA)
            errorProvider1.SetError(
                txtA, "Vui long nhap so nguyen!");

        if (!hopLeB)
            errorProvider1.SetError(
                txtB, "Vui long nhap so nguyen!");

        if (!hopLeA || !hopLeB)
        {
            MessageBox.Show(
                "Du lieu phai la so nguyen!",
                "Loi nhap du lieu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (a == 0 && b == 0)
        {
            MessageBox.Show(
                "UCLN cua hai so 0 khong xac dinh!");
            return;
        }

        long ucln = TinhUCLN(a, b);

        // Neu mot trong hai so la 0 thi BCNN = 0
        long bcnn = 0;

        if (a != 0 && b != 0)
        {
            bcnn = Math.Abs(((long)a / ucln) * b);
        }

        txtUCLN.Text = ucln.ToString();
        txtBCNN.Text = bcnn.ToString();
    }

    // Xu ly nut Tiep tuc
    private void BtnTiepTuc_Click(
        object? sender, EventArgs e)
    {
        txtA.Clear();
        txtB.Clear();
        txtUCLN.Clear();
        txtBCNN.Clear();

        errorProvider1.Clear();
        txtA.Focus();
    }

    // Xoa ket qua cu khi thay doi du lieu
    private void XoaKetQua(
        object? sender, EventArgs e)
    {
        txtUCLN.Clear();
        txtBCNN.Clear();

        if (sender is Control control)
            errorProvider1.SetError(control, "");
    }

    // Nut Thoat
    private void BtnThoat_Click(
        object? sender, EventArgs e)
    {
        Close();
    }

    // Xac nhan khi dong Form
    protected override void OnFormClosing(
        FormClosingEventArgs e)
    {
        DialogResult ketQua = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (ketQua == DialogResult.No)
            e.Cancel = true;

        base.OnFormClosing(e);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}
