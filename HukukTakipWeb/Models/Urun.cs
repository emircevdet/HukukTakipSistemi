using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HukukTakipWeb.Models
{
    [Table("urun")]
    public class Urun
    {
        [Key]
        [Column("urun_id")]
        public int UrunId { get; set; }

        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("avukat_id")]
        public int? AvukatId { get; set; }

        [Column("urun_adi")]
        public string? UrunAdi { get; set; }

        [Column("kredi_birim_kodu")]
        public string? KrediBirimKodu { get; set; }

        [Column("kredi_mudi_no")]
        public string? KrediMudiNo { get; set; }

        [Column("takip_miktari")]
        public decimal? TakipMiktari { get; set; }

        [Column("doviz_tipi")]
        public string? DovizTipi { get; set; }

        [Column("aylik_faiz_orani")]
        public decimal? AylikFaizOrani { get; set; }

        [Column("takip_tarihi")]
        public DateTime? TakipTarihi { get; set; }

        [Column("masraf_mudi_no")]
        public string? MasrafMudiNo { get; set; }

        [Column("masraf_bakiyesi")]
        public decimal? MasrafBakiyesi { get; set; }

        [Column("faiz_mudi_no")]
        public string? FaizMudiNo { get; set; }

        [Column("faiz_bakiyesi")]
        public decimal? FaizBakiyesi { get; set; }

        [Column("takip_birim_kodu")]
        public string? TakipBirimKodu { get; set; }

        [Column("takip_mudi_no")]
        public string? TakipMudiNo { get; set; }

        [Column("aciklama")]
        public string? Aciklama { get; set; }

        // RELATIONS

        [ForeignKey("MusteriId")]
        public Musteri? Musteri { get; set; }

        [ForeignKey("AvukatId")]
        public Avukat? Avukat { get; set; }
    }
}