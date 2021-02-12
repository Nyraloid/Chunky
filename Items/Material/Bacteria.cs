using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class Bacteria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bacteria");
            Tooltip.SetDefault("Troublesome little fellas who can take you down from the inside");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 38;
            item.value = 7000;
            item.rare = ItemRarityID.Orange;

            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.BottledWater, 1);
            recipeP.AddIngredient(ItemID.Torch, 1);
            recipeP.AddIngredient(ItemID.Lens, 1);
            recipeP.AddIngredient(ItemID.RottenChunk, 3);
            recipeP.AddTile(TileID.AlchemyTable);
            recipeP.SetResult(this, 10);
            recipeP.AddRecipe();

            ModRecipe recipeZ = new ModRecipe(mod);
            recipeZ.AddIngredient(ItemID.BottledWater, 1);
            recipeZ.AddIngredient(ItemID.Torch, 1);
            recipeZ.AddIngredient(ItemID.Lens, 1);
            recipeZ.AddIngredient(ItemID.Vertebrae, 3);
            recipeZ.AddTile(TileID.AlchemyTable);
            recipeZ.SetResult(this, 10);
            recipeZ.AddRecipe();

            ModRecipe recipeT = new ModRecipe(mod);
            recipeT.AddIngredient(ItemID.BottledWater, 1);
            recipeT.AddIngredient(ItemID.Torch, 1);
            recipeT.AddIngredient(ItemID.Lens, 1);
            recipeT.AddIngredient(null, "DecomposingFish", 1);
            recipeT.AddTile(TileID.AlchemyTable);
            recipeT.SetResult(this, 10);
            recipeT.AddRecipe();
        }
    }
}