using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace btl_nhom32.Models;
public class Hanghoa
{
    [Key]
    [Display(Name = "Mã hàng")]
    [Required(ErrorMessage = "Phải nhập {0}")]

    [StringLength(250)]
    public string Mahh { get; set; }


    [Display(Name = "Tên hàng hoá")]
    [Required(ErrorMessage = "Phải nhập {0}")]

    [StringLength(250)]
    public string Tenhh { get; set; }


    [Display(Name = "Tên thương hiệu")]
    public string Tenth { get; set; }
    [ForeignKey("Tenth")]
    [Display(Name = "Tên thương hiệu")]
    public Thuonghieu? Thuonghieu { get; set; }

    [Display(Name = "Đơn vị")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [StringLength(150)]
    public string Dvtinh { get; set; }



    [Display(Name = "Giá vốn")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public decimal gvhh { get; set; }

    [Display(Name = "Giá bán")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public decimal gbhh { get; set; }


}