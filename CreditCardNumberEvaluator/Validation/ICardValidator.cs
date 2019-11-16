namespace CreditCardNumberEvaluator.Validation
{
	public interface ICardValidator
	{
		bool IsValid(string cardNumber);
	}
}
