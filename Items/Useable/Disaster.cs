using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    public class Disaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beckoning Calamities");
            Tooltip.SetDefault("sounds like a yugioh card");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 99;
            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Red;
        }

        public override bool UseItem(Player player)
        {
            if (!ChunkyWorld.disaster)
            {
                Main.NewText("Terraria trembles...", 175, 75, 255, false);
                CustomInvasion.StartCustomInvasion();
                ChunkyWorld.NumDisasters = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        */
    }
}