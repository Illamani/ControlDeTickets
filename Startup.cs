namespace FirstAngularNetProyect
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// Configura tu DbContext como un servicio
			services.AddDbContext<AppDbContext>();

			// Otros servicios y configuraciones pueden agregarse aquí
		}
	}
}
