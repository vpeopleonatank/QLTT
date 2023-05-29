using System;
using System.Collections.Generic;

namespace QLTT.Models;

public partial class Khoa
{
    public string Makhoa { get; set; } = null!;

    public string? Tenkhoa { get; set; }

    public string? Dienthoai { get; set; }

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
