using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class LittleStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Little Star");
            Tooltip.SetDefault("Twinkle twinkle");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;

            item.maxStack = 99;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (modPlayer.HasInfinite) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("LittleStar"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.FallenStar, 8);
            recipeP.AddIngredient(ItemID.Cloud, 20);
            recipeP.AddIngredient(ItemID.GoldBar, 5);
            recipeP.AddIngredient(ItemID.Daybloom, 1);
            recipeP.AddIngredient(ItemID.Sunflower, 1);
            recipeP.AddIngredient(ItemID.Goldfish, 1);
            recipeP.AddIngredient(null, "HalfTime", 2);
            recipeP.AddTile(TileID.SkyMill);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}