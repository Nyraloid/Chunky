using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Weapons
{
    public class WhattheHammerDoes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Research on the Hammer and Lightsaber");
            Tooltip.SetDefault("Tells you everything the Timely Hammer and Timely Lightsaber can do.\nIncreases damage while in inventory.");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.rare = 13;
            item.consumable = false;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("Hammer isn't actually a hammer, but a pickaxe and axe. Same with the lightsaber. Can utilize the lifesteal healing up to 100 health. " +
                "While in the inventory, the player is immune to chaos state; and grants effects of the conqueror's set, magic watch, and water candle (does not stack with water candle). " +
                "+15 seconds total of stopped time, +100 defense, +100 health, and +20 mana. +200 flight time while in inventory as well.", 255, 255, 255);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            //recipeP.AddIngredient(ItemID.BlackInk); //Ink to Write with
            //recipeP.AddIngredient(ItemID.PapyrusScarab); //Paper to write on
            //recipeP.AddIngredient(ItemID.Feather); //A feather for writing
            //recipeP.AddIngredient(ItemID.LunarBar); //Legendary Metal to reinforce the feather?
            //recipeP.AddTile(TileID.Bookcases);
            //recipeP.SetResult(this);
            //recipeP.AddRecipe();
        }
    }
}
