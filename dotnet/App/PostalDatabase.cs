public record PostalResult
{
	public PostalResult(string city, string state, string postalCode)
	{
		City = city;
		State = state;
		PostalCode = postalCode;
	}

	public string City { get; init; }
	public string State { get; init; }
	public string PostalCode { get; init; }
}

public interface IPostalDatabase
{
	Task<PostalResult?> GetAsync(string postalCode);
}

public class PostalDatabase : IPostalDatabase
{
	public async Task<PostalResult?> GetAsync(string postalCode)
	{
		await Task.Delay(500);

		return postalCode switch
		{
			"72901" => new PostalResult("Fort Smith", "AR", "72901"),
			"72921" => new PostalResult("Alma", "AR", "72921"),
			"85281" => new PostalResult("Tempe", "AZ", "85281"),
			_ => null
		};
	}
}
