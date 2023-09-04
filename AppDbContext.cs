using Microsoft.EntityFrameworkCore;

namespace FirstAngularNetProyect
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
		{
		}
		public DbSet<Turnos> Turnos { get; set; }

	}
}