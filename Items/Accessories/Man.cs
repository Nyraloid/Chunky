using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Accessories
{
    public class Man : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("An Entire Person");
            Tooltip.SetDefault("Adds the the stats of a player to what you currently have.");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 34;
            item.value = 50000;
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            //recipeP.AddIngredient(ItemID.SoulofLight, 10); //ancient souls of light and dark
            //recipeP.AddIngredient(ItemID.SoulofNight, 10); //ancient souls of light and dark
            //recipeP.AddIngredient(ItemID.SoulofSight, 10); //able to see
            //recipeP.AddIngredient(ItemID.SoulofMight, 10); //having might
            recipeP.AddIngredient(ItemID.ManaCrystal, 1); //20 mana
            recipeP.AddIngredient(ItemID.LifeCrystal, 5); //100 health
            recipeP.AddIngredient(ItemID.FamiliarWig, 1); //any hair
            recipeP.AddIngredient(ItemID.FamiliarShirt, 1); //any shirt
            recipeP.AddIngredient(ItemID.FamiliarPants, 1); //any pants and shoes
            recipeP.AddIngredient(ItemID.Mannequin, 1); //the person
            if (Main.expertMode) recipeP.AddIngredient(ItemID.DemonHeart, 1); //expert heart
            recipeP.AddTile(TileID.BewitchingTable);
            recipeP.AddTile(TileID.AlchemyTable);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}