using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace btl_nhom32.Models;

public class MovieGenreViewModel
{
    public List<Nhacungcap>? Nhacungcap { get; set; }

    public SelectList? Tenncc { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
}