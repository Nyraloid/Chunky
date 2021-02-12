using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    public class Obstidian : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obstidian");
            Tooltip.SetDefault("Grown from obsidian");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.value = 2000;
            item.rare = ItemRarityID.Blue;

            item.maxStack = 16;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed, 3600*5, true);
            player.AddBuff(BuffID.Ironskin, 3600*2, true);
            return true;
        }
    }
}