using System.IO;
using System.Net;

namespace CreditCardNumberEvaluator.API.Binlist
{
	/// <summary>
	/// A implementation of the IApi interface for working with Binlist.net(https://lookup.binlist.net)
	/// </summary>
	public class BinlistApi : IApi<CardInfo>
	{
		private const string _url = "https://lookup.binlist.net";

		/// <summary>
		/// Returns the card information from binlist.net
		/// </summary>
		/// <param name="urn">The card number</param>
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
