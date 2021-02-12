using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class LimeWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lime Worm");
            Tooltip.SetDefault("Fished in the Jungle\n'What does it being green have to do with the jungle?'");
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