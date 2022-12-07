using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace btl_nhom32.Models;
public class Thuonghieu
{
    [Key]
    [Display(Name = "ID thương hiệu")]
    public string Idth { get; set; }


    [Display(Name = "Tên thương hiệu")]
    [StringLength(250)]
    public string Tenth { get; set; }

}