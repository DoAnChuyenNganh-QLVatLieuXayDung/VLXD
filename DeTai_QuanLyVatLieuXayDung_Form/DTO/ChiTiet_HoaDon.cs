using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTiet_HoaDon
    {

        private int thanhtien;
        private string tensp;
        private int mahoadon;
        private int soluong;
        private int giaban;

        public int Mahoadon { get => mahoadon; set => mahoadon = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Giaban { get => giaban; set => giaban = value; }
        public int Thanhtien { get => thanhtien; set => thanhtien = value; }
       
        public ChiTiet_HoaDon()
        { }

        public ChiTiet_HoaDon( string tensp, int mahoadon, int soluong, int giaban, int thanhtien)
        {
            Thanhtien = thanhtien;
            Tensp = tensp;
            Mahoadon = mahoadon;
            Soluong = soluong;
            Giaban = giaban;

        }
    }
}
