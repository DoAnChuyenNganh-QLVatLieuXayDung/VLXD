using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PhieuNhap_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public PhieuNhap_DAL() { }
        public List<PhieuNhap> load()
        {
            return db.PhieuNhaps.OrderBy(c => c.MaPhieuNhap).ToList();
        }


        public List<ChiTietPhieuDatInfo> ctpd(int mapd)
        {
            var ctpd = db.ChiTietPhieuDats
                 .Where(ctpn => ctpn.MaPhieuDat == mapd)
                 .Select(ctpn => new ChiTietPhieuDatInfo
                 {

                     MaPhieuDat = (int)ctpn.MaPhieuDat,
                     TenSP = (string)ctpn.SanPham.TenSP,
                     MaSP = (int)ctpn.MaSanPham,
                     SoLuong = (int)ctpn.SoLuong,

                 })
                 .ToList();

            return ctpd;
        }

        public DateTime lay_ngayDat(int mapd)

        {
            return db.PhieuDats.Where(p => p.MaPhieuDat == mapd).Select(p => p.NgayLap.Value).FirstOrDefault();
        }
        public class ChiTietPhieuDatInfo
        {

            public int MaPhieuDat { get; set; }
            public string TenSP { get; set; }
            public int MaSP { get; set; }
            public int SoLuong { get; set; }

        }






        public bool kiemtraphieudat(int mapd)
        {
            return db.PhieuNhaps.Any(pn => pn.MaPhieuDat == mapd);
        }


        public List<int> TimMaPhieuNhapTheoMaPhieuDat(int maPhieuDat)
        {
            var maPhieuNhap = db.PhieuNhaps
                .Where(pn => pn.MaPhieuDat == maPhieuDat)
                .Select(pn => pn.MaPhieuNhap)
                .ToList();

            return maPhieuNhap;
        }

        public bool ktdusanpham(int mapd)
        {
            if (kiemtraphieudat(mapd))
            {
                var productsInPhieuDat = db.ChiTietPhieuDats
                    .Where(ctpd => ctpd.MaPhieuDat == mapd)
                    .ToDictionary(ctpd => ctpd.MaSanPham, ctpd => ctpd.SoLuong);

                var totalProductsInPhieuNhap = db.ChiTietPhieuNhaps
                    .Where(ctpn => ctpn.PhieuNhap.MaPhieuDat == mapd) // Filter by MaPhieuDat
                    .GroupBy(ctpn => ctpn.MaSP)
                    .ToDictionary(g => g.Key, g => g.Sum(ctpn => ctpn.SoLuong));

                bool allProductsSufficient = productsInPhieuDat.All(product =>
                {
                    int maSanPham = product.Key;
                    int soLuongDat = (int)product.Value;

                    int soLuongNhap = totalProductsInPhieuNhap.ContainsKey(maSanPham) ? (int)totalProductsInPhieuNhap[maSanPham] : 0;

                    if (soLuongNhap != soLuongDat)
                    {
                        Console.WriteLine($"MaSanPham {maSanPham} does not have sufficient products.");
                        return false;
                    }

                    return true;
                });

                return allProductsSufficient;
            }

            return false;
        }







        public List<PhieuDat> doitrangthai(int mapd)
        {
            PhieuDat phieuDatToUpdate = null;

            if (ktdusanpham(mapd))
            {
                phieuDatToUpdate = db.PhieuDats.FirstOrDefault(pd => pd.MaPhieuDat == mapd);

                if (phieuDatToUpdate != null)
                {
                    phieuDatToUpdate.TrangThai = "Hoàn thành";
                    db.SubmitChanges();
                }
            }

            return phieuDatToUpdate != null ? new List<PhieuDat> { phieuDatToUpdate } : null;
        }






        public List<ChiTietPhieuNhapInfo> LoadChiTietPhieuNhap(int maPhieuNhap)
        {
            var chiTietPhieuNhapInfo = db.ChiTietPhieuNhaps
                .Where(ctpn => ctpn.MaPhieuNhap == maPhieuNhap)
                .Select(ctpn => new ChiTietPhieuNhapInfo
                {

                    MaPhieuNhap = (int)ctpn.MaPhieuNhap,
                    TenSP = (string)ctpn.SanPham.TenSP,
                    MaSP = (int)ctpn.MaSP,
                    SoLuong = (int)ctpn.SoLuong,
                    GiaNhap = (int)ctpn.GiaNhap,
                    ThanhTien = (int)ctpn.ThanhTien,
                })
                .ToList();
            return chiTietPhieuNhapInfo;
        }

        public class ChiTietPhieuNhapInfo
        {
            public int MaDaiDien { get; set; }
            public int MaPhieuNhap { get; set; }
            public string TenSP { get; set; }
            public int MaSP { get; set; }
            public int SoLuong { get; set; }
            public int GiaNhap { get; set; }
            public int ThanhTien { get; set; }
        }



        public List<PhieuNhap> insert(int maNV, DateTime ngayNhap, int maPD, int tongtien, string trangthai)
        {
            PhieuNhap nv = new PhieuNhap();

            nv.MaNV = maNV;
            nv.NgayNhap = ngayNhap;
            nv.MaPhieuDat = maPD;
            nv.TongTien = tongtien;
            nv.TrangThai = trangthai;


            db.PhieuNhaps.InsertOnSubmit(nv);
            db.SubmitChanges();
            return db.PhieuNhaps.ToList();

        }

        public List<PhieuNhap> update(int ma, int maNV, DateTime ngayNhap, int maPD, int tongtien, string trangthai)
        {
            PhieuNhap nv = db.PhieuNhaps.Where(n => n.MaPhieuNhap == ma).FirstOrDefault();
            if (nv != null)
            {
                nv.MaNV = maNV;
                nv.NgayNhap = ngayNhap;
                nv.MaPhieuDat = maPD;
                nv.TongTien = tongtien;
                nv.TrangThai = trangthai;

                db.SubmitChanges();
            }
            return db.PhieuNhaps.ToList();

        }

        public List<ChiTietPhieuNhap> InsertChiTietPhieuNhap(int maPhieuNhap, int maSP, int soLuong, int giaBan, int thanhTien)
        {
            ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap();

            chiTiet.MaPhieuNhap = maPhieuNhap;
            chiTiet.MaSP = maSP;
            chiTiet.SoLuong = soLuong;
            chiTiet.GiaNhap = giaBan;
            chiTiet.ThanhTien = thanhTien;

            db.ChiTietPhieuNhaps.InsertOnSubmit(chiTiet);
            db.SubmitChanges();

            return db.ChiTietPhieuNhaps.ToList();
        }

        public List<ChiTietPhieuNhap> UpdateChiTietPhieuNhap(int maPhieuNhap, int maSP, int soLuong, int giaBan, int thanhTien)
        {
            ChiTietPhieuNhap chiTiet = db.ChiTietPhieuNhaps.Where(ct => ct.MaPhieuNhap == maPhieuNhap && ct.MaSP == maSP).FirstOrDefault();

            if (chiTiet != null)
            {
                chiTiet.SoLuong = soLuong;
                chiTiet.GiaNhap = giaBan;
                chiTiet.ThanhTien = thanhTien;

                db.SubmitChanges();
            }

            return db.ChiTietPhieuNhaps.ToList();
        }
        public List<PhieuDatInfo> LoadPhieuDatChuaHoanThanh()
        {
            var query = from pd in db.PhieuDats
                        join hsx in db.HangSanXuats on pd.MaHSX equals hsx.MaHSX
                        where pd.TrangThai == "Chưa hoàn thành"
                        select new PhieuDatInfo
                        {
                            MaPhieuDat = pd.MaPhieuDat,
                            NgayLap = (DateTime)pd.NgayLap,
                            TrangThai = pd.TrangThai,
                            TenHSX = hsx.TenHSX,
                            DiaChi = hsx.DiaChi,
                            SDT = hsx.SDT
                        };

            return query.ToList();
        }

        public class PhieuDatInfo
        {
            public int MaPhieuDat { get; set; }
            public DateTime NgayLap { get; set; }
            public string TrangThai { get; set; }
            public string TenHSX { get; set; }
            public string DiaChi { get; set; }
            public string SDT { get; set; }
        }


        //public List<SanPhamInfo> XuatSanPhamTheoMaPhieuDat(int maPhieuDat)
        //{
        //    var sanPhams = db.ChiTietPhieuDats
        //        .Where(ctpd => ctpd.MaPhieuDat == maPhieuDat)
        //        .Select(ctpd => new SanPhamInfo
        //        {
        //            MaSanPham = ctpd.MaSanPham,
        //            TenSP = ctpd.SanPham.TenSP
        //        })
        //        .ToList();

        //    return sanPhams;
        //}

        public List<SanPhamInfo> XuatSanPhamTheoMaPhieuDat(int maPhieuDat)
        {
            var sanPhams = db.ChiTietPhieuDats
                .Where(ctpd => ctpd.MaPhieuDat == maPhieuDat)
                .Select(ctpd => new SanPhamInfo
                {
                    MaSanPham = (int)ctpd.MaSanPham,
                    TenSP = ctpd.SanPham.TenSP,
                    Soluong = (int)ctpd.SoLuong
                })
                .ToList();

            var totalProductsInPhieuNhap = db.ChiTietPhieuNhaps
                .Where(ctpn => ctpn.PhieuNhap.MaPhieuDat == maPhieuDat)
                .GroupBy(ctpn => ctpn.MaSP)
                .ToDictionary(g => g.Key, g => g.Sum(ctpn => ctpn.SoLuong));

            foreach (var sp in sanPhams)
            {
                int maSanPham = sp.MaSanPham;
                int soLuongDat = sp.Soluong;

                int soLuongNhap = totalProductsInPhieuNhap.ContainsKey(maSanPham) ? (int)totalProductsInPhieuNhap[maSanPham] : 0;

                sp.Soluong = soLuongDat - soLuongNhap;
            }

            return sanPhams;
        }



        private int GetSoluongForProduct(List<SanPhamInfo> sanPhams, int maSanPham)
        {
            var productInfo = sanPhams.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
            return productInfo != null ? productInfo.Soluong : 0;
        }








        public class SanPhamInfo
        {
            public int MaSanPham { get; set; }
            public string TenSP { get; set; }

            public int Soluong { get; set; }

        }


        public void AddChiTietPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            using (var context = new QL_VatLieuXayDungDataContext())
            {
                context.ChiTietPhieuNhaps.InsertOnSubmit(chiTietPhieuNhap);

                var phieuNhap = context.PhieuNhaps.FirstOrDefault(pn => pn.MaPhieuNhap == chiTietPhieuNhap.MaPhieuNhap);

                if (phieuNhap != null)
                {
                    phieuNhap.TongTien += chiTietPhieuNhap.ThanhTien;
                }

                context.SubmitChanges();
            }
        }


        public int LaySoLuongDat(int maPhieuDat, int maSanPham)
        {
            var orderedQuantity = db.ChiTietPhieuDats
                .Where(ctpd => ctpd.MaPhieuDat == maPhieuDat && ctpd.MaSanPham == maSanPham)
                .Sum(ctpd => ctpd.SoLuong) ?? 0;

            var deliveredQuantity = db.ChiTietPhieuNhaps
                .Where(ctpn => ctpn.PhieuNhap.MaPhieuDat == maPhieuDat && ctpn.MaSP == maSanPham)
                .Sum(ctpn => ctpn.SoLuong) ?? 0;

            return orderedQuantity - deliveredQuantity;
        }

        public string tenNV(int ma)
        {
            var ten = db.NhanViens
               .Where(nv => nv.MaNV == ma).Select(nv => nv.TenNV)
               .FirstOrDefault();

            return ten;
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

    }
}

