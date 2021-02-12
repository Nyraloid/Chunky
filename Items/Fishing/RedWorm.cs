using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class RedWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Worm");
            Tooltip.SetDefault("Fished in the Crimson or during Blood Moons\n'It might be undead...'");
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