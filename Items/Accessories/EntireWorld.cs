using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Accessories
{
    public class EntireWorld : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("An Entire Planet");
            Tooltip.SetDefault("Behold, the power of GRAVITY!\n'The ability of a certain Priest are now in your hands.'");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 50000;
            item.rare = 11;
            item.maxStack = 1;
        }

        public override void UpdateInventory(Player player)
        {
            //SPEEEEEEEDWAGOOOOON
            player.maxFallSpeed = 670000000;
            player.maxRunSpeed = 670000000;
            player.moveSpeed *= 1000;
            //Father Pucci would be proud
        }

        public override void AddRecipes()
        {
            //ModRecipe recipeCo = new ModRecipe(mod);
            //recipeCo.AddIngredient(ItemID.DirtBlock, 4995); //An entire planet requires quite a bit of dirt
            //recipeCo.AddIngredient(ItemID.StoneBlock, 4995); //Also needs a crapton of stone
            //recipeCo.AddIngredient(ItemID.MudBlock, 1998); //Quite a bit of mud
            //recipeCo.AddIngredient(ItemID.SandBlock, 1998); //Also quite a bit of sand
            //recipeCo.AddIngredient(ItemID.BottomlessBucket, 1); //Infinite water θωθ
            //recipeCo.AddIngredient(ItemID.AshBlock, 2997); //The Underworld is massive

            //recipeCo.AddIngredient(ItemID.EbonstoneBlock, 999); //Corruption engulfs the world

            //recipeCo.AddIngredient(ItemID.PearlstoneBlock, 999); //So does the hallow
            //recipeCo.AddTile(TileID.LunarCraftingStation);
            //recipeCo.SetResult(this);
            //recipeCo.AddRecipe();

            //ModRecipe recipeCr = new ModRecipe(mod);
            //recipeCr.AddIngredient(ItemID.DirtBlock, 4995); //An entire planet requires quite a bit of dirt
            //recipeCr.AddIngredient(ItemID.StoneBlock, 4995); //Also needs a crapton of stone
            //recipeCr.AddIngredient(ItemID.MudBlock, 1998); //Quite a bit of mud
            //recipeCr.AddIngredient(ItemID.SandBlock, 1998); //Also quite a bit of sand
            //recipeCr.AddIngredient(ItemID.BottomlessBucket, 1); //Infinite water θωθ
            //recipeCr.AddIngredient(ItemID.AshBlock, 2997); //The Underworld is massive

            //recipeCr.AddIngredient(ItemID.CrimstoneBlock, 999); //Crimson isn't as cool as corruption but I need to include it anyway.

            //recipeCr.AddIngredient(ItemID.PearlstoneBlock, 999); //Hallow
            //recipeCr.AddTile(TileID.LunarCraftingStation);
            //recipeCr.SetResult(this);
            //recipeCr.AddRecipe();
        }
    }
}