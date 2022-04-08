using Framework.Model;

namespace Framework.Services
{
    interface ICardService
    {
        Card GetCardByName(string cardName);
    }
}
