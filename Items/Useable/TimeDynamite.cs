using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Useable
{
    internal class TimeDynamite : ModItem
    {
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Time Bomb");
			//ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shootSpeed = 12f;
			item.shoot = ModContent.ProjectileType<Projectiles.TimeDynamite>();
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.consumable = true;
			item.useAnimation = 40;
			item.useTime = 40;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 20, 0, 0);
			item.rare = ItemRarityID.Blue;

			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/SeismicCHarge"); //for some reason will not work
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Dynamite, 20);
			recipe.AddIngredient(mod.ItemType("TardyCardinal"));
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}


	}
}