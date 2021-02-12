using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class HolyTurtle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Turtle");
            Tooltip.SetDefault("An amalgamation of many beasts and spirits");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 26;
            item.value = 30000;
            item.rare = ItemRarityID.LightRed;

            item.maxStack = 1;
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
            player.AddBuff(mod.BuffType("HolyTurtle"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddIngredient(ItemID.DarkShard, 1);
            recipeP.AddIngredient(ItemID.LightShard, 1);
            recipeP.AddIngredient(ItemID.SoulofLight, 1);
            recipeP.AddIngredient(ItemID.SoulofNight, 1);
            recipeP.AddIngredient(null, "SoulOfWight", 1);
            recipeP.AddIngredient(ItemID.TatteredBeeWing, 2);
            recipeP.AddIngredient(ItemID.UnicornHorn, 1);
            recipeP.AddIngredient(ItemID.TurtleShell, 1);
            recipeP.AddIngredient(null, "FourSeasons", 1);
            recipeP.AddTile(TileID.AlchemyTable);
            recipeP.AddTile(TileID.BewitchingTable);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}