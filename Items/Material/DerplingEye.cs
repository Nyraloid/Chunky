using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class DerplingEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Eye");
            Tooltip.SetDefault("Or maybe a water balloon...");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 200;
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 99;
        }
    }
}