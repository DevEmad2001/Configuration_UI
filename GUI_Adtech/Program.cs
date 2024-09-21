using GUI_Adtech.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


///
var appBuilder = WebApplication.CreateBuilder(args);

// إعداد الاتصال بقاعدة البيانات
appBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(appBuilder.Configuration.GetConnectionString("DefaultConnection")));

// باقي الكود...


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
