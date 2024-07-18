using BLL_DAL;
//using DevExpress.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class SanPham_Con : UserControl
    {
        ChiTietDonHang_DAL ct=new ChiTietDonHang_DAL();
        NhapSoLuong t = new NhapSoLuong();
        public int mahd;
        public event EventHandler chon_click;

        public SanPham_Con()
        {
            InitializeComponent();
        }
        public SanPham_Con(int mahoadon)
        {
            InitializeComponent();
            this.mahd = mahoadon;
        }

        string masp, tensp, giaban, soluong;

        private string hinhanh;
        [Category("Custom Props")]
        public string Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; hinh.LoadAsync(value); }
        }
        public int laysoluong()
        {
            return int.Parse(txt_soluong.Text);
        }
        public SanPham_Con(string m,string t,string giaban,string soluong,string h)
        {
            this.masp = m;
            this.tensp = t;
            this.giaban = giaban;
            this.soluong = soluong;
            this.hinhanh = h;
            InitializeComponent();
            
        }

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Giaban { get => giaban; set => giaban = value; }
        public event EventHandler capnhat_click;
        private void btn_chon_Click(object sender, EventArgs e)
        {
                chon_click?.Invoke(this, EventArgs.Empty);
            btn_chon.Text = "Mua thêm";
        }
        public string Soluong { get => soluong; set => soluong = value; }
        public int Mahd { get => mahd; set => mahd = value; }

        private void SanPham_Con_Load(object sender, EventArgs e)
        {
            txt_mamon.Text = masp;  
            txt_giaban.Text = giaban;
            txt_tenmon.Text = tensp;
            txt_soluong.Text = soluong;
            hinh.Image= Image.FromFile(hinhanh);
            frm_ThanhToan tt = new frm_ThanhToan();
      
        }

        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || (e.KeyChar == '0' && textBox.Text.Length == 0))
            {
                e.Handled = true; 
                MessageBox.Show("Vui lòng nhập một số nguyên dương khác 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
