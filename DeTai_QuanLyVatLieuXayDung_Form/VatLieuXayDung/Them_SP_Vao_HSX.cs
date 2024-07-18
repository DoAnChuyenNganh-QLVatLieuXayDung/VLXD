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
    public partial class Them_SP_Vao_HSX : Form
    {
        HangSanXuat_DAL hsx = new HangSanXuat_DAL();
        ct_hangSanXuat_DAL ct_ = new ct_hangSanXuat_DAL();
        private int masp;

        public int Masp { get => masp; set => masp = value; }

        public Them_SP_Vao_HSX()
        {
            InitializeComponent();
            Load += Them_SP_Vao_HSX_Load;
        }

        private void Them_SP_Vao_HSX_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < hsx.load_tenhsx().Count; i++)
            {
                cmb_hsx.Items.Add(hsx.load_tenhsx()[i]);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
           if(cmb_hsx.SelectedIndex >= 0) 
            {

                string ma = cmb_hsx.SelectedItem.ToString();
                DialogResult result = MessageBox.Show("Sản phẩm của  hãng sản xuất này ?", "Chú Ý", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    int mahsx = hsx.laymahsx(ma);
                    bool kq = ct_.intsert(mahsx, Masp);
                    if(kq) 
                    {
                        MessageBox.Show("Đã cập nhật sản phẩm mới vào nhà sản xuất " + ma + " ", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm đã được thêm vào trước đó ", "Thông Báo", MessageBoxButtons.OK);
                    }    
                }
                else
                {

                }
            }
           this.Close();
        }
    }
}
