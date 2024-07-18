using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VatLieuXayDung
{
    public partial class frm_SanPham : Form
    {
     
        SanPham_DAL sp=new SanPham_DAL();
        public string urlh = "";
        public frm_SanPham()
        {
            InitializeComponent();
            Load += Frm_SanPham_Load;
        }

        private void Frm_SanPham_Load(object sender, EventArgs e)
        {
            data_view_sanpham.DataSource = sp.load();
            data_view_sanpham.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            data_view_sanpham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            data_view_sanpham.Columns["SoSao"].HeaderText = "Đánh Giá";
            data_view_sanpham.Columns["GiaBan"].HeaderText = "Giá Bán";
            data_view_sanpham.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            data_view_sanpham.Columns["TinhTrang"].HeaderText = "Tình Trạng";
            data_view_sanpham.Columns["MoTa"].HeaderText = "Mô Tả";
            data_view_sanpham.Columns["ThongTin"].HeaderText = "Thông Tin";
            data_view_sanpham.Columns["MaLoai"].HeaderText = "Mã Loại";
            data_view_sanpham.Columns["TonKho"].HeaderText = "Tồn Kho";
            data_view_sanpham.Columns[12].Visible = false;
            data_view_sanpham.Columns[9].Visible = false;
            data_view_sanpham.Columns[13].Visible = false;
            data_view_sanpham.Columns[14].Visible = false;
            data_view_sanpham.DataSource = sp.load();
            load_cbm();

     
     

        }
        public void load_cbm()
        {
            cbm_trangthai.Items.Add("Còn hàng");
            cbm_trangthai.Items.Add("Hết hàng");
            cbm_trangthai.Items.Add("Tất Cả");
    

            List<string> list_dvt = sp.load_cbm_donvitinh();
            foreach(string s in list_dvt) 
            {
                cbm_donvitinh.Items.Add(s);
            }
            
            List<string> list_maloai = sp.load_cbm_maloai();
            foreach (string s in list_maloai)
            {
                cbm_tenloai.Items.Add(s);
            }
            cbm_tenloai.MaxDropDownItems = 5;
            cbm_tenloai.ItemHeight = 25;      
            cbm_tenloai.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void data_view_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_chonhinh_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog1.FileName;
                urlh = Environment.CurrentDirectory;
                string newstring = urlh.Substring(0, urlh.Length - 10);
                string destinationFolderPath = newstring + "\\Resources\\";
                string des_hinh_web = newstring + "\\Web\\VatLieuXayDung\\VatLieuXayDung\\Content\\images\\product\\large-size\\";
                string des_tinationPath_web = Path.Combine(des_hinh_web, Path.GetFileName(sourceFilePath));
                string destinationPath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));
                File.Copy(sourceFilePath, des_tinationPath_web);
                File.Copy(sourceFilePath, destinationPath);
                lab_hinh.Text = Path.GetFileName(openFileDialog1.FileName);
                hinh.Image = Image.FromFile(destinationPath);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == null)
            {
                data_view_sanpham.DataSource=sp.load();
            }

            if (radio_ten.Checked)
            {
                data_view_sanpham.DataSource = sp.load_tenSanPham(txt_search.Text);
            }
            else if (radio_sosao.Checked)
            {
                data_view_sanpham.DataSource = sp.load_SoSao_SanPham(int.Parse(txt_search.Text));
            }
            else if (radio_giaban.Checked)
            {
                data_view_sanpham.DataSource = sp.load_GiaBan_SanPham(int.Parse(txt_search.Text));
            }
        }
        public void reset_Text()
        {
            txt_ten_sp.Text = string.Empty;
            txt_gianhap.Text = string.Empty;
            txt_gia_ban .Text = string.Empty;
            txt_mota.Text = string.Empty;
            txt_thontin.Text= string.Empty;
            cbm_donvitinh.SelectedIndex = -1;
           
            cbm_tenloai.SelectedIndex = -1;
            cbm_trangthai.SelectedIndex = -1;
            hinh.Image = null;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_gianhap.Text) || string.IsNullOrEmpty(txt_gia_ban.Text)||
                string.IsNullOrEmpty(txt_mota.Text)|| string.IsNullOrEmpty(txt_thontin.Text)
                || string.IsNullOrEmpty(txt_ten_sp.Text) || cbm_donvitinh.SelectedValue!=null||
                 cbm_tenloai.SelectedValue!=null || cbm_trangthai.SelectedValue!=null ||
                string.IsNullOrEmpty(lab_hinh.Text) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    DialogResult r=MessageBox.Show("Bạn muốn thêm sản phẩm "+txt_ten_sp.Text+"","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (r==DialogResult.Yes)    
                    {
                        int maloai = sp.lay_maloai(cbm_tenloai.SelectedItem.ToString());
                        data_view_sanpham.DataSource = sp.insert_SanPham(txt_ten_sp.Text, cbm_donvitinh.SelectedItem.ToString()
                        , 0, int.Parse(txt_gia_ban.Text),
                        int.Parse(txt_gianhap.Text), cbm_trangthai.SelectedItem.ToString(), txt_mota.Text, txt_thontin.Text, lab_hinh.Text, maloai
                       );
                        Them_SP_Vao_HSX t = new Them_SP_Vao_HSX();
                        t.Masp = sp.layma_SP(txt_ten_sp.Text);
                        t.ShowDialog();
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lab_hinh.Text = "";
                        reset_Text();
                        data_view_sanpham.DataSource = sp.load();
                    }


                }
                catch (SqlException ex)
                {

                    if (ex.Number==224)
                    {
                        MessageBox.Show("Số điện thoại hoặc tên đăng nhập đã được sử dụng","Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }    
        }

        private void btn_execl_Click(object sender, EventArgs e)
        {
          





        }

        private void cbm_tenloai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

        }

        private void data_view_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txt_ten_sp.Text = data_view_sanpham.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                txt_gia_ban.Text = data_view_sanpham.Rows[e.RowIndex].Cells["GiaBan"].Value.ToString();
                txt_gianhap.Text = data_view_sanpham.Rows[e.RowIndex].Cells["GiaNhap"].Value.ToString();
                txt_thontin.Text = data_view_sanpham.Rows[e.RowIndex].Cells["ThongTin"].Value.ToString();
                txt_mota.Text = data_view_sanpham.Rows[e.RowIndex].Cells["MoTa"].Value.ToString();

                cbm_donvitinh.SelectedItem = data_view_sanpham.Rows[e.RowIndex].Cells["DonViTinh"].Value.ToString();
          
                int maloai = int.Parse(data_view_sanpham.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString());
                cbm_tenloai.SelectedItem = sp.lay_tenloai(maloai);
                cbm_trangthai.SelectedItem = data_view_sanpham.Rows[e.RowIndex].Cells["Tinhtrang"].Value.ToString();
                string urlh = Environment.CurrentDirectory;
                string newstring = urlh.Substring(0, urlh.Length - 10);
                string destinationFolderPath = newstring + "\\Resources\\" + data_view_sanpham.Rows[e.RowIndex].Cells["ImageUrl"].Value.ToString();

                hinh.Image = Image.FromFile(destinationFolderPath);
            }
            else return;
        }

        private void data_view_sanpham_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_ten_sp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_gia_ban_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_thontin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }

        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
