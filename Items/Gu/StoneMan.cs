using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class StoneMan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Skin");
            Tooltip.SetDefault("Become a statue, in a good way");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 28;
            item.value = 7000;
            item.rare = ItemRarityID.Blue;

            item.maxStack = 16;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (modPlayer.HasInfinite) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("StoneMan"), 1, true);
            return true;
        }
    }
}