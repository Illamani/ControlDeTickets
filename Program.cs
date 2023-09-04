using FirstAngularNetProyect;
using Microsoft.EntityFrameworkCore;
internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllersWithViews();

		IConfigurationRoot configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();

		string connectionString = configuration.GetConnectionString("DefaultConnection");

		builder.Services.AddDbContext<AppDbContext>(options =>
						options.UseSqlServer(connectionString), ServiceLifetime.Scoped)
					.BuildServiceProvider();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}


	app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRouting();

		var serviceProvider = new ServiceCollection()
					.AddDbContext<AppDbContext>(options =>
						options.UseSqlServer(connectionString))
					.BuildServiceProvider();

		using (var scope = serviceProvider.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			dbContext.Database.EnsureCreated();

			Console.WriteLine("Base de datos creada o verificada.");
		}

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller}/{action=Index}/{id?}");

		app.MapFallbackToFile("index.html");

		app.Run();
	}
}