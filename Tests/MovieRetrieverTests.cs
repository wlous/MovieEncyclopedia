using System.Net.Http;
using System.Threading.Tasks;
using MovieRetrieverService;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Tests
	{
		private MovieRetriever _movieRetriever;
		private HttpClient _client;

		[SetUp]
		public void Setup()
		{
			_client = new HttpClient();
			_movieRetriever = new MovieRetriever(_client);
		}

		[Test]
		[Explicit]
		public async Task Retrieving_Movie_From_OMDB_Json()
		{
			var movieJson = await _movieRetriever.RetrieveMovieAsync("Arrival", 0, "short");
		}
	}
}