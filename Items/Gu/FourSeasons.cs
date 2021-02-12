using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class FourSeasons : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Four Seasons");
            Tooltip.SetDefault("Spirits of the four seasons gathered into one ability");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
            item.value = 30000;
            item.rare = ItemRarityID.LightRed;

            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }
    }
}