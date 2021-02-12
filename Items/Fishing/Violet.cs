using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class VioletWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupted Worm");
            Tooltip.SetDefault("Fished in the Corruption or during Blood Moons\n'A baby devourer.'");
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