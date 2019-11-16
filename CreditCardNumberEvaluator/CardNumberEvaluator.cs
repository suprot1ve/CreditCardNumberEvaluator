using CreditCardNumberEvaluator.API;
using CreditCardNumberEvaluator.API.Binlist;
using CreditCardNumberEvaluator.Validation;
using System.Linq;

namespace CreditCardNumberEvaluator
{
	public class CardNumberEvaluator
	{
		private ICardValidator _cardValidator;
		private const int _lengthMin = 12;
		private const int _lengthMax = 19;
		private IApi<CardInfo> _api;

		public CardNumberEvaluator()
		{
			_cardValidator = new LuhnAlgorithm();
			_api = new BinlistApi();
		}

		public CardNumberEvaluator(ICardValidator cardValidator, IApi<CardInfo> api)
		{
			_cardValidator = cardValidator;
			_api = api;
		}

		public bool IsValidCardNumber(string cardNumber)
			=> IsCorrectCardNumber(cardNumber) && _cardValidator.IsValid(cardNumber);

		public CardInfo GetCardData(string cardNumber)
			=> (IsValidCardNumber(cardNumber)) ? _api.GetData(cardNumber) : null;

		private bool IsCorrectCardNumber(string cardNumber)
			=> cardNumber.All(char.IsDigit) && !cardNumber.StartsWith("0")
			&& (cardNumber.Length <= _lengthMax && cardNumber.Length >= _lengthMin);
	}
}
