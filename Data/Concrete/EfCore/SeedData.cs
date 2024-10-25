using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete.EfCore{

    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){
            
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<KiraSitesiContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                if(!context.Kategoriler.Any()){
                    context.Kategoriler.AddRange(
                        new Kategori(){KategoriAdı = "SUV"},
                        new Kategori(){KategoriAdı = "Sedan"},
                        new Kategori(){KategoriAdı = "Hatchback"},
                        new Kategori(){KategoriAdı = "Cabrio"},
                        new Kategori(){KategoriAdı = "Coupe"}
                    );
                    context.SaveChanges();
                }
                if(!context.Kullanıcılar.Any()){
                    context.Kullanıcılar.AddRange(
                        new Kullanıcı(){KullanıcıAdı = "umutakman", Ad = "Umut", Soyad = "Akman"},
                        new Kullanıcı(){KullanıcıAdı = "bugrayildirim", Ad = "Bugra", Soyad = "Yildirim"}
                    );
                    context.SaveChanges();
                }
                if(!context.Arabalar.Any()){
                    context.Arabalar.AddRange(
                        new Araba(){Başlık = "Mercedes-Benz G-Class", Marka = "Mercedes-Benz", Model = "G-Class", Görsel = "g-class.jpg", KoltukSayısı = 5, KiraÜcreti = 1500, Kiralanabilir = true, },
                        new Araba(){Başlık = "BMW 5 Series", Marka = "BMW", Model = "5 Series", Görsel = "5-series.jpg", KoltukSayısı = 5, KiraÜcreti = 1000, Kiralanabilir = true, },
                        new Araba(){Başlık = "Volkswagen Golf", Marka = "Volkswagen", Model = "Golf", Görsel = "golf.jpg", KoltukSayısı = 5, KiraÜcreti = 500, Kiralanabilir = true, }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}