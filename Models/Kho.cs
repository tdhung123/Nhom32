using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace btl_nhom32.Models;
public class Kho
{
    [Key]
    [Display(Name = "Mã kho")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string Makho { get; set; }


    [Display(Name = "Địa chỉ kho")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string Dckho { get; set; }


}