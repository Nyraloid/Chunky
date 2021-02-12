using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class TardyCardinal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tardy Cardinal");
            Tooltip.SetDefault("I'm going to be late!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 16;
            item.value = 7500;
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
            if (modPlayer.HasInfinite) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("TardyCardinal"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddIngredient(ItemID.Fireblossom, 1);
            recipeP.AddIngredient(ItemID.Cardinal, 1);
            recipeP.AddIngredient(ItemID.GoldWorm, 1);
            recipeP.AddIngredient(ItemID.CopperCoin, 1);
            recipeP.AddIngredient(ItemID.SilverCoin, 1);
            recipeP.AddTile(TileID.Tables);
            recipeP.AddTile(TileID.Chairs);
            recipeP.AddTile(TileID.Bottles);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}