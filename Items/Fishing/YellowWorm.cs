using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class YellowWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandy Worm");
            Tooltip.SetDefault("Fished in the Desert\n'I don't like sand. Its course and rough and it gets everywhere.'");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 18;
            item.maxStack = 10;
            item.value = 31415;
            item.bait = 40;
        }
    }
}