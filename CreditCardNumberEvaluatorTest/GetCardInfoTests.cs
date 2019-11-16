using CreditCardNumberEvaluator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardNumberEvaluatorTest
{
	class GetCardInfoTests
	{
		private CardNumberEvaluator _evaluator;

		[SetUp]
		public void SetUp() => _evaluator = new CardNumberEvaluator();

		[Test]
		public void SampleDataTest()
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			data.Add("4929804463622139", "visa");
			data.Add("6762765696545485", "mastercard");

			var cards = data.Select(el => new { Card = _evaluator.GetCardData(el.Key), RightScheme = el.Value });

			foreach (var c in cards)
				Assert.AreEqual(c.Card.Scheme, c.RightScheme);
		}
	}
}
