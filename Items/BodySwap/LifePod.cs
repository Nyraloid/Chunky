using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.BodySwap
{
    public class LifePod : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("For growing bodies");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 100000;
            item.createTile = ModContent.TileType<Tiles.LifePodTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FleshCloningVaat, 1);
            recipe.AddIngredient(ItemID.Glass, 30);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddRecipeGroup("Chunky:Adamantite/Titanium", 10);
            recipe.AddIngredient(ItemID.OutletPump, 1);
            recipe.AddIngredient(ItemID.InletPump, 1);
            recipe.AddIngredient(ItemID.Wire, 100);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}