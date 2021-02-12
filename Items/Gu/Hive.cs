using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class Hive : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beehive");
            Tooltip.SetDefault("Free honey!");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 42;
            item.value = 100;
            item.rare = ItemRarityID.Orange;

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
            player.AddBuff(mod.BuffType("Hive"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddIngredient(ItemID.Stinger, 4);
            recipeP.AddIngredient(ItemID.Hive, 7);
            recipeP.AddIngredient(ItemID.BeeWax, 5);
            recipeP.AddIngredient(ItemID.BottledHoney, 4);
            recipeP.AddIngredient(ItemID.HoneyBlock, 3);
            recipeP.AddIngredient(ItemID.HoneyComb, 1);
            recipeP.AddIngredient(ItemID.Wood, 10);
            recipeP.AddTile(TileID.Bottles);
            recipeP.AddTile(TileID.HeavyWorkBench);
            recipeP.AddTile(TileID.Sawmill);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}