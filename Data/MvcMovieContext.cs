using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using btl_nhom32.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<btl_nhom32.Models.Nhacungcap> Nhacungcap { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Chucvucv> Chucvucv { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Nhanvien> Nhanvien { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Thuonghieu> Thuonghieu { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Hanghoa> Hanghoa { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Kho> Kho { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Nhaphang> Nhaphang { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Kiemkho> Kiemkho { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Khachhang> Khachhang { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Xuathang> Xuathang { get; set; } = default!;

        public DbSet<btl_nhom32.Models.Login> Login { get; set; } = default!;

    
    }
}
