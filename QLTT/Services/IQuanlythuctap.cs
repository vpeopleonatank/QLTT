using QLTT.Models;

namespace QLTT.Services
{
    public interface IQuanlythuctap
    {
        public Task<List<HuongDan>> GetDanhsachSinhVien(string makhoa, string magv, string masv);

        public Task<KetQuaSinhVien> GetThongtindiemSV(string masv);

    }
}
