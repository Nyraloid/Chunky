using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Accessories
{
    public class MagicWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Watch");
            Tooltip.SetDefault("Send a chill through time");
        }

        public override void SetDefaults()
        {
            ///making a major change
            item.width = 22;
            item.height = 26;
            item.value = 1000;
            item.rare = ItemRarityID.Orange;
            //item.defense = 4;
            //item.accessory = true;

            item.maxStack = 16;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        //public override void UpdateAccessory(Player player, bool hideVisual)
        //{
        //    ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
        //
        //    modPlayer.CanUseTimeMagic = true;
        //}

        //public override void UpdateInventory(Player player)
        //{
        //    ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
        //
        //    modPlayer.CanUseTimeMagic = true;
        //}

        ///major changes

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (modPlayer.HasNormal) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("Time"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddIngredient(ItemID.LifeCrystal, 1);
            recipeP.AddIngredient(ItemID.PlatinumWatch, 1);
            recipeP.AddIngredient(ItemID.DemoniteBar, 5);
            recipeP.AddIngredient(ItemID.HellstoneBar, 5);
            recipeP.AddIngredient(ItemID.MeteoriteBar, 5);
            recipeP.AddIngredient(null, "StopAndGo", 1);
            recipeP.AddTile(TileID.Tables);
            recipeP.AddTile(TileID.Chairs);
            recipeP.AddTile(TileID.Bottles);
            recipeP.SetResult(this, 2);
            recipeP.AddRecipe();

            ModRecipe recipeZ = new ModRecipe(mod);
            recipeZ.AddIngredient(ItemID.ManaCrystal, 1);
            recipeZ.AddIngredient(ItemID.LifeCrystal, 1);
            recipeZ.AddIngredient(ItemID.GoldWatch, 1);
            recipeZ.AddIngredient(ItemID.CrimtaneBar, 5);
            recipeZ.AddIngredient(ItemID.HellstoneBar, 5);
            recipeZ.AddIngredient(ItemID.MeteoriteBar, 5);
            recipeZ.AddIngredient(null, "StopAndGo", 1);
            recipeZ.AddTile(TileID.Tables);
            recipeZ.AddTile(TileID.Chairs);
            recipeZ.AddTile(TileID.Bottles);
            recipeZ.SetResult(this, 2);
            recipeZ.AddRecipe();

            ModRecipe recipeP2 = new ModRecipe(mod);
            recipeP2.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP2.AddIngredient(ItemID.LifeCrystal, 1);
            recipeP2.AddIngredient(ItemID.GoldWatch, 1);
            recipeP2.AddIngredient(ItemID.DemoniteBar, 5);
            recipeP2.AddIngredient(ItemID.HellstoneBar, 5);
            recipeP2.AddIngredient(ItemID.MeteoriteBar, 5);
            recipeP2.AddIngredient(null, "StopAndGo", 1);
            recipeP2.AddTile(TileID.Tables);
            recipeP2.AddTile(TileID.Chairs);
            recipeP2.AddTile(TileID.Bottles);
            recipeP2.SetResult(this, 2);
            recipeP2.AddRecipe();

            ModRecipe recipeZ2 = new ModRecipe(mod);
            recipeZ2.AddIngredient(ItemID.ManaCrystal, 1);
            recipeZ2.AddIngredient(ItemID.LifeCrystal, 1);
            recipeZ2.AddIngredient(ItemID.PlatinumWatch, 1);
            recipeZ2.AddIngredient(ItemID.CrimtaneBar, 5);
            recipeZ2.AddIngredient(ItemID.HellstoneBar, 5);
            recipeZ2.AddIngredient(ItemID.MeteoriteBar, 5);
            recipeZ2.AddIngredient(null, "StopAndGo", 1);
            recipeZ2.AddTile(TileID.Tables);
            recipeZ2.AddTile(TileID.Chairs);
            recipeZ2.AddTile(TileID.Bottles);
            recipeZ2.SetResult(this, 2);
            recipeZ2.AddRecipe();
        }
    }
}