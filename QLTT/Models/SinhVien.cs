using System;
using System.Collections.Generic;

namespace QLTT.Models;

public partial class SinhVien
{
    public int Masv { get; set; }

    public string? Hotensv { get; set; }

    public string Makhoa { get; set; } = null!;

    public int? Namsinh { get; set; }

    public string? Quequan { get; set; }

    public virtual ICollection<HuongDan> HuongDans { get; set; } = new List<HuongDan>();

    public virtual Khoa MakhoaNavigation { get; set; } = null!;
}
