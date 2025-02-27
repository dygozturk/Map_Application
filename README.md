# 📍 Map Application (C# .NET Web App)

Bu proje, harita tabanlı bir uygulamadır ve kullanıcıların belirli noktaları yönetmesine olanak tanır. **ASP.NET Core MVC** kullanılarak geliştirilmiştir ve **Repository Pattern & Unit of Work** mimarisi ile yapılandırılmıştır.

## 🚀 Teknolojiler

Bu projede aşağıdaki teknolojiler kullanılmıştır:

- **C# & .NET Core** → Backend iş mantığı ve API yönetimi için
- **Entity Framework Core** → ORM (Veritabanı yönetimi)
- **SQL Server** → Veritabanı çözümü
- **ASP.NET Core MVC** → Model-View-Controller yapısı
- **Repository Pattern & Unit of Work** → Veri yönetimi ve iş katmanı için
- **JSON & REST API** → API ile veri iletişimi

## 📌 Kurulum

Projeyi çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

# 1. Projeyi klonlayın:
git clone https://github.com/kullaniciadi/Map_Application.git

# 2. Dizin içine girin:
cd Map_Application

# 3. Gerekli bağımlılıkları yükleyin:
dotnet restore

# 4. Veritabanını yapılandırın:
# - `appsettings.json` dosyasında `ConnectionStrings` ayarlarını düzenleyin.
# - Veritabanını oluşturmak için şu komutu çalıştırın:
dotnet ef database update

# 5. Projeyi başlatın:
dotnet run

## 🗺 Kullanım
# API Endpointleri:
GET /api/points        # Tüm noktaları getirir
POST /api/points       # Yeni bir nokta ekler
PUT /api/points/{id}   # Bir noktayı günceller
DELETE /api/points/{id} # Belirli bir noktayı siler

## Harita Entegrasyonu
- Harita bileşeni, frontend tarafında Leaflet.js veya Google Maps API ile entegre edilebilir.

🎯 Daha fazla bilgi için geliştirici ile iletişime geçebilirsiniz.
