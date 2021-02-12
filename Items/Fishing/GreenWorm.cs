using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class GreenWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Worm");
            Tooltip.SetDefault("Fished on the Surface\n'But there are already normal worms on the surface...'");
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