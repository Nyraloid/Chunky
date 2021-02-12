using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class HalfTime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smug Bug");
            Tooltip.SetDefault("Bribe the time");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 16;
            item.value = 0;
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
            player.AddBuff(mod.BuffType("HalfTime"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddIngredient(ItemID.Buggy, 1);
            recipeP.AddIngredient(ItemID.Shiverthorn, 1);
            recipeP.AddIngredient(ItemID.PlatinumCoin, 1);
            recipeP.AddIngredient(ItemID.GoldCoin, 1);
            recipeP.AddTile(TileID.Tables);
            recipeP.AddTile(TileID.Chairs);
            recipeP.AddTile(TileID.Bottles);
            recipeP.SetResult(this);
            recipeP.AddRecipe();

            ModRecipe recipeZ = new ModRecipe(mod);
            recipeZ.AddIngredient(ItemID.ManaCrystal, 1);
            recipeZ.AddIngredient(ItemID.Sluggy, 10);
            recipeZ.AddIngredient(ItemID.Shiverthorn, 1);
            recipeZ.AddIngredient(ItemID.PlatinumCoin, 1);
            recipeZ.AddIngredient(ItemID.GoldCoin, 1);
            recipeZ.AddTile(TileID.Tables);
            recipeZ.AddTile(TileID.Chairs);
            recipeZ.AddTile(TileID.Bottles);
            recipeZ.SetResult(this);
            recipeZ.AddRecipe();

            ModRecipe recipeT = new ModRecipe(mod);
            recipeT.AddIngredient(ItemID.ManaCrystal, 1);
            recipeT.AddIngredient(ItemID.Grubby, 30);
            recipeT.AddIngredient(ItemID.Shiverthorn, 1);
            recipeT.AddIngredient(ItemID.PlatinumCoin, 1);
            recipeT.AddIngredient(ItemID.GoldCoin, 1);
            recipeT.AddTile(TileID.Tables);
            recipeT.AddTile(TileID.Chairs);
            recipeT.AddTile(TileID.Bottles);
            recipeT.SetResult(this);
            recipeT.AddRecipe();
        }
    }
}