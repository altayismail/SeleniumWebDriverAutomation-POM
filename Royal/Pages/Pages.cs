using System;

namespace Royal.Pages
{
    public class Pages
    {
        [ThreadStatic]
        public static CardsPage Cards;
        [ThreadStatic]
        public static CardDetailsPage CardDetails;
        [ThreadStatic]
        public static CopyDeckPage CopyDeck;
        [ThreadStatic]
        public static DeckBuilderPage DeckBuilder;
        public static void Init()
        {
            Cards = new CardsPage();
            CardDetails = new CardDetailsPage();
            CopyDeck = new CopyDeckPage();
            DeckBuilder = new DeckBuilderPage();
        }
    }
}
