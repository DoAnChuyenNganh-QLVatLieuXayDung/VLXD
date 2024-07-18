using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LichSuThaoTac_DAL
    {
        QL_VatLieuXayDungDataContext db =new QL_VatLieuXayDungDataContext();
        public LichSuThaoTac_DAL() { }  

        public List<LichSuHoatDong> load()
        {
            return  db.LichSuHoatDongs.ToList();
        }


        public List<LichSuHoatDong> searchTenUser(string ten)
        {
            List<LichSuHoatDong> danhSach = db.LichSuHoatDongs
                .Where(kh => kh.UserName.ToString().Contains(ten))
                .ToList();
            return danhSach;
        }


        public List<LichSuHoatDong> searchNgay(DateTime ngay)
        {
            DateTime ngayChiNgay = ngay.Date;

            List<LichSuHoatDong> danhSach = db.LichSuHoatDongs
                .Where(kh => kh.ThoiGian == ngayChiNgay)
                .ToList();

            return danhSach;
        }

    }
}
