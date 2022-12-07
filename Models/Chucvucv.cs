using System.ComponentModel.DataAnnotations;
namespace btl_nhom32.Models;
public class Chucvucv
{
    [Key]
    [Display(Name = "ID Chức vụ")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập {0}")]

    public string Idcv { get; set; }



    [Display(Name = "Tên công việc")]
    [StringLength(100)]
    [Required(ErrorMessage = "Phải nhập {0}")]

    public string Tencv { get; set; }


    [Display(Name = "Mô tả công việc")]
    [StringLength(250)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    public string Motacn { get; set; }


}