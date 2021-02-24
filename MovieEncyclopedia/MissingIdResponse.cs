using System.Text.Json.Serialization;

namespace MovieEncyclopedia
{
	public class MissingIdResponse
	{
		[JsonPropertyName("Response")]
		public string Response { get; set; }

		[JsonPropertyName("Error")]
		public string Error { get; set; }

	}
}
