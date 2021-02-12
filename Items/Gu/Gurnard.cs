using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class Gurnard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystical Gurnard");
            Tooltip.SetDefault("Caught after the death of the Duke during the Black Sun\nIt's eyes resemble the eclipse...");
        }

        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 28;
            item.value = 100;
            item.rare = ItemRarityID.Yellow;

            item.maxStack = 20;
            item.useStyle = ItemUseStyleID.EatingUsing;
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
            player.AddBuff(mod.BuffType("Gurnard"), 1, true);
            return true;
        }
    }
}