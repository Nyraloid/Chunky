using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class BabyDragonScale : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Dragon's Scale");
            Tooltip.SetDefault("A scale of the legendary Dragon species\nIt's true path of power is still undetermined...");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 20000;
            item.rare = ItemRarityID.Pink;

            item.maxStack = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (modPlayer.HasInstant) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("BabyDragonScale"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(null, "SoulOfWight", 1);
            recipeP.AddIngredient(ItemID.SoulofFlight, 1);
            recipeP.AddIngredient(ItemID.TurtleShell, 1);
            recipeP.AddIngredient(null, "DerplingHusk", 1);
            recipeP.AddIngredient(ItemID.BeeWings, 1);
            recipeP.AddIngredient(ItemID.RottenChunk, 2);
            recipeP.AddIngredient(ItemID.Fireblossom, 1);
            recipeP.AddIngredient(ItemID.Deathweed, 1);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddTile(TileID.MythrilAnvil);
            recipeP.AddTile(TileID.CookingPots);
            recipeP.SetResult(this);
            recipeP.AddRecipe();

            ModRecipe recipeZ = new ModRecipe(mod);
            recipeZ.AddIngredient(null, "SoulOfWight", 1);
            recipeZ.AddIngredient(ItemID.SoulofFlight, 1);
            recipeZ.AddIngredient(ItemID.TurtleShell, 1);
            recipeZ.AddIngredient(null, "DerplingHusk", 1);
            recipeZ.AddIngredient(ItemID.BeeWings, 1);
            recipeZ.AddIngredient(ItemID.Vertebrae, 2);
            recipeZ.AddIngredient(ItemID.Fireblossom, 1);
            recipeZ.AddIngredient(ItemID.Deathweed, 1);
            recipeZ.AddIngredient(ItemID.ManaCrystal, 1);
            recipeZ.AddTile(TileID.MythrilAnvil);
            recipeZ.AddTile(TileID.CookingPots);
            recipeZ.SetResult(this);
            recipeZ.AddRecipe();
        }
    }
}