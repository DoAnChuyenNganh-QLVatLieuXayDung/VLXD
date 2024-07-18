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
    public partial class NhapSoLuong : Form
    {
        public NhapSoLuong()
        {
            InitializeComponent();
        }
        public string InputValue { get; private set; }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            InputValue =txt_SoLuong.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Can_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;

            // Kiểm tra xem ký tự nhập vào có phải là số và là số dương khác 0 hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || (e.KeyChar == '0' && textBox.Text.Length == 0))
            {
                e.Handled = true; // Không cho phép nhập ký tự này
                MessageBox.Show("Vui lòng nhập một số nguyên dương khác 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
