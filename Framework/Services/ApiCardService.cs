using Framework.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class ApiCardService : ICardService
    {
        public const string CARD_API = "https://statsroyale.com/api/cards";
        public IList<Card> GetAllCards()
        {
            var client = new RestClient(CARD_API);
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = client.Execute(request);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception("/cards endpoint is failed" + response.StatusCode);
            }

            return JsonConvert.DeserializeObject<IList<Card>>(response.Content);
        }
        public Card GetCardByName(string cardName)
        {
            var cards = GetAllCards();

            return cards.FirstOrDefault(x => x.Name == cardName);
        }
    }
}
