using System;
using System.Collections.Generic;

namespace QLTT.Models;

public partial class GiangVien
{
    public int Magv { get; set; }

    public string? Hotengv { get; set; }

    public decimal? Luong { get; set; }

    public string Makhoa { get; set; } = null!;

    public virtual ICollection<HuongDan> HuongDans { get; set; } = new List<HuongDan>();

    public virtual Khoa MakhoaNavigation { get; set; } = null!;
}
