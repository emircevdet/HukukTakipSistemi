using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HukukTakipWeb.Models
{
    [Table("icra_takip")]
    public class IcraTakip
    {
        [Key]
        [Column("icra_takip_id")]
        public int IcraTakipId { get; set; }

        [Column("musteri_id")]
        public int? MusteriId { get; set; }

        [Column("urun_id")]
        public int UrunId { get; set; }

        [Column("avukat_id")]
        public int AvukatId { get; set; }

        [Column("ihtar_id")]
        public int? IhtarId { get; set; }

        [Column("avukat_tevzi_no")]
        public string? AvukatTevziNo { get; set; }

        [Column("takip_tarihi")]
        public DateTime? TakipTarihi { get; set; }

        [Column("takip_tipi")]
        public string? TakipTipi { get; set; }

        [Column("icra_mudurlugu")]
        public string? IcraMudurlugu { get; set; }

        [Column("icra_dosya_yili")]
        public string? IcraDosyaYili { get; set; }

        [Column("icra_dosya_no")]
        public string? IcraDosyaNo { get; set; }

        [Column("mahiyet_kodu")]
        public string? MahiyetKodu { get; set; }

        [ForeignKey("MusteriId")]
        public Musteri? Musteri { get; set; }

        [ForeignKey("UrunId")]
        public Urun? Urun { get; set; }

        [ForeignKey("AvukatId")]
        public Avukat? Avukat { get; set; }

        [ForeignKey("IhtarId")]
        public Ihtar? Ihtar { get; set; }
    }
}