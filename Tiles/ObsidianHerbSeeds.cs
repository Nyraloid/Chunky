using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Chunky.Tiles
{
	public class ObsidianHerbSeeds : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Obsidian Seeds");
			Tooltip.SetDefault("Can be planted on obsidian");
        }
        public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 99;
			item.consumable = true;
			item.placeStyle = 0;
			item.width = 12;
			item.height = 14;
			item.value = 80;
			item.createTile = TileType<ObsidianHerb>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 1);
			recipe.AddIngredient(ItemID.FireblossomSeeds, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipeP = new ModRecipe(mod);
			recipeP.AddIngredient(null, "Obstidian", 1);
			recipeP.SetResult(this, 2);
			recipeP.AddRecipe();
		}
	}
}