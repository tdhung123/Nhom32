using System.ComponentModel.DataAnnotations;
namespace btl_nhom32.Models;
public class Khachhang
{
    [Key]
    [Display(Name = "Mã Khách hàng")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [StringLength(250)]
    public string Makh { get; set; }


    [Display(Name = "Tên")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [StringLength(250)]
    public string Tenkh { get; set; }

    [Display(Name = "Địa chỉ")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [StringLength(250)]
    public string Diachikh { get; set; }


    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Số điện thoại")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
    public string Sdtkh { get; set; }

}