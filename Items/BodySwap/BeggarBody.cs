using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.BodySwap
{
    public class BeggarBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beggar's Body");
            Tooltip.SetDefault("Old, pathetic, and dying");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = 0;
            item.rare = ItemRarityID.Gray;
            item.maxStack = 1;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.noUseGraphic = true;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<ChunkyPlayer>().BodyType != "Beggar") return true;

            return false;
        }

        public override bool UseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            //Give normal body item
            if (modPlayer.BodyType == null || modPlayer.BodyType == "OG")
            {
                Item.NewItem(player.position, mod.ItemType("OriginalBody"));
            }
            //it's crafted with the original body item but im still including this

            //Give test body item
            if (modPlayer.BodyType == "Test")
            {
                Item.NewItem(player.position, mod.ItemType("TestBody"));
            }

            //Give god body item
            if (modPlayer.BodyType == "God")
            {
                Item.NewItem(player.position, mod.ItemType("GodBody"));
            }

            //Change to test body
            modPlayer.BodyType = "Beggar";
            player.statLifeMax = modPlayer.Health[2];
            player.statLifeMax2 = modPlayer.Health[2];
            player.statManaMax2 = modPlayer.Mana[2];
            player.statManaMax = modPlayer.Mana[2];
            player.statLife = modPlayer.Health2[2];
            player.statMana = modPlayer.Mana2[2];

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Ale, 3); //dumb dumb got drunk and become dumb dumb
            recipe1.AddIngredient(null, "SoulOfWight", 20); //a soul
            recipe1.AddIngredient(null, "Fetus", 1); //New life
            recipe1.AddIngredient(ItemID.SoulofFright, 7); //scared old man
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.AddTile(TileID.CookingPots); //We're gonna change these to the lab once we make that
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}