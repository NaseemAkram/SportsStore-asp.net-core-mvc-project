using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute("catpage",
 "{category}/Page{productPage:int}",
 new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}",
 new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}",
 new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination",
 "Products/Page{productPage}",
 new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
