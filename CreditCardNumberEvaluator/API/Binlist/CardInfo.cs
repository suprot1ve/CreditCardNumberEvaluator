
namespace CreditCardNumberEvaluator.API.Binlist
{
	public class Number
	{
		public int Length { get; set; }
		public bool Luhn { get; set; }
	}

	public class Country
	{
		public string Numeric { get; set; }
		public string Alpha2 { get; set; }
		public string Name { get; set; }
		public string Emoji { get; set; }
		public string Currency { get; set; }
		public int Latitude { get; set; }
		public int Longitude { get; set; }
	}

	public class Bank
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
	}

	public class CardInfo
	{
		public Number Number { get; set; } = new Number();
		public string Scheme { get; set; }
		public string Type { get; set; }
		public string Brand { get; set; }
		public bool Prepaid { get; set; }
		public Country Country { get; set; } = new Country();
		public Bank Bank { get; set; } = new Bank();
	}
}
