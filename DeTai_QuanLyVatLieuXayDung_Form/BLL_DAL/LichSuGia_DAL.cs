using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LichSuGia_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();



        public LichSuGia_DAL()
        {

        }


        public class SanPhamDto
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public int? GiaBan { get; set; }
        }

        public List<SanPhamDto> Load()
        {
            var result = db.SanPhams
                .Select(sp => new SanPhamDto
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan
                })
                .ToList();

            return result;
        }



        public List<(DateTime? NgayCapNhat, int Gia)> LayGia(int maSP)
        {
            var results = db.LichSuGias
                .Where(ls => ls.MaSP == maSP)
                .Select(ls => new { ls.NgayCapNhat, ls.Gia })
                .ToList();

            if (results != null && results.Any())
            {
                return results
    .Select(result => ((DateTime?)result.NgayCapNhat, result.Gia))
    .ToList();

            }


            return new List<(DateTime? NgayCapNhat, int Gia)>();
        }


        public List<SanPhamDto> SearchMa(int ma)
        {
            List<SanPhamDto> danhSachSanPhamDto = db.SanPhams
                .Where(kh => kh.MaSP == ma)
                .Select(sp => new SanPhamDto
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan
                })
                .ToList();

            return danhSachSanPhamDto;
        }

        public List<SanPhamDto> SearchTen(string ten)
        {
            List<SanPhamDto> danhSachSanPhamDto = db.SanPhams
                .Where(kh => kh.TenSP.Contains(ten))
                .Select(sp => new SanPhamDto
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan
                })
                .ToList();

            return danhSachSanPhamDto;
        }

        public List<SanPhamDto> SearchGia(string gia)
        {
            List<SanPhamDto> danhSachSanPhamDto = db.SanPhams
                .Where(kh => kh.GiaBan.ToString().Contains(gia))
                .Select(sp => new SanPhamDto
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    GiaBan = sp.GiaBan
                })
                .ToList();

            return danhSachSanPhamDto;
        }

    }
}
