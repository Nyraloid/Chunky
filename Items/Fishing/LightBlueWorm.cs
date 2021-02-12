using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class LightBlueWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Worm");
            Tooltip.SetDefault("Fished in the Hallow\n'Worms seem to be able to absorb the powers of the world around them.'");
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