using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync() || await dbContext.Brands.AnyAsync() || await dbContext.Products.AnyAsync()) return;
            Category cat1 = new Category() { CategoryName = "Gents" };
            Category cat2 = new Category() { CategoryName = "Ladies" };
            Category cat3 = new Category() { CategoryName = "Unisex" };
            dbContext.AddRange(cat1, cat2, cat3);
            var brand1 = new Brand() { BrandName = "Dior" };
            var brand2 = new Brand() { BrandName = "Omega" };
            var brand3 = new Brand() { BrandName = "Rolex" };
            var brand4 = new Brand() { BrandName = "Tudor" };
            dbContext.AddRange(brand1, brand2, brand3, brand4);
            var p1 = new Product() { ProductName = "Seamaster Planet Ocean Automatic Men's Watch", Description = "Stainless steel case with a orange rubber strap with a (stiched) black nylon top.", Price = 4895.00m, PictureUri = "1.jpg", Category = cat1, Brand = brand1 };
            var p2 = new Product() { ProductName = "De Ville Automatic Diamond Silver Dial Ladies", Description = "Stainless steel case with a brown (alligator) leather strap. Fixed 18kt rose gold bezel.", Price = 4095.00m, PictureUri = "2.jpg", Category = cat2, Brand = brand1 };
            var p3 = new Product() { ProductName = "Omegamania Quartz Diamond White Dial Unisex", Description = "18kt rose gold case with a white leather strap. Fixed gold-tone diamond set bezel.", Price = 5959.00m, PictureUri = "3.jpg", Category = cat3, Brand = brand1 };
            var p4 = new Product() { ProductName = "Black Bay Fifty-Eight Automatic Black Dial Women's", Description = "Stainless steel case with a stainless steel bracelet. Uni-directional rotating coin edge stainless steel bezel with a black aluminium (count-up elapsed time) ring.", Price = 3750.00m, PictureUri = "4.jpg", Category = cat1, Brand = brand2 };
            var p5 = new Product() { ProductName = "Black Bay Ceramic Automatic Black Dial Men's Watch", Description = "Black ceramic case with a black hybrid leather and rubber strap. Uni-directional rotating black ceramic bezel", Price = 5150.00m, PictureUri = "5.jpg", Category = cat2, Brand = brand2 };
            var p6 = new Product() { ProductName = "Black Bay 41 Automatic Silver Dial Unisex Watch", Description = "Stainless steel case with a stainless steel bracelet. Fixed stainless steel bezel.", Price = 2550.00m, PictureUri = "6.jpg", Category = cat3, Brand = brand2 };
            var p7 = new Product() { ProductName = "Grand Bal Plume Automatic Men's Watch", Description = "Stainless steel case with a black (alligator) leather strap. Fixed stainless steel bezel with an inlaid yellow gold ring set with diamonds.", Price = 8399.00m, PictureUri = "7.jpg", Category = cat1, Brand = brand3 };
            var p8 = new Product() { ProductName = "Grand Bal Miss Rouge Automatic Ladies Watch", Description = "Stainless steel case with a black satin strap. Fixed stainless steel bezel accentuated with diamonds.", Price = 8049.00m, PictureUri = "8.jpg", Category = cat2, Brand = brand3 };
            var p9 = new Product() { ProductName = "La Mini D de Dior Quartz Black Dial Unisex Watch", Description = "Stainless steel case with a black leather strap. Fixed stainless steel bezel set with diamonds.", Price = 2149.00m, PictureUri = "9.jpg", Category = cat3, Brand = brand3 };
            var p10 = new Product() { ProductName = "Lady-Datejust Mint Green Dial 18 Carat Yellow Gold President Watch", Description = "18kt yellow gold case with a 18kt yellow gold President bracelet. Fixed 18kt yellow gold bezel set with diamonds.", Price = 29195.00m, PictureUri = "10.jpg", Category = cat1, Brand = brand4 };
            var p11 = new Product() { ProductName = "Datejust 31 Rose Diamond Dial Automatic Ladies Steel and Everose Gold Oyster Men's Watch", Description = "Stainless steel case with a stainless steel oyster bracelet with everose gold center links. Fixed everose gold bezel set with diamonds.", Price = 16785.00m, PictureUri = "11.jpg", Category = cat2, Brand = brand4 };
            var p12 = new Product() { ProductName = "Lady-Datejust 28 Automatic Chronometer Diamond Green Dial Unisex Watch", Description = "18kt yellow gold case with a 18kt yellow gold Rolex president bracelet. Fixed fluted 18kt yellow gold bezel.", Price = 23995.00m, PictureUri = "12.jpg", Category = cat3, Brand = brand4 };
            dbContext.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

            await dbContext.SaveChangesAsync();
        }
    }
}
