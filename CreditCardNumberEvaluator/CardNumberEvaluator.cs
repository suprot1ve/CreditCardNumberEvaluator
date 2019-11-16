using CreditCardNumberEvaluator.Validation;
using System.Linq;

namespace CreditCardNumberEvaluator
{
	public class CardNumberEvaluator
	{
		private ICardValidator _cardValidator;
		private const int _lengthMin = 12;
		private const int _lengthMax = 19;

		public CardNumberEvaluator() => _cardValidator = new LuhnAlgorithm();

		public CardNumberEvaluator(ICardValidator cardValidator) => _cardValidator = cardValidator;

		public bool IsValidCardNumber(string cardNumber)
			=> IsCorrectCardNumber(cardNumber) && _cardValidator.IsValid(cardNumber);

		private bool IsCorrectCardNumber(string cardNumber)
			=> cardNumber.All(char.IsDigit) && !cardNumber.StartsWith("0")
			&& (cardNumber.Length <= _lengthMax && cardNumber.Length >= _lengthMin);
	}
}
