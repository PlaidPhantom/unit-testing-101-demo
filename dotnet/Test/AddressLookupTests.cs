namespace Test;

[TestClass]
public class AddressLookupTests
{
	[TestMethod]
	public async Task AddressLookup_CallsDbAndReturnsResult()
	{
		// Arrange

		var postalDb = new Mock<IPostalDatabase>();

		postalDb.Setup(d => d.GetAsync(It.IsAny<string>()))
			.ReturnsAsync(new PostalResult("Some City", "ST", "12345"));

		var addressLookup = new AddressLookup(postalDb.Object);

		// Act

		var result = await addressLookup.GetCityAsync("67890");

		// Assert

		postalDb.Verify(d => d.GetAsync("67890"));

		result.Should().BeEquivalentTo(new Address { City = "Some City", State = "ST" });
	}

	[TestMethod]
	public async Task AddressLookup_ReturnsNullOnNoResult()
	{
		var postalDb = new Mock<IPostalDatabase>();

		postalDb.Setup(d => d.GetAsync(It.Is<string>(s => s == "12345")))
			.ReturnsAsync((PostalResult?) null);

		var addressLookup = new AddressLookup(postalDb.Object);

		var result = await addressLookup.GetCityAsync("12345");

		postalDb.Verify(d => d.GetAsync("12345"));

		result.Should().BeNull();
	}

	// [TestMethod]
	// public async Task AddressLookup_ShouldThrowOnNoResult()
	// {
	// 	var postalDb = new Mock<IPostalDatabase>();

	// 	postalDb.Setup(d => d.GetAsync(It.Is<string>(s => s == "12345")))
	// 		.ReturnsAsync((PostalResult?) null);

	// 	var addressLookup = new AddressLookup(postalDb.Object);

	// 	await addressLookup.Invoking(al => al.GetCityAsync("12345"))
	// 		.Should().ThrowAsync<Exception>().WithMessage("Could not find city for 12345!");
	// }
}
