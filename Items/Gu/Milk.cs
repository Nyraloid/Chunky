using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class Milk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Milk");
            Tooltip.SetDefault("Bone Power");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 28;
            item.value = 40;
            item.rare = ItemRarityID.Blue;

            item.maxStack = 16;
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
            player.AddBuff(mod.BuffType("Milk"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddIngredient(ItemID.BottledWater, 1);
            recipeP.AddIngredient(ItemID.Seashell, 2);
            recipeP.AddIngredient(ItemID.Glass, 2);
            recipeP.AddTile(TileID.Tables);
            recipeP.AddTile(TileID.Chairs);
            recipeP.AddTile(TileID.CookingPots);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}