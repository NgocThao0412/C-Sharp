
namespace ThucHanh04c;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTieuDe;
    private Label lblNhapSo;
    private Label lblDaySo;
    private Label lblTong;
    private Label lblChan;
    private Label lblLe;

    private TextBox txtNhapSo;
    private TextBox txtDaySo;
    private TextBox txtTong;
    private TextBox txtTongChan;
    private TextBox txtTongLe;

    private Button btnNhap;
    private Button btnTinhTong;
    private Button btnTongChan;
    private Button btnTongLe;
    private Button btnTiepTuc;
    private Button btnThoat;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.Text = "Day so va Tinh Tong";
        this.ClientSize = new Size(520, 410);
        this.StartPosition = FormStartPosition.CenterScreen;

        lblTieuDe = new Label
        {
            Text = "NHAP DAY SO VA TINH TONG",
            Location = new Point(75, 20),
            Size = new Size(390, 35),
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = Color.Red
        };

        lblNhapSo = new Label
        {
            Text = "Nhap so:",
            Location = new Point(40, 85),
            AutoSize = true
        };

        txtNhapSo = new TextBox
        {
            Location = new Point(150, 80),
            Size = new Size(130, 25)
        };

        btnNhap = new Button
        {
            Text = "Nhap",
            Location = new Point(320, 78),
            Size = new Size(100, 30)
        };

        lblDaySo = new Label
        {
            Text = "Day vua nhap:",
            Location = new Point(40, 135),
            AutoSize = true
        };

        txtDaySo = new TextBox
        {
            Location = new Point(150, 130),
            Size = new Size(270, 25),
            ReadOnly = true
        };

        lblTong = new Label
        {
            Text = "Tong day:",
            Location = new Point(40, 185),
            AutoSize = true
        };

        txtTong = new TextBox
        {
            Location = new Point(150, 180),
            Size = new Size(130, 25),
            ReadOnly = true
        };

        lblChan = new Label
        {
            Text = "Tong chan:",
            Location = new Point(40, 235),
            AutoSize = true
        };

        txtTongChan = new TextBox
        {
            Location = new Point(150, 230),
            Size = new Size(100, 25),
            ReadOnly = true
        };

        lblLe = new Label
        {
            Text = "Tong le:",
            Location = new Point(270, 235),
            AutoSize = true
        };

        txtTongLe = new TextBox
        {
            Location = new Point(350, 230),
            Size = new Size(100, 25),
            ReadOnly = true
        };

        btnTinhTong = new Button
        {
            Text = "Tinh tong",
            Location = new Point(40, 285),
            Size = new Size(100, 32)
        };

        btnTongChan = new Button
        {
            Text = "Tong chan",
            Location = new Point(155, 285),
            Size = new Size(100, 32)
        };

        btnTongLe = new Button
        {
            Text = "Tong le",
            Location = new Point(270, 285),
            Size = new Size(100, 32)
        };

        btnTiepTuc = new Button
        {
            Text = "Tiep tuc",
            Location = new Point(110, 345),
            Size = new Size(110, 32)
        };

        btnThoat = new Button
        {
            Text = "Thoat",
            Location = new Point(275, 345),
            Size = new Size(110, 32)
        };

        Controls.AddRange(new Control[]
        {
            lblTieuDe, lblNhapSo, lblDaySo,
            lblTong, lblChan, lblLe,
            txtNhapSo, txtDaySo, txtTong,
            txtTongChan, txtTongLe,
            btnNhap, btnTinhTong, btnTongChan,
            btnTongLe, btnTiepTuc, btnThoat
        });
    }
}
