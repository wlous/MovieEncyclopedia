namespace MovieRetrieverService
{
	public class MovieQueryBuilder
	{
		private string _query;

		public MovieQueryBuilder Start()
		{
			_query += "?";
			return this;
		}

		public MovieQueryBuilder Separator()
		{
			_query += "&";
			return this;
		}

		public MovieQueryBuilder Title(string title)
		{
			_query += $"t={title}";
			return this;
		}

		public MovieQueryBuilder Year(int year)
		{
			if (year != 0)
			{
				_query += $"y={year}";
			}

			return this;
		}

		public MovieQueryBuilder PlotLength(string plotLength)
		{
			_query += $"plot={plotLength}";
			return this;
		}

		public string Build()
		{
			return _query;
		}
	}
}
