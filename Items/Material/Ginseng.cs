using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class Ginseng : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hundred Man Ginseng");
            Tooltip.SetDefault("Smells very earthy");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.value = 100000;
            item.rare = ItemRarityID.Red;
            item.maxStack = 99;
            item.scale = 2;
        }
    }
}