using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    public class Geode : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geode");
            Tooltip.SetDefault("Break it open and see if there's anything special!");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.value = 2000;
            item.rare = ItemRarityID.Blue;

            item.maxStack = 99;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ItemID.SiltBlock, Main.rand.Next(1, 5));
            player.QuickSpawnItem(ItemID.StoneBlock, 1);
            if (Main.rand.Next(2000) == 0) player.QuickSpawnItem(ItemID.LifeCrystal, 1);
            if (Main.rand.Next(500) == 0) player.QuickSpawnItem(mod.ItemType("StopAndGo"), 1);
            //if (Main.rand.Next(430) == 0) player.QuickSpawnItem(mod.ItemType("MoltenFlesh"), 1);
            if (Main.rand.Next(100) == 0) player.QuickSpawnItem(mod.ItemType("HalfTime"), 1);
            if (Main.rand.Next(100) == 0) player.QuickSpawnItem(mod.ItemType("TardyCardinal"), 1);
            //if (Main.rand.Next(50) == 0) player.QuickSpawnItem(mod.ItemType("IronMan"), 1);
            if (Main.rand.Next(30) == 0) player.QuickSpawnItem(mod.ItemType("StoneMan"), 1);
            if (Main.rand.Next(20) == 0) player.QuickSpawnItem(mod.ItemType("Milk"), 1);
            if (Main.rand.Next(30) == 0) player.QuickSpawnItem(ItemID.Diamond, 1);
            if (Main.rand.Next(25) == 0) player.QuickSpawnItem(ItemID.Emerald, 1);
            if (Main.rand.Next(20) == 0) player.QuickSpawnItem(ItemID.Sapphire, 1);
            if (Main.rand.Next(20) == 0) player.QuickSpawnItem(ItemID.Ruby, 1);
            if (Main.rand.Next(15) == 0) player.QuickSpawnItem(ItemID.Topaz, 1);
            if (Main.rand.Next(15) == 0) player.QuickSpawnItem(ItemID.Amethyst, 1);
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.FallenStar, 1);
            //recipeP.AddIngredient(ItemID.Gel, 1);  bad, evil even
            recipeP.AddIngredient(ItemID.StoneBlock, 5);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}