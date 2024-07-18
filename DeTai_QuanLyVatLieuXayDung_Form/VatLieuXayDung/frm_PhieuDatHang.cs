using Aspose.Words;
using Aspose.Words.Tables;
using BLL_DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVienWinform.Report.AsposeWordExtension;
using static VatLieuXayDung.frm_PhieuDatHang;

namespace VatLieuXayDung
{
    public partial class frm_PhieuDatHang : Form
    {
        HangSanXuat_DAL hsx = new HangSanXuat_DAL();
        SanPham_DAL sp = new SanPham_DAL();
        public frm_PhieuDatHang()
        {
            InitializeComponent();

            Load += Frm_PhieuDatHang_Load1;
        }
        private string ma;

        public string Ma { get => ma; set => ma = value; }

        private void Frm_PhieuDatHang_Load1(object sender, EventArgs e)
        {
            load_data_combox();
        }

        private void Frm_PhieuDatHang_Load(object sender, EventArgs e)
        {
            load_data_combox();
          
        }
        public void load_data_combox()
        {
            List<string> danhSachTenHSX = hsx.load_tenhsx();

            // Thêm cột vào DataGridView

            // Thêm dữ liệu vào cột
            foreach (string tenHSX in danhSachTenHSX)
            {
                data_ha.Rows.Add(tenHSX);
            }
            data_sanpham.DataSource = sp.load();
            data_sanpham.Columns["MASP"].HeaderText = "Mã Sản Phẩm";
            data_sanpham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            data_sanpham.Columns["MASP"].Width = 100;
            int[] columnsToHide = {  2, 3,4,5, 6, 7, 8, 9, 10, 11, 12,13,14 };
            foreach (int columnIndex in columnsToHide)
            {
                data_sanpham.Columns[columnIndex].Visible = false;
            }




        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            if (data_sanpham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = data_sanpham.SelectedRows[0];
                DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                if (data_chitietphieudat.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn column in data_sanpham.Columns)
                    {
                        data_chitietphieudat.Columns.Add(column.Clone() as DataGridViewColumn);
                
                    }

                    DataGridViewTextBoxColumn soLuongColumn = new DataGridViewTextBoxColumn();
                    soLuongColumn.Name = "SoLuong";
                    soLuongColumn.HeaderText = "Số Lượng";
                    data_chitietphieudat.Columns.Add(soLuongColumn);
                }

                // Sử dụng một form tự tạo để nhập số lượng
                using (NhapSoLuong inputDialog = new NhapSoLuong())
                {
                    DialogResult result = inputDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (int.TryParse(inputDialog.InputValue, out int quantity))
                        {
                            sp.insert_ChiTiet_PhieuDat(int.Parse(selectedRow.Cells["MaSP"].Value.ToString()),int.Parse(inputDialog.InputValue));
                            data_chitietphieudat.Rows.Add(newRow);
                            newRow.Cells["SoLuong"].Value = quantity;
                          
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (data_chitietphieudat.SelectedRows.Count > 0)
            {
            
                DataGridViewRow selectedRow = data_chitietphieudat.SelectedRows[0];

            
                if (selectedRow.Cells["MaSP"].Value != null &&
                    Int32.TryParse(selectedRow.Cells["MaSP"].Value.ToString(), out int masp))
                {
    
                    sp.xoa_SP_chitietphieu(masp);
                    data_chitietphieudat.Rows.Remove(selectedRow);
                }
                else
                {
                    MessageBox.Show("Giá trị MaSP không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {

            Ma = "";
            data_sanpham.Enabled = false;
          
        }

        private void btn_InPhieu_Click(object sender, EventArgs e)
        {
            var homNay = DateTime.Now;

            Document baoCao = new Document("Template\\PhieuDatHangHangSanXuat.doc");
            HangSanXuat hsx=sp.lay_dc_tenhsx(Ma);
            baoCao.MailMerge.Execute(new[] { "Ngay" }, new[] { string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });
            baoCao.MailMerge.Execute(new[] { "SoPhieu" }, new[] {sp.LayMaPhieuDatHienTai().ToString()});
            baoCao.MailMerge.Execute(new[] { "TenHSX" }, new[] {Ma});
            baoCao.MailMerge.Execute(new[] { "DiaChi" }, new[] {hsx.DiaChi});
            baoCao.MailMerge.Execute(new[] { "SDT" }, new[] { hsx.SDT });

            
            Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;//Lấy bảng thứ 2 trong file mẫu
            int hangHienTai = 1;
                List<CT_PhieuDat_SP> ct_sp=   sp.LoadChiTiet_PhieuDat();
            bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, 3);
            int i = 1;
            foreach(CT_PhieuDat_SP sp in ct_sp)
            {
                bangThongTinGiaDinh.PutValue(hangHienTai, 0, i.ToString());//Cột STT
                bangThongTinGiaDinh.PutValue(hangHienTai, 1, sp.Tensp);//Cột Họ và tên
                bangThongTinGiaDinh.PutValue(hangHienTai, 2,sp.Donvitinh);//Cột quan hệ
                bangThongTinGiaDinh.PutValue(hangHienTai, 3,sp.Soluong);//Cột Số điện thoại
                hangHienTai++;
                i++;
            }    


            baoCao.SaveAndOpenFile("BaoCao.doc");
        }

        private void data_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_ha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data_ha.SelectedRows.Count >= 0)
            {
                DataGridViewRow selectedRow = data_ha.SelectedRows[0];
                Ma = selectedRow.Cells["TenHSXColumn"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn muốn đặt hàng hãng sản xuất này ?", "Chú Ý", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    data_sanpham.DataSource = sp.load_SP_HSX(ma);
                    sp.insert_PhieuDat(ma);
                    data_sanpham.Enabled = true;
                }
                else
                {

                }
            }
        }

        private void data_sanpham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
            if (e.ColumnIndex >= 0 && data_sanpham.Columns[e.ColumnIndex].ValueType == typeof(int))
            {
         
                if (e.Value != null && (int)e.Value == 0)
                {
               
                    e.Value = string.Empty;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
