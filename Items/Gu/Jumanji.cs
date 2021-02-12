using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class Jumanji : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jumanji");
            Tooltip.SetDefault("itS A sTAMPEEEEDE");
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 32;
            item.value = 0;
            item.rare = ItemRarityID.Green;

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
            player.AddBuff(mod.BuffType("Jumanji"), 1, true);
            return true;
        }
    }
}