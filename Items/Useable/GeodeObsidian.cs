using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    public class GeodeObsidian : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Geode");
            Tooltip.SetDefault("Break it open and see if there's anything special!");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.value = 8000;
            item.rare = ItemRarityID.Green;

            item.maxStack = 99;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ItemID.Obsidian, 1);
            if (Main.rand.Next(430) == 0) player.QuickSpawnItem(mod.ItemType("StopAndGo"), 1);
            if (Main.rand.Next(100) == 0) player.QuickSpawnItem(mod.ItemType("DemonMan"), 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.ObsidianRose, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.MagmaStone, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.LavaCharm, 1);
            if (Main.rand.Next(20) == 0) player.QuickSpawnItem(mod.ItemType("Obstidian"), 1);
            if (Main.rand.Next(20) == 0) player.QuickSpawnItem(mod.ItemType("StoneMan"), 1);
            if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.Hellstone, 1);
            if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.Diamond, 1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.Obsidian, 2);
            recipeP.AddIngredient(ItemID.Hellstone, 1);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}