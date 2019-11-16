using CreditCardNumberEvaluator.Validation;
using NUnit.Framework;
using System.Collections.Generic;

namespace CreditCardNumberEvaluatorTest
{
	class LuhnAlgorithmTests
	{
		[Test]
		public void SampleDataTest()
		{
			Dictionary<string, bool> data = new Dictionary<string, bool>();
			data.Add("4929804463622139", true);
			data.Add("4929804463622138", false);
			data.Add("6762765696545485", true);
			data.Add("5212132012291762", false);
			data.Add("6210948000000029", true);

			ICardValidator validator = new LuhnAlgorithm();

			foreach (var d in data)
				Assert.AreEqual(validator.IsValid(d.Key), d.Value);

		}
	}
}
