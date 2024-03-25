using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebBatDongSan.Models;

public class BDS
{
    public int Id { get; set; }
    [Display(Name = "Tên BĐS"), StringLength(60, MinimumLength = 3)]
    public string? EstateName { get; set; }

    [Display(Name = "Vị trí"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(100, MinimumLength = 3)]
    public string? Location { get; set; }

    [Display(Name = "Tỉnh/thành"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string? District { get; set; }
    [Display(Name = "Diện tích")]
    public decimal Area { get; set; }
    [Display(Name = "Giá"), Range(1, 1000000000000), DataType(DataType.Currency), Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Display(Name = "Hướng")]
    public string? Direction { get; set; }
    [Display(Name = "Mô tả"), StringLength(1000, MinimumLength = 10)]
    public string? Description { get; set; }
}