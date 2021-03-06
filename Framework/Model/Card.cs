
namespace Framework.Model
{
    public class Card
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Icon { get; set; }
        public virtual int Cost { get; set; }
        public virtual string Rarity { get; set; }
        public virtual string Arena { get; set; }
        public virtual string Type { get; set; }

    }
}
