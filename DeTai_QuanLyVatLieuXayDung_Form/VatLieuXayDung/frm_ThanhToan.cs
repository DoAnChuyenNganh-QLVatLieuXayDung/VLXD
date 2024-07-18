using Aspose.Words;
using Aspose.Words.Tables;
using BLL_DAL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVienWinform.Report.AsposeWordExtension;

namespace VatLieuXayDung
{
    public partial class frm_ThanhToan : Form
    {
        SanPham_DAL sp=new SanPham_DAL();
        KhachHang_DAL khachHang=new KhachHang_DAL();
        LoaiSanPham_DAL loaiSP=new LoaiSanPham_DAL();
        HoaDon_DAL hd=new HoaDon_DAL();
        public int mahd { get; private set; }
        ChiTietHoaDon t=new ChiTietHoaDon();
        ChiTietDonHang_DAL ct = new ChiTietDonHang_DAL();
        KhuyenMai_DAL km = new KhuyenMai_DAL();
        public frm_ThanhToan()
        {
            InitializeComponent();
            
            Load += Frm_ThanhToan_Load;
        }
        private void Frm_ThanhToan_Load(object sender, EventArgs e)
        {
            load_menu();
            load_loaiSP();
            load_combox();
        }
        
        public void load_loaiSP()
        {
            panel_loaiSP.Controls.Clear();
            List<String> list = loaiSP.ten_LoaiSP();

            foreach (String item in list)
            {
                Guna2Button btn = new Guna2Button();
                btn.Text = item;
                btn.Width = 110;
                btn.Height = 40;
  
                btn.Font = new System.Drawing.Font("Tahoma", 8f, FontStyle.Bold);

                btn.Click += btn_Click;
                btn.BackColor = Color.FromArgb(255, 215, 0); // Mã màu vàng
                panel_loaiSP.Controls.Add(btn);
            }

            Guna2Button btn1 = new Guna2Button();
            btn1.Text = "Thêm Loại";
            btn1.Width = 110;
            btn1.Height = 40;
 
            btn1.Font = new System.Drawing.Font("Tahoma", 8f, FontStyle.Bold);
            btn1.Click += Btn1_Click;
            panel_loaiSP.Controls.Add(btn1);
            panel_loaiSP.AutoScroll = true;

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
        
            frm_ThemLoaiSP frm=new frm_ThemLoaiSP();
            frm.ShowDialog();
            load_loaiSP();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button)
            {
                Guna2Button clickedButton = (Guna2Button)sender;
                string buttonText = clickedButton.Text;
                flowLayoutPanel1.Controls.Clear();
                List<SanPham> new_sp = sp.load_theotenloai(buttonText);
                foreach (SanPham p in new_sp)
                {
                    string urlh = Environment.CurrentDirectory;
                    string newstring = urlh.Substring(0, urlh.Length - 10);
                    string destinationFolderPath = newstring + "\\Resources\\";
                    string destinationPath = Path.Combine(destinationFolderPath, Path.GetFileName(p.ImageUrl));
                    SanPham_Con sp_con = new SanPham_Con(p.MaSP.ToString(), p.TenSP, FormatCurrency(decimal.Parse(p.GiaBan.ToString())), "0", destinationPath);
                    sp_con.chon_click += Sp_con_chon_click;
                    sp_con.capnhat_click += Sp_con_capnhat_click;
                    flowLayoutPanel1.Controls.Add(sp_con);              
                }
                flowLayoutPanel1.AutoScroll = true;
            }

        }

