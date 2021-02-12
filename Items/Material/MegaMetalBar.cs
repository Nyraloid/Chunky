using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class MegaMetalBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("World Steel");
            Tooltip.SetDefault("'An entire world worth of metal.'");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 3333333;
            item.rare = 11;
            item.maxStack = 1;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.Gold.ToVector3() * 0.1f * Main.essScale);
        }

        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            
            //Pre-hardmode
            recipe.AddRecipeGroup("Chunky:Copper/Tin", 50); //1
            recipe.AddRecipeGroup("IronBar", 50); //2
            recipe.AddRecipeGroup("Chunky:Silver/Tungsten", 50); //3
            recipe.AddRecipeGroup("Chunky:Gold/Platinum", 50); //4
            recipe.AddRecipeGroup("Chunky:Demonite/Crimtane", 50); //5
            recipe.AddIngredient(ItemID.MeteoriteBar, 50); //6
            recipe.AddIngredient(ItemID.HellstoneBar, 50); //7

            //Hardmode
            recipe.AddRecipeGroup("Chunky:Palladium/Cobalt", 50); //8
            recipe.AddRecipeGroup("Chunky:Mythril/Orichalcum", 50); //9
            recipe.AddRecipeGroup("Chunky:Adamantite/Titanium", 50); //10
            recipe.AddIngredient(ItemID.HallowedBar, 50); //11
            recipe.AddIngredient(ItemID.ChlorophyteBar, 150); //12
            recipe.AddIngredient(ItemID.LunarBar, 50); //13
            recipe.AddIngredient(null, "SpookyMushroom", 25); //14

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        */
    }
}