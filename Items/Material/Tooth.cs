using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class Tooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tooth");
            Tooltip.SetDefault("The first lost tooth of a young child.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 0;
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 1;
        }
    }
}