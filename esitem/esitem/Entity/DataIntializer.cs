using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace esitem.Entity
{
    public class DataIntializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            { 
                new Category() {Name="PASTALAR",Description="YAŞPASTA ÜRÜNLERİ"},
                new Category() {Name="TATLILAR",Description="TATLI ÜRÜNLERİ"},
                new Category() {Name="DONDURMA",Description="DONDURMA ÇEŞİTLERİ" },
            
            };
            foreach (var Kategori in kategoriler)
            {
                context.Categories.Add(Kategori);
            }
            context.SaveChanges();
            var urunler = new List<Ürün>()
            {
                new Ürün(){Name="Baton Pasta",Description="Baton Pastaları",Price=80,Stock=125,IsHome=true,IsApproved=true,IsFeatured=false,Slider=true,CategoryId=1,İmage="1.jpg"},
                new Ürün(){Name="Cevizli Baklava",Description="Tatlı Ürünleri",Price=70,Stock=100,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=2,İmage="2.jpeg" },
                new Ürün(){Name="Antep Fıstık Baklava",Description="Tatlı Ürünleri",Price=110,Stock=10,IsHome=false,IsApproved=true,IsFeatured=true,Slider=false,CategoryId=2,İmage="1.jpeg"},
                new Ürün(){Name="MaraşDondurması",Description="Dondurma Çeşitleri",Price=40,Stock=25,IsHome=false,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=3,İmage="1.jpg"},


            };
            foreach (var urun in urunler)
            {
                context.Ürüns.Add(urun);
               
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}