public interface IMathHelper
{
	public int Add(int a, int b);
	public int Multiply(int a, int b);
}

public class MathHelper : IMathHelper
{
	public int Add(int a, int b) => a + b;

	// oops!
	public int Multiply(int a, int b) => a + b;
	//public int Multiply(int a, int b) => a * b;
}
