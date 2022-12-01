namespace Test;

[TestClass]
public class MathHelperTests
{
	// these both have "...Cleanup" parallels
	[ClassInitialize]
	public static void RunBeforeAllTests(TestContext context)
	{
	}

	[TestInitialize]
	public void RunEveryTest()
	{
	}

	[TestMethod]
	public void MathHelper_Adds()
	{
		var helper = new MathHelper();

		var result = helper.Add(2, 3);

		// built-in MSTest Assert class
		Assert.AreEqual(result, 5);
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
