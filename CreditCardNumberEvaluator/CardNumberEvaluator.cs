using CreditCardNumberEvaluator.API;
using CreditCardNumberEvaluator.API.Binlist;
using CreditCardNumberEvaluator.Validation;
using System.Linq;

namespace CreditCardNumberEvaluator
{
	/// <summary>
	/// A card evaluator to validate a card number and get additional information about a card
	/// </summary>
	public class CardNumberEvaluator
	{
		#region Private Fields

		private ICardValidator _cardValidator;
		private const int _lengthMin = 12;
		private const int _lengthMax = 19;
		private IApi<CardInfo> _api;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a card evaluator with the Luhn algorithm and Binlist API
		/// </summary>
		public CardNumberEvaluator()
		{
			_cardValidator = new LuhnAlgorithm();
			_api = new BinlistApi();
		}

		/// <summary>
		/// Initializes a card evaluator with a given validation algorithm and API
		/// </summary>
		/// <param name="cardValidator">The algorithm for validation a card number</param>
		/// <param name="api">The remote API</param>
		public CardNumberEvaluator(ICardValidator cardValidator, IApi<CardInfo> api)
		{
			_cardValidator = cardValidator;
			_api = api;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Indicates whether a card number is valid
		/// </summary>
		/// <param name="cardNumber">The card number</param>
		public bool IsValidCardNumber(string cardNumber)
			=> IsCorrectCardNumber(cardNumber) && _cardValidator.IsValid(cardNumber);


		/// <summary>
		/// Returns the card information from the Internet resource
		/// </summary>
		/// <param name="cardNumber">The card number</param>
		/// <returns>If successful returns a card information, otherwise null</returns>
		public CardInfo GetCardData(string cardNumber)
			=> (IsValidCardNumber(cardNumber)) ? _api.GetData(cardNumber) : null;

		#endregion

		#region Private Methods

		private bool IsCorrectCardNumber(string cardNumber)
			=> cardNumber.All(char.IsDigit) && !cardNumber.StartsWith("0")
			&& (cardNumber.Length <= _lengthMax && cardNumber.Length >= _lengthMin);

		#endregion
	}
}
