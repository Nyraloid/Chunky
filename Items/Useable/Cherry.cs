using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    public class Cherry : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cherry");
            Tooltip.SetDefault("'If you'd stop licking it and dropping it you'd get the effect permanently'");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 24;
            item.rare = ItemRarityID.Pink;
            item.value = 50000;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
            item.maxStack = 16;
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (modPlayer.HasInstant) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("CherryPower"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueBerries, 1); //Blueberries are just blue cherries, right?
            recipe.AddIngredient(ItemID.YellowMarigold, 1); //idfk, I just wanna do this
            recipe.AddIngredient(ItemID.HallowedBar, 1); //idfk, I just wanna do this
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.AddTile(TileID.Bottles);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}