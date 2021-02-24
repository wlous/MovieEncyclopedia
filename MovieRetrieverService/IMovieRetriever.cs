using MovieRetrieverService.Models;
using System.Threading.Tasks;

namespace MovieRetrieverService
{
	public interface IMovieRetriever
	{
		Task<Movie> RetrieveMovieAsync(string title, int year, string plotLength);
		Task<Movie> RetrieveMovieByTitleAsync(string title);
		Task<Movie> RetrieveMovieByTitleAndPlotLengthAsync(string title, string plotLength);
	}
}
