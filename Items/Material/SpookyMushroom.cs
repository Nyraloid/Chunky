using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class SpookyMushroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Mushroom");
            Tooltip.SetDefault("'Dootshroom'");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.value = 10000;
            item.rare = 8;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GlowingMushroom, 30);
            recipe.AddIngredient(ItemID.Ectoplasm, 1);
            recipe.AddTile(TileID.Autohammer);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}