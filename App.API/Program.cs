using App.API.Abstract;
using App.API.Concrete;
using App.Data;
using App.Service.Abstract;
using App.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ; // Eðer sonsuz döngü hatasý alýrsan AddJsonOptions(IgnoreCycles) kullan
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
builder.Services.AddScoped<IDepartmentsPostsService, DepartmentsPostsService>();
builder.Services.AddScoped<IDoctorsService, DoctorsService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPostCommentService, PostCommentService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IFileService, FileService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


// app.UseStaticFiles(...) : Bu, ASP.NET Core uygulamanızın statik dosyaları (örneğin: .jpg, .png, .css, .js) sunabilmesi için gerekli bir middleware'yi ekler. Middleware, gelen HTTP isteklerini işlemek için kullanılan bir tür yazılım katmanıdır.

app.UseStaticFiles(new StaticFileOptions
{
    // new StaticFileOptions:  Bu, statik dosya hizmetinin nasıl çalıştırılacağını belirlemek için seçenekler sağlar. Yani bu sayede, hangi dosyaların hangi yollardan sunulacağını özelleştirebiliriz.

    // FileProvider = new PhysicalFileProvider(...):  Bu, fiziksel dosya sisteminden dosyaları sağlayan bir sağlayıcı oluşturur. Bu, uygulamanızın belirtilen klasördeki dosyalara erişmesine olanak tanır.
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Uploads")),

    //Path.Combine(builder.Environment.ContentRootPath, "Uploads"):  Bu, ContentRootPath ile "Uploads" adlı klasörü birleştirerek tam bir dosya yolu oluşturur. ContentRootPath, projenizin kök klasörüne işaret eder. Yani bu kombinasyon, projenizin kökündeki Uploads klasörüne bir yol oluşturur.

    RequestPath = "/Resources"
});





app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var db = dbContext.Database;

    if (!await db.CanConnectAsync())
    {
        await db.EnsureCreatedAsync();
        DbSeeder.Seed(dbContext);
    }
}

app.Run();
