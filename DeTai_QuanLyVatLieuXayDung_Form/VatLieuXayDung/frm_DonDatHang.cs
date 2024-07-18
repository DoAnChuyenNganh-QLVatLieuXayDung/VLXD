using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_DonDatHang : Form
    {
        int mahoaDon;

        string ten;

        public int MahoaDon
        {
            get { return mahoaDon; }
            set { mahoaDon = value; }
        }

        public string Ten { get => ten; set => ten = value; }

        KhachHang_DAL   kh=new KhachHang_DAL();
        ChiTietDonHang_DAL ct_hd = new ChiTietDonHang_DAL();
        HoaDon_DAL hd=new HoaDon_DAL();
        public frm_DonDatHang()
        {
            InitializeComponent();
            Load += Frm_DonDatHang_Load;
        }

        private void Frm_DonDatHang_Load(object sender, EventArgs e)
        {
            load_hoadon();
            cbm_trangthaidonhang.Enabled = false;
            radibtn_xacnhan.Enabled = false;
            radibtn_chogiaohang.Enabled = false;
            radibtn_cholayhang.Enabled=false;
            cbm_trangthaidonhang.Items.Add("Tất cả");
            cbm_trangthaidonhang.Items.Add("Chờ xác nhận");
            cbm_trangthaidonhang.Items.Add("Chờ lấy hàng");
            cbm_trangthaidonhang.Items.Add("Chờ giao hàng");
            cbm_trangthaidonhang.Items.Add("Đang giao hàng");
            cbm_trangthaidonhang.Items.Add("Giao hàng thành công");
            List<DateTime> l = hd.LayDanhSachNgayLap();
            List<DateTime> ls = new List<DateTime>();
            foreach (DateTime s in l)
            {

                ls.Add(DateTime.Parse(s.ToString()));
            }
            List<int> ngay = LayDanhSachNgay(ls);
            List<int> thang = LayDanhSachThang(ls);
            List<int> nam = LayDanhSachNam(ls);
            foreach (int columnIndex in ngay)
            {
                cbm_ngay.Items.Add(columnIndex);
            }
            foreach (int columnIndex in thang)
            {
                cbm_thang.Items.Add(columnIndex);
            }
            foreach (int columnIndex in nam)
            {
                cbm_nam.Items.Add(columnIndex);
            }
        }
 

        public void load_hoadon()
        {
            data_hoadon.DataSource = null;
            data_hoadon.DataSource = hd.load();
            btn_xacnhanthanhtoan.Text = "Xác Nhận Đơn";
            data_hoadon.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            data_hoadon.Columns["NgayLapHD"].HeaderText = "Ngày Lập ";
            data_hoadon.Columns["TienCoc"].HeaderText = "Tiền Cọc";
            data_hoadon.Columns["MaKhuyenMai"].HeaderText = "Khuyến Mãi";
            data_hoadon.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            data_hoadon.Columns["TrangThaiDonHang"].HeaderText = "Trạng Thái";
           
            int[] columnsToHide = {1,3,4,5,6,7,11,12,14,15};
            foreach (int columnIndex in columnsToHide)
            {
                data_hoadon.Columns[columnIndex].Visible = false;
            }




    

        }

        public void load_ct_hoadon(int makh)
        {
            data_chitietdonhang.DataSource = null;
            data_chitietdonhang.DataSource = ct_hd.LoadChiTiet_HoaDon(makh);
            data_chitietdonhang.Columns["Mahoadon"].HeaderText = "Mã Hóa Đơn";
            data_chitietdonhang.Columns["Tensp"].HeaderText = "Tên sản phẩm";
           
            data_chitietdonhang.Columns["Soluong"].HeaderText = "Số lượng";
            data_chitietdonhang.Columns["Giaban"].HeaderText = "Giá bán";
            data_chitietdonhang.Columns["Thanhtien"].HeaderText = "Thành Tiền";
            //int[] columnsToHide = {5,6};
            //foreach (int columnIndex in columnsToHide)
            //{
            //    data_chitietdonhang.Columns[columnIndex].Visible = false;
            //}
        }

        public void check_trangthai()
        {
            Boolean kt = hd.update(mahoaDon);
            if (kt)
            {
                MessageBox.Show("Xác nhận thành công !", "Thông Báo", MessageBoxButtons.OK);
                string user = ten;
                DateTime ngay = DateTime.Now;
                string hoatdong = "Xác nhận thanh toán cho hoá đơn : " + mahoaDon;
                string trangthai = "On";

                List<LichSuHoatDong> ketQua = kh.insertLS(user, ngay, hoatdong, trangthai);
            }
            else
            {

                MessageBox.Show("Xác nhận không thành công !", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void check_trangthaidonhang(string trangthaidonhang)
        {
            Boolean kt = hd.update_trangthaidonhang(mahoaDon, trangthaidonhang);
            if (kt)
            {
                MessageBox.Show("Xác nhận " + trangthaidonhang + "  thành công !", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Information);



                string user = ten;
                DateTime ngay = DateTime.Now;
                string hoatdong = "Xác nhận trạng thái "+trangthaidonhang+" cho đơn hàng : " + mahoaDon;
                string trangthai = "On";

                List<LichSuHoatDong> ketQua = kh.insertLS(user, ngay, hoatdong, trangthai);
            }

            else
            {

                MessageBox.Show("Xác nhận không thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void reset()
        {
            cbm_trangthaidonhang.Enabled = false;
            radibtn_xacnhan.Enabled = false;
            radibtn_chogiaohang.Enabled = false;
            radibtn_cholayhang.Enabled = false;

        }
        private void btn_xacnhanthanhtoan_Click(object sender, EventArgs e)
        {
            string trangthaidonhang = hd.lay_trangthaidonhang(mahoaDon);
            if (radibtn_xacnhan.Checked)
            {
                btn_xacnhanthanhtoan.Text = radibtn_xacnhan.Text;
                check_trangthaidonhang("Chờ lấy hàng");
                data_chitietdonhang.DataSource = null;
                load_hoadon();
                radibtn_xacnhan.Checked = false;
                btn_xacnhanthanhtoan.Text = "Xác Nhận Đơn";
            }
            else if (radibtn_cholayhang.Checked)
            {

                btn_xacnhanthanhtoan.Text = radibtn_cholayhang.Text;
                data_chitietdonhang.DataSource = null;
                check_trangthaidonhang("Đang giao hàng");
                check_trangthai();
                load_hoadon();
                radibtn_cholayhang.Checked = false;
                btn_xacnhanthanhtoan.Text = "Xác Nhận Đơn";

            }
            else if(radibtn_chogiaohang.Checked)
            {
                btn_xacnhanthanhtoan.Text = radibtn_chogiaohang.Text;
                data_chitietdonhang.DataSource = null;
                check_trangthaidonhang("Giao hàng thành công");
                load_hoadon();
                radibtn_chogiaohang.Checked = false;
                btn_xacnhanthanhtoan.Text = "Xác Nhận Đơn";


            }
            load_hoadon();

        }


        public void reset_data_hoadon()
        {
           
            data_hoadon.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            data_hoadon.Columns["NgayLapHD"].HeaderText = "Ngày Lập ";
            data_hoadon.Columns["TienCoc"].HeaderText = "Tiền Cọc";
            data_hoadon.Columns["MaKhuyenMai"].HeaderText = "Khuyến Mãi";
            data_hoadon.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            data_hoadon.Columns["TrangThaiDonHang"].HeaderText = "Trạng Thái";
            int[] columnsToHide = { 1, 3, 4, 5, 6, 7, 11, 12, 14, 15 };
            foreach (int columnIndex in columnsToHide)
            {
                data_hoadon.Columns[columnIndex].Visible = false;
            }
        }
        public void tim_hoaDon()
        {
            data_hoadon.DataSource = null;
            if (cbm_nam.SelectedItem != null && cbm_thang.SelectedItem != null && cbm_ngay.SelectedItem != null)
            {
                DateTime ngay = ParseStringToDateTime(cbm_ngay.SelectedItem.ToString(), cbm_thang.SelectedItem.ToString(), cbm_nam.SelectedItem.ToString());
                data_hoadon.DataSource = hd.tim_hoaDon_ngaythangnam(ngay);
                reset_data_hoadon();
            }
            else if (cbm_nam.SelectedItem != null && cbm_thang.SelectedItem != null)
            {
                DateTime ngay = ParseStringToDateTime("01", cbm_thang.SelectedItem.ToString(), cbm_nam.SelectedItem.ToString());
                data_hoadon.DataSource = hd.tim_hoaDon_thang(ngay);
                reset_data_hoadon();
            }
            else if (cbm_nam.SelectedItem != null)
            {
                DateTime ngay = ParseStringToDateTime("01", "01", cbm_nam.SelectedItem.ToString());
                data_hoadon.DataSource = hd.tim_hoaDon_nam(ngay);
                reset_data_hoadon();
            }
            else
            {
                MessageBox.Show("Không có đơn hàng vào khoảng thời gian này", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_data_hoadon();
            }
        }

        public void tim_HoaDon_dieukien(string trangthai)
        {
            data_hoadon.DataSource = null;
            if (cbm_nam.SelectedItem != null && cbm_thang.SelectedItem != null && cbm_ngay.SelectedItem != null)
            {
            
                DateTime ngay = ParseStringToDateTime(cbm_ngay.SelectedItem.ToString(), cbm_thang.SelectedItem.ToString(), cbm_nam.SelectedItem.ToString());
                data_hoadon.DataSource = hd.tim_hoaDon_ngaythangnam_dieukien(ngay,trangthai);
                reset_data_hoadon();
            }
            else if (cbm_nam.SelectedItem != null && cbm_thang.SelectedItem != null)
            {

                DateTime ngay = ParseStringToDateTime("01", cbm_thang.SelectedItem.ToString(), cbm_nam.SelectedItem.ToString());
                data_hoadon.DataSource = hd.tim_hoaDon_thang_dieukien(ngay,trangthai);
                reset_data_hoadon();
            }
            else if (cbm_nam.SelectedItem != null)
            {
               
                DateTime ngay = ParseStringToDateTime("01", "01", cbm_nam.SelectedItem.ToString());
                data_hoadon.DataSource = hd.tim_hoaDon_nam_dieukien(ngay,trangthai);
                reset_data_hoadon();
            }
            else
            {
              
                MessageBox.Show("Không có đơn hàng vào khoảng thời gian này", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_data_hoadon();
            }
        }
      

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if(cbm_trangthaidonhang.SelectedItem=="Tất cả" || cbm_trangthaidonhang.SelectedItem==null)
            {
                tim_hoaDon();
             
            }    
            else if(cbm_trangthaidonhang.SelectedItem == "Chờ lấy hàng")
            {
                tim_HoaDon_dieukien("Chờ lấy hàng");
               
            }    
            else if(cbm_trangthaidonhang.SelectedItem == "Chờ giao hàng")
            {
                tim_HoaDon_dieukien("Chờ giao hàng");
               
      
               
            }
            else if(cbm_trangthaidonhang.SelectedItem == "Chờ xác nhận")
            {
                tim_HoaDon_dieukien("Chờ xác nhận");
            }
            else if (cbm_trangthaidonhang.SelectedItem == "Giao hàng thành công")
            {
                tim_HoaDon_dieukien("Giao hàng thành công");
            }
            else if (cbm_trangthaidonhang.SelectedItem == "Đang giao hàng")
            {
                tim_HoaDon_dieukien("Đang giao hàng");
            }
            else
            {
          
                MessageBox.Show("Không có đơn hàng vào khoảng thời gian này", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void data_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                mahoaDon = Int32.Parse(data_hoadon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString());            
               load_ct_hoadon(mahoaDon);
              KhachHang newKH=  kh.lay_khachhang_tuhoadon(mahoaDon);
                txt_makh.Text = newKH.MaKH.ToString();
                txt_ten.Text=newKH.TenKH.ToString();
                txt_sodt.Text=newKH.SDT.ToString();
                txt_diachi.Text=newKH.DiaChi.ToString();
                string trangthaidonhang = hd.lay_trangthaidonhang(mahoaDon);
                if (trangthaidonhang == "Chờ xác nhận")
                {
                    radibtn_xacnhan.Enabled = true;
                    btn_xacnhanthanhtoan.Text = "Xác Nhận";
                }
                else if(trangthaidonhang=="Chờ lấy hàng")
                {
                    radibtn_xacnhan.Enabled = false;
                    radibtn_cholayhang.Enabled = true;
                    radibtn_chogiaohang.Enabled = false;
                    btn_xacnhanthanhtoan.Text = "Lấy Hàng";
                }    
                else
                if(trangthaidonhang=="Đang giao hàng")
                {
                    radibtn_xacnhan.Enabled = false;
                    radibtn_cholayhang.Enabled = false;
                    radibtn_chogiaohang.Enabled = true;
                    btn_xacnhanthanhtoan.Text = "Giao Hàng";
                }
                else
                {
                    radibtn_xacnhan.Enabled = false;
                    radibtn_cholayhang.Enabled = false;
                    radibtn_chogiaohang.Enabled = false;
                }    

            }
            else return;
        }


        public List<int> LayDanhSachNgay(List<DateTime> danhSachNgayLap)
        {
            return danhSachNgayLap.Select(date => date.Day).Distinct().ToList();
        }

        public List<int> LayDanhSachThang(List<DateTime> danhSachNgayLap)
        {
            return danhSachNgayLap.Select(date => date.Month).Distinct().ToList();
        }

        public List<int> LayDanhSachNam(List<DateTime> danhSachNgayLap)
        {
            return danhSachNgayLap.Select(date => date.Year).Distinct().ToList();
        }

        private void cbm_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbm_thang.Enabled = true;
        }

        private void cbm_thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbm_ngay.Enabled = true;
        }

        public  DateTime ParseStringToDateTime(string ngay, string thang, string nam)
        {
           
            string ngayThangNamString = $"{nam}-{thang}-{ngay}";

       
            DateTime ngayThangNam = DateTime.ParseExact(ngayThangNamString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return ngayThangNam.Date;
        }

        private void cbm_nam_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbm_nam.SelectedIndex != -1)
            {
                cbm_trangthaidonhang.Enabled = true;
            }
            else
            {
                cbm_trangthaidonhang.Enabled = false;
            }
        }

        private void radibtn_xacnhan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbm_trangthaidonhang_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void data_hoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
