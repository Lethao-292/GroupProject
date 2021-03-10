using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class SinhVien
    {
        public int MaSV { get; private set; }
        public String HoSV { get; set; }
        public String TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public String MaKhoa { get; set; }
        public SinhVien()
        {

        }
        public SinhVien(int MaSV, String HoSV, String TenSV, DateTime NgaySinh, bool GioiTinh, String MaKhoa)
        {
            this.MaSV = MaSV;
            this.HoSV = HoSV;
            this.TenSV = TenSV;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.MaKhoa = MaKhoa;
        }
    }
}
