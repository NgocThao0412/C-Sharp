
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04c;

public class FormBai5 : Form
{
    private TextBox txtSo = new TextBox();
    private TextBox txtKetQua = new TextBox();

    private Button btnThucHien = new Button();
    private Button btnXoa = new Button();
    private Button btnThoat = new Button();

    private ErrorProvider errorProvider1 = new ErrorProvider();

    private readonly string[] chuSo =
    {
        "không", "một", "hai", "ba", "bốn",
        "năm", "sáu", "bảy", "tám", "chín"
    };

    public FormBai5()
    {
        Text = "Bai 5 - Doc so thanh chu";
        ClientSize = new Size(560, 340);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        errorProvider1.ContainerControl = this;

        Label lblTieuDe = new Label
        {
            Text = "CHUONG TRINH DOC SO THANH CHU",
            Location = new Point(45, 20),
            Size = new Size(490, 40),
            Font = new Font("Arial", 15, FontStyle.Bold),
            ForeColor = Color.Blue
        };
        Controls.Add(lblTieuDe);

        Label lblSo = new Label
        {
            Text = "Nhap so (1 - 999):",
            Location = new Point(35, 95),
            AutoSize = true
        };
        Controls.Add(lblSo);

        txtSo.Location = new Point(215, 90);
        txtSo.Size = new Size(270, 28);
        txtSo.MaxLength = 3;
        Controls.Add(txtSo);

        Label lblKetQua = new Label
        {
            Text = "Doc thanh chu:",
            Location = new Point(35, 160),
            AutoSize = true
        };
        Controls.Add(lblKetQua);

        txtKetQua.Location = new Point(215, 155);
        txtKetQua.Size = new Size(270, 65);
        txtKetQua.Multiline = true;
        txtKetQua.ReadOnly = true;
        Controls.Add(txtKetQua);

        btnThucHien.Text = "Thuc hien";
        btnThucHien.SetBounds(50, 260, 130, 40);

        btnXoa.Text = "Xoa";
        btnXoa.SetBounds(215, 260, 130, 40);

        btnThoat.Text = "Thoat";
        btnThoat.SetBounds(380, 260, 130, 40);

        Controls.AddRange(new Control[]
        {
            btnThucHien, btnXoa, btnThoat
        });

        btnThucHien.Click += BtnThucHien_Click;
        btnXoa.Click += BtnXoa_Click;
        btnThoat.Click += BtnThoat_Click;

        txtSo.KeyPress += TxtSo_KeyPress;
        txtSo.TextChanged += TxtSo_TextChanged;

        FormClosing += FormBai5_FormClosing;

        AcceptButton = btnThucHien;
        ActiveControl = txtSo;
    }

    // Chi cho nhap chu so
    private void TxtSo_KeyPress(
        object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void TxtSo_TextChanged(
        object? sender, EventArgs e)
    {
        txtKetQua.Clear();
        errorProvider1.SetError(txtSo, "");
    }

    // Doc hai chu so
    private string DocHaiChuSo(int so, bool coHangTram)
    {
        int chuc = so / 10;
        int donVi = so % 10;

        if (chuc == 0)
        {
            if (donVi == 0)
                return "";

            if (coHangTram)
                return "lẻ " + chuSo[donVi];

            return chuSo[donVi];
        }

        if (chuc == 1)
        {
            if (donVi == 0)
                return "mười";

            if (donVi == 5)
                return "mười lăm";

            return "mười " + chuSo[donVi];
        }

        string ketQua = chuSo[chuc] + " mươi";

        if (donVi == 0)
            return ketQua;

        if (donVi == 1)
            return ketQua + " mốt";

        if (donVi == 5)
            return ketQua + " lăm";

        return ketQua + " " + chuSo[donVi];
    }

    // Doc so tu 1 den 999
    private string DocSo(int so)
    {
        if (so < 100)
            return DocHaiChuSo(so, false);

        int tram = so / 100;
        int phanConLai = so % 100;

        string ketQua = chuSo[tram] + " trăm";

        if (phanConLai == 0)
            return ketQua;

        return ketQua + " " +
            DocHaiChuSo(phanConLai, true);
    }

    // Nut Thuc hien
    private void BtnThucHien_Click(
        object? sender, EventArgs e)
    {
        errorProvider1.Clear();

        if (!int.TryParse(txtSo.Text, out int so) ||
            so < 1 || so > 999)
        {
            txtKetQua.Clear();

            errorProvider1.SetError(
                txtSo, "Nhap so nguyen tu 1 den 999!");

            MessageBox.Show(
                "Vui long nhap so nguyen tu 1 den 999!",
                "Loi nhap du lieu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        txtKetQua.Text = DocSo(so);
    }

    // Nut Xoa
    private void BtnXoa_Click(
        object? sender, EventArgs e)
    {
        txtSo.Clear();
        txtKetQua.Clear();
        errorProvider1.Clear();
        txtSo.Focus();
    }

    // Nut Thoat
    private void BtnThoat_Click(
        object? sender, EventArgs e)
    {
        Close();
    }

    // Xac nhan khi dong Form
    private void FormBai5_FormClosing(
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}
