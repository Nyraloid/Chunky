using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.BodySwap
{
    public class Fetus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrarian Fetus");
            Tooltip.SetDefault("Yummy\nCan be consumed to increase max life while in the Sovereign Body.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 29;
            item.value = 100000;
            item.rare = ItemRarityID.White;
            item.maxStack = 10;
            //item.scale = 1.2f;

            //item.useStyle = ItemUseStyleID.EatingUsing;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 45;
            item.useAnimation = 45;
            item.UseSound = SoundID.Item2; //hopefully is eat
            item.useTurn = true;
            //item.noUseGraphic = true;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            //if (player.GetModPlayer<ChunkyPlayer>().BodyType == "God" && player.GetModPlayer<ChunkyPlayer>().Fetuses < player.GetModPlayer<ChunkyPlayer>().FetusMax) return true;
            if (player.GetModPlayer<ChunkyPlayer>().BodyType == "God") return true; //No limit anymore since calamities grow indefinitely

            return false;
        }

        public override bool UseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            if (modPlayer.Fetuses < 25)
            {
                player.statLifeMax2 += 2;
                player.statLife += 2;
                player.HealEffect(2, true);
            }
            else
            {
                player.statLifeMax2 += 1;
                player.statLife += 1;
                player.HealEffect(1, true);
            }

            modPlayer.Fetuses += 1;

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "TimeDroplet", 1);
            recipe1.AddIngredient(null, "SoulOfWight", 3);
            recipe1.AddIngredient(ItemID.RottenChunk, 3);
            recipe1.AddIngredient(ItemID.ClayBlock, 5);
            recipe1.AddIngredient(ItemID.LifeFruit, 1);
            recipe1.AddRecipeGroup("Chunky:Gem", 1);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.AddTile(TileID.CookingPots);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "TimeDroplet", 1);
            recipe2.AddIngredient(null, "SoulOfWight", 3);
            recipe2.AddIngredient(ItemID.Vertebrae, 3);
            recipe2.AddIngredient(ItemID.LifeFruit, 1);
            recipe1.AddIngredient(ItemID.ClayBlock, 5);
            recipe2.AddRecipeGroup("Chunky:Gem", 1);
            recipe2.AddTile(TileID.LunarCraftingStation);
            recipe1.AddTile(TileID.CookingPots);
            recipe2.SetResult(this);
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "TimeDroplet", 3);
            recipe3.AddIngredient(null, "SoulOfWight", 9);
            recipe3.AddIngredient(ItemID.RottenChunk, 6);
            recipe3.AddIngredient(ItemID.LifeCrystal, 1);
            recipe1.AddIngredient(ItemID.ClayBlock, 15);
            recipe3.AddRecipeGroup("Chunky:Gem", 1);
            recipe3.AddTile(TileID.LunarCraftingStation);
            recipe1.AddTile(TileID.CookingPots);
            recipe3.SetResult(this, 3);
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe1.AddIngredient(null, "TimeDroplet", 3);
            recipe4.AddIngredient(null, "SoulOfWight", 9);
            recipe4.AddIngredient(ItemID.Vertebrae, 6);
            recipe4.AddIngredient(ItemID.LifeCrystal, 1);
            recipe1.AddIngredient(ItemID.ClayBlock, 15);
            recipe4.AddRecipeGroup("Chunky:Gem", 1);
            recipe4.AddTile(TileID.LunarCraftingStation);
            recipe1.AddTile(TileID.CookingPots);
            recipe4.SetResult(this, 3);
            recipe4.AddRecipe();
        }
    }
}