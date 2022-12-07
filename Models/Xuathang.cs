using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace btl_nhom32.Models;
public class Xuathang
{
    [Key]
    [Display(Name = "ID xuất hàng")]

    public string Idxh { get; set; }




    [Display(Name = "Mã nhân viên")]
    public string Manv { get; set; }
    [ForeignKey("Manv")]
    [Display(Name = "Mã nhân viên")]
    public Nhanvien? Nhanvien { get; set; }



    [Display(Name = "Mã khách hàng")]
    public string Makh { get; set; }
    [ForeignKey("Makh")]
    [Display(Name = "Mã khách hàng")]
    public Khachhang? Khachhang { get; set; }
    [DataType(DataType.Date)]


    [Display(Name = "Ngày xuất hàng")]
    public DateTime ngayxh { get; set; }



    [Display(Name = "Tình trạng phiếu xuất")]
    public string trangtxh { get; set; }



}