using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Accessories
{
    public class MoreMagicalWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magicaler Watch");
            Tooltip.SetDefault("Retry Button");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 314159;
            item.rare = ItemRarityID.Pink;

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
            player.AddBuff(mod.BuffType("ReverseTime"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 2);
            recipeP.AddIngredient(ItemID.CrystalShard, 1);
            recipeP.AddIngredient(ItemID.Chain, 1);
            recipeP.AddIngredient(ItemID.SoulofMight, 1);
            recipeP.AddIngredient(null, "SoulOfWight", 7);
            recipeP.AddIngredient(ItemID.HallowedBar, 5);
            recipeP.AddRecipeGroup("Chunky:Adamantite/Titanium", 5);
            recipeP.AddIngredient(ItemID.UnicornHorn, 1);
            recipeP.AddIngredient(ItemID.PixieDust, 3);
            recipeP.AddIngredient(null, "MagicWatch", 1);
            recipeP.AddTile(TileID.MythrilAnvil);
            recipeP.AddTile(TileID.Tables);
            recipeP.AddTile(TileID.Chairs);
            recipeP.AddTile(TileID.Bottles);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}