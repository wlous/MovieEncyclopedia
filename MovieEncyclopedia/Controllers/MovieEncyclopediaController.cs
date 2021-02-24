using Microsoft.AspNetCore.Mvc;
using MovieRetrieverService.Models;
using System.Text.Json;
using System.Threading.Tasks;
using MovieRequestReceiverService;

namespace MovieEncyclopedia.Controllers
{
	[ApiController]
	[Produces("application/json", "application/xml")]
	[Route("[controller]")]
	public class MovieEncyclopediaController : ControllerBase
	{
		private IMovieRequestReceiver _requestReceiver;
	
		public MovieEncyclopediaController(IMovieRequestReceiver requestReceiver)
		{
			_requestReceiver = requestReceiver;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string title, int year, string plot)//todo: se till att man måste skicka en parameter
		{
			Movie movie;//todo: snygga till

			try
			{
				movie = await _requestReceiver.HandleMovieRequest(title, year, plot).ConfigureAwait(false);
			}
			catch (MovieTitleMissingException)//todo: implementera annat fel när filmen inte finns
			{
				var missingIdResponse = JsonSerializer.Serialize(
					new MissingIdResponse
					{
						Response = "false", 
						Error = "Incorrect IMDb ID."
					});//todo: detta ska inte vara här och ska göras snyggare! 

				return Ok(missingIdResponse);
			}
			return Ok(movie);
		}
	}
}
