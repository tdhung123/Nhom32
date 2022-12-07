using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace btl_nhom32.Models;
public class Nhanvien
{
    [Key]
    [Display(Name = "Mã nhân viên")]
    public string Manv { get; set; }

    [Display(Name = "Tên nhân viên")]
    [StringLength(250)]
    public string Tennv { get; set; }

    [Display(Name = "Giới tính")]
    public string Gioitinhnv { get; set; }

    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
    public DateTime ngaynv { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Số điện thoại")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
    public string Sdtnv { get; set; }

    [Display(Name = "Địa chỉ")]
    [StringLength(250)]
    public string Diachinv { get; set; }

    [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
    [Display(Name = "Email")]
    public string Emailnv { get; set; }



    [Display(Name = "Tên công việc")]
    public string Tencv { get; set; }
    [ForeignKey("Tencv")]
    [Display(Name = "Tên công việc")]
    public Chucvucv? Chucvucv { get; set; }


    [DataType(DataType.Date)]

    [Display(Name = "Ngày vào làm")]
    public DateTime ngaylamnv { get; set; }


}