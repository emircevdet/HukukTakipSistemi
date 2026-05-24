Hukuk Takip Yönetim Sistemi

ASP.NET Core MVC kullanılarak geliştirilmiş hukuk takip otomasyon sistemi.

Kullanılan Teknolojiler
ASP.NET Core MVC
MSSQL
Entity Framework Core
LINQ
Bootstrap
JavaScript
Fetch API

Modüller
Müşteri Yönetimi
Avukat Yönetimi
Ürün Yönetimi
İhtar Yönetimi
İcra Takip Yönetimi

Özellikler
CRUD işlemleri
Dinamik dropdown yapıları
Session tabanlı kullanıcı kontrolü
Validation işlemleri
İlişkili veritabanı yapısı
LINQ sorguları
Frontend - Backend veri iletişimi

Veritabanı Yapısı
Tablolar
musteri
avukat
urun
ihtar
icra_takip

İlişkiler
Bir müşterinin birden fazla ürünü olabilir
Ürünler avukatlarla ilişkilidir
İhtar kayıtları müşteri ve ürünle bağlantılıdır
İcra takip modülü tüm tabloları birlikte kullanır

Kullanılan LINQ Yapıları
Where
Include
Select
AnyAsync
FirstOrDefaultAsync

Validation İşlemleri
TCKN doğrulama
IBAN doğrulama
zorunlu alan kontrolü
tekrar eden kayıt kontrolü
