namespace CreditCardNumberEvaluator.API
{
	public interface IApi<T>
	{
		T GetData(string urn);
	}
}
