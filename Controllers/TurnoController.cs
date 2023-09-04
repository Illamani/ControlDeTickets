using Microsoft.AspNetCore.Mvc;

namespace FirstAngularNetProyect.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TurnoController : ControllerBase
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

		private readonly ILogger<TurnoController> _logger;

		public TurnoController(ILogger<TurnoController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
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
		public string InsertTurnos(Turnos turnos)
		{
			var prueba = "hola";
			return prueba;
		}
	}
}
