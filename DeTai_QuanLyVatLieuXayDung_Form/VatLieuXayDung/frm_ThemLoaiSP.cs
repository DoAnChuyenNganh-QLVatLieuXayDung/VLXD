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
    public partial class frm_ThemLoaiSP : Form
    {
        LoaiSanPham_DAL l=new LoaiSanPham_DAL();
        public frm_ThemLoaiSP()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thêm loại sản phẩm mới này:" + txt_tenloai.Text + "", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) 
            {
                if(l.insertloaiSP(txt_tenloai.Text,txt_mota.Text))
                {
                    MessageBox.Show("Thêm Thành Công !");
                }
                else
                {
                    MessageBox.Show("Loại sản phẩm đã tồn tại !");
                }    
                
            }
            this.Close();
        }

        private void txt_tenloai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }


        }
    }
}
