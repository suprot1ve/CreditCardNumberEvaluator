using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardNumberEvaluator.Validation
{
	public class LuhnAlgorithm : ICardValidator
	{
		public bool IsValid(string cardNumber) => IsValid(cardNumber.Select(n => (int)Char.GetNumericValue(n)));

		private bool IsValid(IEnumerable<int> digits)
			=> digits.Reverse()
			.Select((d, i) => (i % 2 != 0) ? ((d * 2 > 9) ? d * 2 - 9 : d * 2) : d)
			.Sum() % 10 == 0;
	}
}
