using App.Data;
using App.Data.Entity;
using App.Service.Abstract;
using App.Service.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Eðer sonsuz döngü hatasý alýrsan AddJsonOptions(IgnoreCycles) kullan
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connStr = builder.Configuration.GetConnectionString("DBConStr"); // Builder konfigürasyonu içerisinde "DBConStr" appsettings.json deðerini oku.

    options.UseSqlServer(connStr);
});

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ISettingService, SettingService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>(); // Uygulama ayaða kalktýðýnda, belirtilen Database'i getir.

    var db = dbContext.Database;

    if (!await db.CanConnectAsync()) // Eğer ilgili database'yi bulamıyorsan 
    {


        await db.EnsureCreatedAsync();

        // TODO: eðer veritabaný sýfýrdan oluþturulunca
        // içerisindeki bazý tablolarda kayýt olmasý gerekiyorsa
        // burada seed yapýlmalý
        DbSeeder.Seed(dbContext);

    }
}

app.Run();
