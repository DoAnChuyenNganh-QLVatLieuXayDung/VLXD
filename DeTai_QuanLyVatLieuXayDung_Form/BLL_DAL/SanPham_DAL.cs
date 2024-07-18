using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class SanPham_DAL
    {
        public SanPham_DAL() { }    

        QL_VatLieuXayDungDataContext db=new QL_VatLieuXayDungDataContext();

        public int layma_HSX(string tenhsx)
        {
            return db.HangSanXuats.Where(p=>p.TenHSX.Contains(tenhsx)).Select(p=>p.MaHSX).FirstOrDefault();
        }
        public int layma_SP(string tenhsx)
        {
            return db.SanPhams.Where(p => p.TenSP.Contains(tenhsx)).Select(p => p.MaSP).FirstOrDefault();
        }
        public List<SanPham> load_SP_HSX(string tenhsx)
        {

                int maHSX = layma_HSX(tenhsx);

                var ketQua = (
                    from chiTiet in db.ChiTiet_SanPham_HangSanXuats
                    where chiTiet.MaHSX == maHSX
                    join sanPham in db.SanPhams on chiTiet.MaSP equals sanPham.MaSP
                    select sanPham
                )
                .ToList();
                return ketQua;

        }

        public List<SanPham> load()
        {
            return db.SanPhams.ToList();
            
        }
        public int laySoLuongSP_Kho(int masp)
        {
            return db.SanPhams.Where(p=>p.MaSP==masp).Select(p=>p.TonKho).FirstOrDefault().Value;
        }
        public List<SanPham> load_theotenloai(string tenloai)
        {
            int maloai=lay_maloai(tenloai);
            return db.SanPhams.Where(p=>p.MaLoai==maloai).Select(p=>p).ToList();
        }
        public List<SanPham> load_tenSanPham(string tensp) {  return db.SanPhams.Where(p=>p.TenSP.Contains(tensp)).ToList();}
        public List<SanPham> load_SoSao_SanPham(int tensp) { return db.SanPhams.Where(p => p.SoSao==tensp).ToList(); }
        public List<SanPham> load_GiaBan_SanPham(int tensp) { return db.SanPhams.Where(p => p.GiaBan==tensp).ToList(); }
        /// <summary>
        /// Đếm Sản Phẩm theo tên
        /// </summary>
        /// <param name="tenloaisp"></param>
        /// <returns></returns>
        public int Dem_tenSanPham(string tensp) 
        { 
            return db.SanPhams.Where(p => p.TenSP.Contains(tensp)).Count(); 
        }

        /// <summary>
        /// Đếm theo loại
        /// </summary>
        /// <param name="tenloaisp"></param>
        /// <returns></returns>
        /// 
        public int Dem_tenloaiSanPham(int maloai)
        {
            return db.SanPhams.Where(p => p.MaLoai==maloai).Count();
        }
        public List<SanPham> load_tenloaiSanPham(int tenloaisp) { return db.SanPhams.Where(p => p.MaLoai==tenloaisp).ToList(); }
        public List<ChiTietPhieuDat> load_CT_PhieuDat()
        {
            return db.ChiTietPhieuDats.ToList();
        }

        public List<CT_PhieuDat_SP> LoadChiTiet_PhieuDat()
        {
            var chiTietPhieuNhapInfo = db.ChiTietPhieuDats
                .Where(ctpn => ctpn.MaPhieuDat == LayMaPhieuDatHienTai())
                .Select(ctpn => new CT_PhieuDat_SP
                {
                    Tensp = lay_tensp(ctpn.MaSanPham),
                    Donvitinh =lay_DVT(ctpn.MaSanPham),
                    Soluong = ctpn.SoLuong.ToString(),
                })
                .ToList();
            return chiTietPhieuNhapInfo;
        }
        public List<LichSuHoatDong> insertLS(string user, DateTime ngay, string hoatdong, string trangthai)
        {
            LichSuHoatDong ls = new LichSuHoatDong();

            ls.UserName = user;
            ls.ThoiGian = ngay;
            ls.HoatDong = hoatdong;
            ls.TrangThai = trangthai;

            db.LichSuHoatDongs.InsertOnSubmit(ls);
            db.SubmitChanges();
            return db.LichSuHoatDongs.ToList();

        }

        public List<SanPham> insert_SanPham(string tensp,string dvt,int sosao,int giaban,int gianhap,string tinhtrang,string mota,string thongtin, string hinh,int maloai)
        {
            SanPham ls = new SanPham();
            ls.TenSP = tensp;
            ls.DonViTinh = dvt;
            ls.SoSao = sosao;
            ls.GiaBan=giaban;
            ls.GiaNhap= gianhap;
            ls.TinhTrang= tinhtrang;
            ls.MoTa=    mota;
            ls.ThongTin=    thongtin;
            ls.ImageUrl = hinh;
            ls.MaLoai= maloai;
            ls.TonKho = 0;
            db.SanPhams.InsertOnSubmit(ls);
            db.SubmitChanges();
            return db.SanPhams.ToList();
        }

        public List<String> load_cbm_donvitinh()
        {
            List<String> list = new List<String>();
            var uniqueNames = db.SanPhams.Select(p => p.DonViTinh).Distinct().ToList();
            foreach (var name in uniqueNames)
            {
          
                list.Add(name);
            }
            return list;
        }
        public List<String> load_cbm_maloai()
        {
            List<String> list = new List<String>();
            var uniqueNames = db.LoaiSanPhams.Select(p => p.TenLoai).Distinct().ToList();
            foreach (var name in uniqueNames)
            {

                list.Add(name.ToString());
            }
            return list;
        }
        public int lay_maloai(string tenloai)
        {
            return db.LoaiSanPhams.Where(p => p.TenLoai.Contains(tenloai)).Select(p => p.MaLoai).FirstOrDefault();
        }
        public string lay_tenloai(int maloai)
        {
            return db.LoaiSanPhams.Where(p => p.MaLoai==maloai).Select(p => p.TenLoai).FirstOrDefault();
        }
        public string lay_tensp(int maloai)
        {
            return db.SanPhams.Where(p => p.MaSP== maloai).Select(p => p.TenSP).FirstOrDefault();
        }
        public string lay_DVT(int maloai)
        {
            return db.SanPhams.Where(p => p.MaSP == maloai).Select(p => p.DonViTinh).FirstOrDefault();
        }
        public int LayMaPhieuDatHienTai()
        {
            // Lấy mã phiếu đặt cuối cùng từ cơ sở dữ liệu
            int? maPhieuDat = db.PhieuDats
                .OrderByDescending(p => p.MaPhieuDat)
                .Select(p => (int?)p.MaPhieuDat)
                .FirstOrDefault();

            // Kiểm tra nếu maPhieuDat là null, trả về giá trị mặc định là 0
            return maPhieuDat ?? 0;

        }
        public HangSanXuat lay_dc_tenhsx(string tenhsx)
        {
            return db.HangSanXuats.Where(p=>p.TenHSX==tenhsx).Select(p=>p).FirstOrDefault();

        }

        public List<ChiTietPhieuDat> insert_ChiTiet_PhieuDat(int masp, int soluong)
        {

            ChiTietPhieuDat chiTietPhieuDat = new ChiTietPhieuDat();
            chiTietPhieuDat.MaPhieuDat = LayMaPhieuDatHienTai();
            chiTietPhieuDat.MaSanPham = masp;
            chiTietPhieuDat.SoLuong = soluong;
    
            db.ChiTietPhieuDats.InsertOnSubmit(chiTietPhieuDat);
            db.SubmitChanges();
            return db.ChiTietPhieuDats.ToList();
        }
        public List<PhieuDat> insert_PhieuDat(string tenhsx)
        {
            DateTime currentDate = DateTime.Today;
            string dateString = currentDate.ToString("dd/MM/yyyy");
            PhieuDat phieuDat = new PhieuDat();
            phieuDat.NgayLap = currentDate;
       
            phieuDat.TrangThai = "Chưa hoàn thành";
            phieuDat.MaHSX = layma_HSX(tenhsx);
            db.PhieuDats.InsertOnSubmit(phieuDat);

            db.SubmitChanges();
            return db.PhieuDats.ToList();

        }
        public List<ChiTietPhieuDat> xoa_SP_chitietphieu(int masp)
        {
            try
            {
                int maPhieuDat = LayMaPhieuDatHienTai();
                var chiTietPhieuDatToDelete = db.ChiTietPhieuDats
                    .Where(ctpd => ctpd.MaPhieuDat == maPhieuDat && ctpd.MaSanPham == masp).Select(p=>p)
                    .ToList();

                if (chiTietPhieuDatToDelete.Any())
                {
                    // Xóa các chi tiết phiếu đặt khỏi cơ sở dữ liệu
                    db.ChiTietPhieuDats.DeleteAllOnSubmit(chiTietPhieuDatToDelete);
                    db.SubmitChanges();
                }

                // Trả về danh sách sau khi xóa (nếu cần)
                return chiTietPhieuDatToDelete;
            }
            catch (Exception ex)
            {
                // Xử lý exception (in hoặc log lỗi)
                Console.WriteLine($"Lỗi khi xóa chi tiết phiếu đặt: {ex.Message}");
                return null;
            }

        }

    }
}
