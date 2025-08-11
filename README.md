# 🚗 Cental - Modern Araç Kiralama Platformu

<div align="center">
  <img src="https://img.shields.io/badge/.NET%20Core-8.0-purple?style=for-the-badge&logo=dotnet" />
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-blue?style=for-the-badge&logo=nuget" />
  <img src="https://img.shields.io/badge/Bootstrap-5.3-blueviolet?style=for-the-badge&logo=bootstrap" />
  <img src="https://img.shields.io/badge/SQL%20Server-2022-red?style=for-the-badge&logo=microsoft-sql-server" />
</div>

## 🎯 Hakkında

**Cental**, modern ve kullanıcı dostu bir araç kiralama platformudur. ASP.NET Core 8.0 ile geliştirilmiş olan bu proje, N-Katmanlı mimari ve SOLID prensiplerine uygun olarak tasarlanmıştır. Mapster ile nesne eşleme, FluentValidation ile veri doğrulama ve Identity ile güvenli kimlik yönetimi sağlanmaktadır.

## ✨ Özellikler

### 🏠 Ana Sayfa
- ✅ Hero banner ile rezervasyon formu
- ✅ Öne çıkan araçlar
- ✅ Hizmet süreci gösterimi
- ✅ Müşteri yorumları (Testimonials)
- ✅ İstatistik göstergeleri

### 🚙 Araç Yönetimi
- ✅ Araç listeleme ve detaylı görüntüleme
- ✅ Marka bazlı filtreleme
- ✅ Kategori yönetimi
- ✅ Yakıt tipi, vites tipi, koltuk sayısı gibi detaylar
- ✅ Araç görselleri yönetimi

### 📅 Rezervasyon Sistemi
- ✅ Online rezervasyon oluşturma
- ✅ Alış/Teslim lokasyonu seçimi
- ✅ Rezervasyon onay sistemi
- ✅ Rezervasyon iptali

### 👤 Kullanıcı Yönetimi
- ✅ Identity ile üyelik sistemi
- ✅ Rol bazlı yetkilendirme (Admin, User)
- ✅ Profil yönetimi
- ✅ Şifre sıfırlama

### 👨‍💼 Admin Paneli
- ✅ Dashboard ve istatistikler
- ✅ Araç CRUD işlemleri
- ✅ Rezervasyon yönetimi
- ✅ Kullanıcı yönetimi
- ✅ Blog yönetimi
- ✅ Banner yönetimi
- ✅ İletişim formu yönetimi
- ✅ Hizmet (Service) yönetimi
- ✅ Özellik (Feature) yönetimi

### 🔧 Sistem Özellikleri
- ✅ ViewComponent mimarisi
- ✅ DTO (Data Transfer Object) kullanımı
- ✅ Repository Pattern
- ✅ Dependency Injection
- ✅ Responsive tasarım
- ✅ FluentValidation ile form doğrulama

## 🛠 Teknolojiler

### Backend
- **ASP.NET Core 8.0** - Web Framework
- **Entity Framework Core 8.0** - ORM
- **SQL Server** - Veritabanı
- **Identity Core** - Kimlik doğrulama ve yetkilendirme
- **Mapster** - Nesne eşleme
- **FluentValidation** - Veri doğrulama

### Frontend
- **HTML5 & CSS3**
- **Bootstrap 5.3**
- **jQuery**
- **Font Awesome** - İkonlar
- **Owl Carousel** - Slider

### Mimari
- **N-Tier Architecture** - N-Katmanlı Mimari
- **Repository Pattern**
- **Dependency Injection**
- **ViewComponents**
- **Areas** - User ve Manager Paneli

## 🗄 Veritabanı Modelleri

### Temel Modeller

- **AppUser** - Identity kullanıcı modeli
- **AppRole** - Identity rol modeli
- **Car** - Araç bilgileri
- **Brand** - Marka bilgileri
- **Category** - Kategori bilgileri
- **Booking** - Rezervasyon bilgileri
- **Review** - Araç yorumları
- **Blog** - Blog yazıları
- **Contact** - İletişim formları
- **Service** - Hizmetler
- **Feature** - Özellikler
- **Testimonial** - Müşteri yorumları
- **Banner** - Ana sayfa banner'ları
- **About** - Hakkımızda bilgileri
- **Process** - Süreç adımları

📸 Ekran Görüntüleri
<details> <summary>🏠 Ana Sayfa</summary> <br> <div align="center">
<img width="100%" alt="Ana Sayfa" src="https://github.com/user-attachments/assets/a875a366-5b73-4a04-9584-dd4b66d400d9" />
</div> <br>
Özellikler:


✅ Hero section ile rezervasyon formu
✅ Öne çıkan araçlar
✅ Hizmet süreci
✅ Müşteri yorumları
✅ İstatistikler
</details><details> <summary>🚗 Araç Yönetimi</summary> <br>
📋 Araç Listesi
<div align="center"> <img src="https://github.com/user-attachments/assets/2353c9ce-9c6f-4655-aaf3-483db49431e3" alt="Araç Listesi" width="100%"> </div> <br>
➕ Yeni Araç Ekleme
<div align="center"> <img src="https://github.com/user-attachments/assets/667d4277-7f00-47f5-8432-1fec388a03fd" alt="Araç Ekleme Formu" width="100%"> </div> <br>
Özellikler:

✅ Filtreleme seçenekleri
✅ Grid/Liste görünümü
✅ Detaylı araç bilgileri
✅ CRUD işlemleri
</details><details> <summary>📊 Admin Dashboard</summary> <br> <div align="center"> 
  <img width="100%" alt="Admin Dashboard" src="https://github.com/user-attachments/assets/55f25700-7fbd-488c-a563-c9f5e2a92ee6" />
</div> <br>
Özellikler:

✅ İstatistik kartları
✅ Son rezervasyonlar
✅ Grafik gösterimleri
✅ Hızlı erişim menüleri
</details><details> <summary>👤 Kullanıcı Paneli - Rezervasyonlarım</summary> <br> <div align="center"> <img src="https://github.com/user-attachments/assets/c0d2aa20-271e-4ddd-bc53-0f5e284a4a57" alt="Kullanıcı Rezervasyonları" width="100%"> </div> <br>
Özellikler:

✅ Profil yönetimi
✅ Rezervasyon geçmişi
✅ Aktif rezervasyonlar
✅ Rezervasyon detayları
</details>
