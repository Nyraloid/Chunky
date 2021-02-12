using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class InfestedMeteorite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vaguely Mystical Rocks");
            Tooltip.SetDefault("There's probably something special about them");
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 10000;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 99;
        }

        public override void UpdateInventory(Player player)
        {
            Vector2 position = player.position;
            Lighting.AddLight((int)((position.X + (float)(player.width / 2)) / 16f), (int)((position.Y + (float)(player.height / 2)) / 16f), 1f, 0.9f, 0.4f);
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.Gold.ToVector3() * 0.1f * Main.essScale);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
            recipe.AddIngredient(null, "Bacteria", 3);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}