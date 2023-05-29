using Microsoft.EntityFrameworkCore;
using QLTT.Models;

namespace QLTT.Services
{
    public class Quanlythuctap : IQuanlythuctap
    {

        private readonly ThucTapContext _thuctapContext;
        public Quanlythuctap(ThucTapContext thuctapContext)
        {
            _thuctapContext = thuctapContext;
        }
        public async Task<List<HuongDan>> GetDanhsachSinhVien(string makhoa, string magv, string masv)
        {

            var huongdans = from d in _thuctapContext.HuongDans.Include(i => i.MagvNavigation)
                           .Include(i => i.MasvNavigation).Include(i => i.MadtNavigation)
                            select d;
            if (!string.IsNullOrEmpty(makhoa))
            {
                huongdans = huongdans.Where(s => s.MasvNavigation.Makhoa == makhoa);
                //.Where(s => s.MagvNavigation.Makhoa == Makhoa);
            }
            if (!string.IsNullOrEmpty(masv))
            {
                huongdans = huongdans.Where(s => s.Masv == int.Parse(masv));
            }
            if (!string.IsNullOrEmpty(magv))
            {
                huongdans = huongdans.Where(s => s.Magv == int.Parse(magv));
            }

            return await huongdans.ToListAsync();
        }

        public async Task<KetQuaSinhVien> GetThongtindiemSV(string masv)
        {
            var ketquasv = new KetQuaSinhVien();
            var query = from d in _thuctapContext.HuongDans.Where(s => s.Masv == int.Parse(masv)) select d.Ketqua;
            var kq = await query.FirstOrDefaultAsync();
            if (kq != null)
            {
                ketquasv.tongDiemTb = (decimal) kq;
                ketquasv.xepLoai = kq >= 4 ? "Đạt" : "Không đạt";

            } else
            {
                ketquasv.tongDiemTb = -1;
            }
            return ketquasv;
        }
    }
}
