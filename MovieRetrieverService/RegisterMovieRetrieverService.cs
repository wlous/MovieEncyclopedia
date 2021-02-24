using Microsoft.Extensions.DependencyInjection;


namespace MovieRetrieverService
{
	public static class RegisterMovieRetrieverService
	{
		public static void UseServices(this IServiceCollection services)
		{
			services.AddHttpClient<IMovieRetriever, MovieRetriever>();
		}
	}
}
