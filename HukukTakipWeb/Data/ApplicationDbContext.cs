using HukukTakipWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HukukTakipWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Avukat> Avukatlar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Ihtar> Ihtarlar { get; set; }
        public DbSet<IcraTakip> IcraTakipler { get; set; }
    }
}