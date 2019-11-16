using System.IO;
using System.Net;

namespace CreditCardNumberEvaluator.API.Binlist
{
	class BinlistApi : IApi<CardInfo>
	{
		private const string _url = "https://lookup.binlist.net";

		public CardInfo GetData(string urn) => JSONHelper.GetCardInfoFromJSON(GetJsonData(urn));

		private string GetJsonData(string urn)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{_url}/{urn}");
			request.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			using (Stream stream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
					return reader.ReadToEnd();
		}
	}
}
