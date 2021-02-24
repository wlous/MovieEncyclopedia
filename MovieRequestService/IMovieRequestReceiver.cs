using System.Threading.Tasks;
using MovieRetrieverService.Models;

namespace MovieRequestReceiverService
{
	public interface IMovieRequestReceiver
	{
		Task<Movie> HandleMovieRequest(string title, int year, string plotLength);
	}
}
