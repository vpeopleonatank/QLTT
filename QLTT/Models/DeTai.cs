using System;
using System.Collections.Generic;

namespace QLTT.Models;

public partial class DeTai
{
    public string Madt { get; set; } = null!;

    public string? Tendt { get; set; }

    public int? Kinhphi { get; set; }

    public string? Noithuctap { get; set; }

    public virtual ICollection<HuongDan> HuongDans { get; set; } = new List<HuongDan>();
}
