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

	if (!await db.CanConnectAsync()) // Eðer ilgili database'yi bulamýyorsan 
	{
		await db.EnsureCreatedAsync();

		// TODO: eðer veritabaný sýfýrdan oluþturulunca
		// içerisindeki bazý tablolarda kayýt olmasý gerekiyorsa
		// burada seed yapýlmalý



		User admin = new()
		{
			Email = "admin@noeva.com",
			City = "Çorum",
			Id = 1,
			Password = "123456",
			Phone = "5469389421"
		};

		User doctor = new()
		{
			Email = "doctor@noeva.com",
			City = "Çanakkale",
			Id = 2,
			Password = "123456",
			Phone = "54693190421"
		};

		Department kardiyoloji = new()
		{
			Id = 1,
			Description = "Cardio and other things",
			Name = "Cardiology"

		};


		Post post = new()
		{
			Content = "Our Hospital is the best",
			Id = 1,
			Title = "Best Hospital",
			UserId = 2
		};

		DepartmentPost departmentPost = new()
		{
			Id = 1,
			DepartmentId = 1,
			PostId = 1
		};
	}
}

app.Run();
