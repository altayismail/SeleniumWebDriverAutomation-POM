
namespace Framework.Model
{
    public class BarbarianCard : Card
    {
        public override string Name { get; set; } = "Barbarians";
        public override int Cost { get; set; } = 5;
        public override string Rarity { get; set; } = "Common";
        public override string Type { get; set; } = "Troop";
        public override string Arena { get; set; } = "Arena 3";
    }
}
