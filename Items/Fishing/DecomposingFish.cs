using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class DecomposingFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decomposing Fish");
            Tooltip.SetDefault("It's still edible\nThe other fish'll love it");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.maxStack = 999;
            item.rare = ItemRarityID.White;
            item.value = -1;
            item.bait = 20;
        }
    }
}