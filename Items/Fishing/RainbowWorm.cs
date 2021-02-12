using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class RainbowWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Worm");
            Tooltip.SetDefault("Massive fishing power increase\nAll damage increased depending on how many bosses are dead\n'Yes, I just dyed a worm in eight colors.'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 22;
            item.maxStack = 1;
            item.value = 10000000;
            item.accessory = true;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage *= 1.1f;
            player.magicDamage *= 1.1f;
            player.rangedDamage *= 1.1f;
            player.minionDamage *= 1.1f;
            if (NPC.downedPlantBoss)
            {
                player.meleeDamage *= 1.15f;
                player.magicDamage *= 1.15f;
                player.rangedDamage *= 1.15f;
                player.minionDamage *= 1.15f;
            }
            if (NPC.downedFishron)
            {
                player.meleeDamage *= 1.2f;
                player.magicDamage *= 1.2f;
                player.rangedDamage *= 1.2f;
                player.minionDamage *= 1.2f;
            }

            player.fishingSkill += 1000000; //possibly too op
        }

        public override void AddRecipes()
        {
            if (Main.expertMode) //Can only be crafted in expert mode
            {
                ModRecipe recipeP = new ModRecipe(mod);

                recipeP.AddIngredient(null, "RedWorm", 1);
                recipeP.AddIngredient(null, "OrangeWorm", 1);
                recipeP.AddIngredient(null, "YellowWorm", 1);
                recipeP.AddIngredient(null, "LimeWorm", 1);
                recipeP.AddIngredient(null, "GreenWorm", 1);
                recipeP.AddIngredient(null, "LightBlueWorm", 1);
                recipeP.AddIngredient(null, "BlueWorm", 1);
                recipeP.AddIngredient(null, "VioletWorm", 1);
                recipeP.AddIngredient(ItemID.TruffleWorm, 1); //Yes, we need the demon worm too
                recipeP.AddIngredient(ItemID.FallenStar, 100); //We need some magic in there too

                recipeP.AddTile(TileID.MythrilAnvil);
                recipeP.SetResult(this);
                recipeP.AddRecipe();
            }
        }
    }
}