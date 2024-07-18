using BLL_DAL;
using Guna.Charts.Interfaces;
using Guna.Charts.WinForms;
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
    public partial class frm_ThongKe : Form
    {
        public ThongKe_DAL DAL =  new ThongKe_DAL();

        public frm_ThongKe()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            int tonghoadon = int.Parse(DAL.TongTienHoaDon().ToString());
            txt_sumDH.Text = tonghoadon.ToString("#,##0");

          
            txt_sumHD.Text = DAL.tongHD().ToString();
            txt_sumKH.Text = DAL.tongKH().ToString();
            //sodo();

            gunaChart1.Datasets.Clear();
            Line.Example(gunaChart1);


            data_top.DataSource = DAL.Top5SanPhamBanChay(btn_bd_sp.Value , btn_kt_sp.Value);

            data_top.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            data_top.Columns["SoLuongBan"].HeaderText = "Số lượng bán";
            data_top.Columns[0].Visible = false;

        }

        private GunaChart chart;

       

        private void gunaChart1_Load(object sender, EventArgs e)
        {

        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
        //    chart_loinhuan.Datasets.Clear();
        //    Doughnut.Example(chart_loinhuan, txt_bd.Value);
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_loc_dt_Click(object sender, EventArgs e)
        {
            if (btn_bd_dt.Value == btn_kt_dt.Value) {
                gunaChart1.Datasets.Clear();
                Line.Example(gunaChart1);
                return; }
            if (btn_bd_dt.Value > btn_kt_dt.Value) { MessageBox.Show("Ngày bắt đầu lớn hơn ngày kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            gunaChart1.Datasets.Clear();
            Line.Example_BD_KT(gunaChart1, btn_bd_dt.Value.Date , btn_kt_dt.Value.Date);

        }

        private void btn_loc_sp_Click(object sender, EventArgs e)
        {
            if(btn_bd_sp.Value>btn_kt_sp.Value) { MessageBox.Show("Ngày bắt đầu lớn hơn ngày kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            data_top.DataSource = DAL.Top5SanPhamBanChay(btn_bd_sp.Value, btn_kt_sp.Value);
            data_top.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            data_top.Columns["SoLuongBan"].HeaderText = "Số lượng bán";
            data_top.Columns[0].Visible = false;
        }

        private void data_top_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

