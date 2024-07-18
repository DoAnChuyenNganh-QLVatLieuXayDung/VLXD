using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_LichSuMuaHang : Form
    {
        LichSuMuaHang_DAL  DAL = new LichSuMuaHang_DAL();

        public frm_LichSuMuaHang()
        {
            InitializeComponent();
        }

        public void load()
        {
          
            txt_search.Clear();

           

            data_kh.DataSource = DAL.loadKH();
            data_kh.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            data_kh.Columns["TenKH"].HeaderText = "Họ và Tên";
            data_kh.Columns["SDT"].HeaderText = "Số Điện Thoại";
            int[] columnsToHide = { 2, 3, 4, 6, 7, 8, 9 };
            foreach (int columnIndex in columnsToHide)
            {
                data_kh.Columns[columnIndex].Visible = false;
            }

            data_hd.Rows.Clear();   

        }

        private void frm_LichSuMuaHang_Load(object sender, EventArgs e)
        {
            load(); 
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                load();
            }

            if (radio_ten.Checked)
            {
                data_kh.DataSource = DAL.searchTen(txt_search.Text);
            }
            else if (radio_sdt.Checked)
            {
                data_kh.DataSource = DAL.searchSDT(txt_search.Text);
            }
            else if (radio_gioitinh.Checked)
            {
                data_kh.DataSource = DAL.searchGiotTinh(txt_search.Text);
            }
        }

        private void data_kh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maKHCellValue = data_kh.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            if (int.TryParse(maKHCellValue, out int ma))
            {
                data_hd.DataSource = DAL.loadHD(ma);

                data_hd.Columns["MaHD"].HeaderText = "Mã Hoá Đơn";
                data_hd.Columns["NgayLapHD"].HeaderText = "Ngày Lập Hoá Đơn";
                data_hd.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                data_hd.Columns["TienCoc"].HeaderText = "Tiền Cọc";
                data_hd.Columns["TrangThaiDonHang"].HeaderText = "Trạng Thái Đơn Hàng";
                int[] columnsToHide = { 1, 3, 4,5, 6, 7, 10,11,12,14,15 };
                foreach (int columnIndex in columnsToHide)
                {
                    data_hd.Columns[columnIndex].Visible = false;
                }

                txt_sumHD.Text = DAL.tongHD(ma).ToString();
                txt_sumMoney.Text = DAL.TongTienHoaDon(ma).ToString("N2");
            }
            else
            {
                MessageBox.Show("Giá trị không hợp lệ cho MaKH.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = txt_bd.Value;
            DateTime ngayKetThuc = txt_kt.Value;
            if (ngayKetThuc < ngayBatDau)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            foreach (DataGridViewRow row in data_hd.Rows)
            {
                if (row.Cells["NgayLapHD"].Value != null)
                {
                    DateTime ngayHoaDon = Convert.ToDateTime(row.Cells["NgayLapHD"].Value);
                    if (ngayHoaDon >= ngayBatDau && ngayHoaDon <= ngayKetThuc)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
