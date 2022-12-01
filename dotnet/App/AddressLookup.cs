public record Address
{
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
}

public interface IAddressLookup
{
	Task<Address?> GetCityAsync(string postalCode);
}

public class AddressLookup : IAddressLookup
{
	private readonly IPostalDatabase _db;

	public AddressLookup(IPostalDatabase db)
	{
		_db = db;
	}

	public async Task<Address?> GetCityAsync(string postalCode)
	{
		var result = await _db.GetAsync(postalCode);

		// if (result == null)
		// 	throw new Exception($"Could not find city for {postalCode}!");

		// SURELY we'll never get null...
		return new Address { City = result!.City, State = result.State };
		//return result != null ? new Address { City = result.City, State = result.State } : null;
	}
}
