using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class StopAndGo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stop and Go");
            Tooltip.SetDefault("Push, and pull...\nStop, and go...\nYin; and Yang...\nWell, not really. At least not yet");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8));
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = 20000;
            item.rare = ItemRarityID.Green;

            item.maxStack = 16;
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
            player.AddBuff(mod.BuffType("StopAndGo"), 1, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipeP = new ModRecipe(mod);
            recipeP.AddIngredient(ItemID.ManaCrystal, 2);
            recipeP.AddIngredient(ItemID.JungleSpores, 5);
            recipeP.AddIngredient(ItemID.ShadowScale, 3);
            recipeP.AddIngredient(ItemID.Bone, 7);

            //Slow
            recipeP.AddIngredient(null, "HalfTime", 1);
            recipeP.AddIngredient(ItemID.BottledHoney, 3);
            recipeP.AddIngredient(ItemID.HoneyBlock, 4);
            recipeP.AddIngredient(ItemID.Shiverthorn, 1);

            //Fast
            recipeP.AddIngredient(null, "TardyCardinal", 1);
            recipeP.AddIngredient(ItemID.SwiftnessPotion, 2);
            recipeP.AddIngredient(ItemID.Fireblossom, 2);

            recipeP.AddTile(TileID.SkyMill);
            recipeP.SetResult(this);
            recipeP.AddRecipe();
        }
    }
}