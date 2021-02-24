namespace MovieRetrieverService
{
	public class MovieRequest
	{
		public string Title { get; set; }
	
		public int Year { get; set; }
		
		public PlotLength PlotLength { get; set; }
	}
}
