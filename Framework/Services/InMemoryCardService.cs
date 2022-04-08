using Framework.Model;
using System;

namespace Framework.Services
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCardByName(string cardName)
        {
            switch (cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                case "Barbarians":
                    return new BarbarianCard();
                default:
                    throw new ArgumentException("Card is not available: " + cardName);
            }
        }
    }
}
