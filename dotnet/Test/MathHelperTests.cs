namespace Test;

[TestClass]
public class MathHelperTests
{
	[TestMethod]
	public void MathHelper_Adds()
	{
		var helper = new MathHelper();

		// built-in MSTest Assert class
		Assert.AreEqual(helper.Add(2, 3), 5);
	}

	// run multiple test cases with DataRowAttribute
	[DataTestMethod]
	[DataRow(2, 3, 6)]
	[DataRow(7, 11, 77)]
	public void MathHelper_Multiplies(int a, int b, int expected)
	{
		var helper = new MathHelper();

		var result = helper.Multiply(a, b);

		// FluentAssertions "fluent" syntax
		result.Should().Be(expected);
	}
}
