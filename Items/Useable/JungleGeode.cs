using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    public class JungleGeode : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sweet Greens");
            Tooltip.SetDefault("It's just a clump of honey and leaves");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.value = 2000;
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
            player.QuickSpawnItem(ItemID.HoneyBlock, 1);
            player.QuickSpawnItem(ItemID.Vine, 1);
            if (Main.rand.Next(200) == 0) player.QuickSpawnItem(mod.ItemType("Jumanji"), 1);
            if (Main.rand.Next(200) == 0) player.QuickSpawnItem(ItemID.FiberglassFishingPole, 1);
            if (Main.rand.Next(200) == 0) player.QuickSpawnItem(ItemID.Boomstick, 1);
            if (Main.rand.Next(150) == 0) player.QuickSpawnItem(ItemID.StaffofRegrowth, 1);
            if (Main.rand.Next(150) == 0) player.QuickSpawnItem(ItemID.FlowerBoots, 1);
            if (Main.rand.Next(150) == 0) player.QuickSpawnItem(ItemID.FeralClaws, 1);
            if (Main.rand.Next(150) == 0) player.QuickSpawnItem(ItemID.AnkletoftheWind, 1);
            if (Main.rand.Next(100) == 0) player.QuickSpawnItem(ItemID.NaturesGift, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.SkyBlueFlower, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.LivingMahoganyLeafWand, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.LivingMahoganyWand, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.JungleRose, 1);
            if (Main.rand.Next(40) == 0) player.QuickSpawnItem(ItemID.VioletHusk, 1);
            if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.Stinger, Main.rand.Next(1, 3));
            if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.MoonglowSeeds, Main.rand.Next(1, 3));
            if (Main.rand.Next(3) == 0) player.QuickSpawnItem(ItemID.Moonglow, 1);
            if (Main.rand.Next(3) == 0) player.QuickSpawnItem(ItemID.JungleSpores, Main.rand.Next(1,3));

            if (Main.rand.Next(300) == 0) player.QuickSpawnItem(mod.ItemType("SmugBug"), 1);
            if (Main.rand.Next(100) == 0) player.QuickSpawnItem(ItemID.Buggy, 1);
            if (Main.rand.Next(50) == 0) player.QuickSpawnItem(ItemID.Sluggy, 1);
            if (Main.rand.Next(10) == 0) player.QuickSpawnItem(ItemID.Grubby, 1);

            if (NPC.downedMechBossAny && Main.rand.Next(100) == 0) player.QuickSpawnItem(ItemID.LifeFruit, 1);
            if (Main.rand.Next(200) == 0) player.QuickSpawnItem(ItemID.LifeFruit, 1);
            //include better jumanji maybe?
            if (NPC.downedPlantBoss && Main.rand.Next(300) == 0) player.QuickSpawnItem(ItemID.Seedling, 1); 
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.HoneyBlock, 1);
            recipeP.AddIngredient(ItemID.Vine, 1);
            recipeP.AddIngredient(ItemID.JungleSpores, 1);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}