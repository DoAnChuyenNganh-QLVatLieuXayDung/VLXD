using Aspose.Words;
using Aspose.Words.Tables;
using BLL_DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVienWinform.Report.AsposeWordExtension;
using static BLL_DAL.PhieuNhap_DAL;

namespace VatLieuXayDung
{
    public partial class frm_PhieuNhap : Form
    {
        PhieuNhap_DAL DAL = new PhieuNhap_DAL();
        TaiKhoan_DAL TK_DAL = new TaiKhoan_DAL();

        public int maNV;

        public int MaNV { get => maNV; set => maNV = value; }
        public string User { get => user; set => user = value; }
        public int MaPhieuDat { get => maPhieuDat; set => maPhieuDat = value; }
        public int MaPhieuNhap { get => maPhieuNhap; set => maPhieuNhap = value; }

        private string user;


        public frm_PhieuNhap()
        {
            InitializeComponent();
            cbo_masp.Enabled = false;
            txt_soluong.Enabled = false;
            txt_dongia.Enabled = false;
        }

        private void cbo_gioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt_maPD.Text, out int mapd) && cbo_masp.SelectedValue is int maSP)
            {
                txt_soluong.Text = DAL.LaySoLuongDat(mapd, maSP).ToString();
            }
            else
            {
                Console.WriteLine("Invalid input for mapd or maSP.");
            }
        }



        public void loadphieudat()
        {
            data_Phieudat.DataSource = DAL.LoadPhieuDatChuaHoanThanh();

            data_Phieudat.Columns["MaPhieuDat"].HeaderText = "Mã phiếu";

            data_Phieudat.Columns["NgayLap"].HeaderText = "Ngày lập";
            data_Phieudat.Columns["TrangThai"].HeaderText = "Trạng Thái";
            data_Phieudat.Columns["TenHSX"].HeaderText = "Hãng Sản Xuất";


            int[] columnsToHide = { 4, 5 };
            foreach (int columnIndex in columnsToHide)
            {
                data_Phieudat.Columns[columnIndex].Visible = false;
            }


        }

        private void data_Phieudat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                int mapd = int.Parse(data_Phieudat.Rows[e.RowIndex].Cells["MaPhieuDat"].Value.ToString());
                txt_maPD.Text = mapd.ToString();
                // txt_tongTien.Text = data_Phieudat.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();
                //cbo_masp.DataSource = DAL.XuatSanPhamTheoMaPhieuDat(mapd);

                data_chiphieudat.DataSource = DAL.ctpd(mapd);
                data_chiphieudat.Columns["TenSP"].HeaderText = "Sản phẩm";
                data_chiphieudat.Columns["SoLuong"].HeaderText = "Số lượng";


                int[] columnsToHide = { 0, 2 };
                foreach (int columnIndex in columnsToHide)
                {
                    data_chiphieudat.Columns[columnIndex].Visible = false;
                }


            }
            else return;


        }
        int maPhieuDat;
        int maPhieuNhap;

        private void data_phieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                btn_lapPN.Enabled = false;

                btn_themVaoChiTietPN.Enabled = true;
                cbo_masp.Enabled = true;
                txt_soluong.Enabled = true;
                txt_dongia.Enabled = true;

                txt_maNV.Enabled = false;
                txt_maPD.Enabled = false;
                txt_maPN.Enabled = false;
                txt_tongTien.Enabled = false;

                int mapd = int.Parse(data_phieunhap.Rows[e.RowIndex].Cells["MaPhieuDat"].Value.ToString());
                txt_maPD.Text = mapd.ToString();
                maPhieuDat = mapd;
                txt_maPN.Text = data_phieunhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value.ToString();
                maPhieuNhap = int.Parse(txt_maPN.Text);
                int ma = int.Parse(data_phieunhap.Rows[e.RowIndex].Cells["MaNV"].Value.ToString());
                txt_maNV.Text = DAL.tenNV(ma);
                txt_ngay.Text = data_phieunhap.Rows[e.RowIndex].Cells["NgayNhap"].Value.ToString();

                txt_tongTien.Text = data_phieunhap.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();







                var sanPhams = DAL.XuatSanPhamTheoMaPhieuDat(mapd);
                Console.WriteLine($"Number of items in sanPhams: {sanPhams.Count}");

                foreach (var sp in sanPhams)
                {
                    Console.WriteLine($"{sp.MaSanPham}, {sp.TenSP}, {sp.Soluong}");
                }

                cbo_masp.DataSource = sanPhams;
                cbo_masp.DisplayMember = "TenSP";
                cbo_masp.ValueMember = "MaSanPham";






                data_chitietPN.DataSource = DAL.LoadChiTietPhieuNhap(int.Parse(txt_maPN.Text));
                data_chitietPN.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                data_chitietPN.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                data_chitietPN.Columns["SoLuong"].HeaderText = "Số lượng";
                data_chitietPN.Columns["GiaNhap"].HeaderText = "Giá nhập";
                data_chitietPN.Columns["ThanhTien"].HeaderText = "Thành tiền";

                int[] columnsToHide = { 0, 3 };
                foreach (int columnIndex in columnsToHide)
                {
                    data_chitietPN.Columns[columnIndex].Visible = false;
                }
            }
            else return;
        }




        public void load()
        {

            data_phieunhap.DataSource = DAL.load();
            data_phieunhap.Columns["MaNV"].HeaderText = "Mã nhân viên";
            data_phieunhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            data_phieunhap.Columns["MaPhieuDat"].HeaderText = "Mã Phiếu Đặt";
            data_phieunhap.Columns["TongTien"].HeaderText = "Tổng tiền";
            data_phieunhap.Columns["TrangThai"].HeaderText = "Trạng Thái";

            int[] columnsToHide = { 0, 6, 7 };
            foreach (int columnIndex in columnsToHide)
            {
                data_phieunhap.Columns[columnIndex].Visible = false;
            }

            data_Phieudat.DataSource = DAL.LoadPhieuDatChuaHoanThanh();
            data_Phieudat.Columns["MaPhieuDat"].HeaderText = "Mã Phiếu Đặt";
            data_Phieudat.Columns["NgayLap"].HeaderText = "Ngày lập";
            data_Phieudat.Columns["TrangThai"].HeaderText = "Trạng Thái";
            data_Phieudat.Columns["TenHSX"].HeaderText = "Hãng Sản Xuất";


            int[] columnsToHide1 = {  4, 5 };
            foreach (int columnIndex in columnsToHide1)
            {
                data_Phieudat.Columns[columnIndex].Visible = false;
            }

            loadphieudat();
            txt_maPN.Enabled = true;
            txt_maNV.Enabled = false;
            txt_dongia.Clear();
            txt_maNV.Text = User.ToString();
            txt_thanhtien.Clear();
            txt_maPD.Clear();
            txt_ngay.Value = DateTime.Now;
            txt_soluong.Clear();
            txt_maPN.Clear();
            txt_tongTien.Clear();
            cbo_masp.SelectedItem = "...";
            txt_maPD.Enabled = false;
            txt_maPN.Enabled = false;

            txt_tongTien.Enabled = false;

            // data_chiphieudat.Rows.Clear();
            btn_themVaoChiTietPN.Enabled = true;
            //.Enabled = false;
            btn_lapPN.Enabled = true;
        }

        private void btn_themVaoChiTietPN_Click(object sender, EventArgs e)
        {
            string dongiaText1 = txt_dongia.Text;
            string numericDongiaText1 = new string(dongiaText1.Where(char.IsDigit).ToArray());

            if (int.TryParse(numericDongiaText1, out int dongiaValue1))
            {
                if (dongiaValue1 > 999999999)
                {
                    MessageBox.Show("Nhập không được lớn hơn 999,999,999", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }


            if (string.IsNullOrWhiteSpace(txt_soluong.Text) || string.IsNullOrWhiteSpace(txt_dongia.Text)
                || string.IsNullOrWhiteSpace(txt_maPN.Text)
           )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.MaPhieuNhap = int.Parse(txt_maPN.Text);

                if (int.Parse(txt_soluong.Text) > DAL.LaySoLuongDat(maPhieuDat, (int)cbo_masp.SelectedValue))
                {
                    MessageBox.Show("Số lượng nhập không được lớn hơn số lượng đặt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ctpn.MaSP = (int)cbo_masp.SelectedValue;
                ctpn.SoLuong = int.Parse(txt_soluong.Text);
                string dongiaText = txt_dongia.Text;
                string numericDongiaText = new string(dongiaText.Where(char.IsDigit).ToArray());
                if (int.TryParse(numericDongiaText, out int dongiaValue))
                {


                    ctpn.GiaNhap = dongiaValue;

                }

                ctpn.ThanhTien = int.Parse(txt_soluong.Text) * dongiaValue;
                int soLuongDat = DAL.LaySoLuongDat((int)ctpn.MaPhieuNhap, (int)ctpn.MaSP);


                try
                {
                    DAL.AddChiTietPhieuNhap(ctpn);

                    MessageBox.Show("Nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    load();
                    data_Phieudat.DataSource = DAL.LoadPhieuDatChuaHoanThanh();
                    data_Phieudat.Columns["MaPhieuDat"].HeaderText = "Mã Phiếu Đặt";
                    data_Phieudat.Columns["NgayLap"].HeaderText = "Ngày lập";
                    data_Phieudat.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    data_Phieudat.Columns["TenHSX"].HeaderText = "Hãng Sản Xuất";


                    int[] columnsToHide = {  4, 5 };
                    foreach (int columnIndex in columnsToHide)
                    {
                        data_Phieudat.Columns[columnIndex].Visible = false;
                    }



                    try { DAL.doitrangthai(maPhieuDat); }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }




                    data_phieunhap.DataSource = DAL.load();







                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Đã có sản phẩm trong phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_suaPN_Click(object sender, EventArgs e)
        {
            if (txt_maPN.Text == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_maPD.Text) || string.IsNullOrWhiteSpace(txt_maNV.Text)
            )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_phieunhap.DataSource = DAL.update(int.Parse(txt_maPN.Text), MaNV, txt_ngay.Value, int.Parse(txt_maPD.Text), int.Parse(txt_tongTien.Text), "Đã nhập");
                    MessageBox.Show("Lập thành công");
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            cbo_masp.Refresh();
            cbo_masp.Enabled = false;
            txt_soluong.Enabled = false;
            txt_dongia.Enabled = false;
            txt_maPD.Enabled = true; txt_tongTien.Enabled = true;
            txt_maNV.Enabled = true; txt_tongTien.Enabled = true;


            load();
        }

        private void btn_suaCTPN_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_soluong.Text) || string.IsNullOrWhiteSpace(txt_dongia.Text)
           )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {

                    int thanhtine = int.Parse(txt_soluong.Text) * int.Parse(txt_dongia.Text);


                    data_chitietPN.DataSource = DAL.UpdateChiTietPhieuNhap(int.Parse(txt_maPN.Text),
                        (int)cbo_masp.SelectedValue, int.Parse(txt_soluong.Text),
                        int.Parse(txt_dongia.Text), thanhtine
                        );
                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try { DAL.doitrangthai(maPhieuDat); }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }

                    load();


                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Lỗi");
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_lapPN_Click(object sender, EventArgs e)
        {
            if (txt_maPD.Text == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu đặt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_maPD.Text)
            )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    data_phieunhap.DataSource = DAL.insert(MaNV, txt_ngay.Value, int.Parse(txt_maPD.Text), 0, "Nhập kho");
                    MessageBox.Show("Lập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Lỗi");
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        private void frm_PhieuNhap_Load(object sender, EventArgs e)
        {

            load();
        }

        private void txt_thanhtien_TextChanged(object sender, EventArgs e)
        {
            string currentText = txt_thanhtien.Text;
            string numericText = new string(currentText.Where(char.IsDigit).ToArray());
            if (decimal.TryParse(numericText, out decimal numericValue))
            {
                string formattedText = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} VND", numericValue);
                txt_thanhtien.Text = formattedText;
                txt_thanhtien.SelectionStart = formattedText.Length;
            }
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {

            TinhTien();
        }

        private void txt_dongia_TextChanged(object sender, EventArgs e)
        {
            string currentText = txt_dongia.Text;

            string numericText = new string(currentText.Where(char.IsDigit).ToArray());

            if (long.TryParse(numericText, out long numericValue))
            {
                string formattedText = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} VND", numericValue);

                txt_dongia.Text = formattedText;

                txt_dongia.SelectionStart = formattedText.Length;
            }

            TinhTien();
        }

        private void TinhTien()
        {
            string dongiaText = txt_dongia.Text;
            string numericDongiaText = new string(dongiaText.Where(char.IsDigit).ToArray());
            if (int.TryParse(txt_soluong.Text, out int soLuong) && int.TryParse(numericDongiaText, out int donGia))
            {
                int thanhTien = soLuong * donGia;
                string formattedText = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} VND", thanhTien);
                txt_thanhtien.Text = formattedText;
            }
            else
            {
                txt_thanhtien.Text = "";
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_dongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txt_thanhtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void data_chitietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            // {


            //     txt_maPN.Text = data_phieunhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value.ToString();
            //     maPhieuNhap = int.Parse(txt_maPN.Text);
            //     cbo_masp.SelectedItem = data_phieunhap.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();

            //     txt_soluong.Text = data_phieunhap.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();

            //     txt_dongia.Text = data_phieunhap.Rows[e.RowIndex].Cells["GiaNhap"].Value.ToString();

            //     txt_thanhtien.Text = data_phieunhap.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();

            // }
            // else { return; }


            //     btn_themVaoChiTietPN.Enabled = false;
            //// btn_suaCTPN.Enabled = true;    
        }

        private void txt_tongTien_TextChanged(object sender, EventArgs e)
        {
            string currentText = txt_tongTien.Text;
            string numericText = new string(currentText.Where(char.IsDigit).ToArray());
            if (decimal.TryParse(numericText, out decimal numericValue))
            {
                string formattedText = string.Format(CultureInfo.GetCultureInfo("vi-VN"), "{0:N0} VND", numericValue);
                txt_tongTien.Text = formattedText;
                txt_tongTien.SelectionStart = formattedText.Length;
            }
        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var homNay = DateTime.Now;

            Document baoCao = new Document("Template\\PhieuNhap.doc");
            baoCao.MailMerge.Execute(new[] { "MaPhieuDat" }, new[] { txt_maPD.Text });
            baoCao.MailMerge.Execute(new[] { "TenNhanVienNhap" }, new[] { TK_DAL.layTenTKonline() });
            baoCao.MailMerge.Execute(new[] { "NgayLapPhieuDat" }, new[] {DAL.lay_ngayDat(int.Parse(txt_maPD.Text)).Date.ToString() });
            baoCao.MailMerge.Execute(new[] { "MaPhieuNhap" }, new[] { maPhieuNhap.ToString() });
            baoCao.MailMerge.Execute(new[] { "NgayNhap" }, new[] { string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });


            Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;//Lấy bảng thứ 2 trong file mẫu
            int hangHienTai = 1;
            List<ChiTietPhieuNhapInfo> ct_sp = DAL.LoadChiTietPhieuNhap(maPhieuNhap);
            bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, 3);
            int i = 1;
            foreach (ChiTietPhieuNhapInfo sp in ct_sp)
            {
                bangThongTinGiaDinh.PutValue(hangHienTai, 0, i.ToString());//Cột STT
                bangThongTinGiaDinh.PutValue(hangHienTai, 1, sp.TenSP);//Cột Họ và tên
                bangThongTinGiaDinh.PutValue(hangHienTai, 2, sp.SoLuong.ToString());//Cột quan hệ
                bangThongTinGiaDinh.PutValue(hangHienTai, 3, sp.GiaNhap.ToString());//Cột Số điện thoại
                bangThongTinGiaDinh.PutValue(hangHienTai, 4, sp.ThanhTien.ToString());//Cột Số điện thoại
                hangHienTai++;
                i++;
            }


            baoCao.SaveAndOpenFile("BaoCao.doc");
        }
    }
}
