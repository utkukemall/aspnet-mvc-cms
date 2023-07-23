using App.Data;
using App.Data.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient();

//builder.Services.AddSession();

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    string? connStr = builder.Configuration.GetConnectionString("DBConStr"); // Builder konfigürasyonu içerisinde "DBConStr" appsettings.json deðerini oku.

//    options.UseSqlServer(connStr);
//});

//builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(k =>
{
    k.LoginPath = "/Auth/";
    k.LogoutPath = "/Auth/";
    k.AccessDeniedPath = "/Auth/";
    k.Cookie.Name = "AuthenticationCookie";
    k.Cookie.MaxAge = TimeSpan.FromDays(1);
});

builder.Services.AddAuthorization(p =>
{
    p.AddPolicy("AdminPolicy", c => c.RequireClaim("Role", "Admin"));
    p.AddPolicy("DoctorPolicy", c => c.RequireClaim("Role", "Doctor"));
    p.AddPolicy("UserPolicy", c => c.RequireClaim("Role", "User"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// JWT - Token ve Cookie araþtýr.

//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>(); // Uygulama ayaða kalktýðýnda, belirtilen Database'i getir.

//    var db = dbContext.Database; 

//    if(!await db.CanConnectAsync()) // Eðer ilgili database'yi bulamýyorsan 
//    {
//        await db.EnsureCreatedAsync();

//        // TODO: eðer veritabaný sýfýrdan oluþturulunca
//        // içerisindeki bazý tablolarda kayýt olmasý gerekiyorsa
//        // burada seed yapýlmalý



//        User admin = new()
//        {
//            Email = "admin@noeva.com",
//            City = "Çorum",
//            Id = 1,
//            Password ="123456",
//            Phone = "5469389421"
//        };

//        User doctor = new()
//        {
//            Email = "doctor@noeva.com",
//            City = "Çanakkale",
//            Id = 2,
//            Password = "123456",
//            Phone = "54693190421"
//        };

//        Department kardiyoloji = new()
//        {
//            Id=1,
//            Description = "Cardio and other things",
//            Name = "Cardiology"

//        };


//        Post post = new()
//        {
//            Content = "Our Hospital is the best",
//            Id = 1,
//            Title = "Best Hospital",
//            UserId = 2
//        };

//        DepartmentPost departmentPost = new()
//        {
//            Id = 1,
//            DepartmentId = 1,
//            PostId = 1
//        };
//    }
//}

// Category ve Services(Hospital Services) kýsmýný güncelle.

app.Run();
