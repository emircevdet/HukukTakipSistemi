using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HukukTakipWeb.Models
{
    [Table("ihtar")]
    public class Ihtar
    {
        [Key]
        [Column("ihtar_id")]
        public int IhtarId { get; set; }

        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("urun_id")]
        public int? UrunId { get; set; }

        [Column("noter_adi")]
        public string? NoterAdi { get; set; }

        [Column("yevmiye_no")]
        public string? YevmiyeNo { get; set; }

        [Column("ihtar_tarihi")]
        public DateTime? IhtarTarihi { get; set; }

        [Column("ihtarname_suresi")]
        public int? IhtarnameSuresi { get; set; }

        [Column("teblig_tarihi")]
        public DateTime? TebligTarihi { get; set; }

        [Column("ihtar_teblig_giris_tarihi")]
        public DateTime? IhtarTebligGirisTarihi { get; set; }

        [Column("kat_tarihi")]
        public DateTime? KatTarihi { get; set; }

        [Column("ihtarname_nakit_tutari")]
        public decimal? IhtarnameNakitTutari { get; set; }

        [Column("ihtarname_gayri_nakit_tutari")]
        public decimal? IhtarnameGayriNakitTutari { get; set; }

        [Column("ihtar_no")]
        public string? IhtarNo { get; set; }

        [ForeignKey("MusteriId")]
        public Musteri? Musteri { get; set; }

        [ForeignKey("UrunId")]
        public Urun? Urun { get; set; }
    }
}