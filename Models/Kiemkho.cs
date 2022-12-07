using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace btl_nhom32.Models;
public class Kiemkho
{
    [Key]
    [Display(Name = "Mã kiểm kho")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string Idkk { get; set; }

    [Display(Name = "Ngày kiểm kho")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public DateTime Ngaykk { get; set; }


    [Display(Name = "Mã hàng hoá")]
    public string Mahh { get; set; }
    [ForeignKey("Mahh")]
    [Display(Name = "Mã hàng hoá")]
    public Hanghoa? Hanghoa { get; set; }


    [Display(Name = "Mã kho")]

    public string Makho { get; set; }
    [ForeignKey("Makho")]
    [Display(Name = "Mã kho")]
    public Kho? Kho { get; set; }



    [Display(Name = "Số lượng hàng còn trong kho")]
    [Phone(ErrorMessage = "Ghi số lượng ")]
    public string Sluongkk { get; set; }
}