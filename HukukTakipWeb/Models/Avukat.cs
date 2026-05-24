using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HukukTakipWeb.Models
{
    [Table("avukat")]
    public class Avukat
    {
        [Key]
        [Column("avukat_id")]
        public int AvukatId { get; set; }

        [Column("adi")]
        public string? Adi { get; set; }

        [Column("soyadi")]
        public string? Soyadi { get; set; }

        [Column("kullanici_adi")]
        public string? KullaniciAdi { get; set; }

        [Column("musteri_no")]
        public string? MusteriNo { get; set; }

        [Column("tckn")]
        public string? Tckn { get; set; }

        [Column("vergi_dairesi")]
        public string? VergiDairesi { get; set; }

        [Column("vergi_no")]
        public string? VergiNo { get; set; }

        [Column("cep_telefonu")]
        public string? CepTelefonu { get; set; }

        [Column("is_telefon_no")]
        public string? IsTelefonNo { get; set; }

        [Column("is_fax_no")]
        public string? IsFaxNo { get; set; }

        [Column("e_mail_adresi")]
        public string? EMailAdresi { get; set; }

        [Column("sehir")]
        public string? Sehir { get; set; }

        [Column("ilce")]
        public string? Ilce { get; set; }

        [Column("tam_adres")]
        public string? TamAdres { get; set; }

        [Column("avans_hesap_subesi")]
        public string? AvansHesapSubesi { get; set; }

        [Column("avans_hesap_no")]
        public string? AvansHesapNo { get; set; }

        [Column("vadesiz_hesap_subesi")]
        public string? VadesizHesapSubesi { get; set; }

        [Column("vadesiz_hesap_no")]
        public string? VadesizHesapNo { get; set; }

        [Column("halkbank_vadesiz_iban_no")]
        public string? HalkbankVadesizIbanNo { get; set; }

        [Column("diger_banka_iban_no")]
        public string? DigerBankaIbanNo { get; set; }

        [Column("dosya_dagitim")]
        public bool? DosyaDagitim { get; set; }

        [Column("avans_asim_limiti")]
        public decimal? AvansAsimLimiti { get; set; }

        [Column("avukat_tipi")]
        public string? AvukatTipi { get; set; }

        [Column("iletisim_verilsin_mi")]
        public bool? IletisimVerilsinMi { get; set; }

        [Column("dialogdan")]
        public bool? Dialogdan { get; set; }

        [Column("dialog_yasal")]
        public bool? DialogYasal { get; set; }

        [Column("normal")]
        public bool? Normal { get; set; }

        [Column("hesap_aktif_mi")]
        public bool HesapAktifMi { get; set; }
    }
}