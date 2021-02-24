using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieRetrieverService.Models;


namespace MovieRetrieverService
{
	public class MovieRetriever : IMovieRetriever
	{
		private const string BaseUrl = "http://omdbapi.com";
		private HttpClient _client;

		public MovieRetriever(HttpClient client)
		{
			_client = client;
		}

		public async Task<Movie> RetrieveMovieAsync(string title, int year, string plotLength)
		{
			var query = new MovieQueryBuilder()
				            .Start()
				            .Title(title)
				            .Separator()
				            .Year(year)
				            .Separator()
				            .PlotLength(plotLength)
				            .Separator()
				            .Build()
			            + "apikey=c29b4674";//todo: lägg apikey i appsettings
			
			
			var response = await GetMovieAsync(query).ConfigureAwait(false);
			return await DeserializeAsync(response).ConfigureAwait(false);
		}

		public async Task<Movie> RetrieveMovieByTitleAsync(string title)
		{
			var query = new MovieQueryBuilder()
				            .Start()
				            .Title(title)
				            .Separator()
				            .Build()
			            + "apikey=c29b4674";

			var response = await GetMovieAsync(query).ConfigureAwait(false);
			return await DeserializeAsync(response).ConfigureAwait(false);
		}

		public async Task<Movie> RetrieveMovieByTitleAndPlotLengthAsync(string title, string plotLength)
		{
			var query = new MovieQueryBuilder()
				.Start()
				.Title(title)
				.Separator()
				.PlotLength(plotLength)
				.Separator()
				.Build()
				+ "apikey=c29b4674";

			var response = await GetMovieAsync(query).ConfigureAwait(false);
			return await DeserializeAsync(response).ConfigureAwait(false);
		}

		private async Task<Movie> DeserializeAsync(HttpResponseMessage response)
		{
			var stream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<Movie>(stream);
		}

		private async Task<HttpResponseMessage> GetMovieAsync(string query)
		{
			return await _client.GetAsync(BaseUrl + query);
		}
	}
}
