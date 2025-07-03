# Bluesense Real-Time Chat Backend Task'ım(Mehmet Emin Tok)

## Özellikler

- JWT tabanlı kimlik doğrulama (access & refresh token)
- Gerçek zamanlı chat (SignalR)
- Polyglot Persistence: PostgreSQL (ilişkisel), Redis (cache)
- Grup yönetimi (public/private, davet/approval)
- Mesaj gönderme, düzenleme, silme (soft delete), dosya yükleme
- Mesajlarda sayfalama ve full-text arama
- Docker & docker-compose ile kolay kurulum
- CI/CD: GitHub Actions ile build, test, docker image
- Onion Architecture (Domain, Application, Infrastructure, API)

## Kurulum

### Geliştirici Ortamı

1. **Gerekli Araçlar:**
   .NET 8 SDK ve Docker yüklü olmalı
2. **Projeyi Klonla:**
   ```sh
   git clone <repo-url>
   cd Bluesense
   ```
3. **Docker ile Başlat:**
   ```sh
   docker-compose up --build
   ```
   - API: http://localhost:5000
   - Swagger: http://localhost:5000/swagger
   - SignalR Hub: ws://localhost:5000/chathub

## API Kullanımı

- Swagger arayüzü ile tüm endpointleri test edebilirsiniz.
- JWT ile korunan endpointler için önce `/api/auth/login` ile token alın.
- SignalR ile gerçek zamanlı chat için `/chathub` endpointini kullanın.

## CI/CD

- `.github/workflows/ci-cd.yml` ile otomatik build, test ve docker image pipeline'ı hazır.
- Testler: xUnit ile unit ve integration testler.

## Yayınlama (Deployment)  Adımları

- Projeyi bir sunucuya veya kendi bilgisayarınıza kopyalayın.
- Ortam değişkenlerini (veritabanı, redis, jwt secret) ayarlayın.
- `docker-compose up --build` komutunu çalıştırın, hepsi otomatik başlar.
- Veritabanı şeması için EF Core migration komutlarını kullanabilirsiniz.

## Varsayımlar ve Tercih Gerekçeleri 

- Katmanlı mimari (Onion) ile kodun bakımı ve testleri kolay olsun istedik.
- Mesajlar ve kullanıcılar için PostgreSQL, hızlı erişim için Redis kullandım.
- Güvenli oturum için JWT ve refresh token tercih edildi.
- Gerçek zamanlı chat için SignalR seçildi.
- Dosya yükleme örneği basit tutuldu, gerçek ortamda bulut servis önerilir.
- Test ve CI/CD altyapısı hazır, detaylar geliştirilebilir.

## Mimari

- **Onion Architecture:**
  - `Domain`: Entity ve saf modeller
  - `Application`: Servisler, DTO'lar, iş kuralları
  - `Infrastructure`: DbContext, Repository, Cache
  - `API`: Controller, SignalR, DI, Swagger
- **Polyglot Persistence:**
  - Kullanıcı, grup, mesaj meta verisi: PostgreSQL
  - Hızlı mesaj erişimi/cache: Redis

## İletişim

-Mehmet Emin Tok mhmtmntok@gmail.com 05342119155
