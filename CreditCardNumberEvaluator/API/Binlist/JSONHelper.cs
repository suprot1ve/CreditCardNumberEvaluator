using System.Web.Script.Serialization;

namespace CreditCardNumberEvaluator.API.Binlist
{
	public static class JSONHelper
	{
		public static CardInfo GetCardInfoFromJSON(string data)
			=> new JavaScriptSerializer().Deserialize<CardInfo>(data);

	}
}
