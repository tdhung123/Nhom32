using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace btl_nhom32.Models;
public class Nhaphang
{
    [Key]
    [Display(Name = "ID nhập hàng")]
    public string Idnh { get; set; }

    [Display(Name = "Mã hàng hoá")]
    public string Mahh { get; set; }
    [ForeignKey("Mahh")]
    [Display(Name = "Mã hàng hoá")]
    public Hanghoa? Hanghoa { get; set; }


    [Display(Name = "Mã nhà cung cấp")]
    public string Mancc { get; set; }
    [ForeignKey("Mancc")]
    [Display(Name = "Mã nhà cung cấp")]
    public Nhacungcap? Nhacungcap { get; set; }

    [Display(Name = "Mã kho")]
    public string Makho { get; set; }
    [ForeignKey("Makho")]
    [Display(Name = "Mã kho")]
    public Kho? Kho { get; set; }


    [Display(Name = "Số lượng nhập hàng")]
    [Phone(ErrorMessage = "Ghi số lượng ")]
    public string Soluongnh { get; set; }



    [Display(Name = "Ngày nhập hàng")]
    public DateTime ngaynh { get; set; }


}