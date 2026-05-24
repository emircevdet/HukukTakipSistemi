using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HukukTakipWeb.Models
{
    [Table("musteri")]
    public class Musteri
    {
        [Key]
        [Column("musteri_id")]
        public int MusteriId { get; set; }

        [Column("musteri_no")]
        public string? MusteriNo { get; set; }

        [Required]
        [Column("ad_unvan")]
        public string AdUnvan { get; set; }

        [Column("borclu_soyadi")]
        public string? BorcluSoyadi { get; set; }

        [Required]
        [StringLength(11)]
        [Column("tckn")]
        public string Tckn { get; set; }

        [Column("dogum_tarihi")]
        public DateTime? DogumTarihi { get; set; }

        [Column("dogum_yeri")]
        public string? DogumYeri { get; set; }

        [Column("cinsiyet")]
        public string? Cinsiyet { get; set; }

        [Column("medeni_durum")]
        public string? MedeniDurum { get; set; }

        [Column("baba_adi")]
        public string? BabaAdi { get; set; }

        [Column("anne_adi")]
        public string? AnneAdi { get; set; }

        [Column("sehir")]
        public string? Sehir { get; set; }

        [Column("ilce")]
        public string? Ilce { get; set; }

        [Column("adres")]
        public string? Adres { get; set; }

        [Column("vergi_dairesi")]
        public string? VergiDairesi { get; set; }

        [Column("vergi_no")]
        public string? VergiNo { get; set; }

        [Column("borclu_turu")]
        public string? BorcluTuru { get; set; }

        [Column("borclu_tipi")]
        public string? BorcluTipi { get; set; }

        [Column("hayatta_mi")]
        public bool HayattaMi { get; set; } = true;
    }
}