        private void Sp_con_capnhat_click(object sender, EventArgs e)
        {
            if (mahd > 0)
            {
                //txt_magiamgia.Enabled = true;
                SanPham_Con sp1 = sender as SanPham_Con;
                if (sp1.laysoluong() > 0)
                {
                    ct.update(mahd, int.Parse(sp1.Masp), sp1.laysoluong());
                    load_ct_hoadon(mahd);
                    txt_thanhtien.Text = "";
                    txt_tongsl.Text = "";
                    txt_tongsl.Text = ct.tong_soluong_DH(mahd).ToString();
                    txt_tongtien.Text = FormatCurrency(decimal.Parse(ct.tong_thanhtien(mahd).ToString()));
                    MessageBox.Show("Số lượng sản phẩm "+sp1.Tensp + " đã cập nhật !");
                    load_ct_hoadon(mahd);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập số lượng sản phẩm !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa lập mã phiếu mua", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void load_ct_hoadon(int mahd)
        {
            data_ct_hoadon.DataSource = null;
            data_ct_hoadon.DataSource = ct.LoadChiTiet_HoaDon(mahd);
            data_ct_hoadon.Columns["Mahoadon"].HeaderText = "Mã Hóa Đơn";
            data_ct_hoadon.Columns["Tensp"].HeaderText = "Tên sản phẩm";

            data_ct_hoadon.Columns["Soluong"].HeaderText = "Số lượng";
            data_ct_hoadon.Columns["Giaban"].HeaderText = "Giá bán";
            data_ct_hoadon.Columns["Thanhtien"].HeaderText = "Thành Tiền";
        }
        private void Sp_con_chon_click(object sender, EventArgs e)
        {
          
            groupBox4.Enabled = true;
            if (mahd > 0 )
            {
                //txt_magiamgia.Enabled = true;
                SanPham_Con sp1 = sender as SanPham_Con;
                if (hd.lay_trangthaidonhang(mahd)== "Trống")
                {
                    if (sp1.laysoluong() > sp.laySoLuongSP_Kho(int.Parse(sp1.Masp)))
                    {
                        MessageBox.Show("Vượt quá số lượng kho !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    if (sp1.laysoluong() > 0 && sp1.laysoluong() <= sp.laySoLuongSP_Kho(int.Parse(sp1.Masp)))
                    {
                        if (ct.kiemtra_CT_HD_cochua(mahd, int.Parse(sp1.Masp)) == false)
                        {
                            ct.intsert_CT_HD(mahd, int.Parse(sp1.Masp.ToString()), sp1.laysoluong(), int.Parse(sp1.Giaban.ToString()));
                            load_ct_hoadon(mahd);
                            txt_thanhtien.Text = "";
                            txt_tongsl.Text = "";
                            txt_tongsl.Text = ct.tong_soluong_DH(mahd).ToString();
                            txt_tongtien.Text = FormatCurrency(decimal.Parse(ct.tong_thanhtien(mahd).ToString()));
                        }
                        else
                        {
                            if (sp1.laysoluong() > sp.laySoLuongSP_Kho(int.Parse(sp1.Masp)))
                            {
                                MessageBox.Show("Vượt quá số lượng kho !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            if (sp1.laysoluong() > 0 && sp1.laysoluong() <= sp.laySoLuongSP_Kho(int.Parse(sp1.Masp)))
                            {
                                DialogResult r = MessageBox.Show("Bạn có cập nhật sản phẩm:\n" + sp1.Tensp + " với số lượng: " + sp1.laysoluong() + "", "Thông báo", MessageBoxButtons.YesNo);
                                if (r == DialogResult.Yes)
                                {

                                    ct.update(mahd, int.Parse(sp1.Masp), sp1.laysoluong());
                                    load_ct_hoadon(mahd);
                                    txt_thanhtien.Text = "";
                                    txt_tongsl.Text = "";
                                    txt_tongsl.Text = ct.tong_soluong_DH(mahd).ToString();
                                    txt_tongtien.Text = FormatCurrency(decimal.Parse(ct.tong_thanhtien(mahd).ToString()));
                                    MessageBox.Show("Số lượng sản phẩm " + sp1.Tensp + " đã cập nhật !");
                                    load_ct_hoadon(mahd);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Bạn chưa nhập số lượng !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng sản phẩm !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Hóa đơn đã thanh toán !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                }    
            }
            else
            {
                MessageBox.Show("Bạn chưa lập mã phiếu mua", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
        public string FormatCurrency(decimal amount)
        {
            return amount.ToString("#,##0") + " VND";
        }

        public decimal ParseCurrency(string formattedAmount)
        {
            string numericString = new string(formattedAmount.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(numericString, out decimal result))
            {
                return result;
            }
            else
            {           
                return 0;
            }
        }

        public void load_menu()
        {
            flowLayoutPanel1.Controls.Clear();
            List<SanPham> new_sp=  sp.load();
            foreach(SanPham p in new_sp)
            {
                string urlh = Environment.CurrentDirectory;
                string newstring = urlh.Substring(0, urlh.Length - 10);
                string destinationFolderPath = newstring + "\\Resources\\";
                string destinationPath = Path.Combine(destinationFolderPath, Path.GetFileName(p.ImageUrl));
                SanPham_Con sp_con =new SanPham_Con(p.MaSP.ToString(), p.TenSP, p.GiaBan.ToString(),"0",destinationPath);
                sp_con.chon_click += Sp_con_chon_click;
                flowLayoutPanel1.Controls.Add(sp_con);
            }
            flowLayoutPanel1.AutoScroll = true;
        }
        public void load_combox()
        {
            cbm_khachhang.Text = "";
            List<String> list= khachHang.load_sdt();
            foreach(String s in list)
            {
                cbm_khachhang.AutoCompleteCustomSource.Add(s);
            }

            //txt_magiamgia.Text = string.Empty;
            //List<string> list_giamgia=km.ma_giam_gia();
            //foreach (String s in list_giamgia)
            //{
            //    txt_magiamgia.AutoCompleteCustomSource.Add(s);
            //}

            List<KhuyenMai> list1 = km.ma_giam_gia2();
            foreach (KhuyenMai ki in list1)
            {
                cbm_ma_KM.Items.Add(ki.MaKhuyenMai+" - "+ki.PhanTramGiam+"%");
            }    
        
        }
        private void btn_taophieu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbm_khachhang.Text))
            {
                DialogResult r = MessageBox.Show("Bạn muốn tạo phiếu mua hàng", "Thông Báo", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    KhachHang kh=khachHang.laymot_Kh_SDT(cbm_khachhang.Text);
                    if (kh != null) 
                    {
                       bool kq=hd.insert_hoadon(kh);
                        if (kq) 
                        {
                            
                            MessageBox.Show("Lập phiếu thành công !","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            cbm_khachhang.Enabled = false;
                           
                            cbm_khachhang.Enabled = false;
                            txt_tenkhachhang.Enabled=false;
                            txt_diachi.Enabled=false;
                            txt_sophieu.Text = "";
                            this.mahd = hd.LayHoaDonVuaTao();
                            txt_sophieu.Text =mahd.ToString();
                          
                            btn_taophieu.Enabled = false;
                            btn_them.Enabled = false;
                        }
                    }


                }
            }
            else
            {

            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbm_khachhang.Text) && !string.IsNullOrEmpty(txt_diachi.Text) && !string.IsNullOrEmpty(txt_tenkhachhang.Text))
            {
                if (btn_them.Text == "Thêm Khách Hàng")
                {
                    bool kq = khachHang.insert_KhachHang_VangLai(txt_tenkhachhang.Text, "Khác", cbm_khachhang.Text, txt_diachi.Text);
                    if (cbm_khachhang.TextLength < 10 || cbm_khachhang.TextLength > 10)
                    { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    if (kq)
                    {
                        MessageBox.Show("Đã lưu thông tin khách hàng ", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_them.Text = "Sửa thông tin";
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng đã tồn tại ", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btn_taophieu.Enabled = true;

                }
                else
                if (btn_them.Text == "Sửa thông tin")
                    {
                        bool kq = khachHang.update_thongtin_giaohang(cbm_khachhang.Text, txt_tenkhachhang.Text, txt_diachi.Text);
                        if (cbm_khachhang.TextLength < 10 || cbm_khachhang.TextLength > 10)
                        { MessageBox.Show("Vui lòng kiểm tra lại số điện thoại", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                        if (kq)
                        {
                            MessageBox.Show("Đã cập nhật thông tin khách hàng ", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thông tin giao hàng mới đã được lưu ", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }    
                        btn_taophieu.Enabled = true;
                    }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
     
        }

        private void cbm_khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                KhachHang kh = khachHang.layThongTinKhachHang(cbm_khachhang.Text);
                if (kh != null)
                {
                    txt_diachi.Text = "";
                    txt_tenkhachhang.Text = "";
                    txt_tenkhachhang.Text += kh.TenKH;
                    txt_diachi.Text += kh.DiaChi;
                    btn_taophieu.Enabled=true;
                    txt_tenkhachhang.Enabled = true;
                    txt_diachi.Enabled = true;
                    btn_them.Enabled = true;
                    btn_them.Text = "Sửa thông tin";
                }
                else
                {
                    txt_tenkhachhang.Enabled = true;
                    txt_diachi.Enabled = true;
                    btn_them.Enabled = true;
                }    
            }
        }

        private void txt_magiamgia_KeyDown(object sender, KeyEventArgs e)
        {
            //double kq = 1;
            //float b = (float)1.0;
            //int a = 0;
            //if (e.KeyCode == Keys.Enter) 
            //{
            //    if(!string.IsNullOrEmpty(txt_magiamgia.Text))
            //    {
            //        a = ct.tong_thanhtien(mahd);
            //        b=(km.LayPhanTramKhuyenMai(txt_magiamgia.Text) /(float) 100);
            //        kq *= a * b;
            //        double thanhtien = a - kq;
            //        txt_tongtien.Text = FormatCurrency(decimal.Parse(a.ToString()));
            //        txt_giamgia.Text = FormatCurrency(decimal.Parse(kq.ToString()));
            //        txt_thanhtien.Text=FormatCurrency(decimal.Parse(thanhtien.ToString()));
            //    }
            //    else
            //    {
            //        a = ct.tong_thanhtien(mahd);
            //        txt_tongtien.Text = FormatCurrency(decimal.Parse(a.ToString()));
            //        txt_thanhtien.Text = FormatCurrency(decimal.Parse(a.ToString()));
            //    }    

            //}
        }


        private void radiobtn_coc_CheckedChanged(object sender, EventArgs e)
        {
            txt_tiencoc.Enabled = true;
            btn_thanhtoan.Enabled = true;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            
            radiobtn_coc.Checked = false;
            radiobtn_trahet.Checked = false;
            cbm_khachhang.ResetText();
            cbm_khachhang.Enabled = true;
            txt_diachi.Text = "";
            txt_tenkhachhang.Text = "";
            txt_tenkhachhang.Enabled =false;
            txt_diachi.Enabled = false;
            txt_tiencoc.Text = "";
            txt_giamgia.Text = "";
            txt_sophieu.Text = "";
            txt_thanhtien.Text = "";
            txt_tongsl.Text = "";
            txt_tongtien.Text = "";
            data_ct_hoadon.DataSource = null;
            load_menu();
            btn_thanhtoan.Enabled = false;

        }

        private void txt_tiencoc_KeyDown(object sender, KeyEventArgs e)
        {
            int kq = 0;
            if (e.KeyCode == Keys.Enter) 
            {
                int tt = int.Parse(ParseCurrency(txt_thanhtien.Text).ToString());
                int tc = int.Parse(txt_tiencoc.Text);
                kq = tt - tc;
                txt_tiencoc.Text = FormatCurrency(decimal.Parse(txt_tiencoc.Text.ToString()));
                txt_thanhtien.Text = FormatCurrency(decimal.Parse(kq.ToString()));
            }
        }

        private void data_ct_hoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
 

                int mahd =int.Parse(data_ct_hoadon.Rows[e.RowIndex].Cells["Mahoadon"].Value.ToString());
                int masp= ct.lay_masp(data_ct_hoadon.Rows[e.RowIndex].Cells["Tensp"].Value.ToString());
                DialogResult r=MessageBox.Show("Bạn muốn hủy chọn sản phẩm này !","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (ct.xoa_CT_SP(mahd, masp))
                    {
                        MessageBox.Show("Hủy chọn thành công !", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load_ct_hoadon(mahd);
                        txt_tongsl.Text = ct.tong_soluong_DH(mahd).ToString();
                        txt_tongtien.Text = FormatCurrency(decimal.Parse(ct.tong_thanhtien(mahd).ToString()));
                    }
                }
                
            }
            else return;

           
        }

        private void data_ct_hoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_hoaddon_Click(object sender, EventArgs e)
        {
            var homNay = DateTime.Now;
            
            Document baoCao = new Document("Template\\HoaDon_ThanhToan.doc");
            baoCao.MailMerge.Execute(new[] { "Ngay" }, new[] { string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year) });
            baoCao.MailMerge.Execute(new[] { "SoHoaDon" }, new[] { mahd.ToString() });
            baoCao.MailMerge.Execute(new[] { "HoTenKH" }, new[] { txt_tenkhachhang.Text});
            baoCao.MailMerge.Execute(new[] { "DiaChi" }, new[] { txt_diachi.Text });
            baoCao.MailMerge.Execute(new[] { "SDT" }, new[] { cbm_khachhang.Text });

            baoCao.MailMerge.Execute(new[] { "TongSoLuong" }, new[] { txt_tongsl.Text });
            baoCao.MailMerge.Execute(new[] { "TongTien" }, new[] { txt_tongtien.Text });
            baoCao.MailMerge.Execute(new[] { "GiamGia" }, new[] { txt_giamgia.Text });
            baoCao.MailMerge.Execute(new[] { "TienCoc" }, new[] { txt_tiencoc.Text });
            baoCao.MailMerge.Execute(new[] { "ThanhTien" }, new[] { txt_thanhtien.Text });
            Table bangThongTinGiaDinh = baoCao.GetChild(NodeType.Table, 1, true) as Table;
            int hangHienTai = 1;
            List<CT_SP_HoaDon> ct_sp = hd.LoadChiTiet_HoaDon(mahd);
            bangThongTinGiaDinh.InsertRows(hangHienTai, hangHienTai, 3);
            int i = 1;
            foreach (CT_SP_HoaDon sp in ct_sp)
            {
                bangThongTinGiaDinh.PutValue(hangHienTai, 0, i.ToString());
                bangThongTinGiaDinh.PutValue(hangHienTai, 1, sp.Tensp);
                bangThongTinGiaDinh.PutValue(hangHienTai, 2, sp.Donvitinh);
                bangThongTinGiaDinh.PutValue(hangHienTai, 3, sp.Soluong);
                bangThongTinGiaDinh.PutValue(hangHienTai, 4, sp.Dongia);
                bangThongTinGiaDinh.PutValue(hangHienTai, 5, sp.Thanhtien);
                hangHienTai++;
                i++;
            } 
            baoCao.SaveAndOpenFile("BaoCao.doc");
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
         
            if(cbm_ma_KM.SelectedIndex.ToString()==null)
            {
                if(txt_tiencoc.Text == "0")
                {
                    HoaDon hoadon = new HoaDon();
                    hoadon.MaHD = mahd;
                    hoadon.ThanhTien = int.Parse(ParseCurrency(txt_thanhtien.Text).ToString());
                    hoadon.TienCoc = 0;
                    hoadon.MaKhuyenMai = "Không có mã giảm giá";
                    hoadon.TrangThai =true;
                    hoadon.TrangThaiDonHang = "Chờ lấy hàng";
                   if( hd.update_hoadon_thanhtoantaiquay(hoadon))
                    {
                        MessageBox.Show("Xác nhận thanh toán thành công.","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information );
                        btn_hoaddon.Enabled = true;
                    }    
                } 
                else
                {
                    HoaDon hoadon = new HoaDon();
                    hoadon.MaHD = mahd;
                    hoadon.ThanhTien = int.Parse(ParseCurrency(txt_thanhtien.Text).ToString());
                    hoadon.TienCoc = int.Parse(ParseCurrency(txt_tiencoc.Text).ToString());
                    hoadon.MaKhuyenMai = "Không có mã giảm giá";
                    hoadon.TrangThai = true;
                    hoadon.TrangThaiDonHang = "Chờ lấy hàng";
                    if (hd.update_hoadon_thanhtoantaiquay(hoadon))
                    {
                        MessageBox.Show("Xác nhận thanh toán thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_hoaddon.Enabled = true;
                    }
                }    
            }    
            else
            {
                if (txt_tiencoc.Text == "0")
                {
                    HoaDon hoadon = new HoaDon();
                    hoadon.MaHD = mahd;
                    hoadon.ThanhTien = int.Parse(ParseCurrency(txt_thanhtien.Text).ToString());
                    hoadon.TienCoc = 0;
                    hoadon.MaKhuyenMai = catChuoi(cbm_ma_KM.SelectedItem.ToString());
                    hoadon.TrangThai = true;
                    hoadon.TrangThaiDonHang = "Chờ lấy hàng";
                    if (hd.update_hoadon_thanhtoantaiquay(hoadon))
                    {
                        MessageBox.Show("Xác nhận thanh toán thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_hoaddon.Enabled = true;
                    }
                }
                else
                {
                    HoaDon hoadon = new HoaDon();
                    hoadon.MaHD = mahd;
                    hoadon.ThanhTien = int.Parse(ParseCurrency(txt_thanhtien.Text).ToString());
                    hoadon.TienCoc = int.Parse(ParseCurrency(txt_tiencoc.Text).ToString());
                    hoadon.MaKhuyenMai =catChuoi(cbm_ma_KM .SelectedItem.ToString());
                    hoadon.TrangThai = true;
                    hoadon.TrangThaiDonHang = "Chờ lấy hàng";
                    if (hd.update_hoadon_thanhtoantaiquay(hoadon))
                    {
                        MessageBox.Show("Xác nhận thanh toán thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_hoaddon.Enabled = true;
                    }
                }
            }    
        }

        private void txt_magiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_tongsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txt_tiencoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_tenkhachhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }


        private void cbm_khachhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsControl(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (cbm_khachhang.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_diachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radiobtn_trahet_CheckedChanged(object sender, EventArgs e)
        {
               btn_thanhtoan.Enabled = true;
        }
        public string catChuoi(string s)
        {
           
            string[] parts = s.Split('-');

            if (parts.Length > 1)
            {
                string result = parts[0];
                return result; // Kết quả: "gdjsfjsf"
            }
            return "Không có mã khuyến mãi";
        }
        private void cbm_ma_KM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbm_ma_KM.SelectedItem!=null)
            {
                double kq = 1;
                float b = (float)1.0;
                int a = 0;
                    if (!string.IsNullOrEmpty(catChuoi(cbm_ma_KM.SelectedItem.ToString())))
                    {
                        a = ct.tong_thanhtien(mahd);
                        b = (km.LayPhanTramKhuyenMai(catChuoi(cbm_ma_KM.SelectedItem.ToString())) / (float)100);
                        kq *= a * b;
                        double thanhtien = a - kq;
                        txt_tongtien.Text = FormatCurrency(decimal.Parse(a.ToString()));
                        txt_giamgia.Text = FormatCurrency(decimal.Parse(kq.ToString()));
                        txt_thanhtien.Text = FormatCurrency(decimal.Parse(thanhtien.ToString()));
                    }
                    else
                    {
                        a = ct.tong_thanhtien(mahd);
                        txt_tongtien.Text = FormatCurrency(decimal.Parse(a.ToString()));
                        txt_thanhtien.Text = FormatCurrency(decimal.Parse(a.ToString()));
                    }

                
            }    
        }
    }
}
