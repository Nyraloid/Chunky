using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class BlueWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Worm");
            Tooltip.SetDefault("Fished in the Sky\n'A harpy dropped him in the water. Worms are oppressed in the world of Terraria.'");
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