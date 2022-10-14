using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "kayak",
                        Description = "a bot for one person",
                        Category = "watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "protuctive and fastionable",
                        Category = "water sport",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "scoccer Ball",
                        Description = "fifa approved size and weight",
                        Category = "scorrer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "flags",
                        Description = "give your playing field a professional touch",
                        Category = "soccer",
                        Price = 19.5m
                    },
                    new Product
                    {
                        Name = "stadium",
                        Description = "35-000 seat stadium",
                        Category = "soccer",
                        Price = 75600
                    },
                    new Product
                    {
                        Name = "thinking cap",
                        Description = "improve brain efficiency by 75%",
                        Category = "chess",
                        Price = 16
                    },

                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },

                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
