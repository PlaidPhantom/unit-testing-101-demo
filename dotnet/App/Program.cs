using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddTransient<IMathHelper, MathHelper>();
services.AddTransient<IPostalDatabase, PostalDatabase>();
services.AddTransient<IAddressLookup, AddressLookup>();

var provider = services.BuildServiceProvider();


var mathHelper = provider.GetService<IMathHelper>()!;
var addressLookup = provider.GetService<IAddressLookup>()!;

int a, b;

switch (args[0]) {
	case "add":
		a = int.Parse(args[1]);
		b = int.Parse(args[2]);
		Console.WriteLine($"{a} + {b} = {mathHelper.Add(a, b)}");
		break;
	case "mult":
		a = int.Parse(args[1]);
		b = int.Parse(args[2]);
		Console.WriteLine($"{a} * {b} = {mathHelper.Multiply(a, b)}");
		break;
	case "postal":
		var result = await addressLookup.GetCityAsync(args[1]);
		if (result != null)
			Console.WriteLine($"Found city {result.City}, {result.State} {args[1]}");
		else
			Console.WriteLine("Could not find postal code \"{args[1]}\".");
		break;
	default: throw new NotImplementedException();
}
