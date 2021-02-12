using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class Durian : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Ancient Durian");
            Tooltip.SetDefault("It's mighty odor fills your body with pain,\nbut it's creamy flavor and texture bring you euphoria");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 10;
            item.value = 100000;
            item.rare = ItemRarityID.Red;
            item.maxStack = 99;
        }
    }
}