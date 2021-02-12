using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class DerplingHusk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Husk");
            Tooltip.SetDefault("Tough, blue, and smells horrible");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 22;
            item.value = 300;
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 99;
        }
    }
}