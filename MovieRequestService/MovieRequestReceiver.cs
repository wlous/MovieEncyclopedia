using System.Threading.Tasks;
using MovieRetrieverService;
using MovieRetrieverService.Models;

namespace MovieRequestReceiverService
{
	public class MovieRequestReceiver : IMovieRequestReceiver
	{
		private IMovieRetriever _movieRetriever;

		public MovieRequestReceiver(IMovieRetriever movieRetriever)
		{
			_movieRetriever = movieRetriever;
		}

		public async Task<Movie> HandleMovieRequest(string title, int year, string plotLength)
		{
			if (string.IsNullOrEmpty(title))
				throw new MovieTitleMissingException();

			if (year != 0)
				return await _movieRetriever.RetrieveMovieAsync(title, year, plotLength);
			
			if (string.IsNullOrEmpty(plotLength))
			{
				return await _movieRetriever.RetrieveMovieByTitleAsync(title);
			}
			
			return await _movieRetriever.RetrieveMovieByTitleAndPlotLengthAsync(title, plotLength);
		}
	}
}
