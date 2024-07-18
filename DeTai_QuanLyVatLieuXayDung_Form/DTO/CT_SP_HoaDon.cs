using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_SP_HoaDon
    {
        private string tensp, donvitinh, soluong, dongia, thanhtien;

        public string Tensp { get => tensp; set => tensp = value; }
        public string Donvitinh { get => donvitinh; set => donvitinh = value; }
        public string Soluong { get => soluong; set => soluong = value; }
        public string Dongia { get => dongia; set => dongia = value; }
        public string Thanhtien { get => thanhtien; set => thanhtien = value; }
        public CT_SP_HoaDon() { }
        public CT_SP_HoaDon(string tensp, string donvitinh, string soluong, string dongia, string thanhtien)
        {
            Tensp = tensp;
            Donvitinh = donvitinh;
            Soluong = soluong;
            Dongia = dongia;
            Thanhtien = thanhtien;
   
        }
    }
}
