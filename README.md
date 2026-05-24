Hukuk Takip Yönetim Sistemi

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir hukuk takip otomasyon sistemidir.
Proje staj sürecinde backend geliştirme, MVC mimarisi ve veritabanı yönetimini uygulamalı şekilde öğrenmek amacıyla geliştirilmiştir.

Kullanılan Teknolojiler
ASP.NET Core MVC
MSSQL
Entity Framework Core
LINQ
Bootstrap
JavaScript
Fetch API
Proje Modülleri
Müşteri Yönetimi
Müşteri ekleme
Güncelleme
Silme
Arama işlemleri
TCKN doğrulama kontrolleri
Avukat Yönetimi
Avukat kayıt işlemleri
IBAN doğrulama işlemleri
Güncelleme ve listeleme
Ürün Yönetimi
Müşteri ve avukat ilişkili ürün yönetimi
İhtar Yönetimi
Müşteriye ait ihtar kayıtlarının tutulması
Ürün ilişkili ihtar yönetimi
İcra Takip Yönetimi
Dinamik müşteri seçimi
Otomatik ürün listeleme
Avukat bilgisinin otomatik getirilmesi
İhtar filtreleme işlemleri
Veritabanı Yapısı

Projede ilişkisel veritabanı yapısı kullanılmıştır.

Temel Tablolar
musteri
avukat
urun
ihtar
icra_takip
Tablolar Arasındaki İlişkiler
Bir müşterinin birden fazla ürünü olabilir
Ürünler avukatlarla ilişkilidir
İhtar kayıtları müşteri ve ürünle bağlantılıdır
İcra takip modülü tüm tabloları birlikte kullanır
Kullanılan Yapılar
CRUD İşlemleri
Create
Read
Update
Delete
LINQ Kullanımı
Where
Include
Select
AnyAsync
FirstOrDefaultAsync
Validation İşlemleri
TCKN kontrolü
IBAN kontrolü
zorunlu alan kontrolü
tekrar eden kayıt kontrolü
Session Kullanımı
kullanıcı giriş kontrolü
login/logout işlemleri
oturum yönetimi
