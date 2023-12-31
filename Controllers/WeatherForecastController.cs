﻿using Microsoft.AspNetCore.Mvc;

namespace FirstAngularNetProyect.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{

		private static readonly string[] Nombres = new[]
		{
		"Brisa", "Jennifer", "Andrea", "Camila", "Maira", "Wanda", "Barbara", "Guillermina", "Sofia", "Lucia"
		};

		private static readonly string[] Apellidos = new[]
		{
		"Zeballos", "Cavigioli", "Faez", "Vallejos", "Enriquez", "Chiazzaro", "Messi", "Giraldo", "Kiedis", "Gomez"
		};

		private static readonly string[] TiposPeinados = new[]
		{
		"Coleta Cruzada", "Semirecogido", "Semirecogido con lazo", "Falsa coleta de burbujas", "Doble coleta de burbujas",
		"Moño desenfadado", "Recogido bajo con trenza en espiga", "Falsa tenza", "Moño elegante", "Trenzas boho"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly AppDbContext _dbContext;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}

		[HttpGet]
		[Route("getTurnos")]
		public List<Turnos> GetTurnos()
		{
			return Enumerable.Range(1, 5).Select(index => new Turnos
			{
				Fecha = DateTime.Now.AddDays(index),
				Nombre = Nombres[Random.Shared.Next(Nombres.Length)],
				Apellido = Apellidos[Random.Shared.Next(Apellidos.Length)],
				TipoPeinado = TiposPeinados[Random.Shared.Next(TiposPeinados.Length)]
			}).ToList();
		}

		[HttpPost]
		[Route("InsertTurnos")]
		public async void InsertTurnos(Turnos turnos)
		{
			var turno = _dbContext.Turnos.Add(turnos);
			await _dbContext.SaveChangesAsync();
		}
	}
}