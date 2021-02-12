using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class WizardsLastRhymes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Wizard's Last Rhymes");
            Tooltip.SetDefault("The Poem's Tragic Rhymes");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 40;
            item.value = 1000000;
            item.rare = ItemRarityID.Red;

            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (modPlayer.HasNormal) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("LastRhymes"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.WandofSparking, 1);
            recipeP.AddIngredient(ItemID.RainbowCrystalStaff, 1);
            recipeP.AddIngredient(null, "Gurnard", 1);
            recipeP.AddIngredient(null, "BabyDragonScale", 3);
            recipeP.AddIngredient(ItemID.GiantHarpyFeather, 1);
            recipeP.AddIngredient(ItemID.FragmentNebula, 10);
            recipeP.AddIngredient(ItemID.FragmentSolar, 10);
            recipeP.AddIngredient(ItemID.FragmentStardust, 10);
            recipeP.AddIngredient(ItemID.FragmentVortex, 10);
            recipeP.AddIngredient(ItemID.ManaCrystal, 1);
            recipeP.AddTile(TileID.LunarCraftingStation);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}