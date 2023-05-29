using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLTT.Models;

public partial class HuongDan
{
    public int Mahd { get; set; }

    public int Masv { get; set; }

    public string Madt { get; set; } = null!;

    public int Magv { get; set; }

    public decimal? Ketqua { get; set; }

    [Display(Name = "Đề tài")]
    public DeTai? MadtNavigation { get; set; } = null!;

    [Display(Name = "Giảng viên")]
    public GiangVien? MagvNavigation { get; set; } = null!;

    [Display(Name = "Sinh viên")]
    public SinhVien? MasvNavigation { get; set; } = null!;
}
