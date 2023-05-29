using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using QLTT.Models;
using QLTT.Services;

namespace QLTT.Controllers
{
    public class QlttController : Controller
    {

        private readonly ThucTapContext _thuctapContext;
        private readonly IQuanlythuctap iQuanlythuctap;
        public QlttController(ThucTapContext thuctapContext, IQuanlythuctap quanlythuctap)
        {
            _thuctapContext = thuctapContext;
            iQuanlythuctap = quanlythuctap;
        }
        public async Task<IActionResult> Index(string Makhoa, string Masv, string Magv)
        {
            var khoas = from d in _thuctapContext.Khoas
                        select d;
            ViewData["khoas"] = await khoas.ToListAsync();
            var huongdansList = await iQuanlythuctap.GetDanhsachSinhVien(Makhoa, Magv, Masv);
            var huongdanVM = new HuongdanViewModel();
            huongdanVM.Huongdans = huongdansList;
            int soLuonggv = (from m in huongdanVM.Huongdans select m.Magv).Distinct().Count();
            int soLuongsv = (from m in huongdanVM.Huongdans select m.Masv).Distinct().Count();
            huongdanVM.Soluonggv = soLuonggv;
            huongdanVM.Soluongsv = soLuongsv;
            return View(huongdanVM);
        }

        public async Task<IActionResult> Create()
        {
            var sinhviens = await _thuctapContext.SinhViens.ToListAsync();
            var giangviens = await _thuctapContext.GiangViens.ToListAsync();
            var detais = await _thuctapContext.DeTais.ToListAsync();
            ViewData["sinhviens"] = sinhviens;
            ViewData["giangviens"] = giangviens;
            ViewData["detais"] = detais;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masv", "Magv", "Madt", "Ketqua")] HuongDan huongdan)
        {
            if (ModelState.IsValid)
            {
                _thuctapContext.Add(huongdan);
                await _thuctapContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var sinhviens = await _thuctapContext.SinhViens.ToListAsync();
            var giangviens = await _thuctapContext.GiangViens.ToListAsync();
            var detais = await _thuctapContext.DeTais.ToListAsync();
            ViewData["sinhviens"] = sinhviens;
            ViewData["giangviens"] = giangviens;
            ViewData["detais"] = detais;
            return View(huongdan);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var huongdan = await _thuctapContext.HuongDans.FirstOrDefaultAsync(m => m.Mahd == id);
            if (huongdan == null)
            {
                return NotFound();
            }

            var sinhviens = await _thuctapContext.SinhViens.ToListAsync();
            var giangviens = await _thuctapContext.GiangViens.ToListAsync();
            var detais = await _thuctapContext.DeTais.ToListAsync();
            ViewData["sinhviens"] = sinhviens;
            ViewData["giangviens"] = giangviens;
            ViewData["detais"] = detais;
            return View(huongdan);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huongdan = await _thuctapContext.HuongDans.Include(i => i.MasvNavigation)
                .Include(i => i.MagvNavigation)
                .Include(i => i.MadtNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (huongdan == null)
            {
                return NotFound();
            }

            return View(huongdan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HuongDan huongdan = await _thuctapContext.HuongDans.SingleAsync(m => m.Mahd == id);
            _thuctapContext.HuongDans.Remove(huongdan);

            await _thuctapContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TraCuuDiemSv(string masv)
        {
            if (!string.IsNullOrEmpty(masv))
            {
                var ketquasv = await iQuanlythuctap.GetThongtindiemSV(masv);
                ViewData["KetQuaSinhVien"] = ketquasv;
                var sinhvien = await _thuctapContext.SinhViens.FirstOrDefaultAsync(m => m.Masv == int.Parse(masv));
                if (sinhvien != null)
                {
                    return View(sinhvien);
                }
            }
            return View();
        }
    }
}
