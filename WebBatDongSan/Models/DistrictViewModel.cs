using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebBatDongSan.Models;

public class DistrictViewModel
{
    public List<BDS>? Bds { get; set; }
    public SelectList? Districts { get; set; }
    public string? District { get; set; }
    public string? SearchString { get; set; }
}