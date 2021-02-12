using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.BodySwap
{
    public class GodBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diety Physique");
            Tooltip.SetDefault("Eternal Life\nUnfortunately, the materials available in this small world cannot fund true eternal life.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = 99999999;
            item.rare = ItemRarityID.Purple;
            item.maxStack = 1;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.noUseGraphic = true;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<ChunkyPlayer>().BodyType != "God") return true;

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

            //Give beggar body item
            if (modPlayer.BodyType == "Beggar")
            {
                Item.NewItem(player.position, mod.ItemType("BeggarBody"));
            }

            //Change to test body
            //player.statLife = modPlayer.Health2[3];
            //player.statMana = modPlayer.Mana2[3];
            modPlayer.BodyType = "God";
            player.statLifeMax = modPlayer.Health[3]; //we're doing it like this
            player.statManaMax = modPlayer.Health[3];
            player.statLifeMax2 = modPlayer.Health[3]; //This is the actual health
            player.statManaMax2 = modPlayer.Mana[3];
            //player.statLifeMax2 += 200;
            //Main.NewText(player.statLifeMax2);
            //Main.NewText(player.statLife);
            player.statLife = modPlayer.Health2[3];
            player.statMana = modPlayer.Mana2[3];
            //Main.NewText(player.statLife);

            return true;
        }

        public override void AddRecipes()
        {
            //idk if we want this recipe to only work during a calamity, but we do only want it to work with maxed out original body
            //if (Main.player[Main.myPlayer].GetModPlayer<ChunkyPlayer>().Mana[0] >= 200 && Main.player[Main.myPlayer].GetModPlayer<ChunkyPlayer>().Health[0] >= 500)
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.CelestialStone, 1); //because it's very mystical
            recipe1.AddIngredient(null, "OriginalBody", 1); //The player's original body
            recipe1.AddIngredient(null, "SoulOfWight", 300); //Heavily condensed soul
            recipe1.AddIngredient(null, "Fetus", 5); //New life
            recipe1.AddIngredient(null, "TimeDroplet", 5); //Longevity
            recipe1.AddIngredient(null, "Ginseng", 5); //For all the reasons ginseng is and was used in china
            recipe1.AddIngredient(null, "Durian", 5); //Because?
                                                      //We need more mystical stuff
                                                      //Fragment of the heavens crafted from the lunar fragments and luminite bars
                                                      //10,000 year old rum fished in the ocean during a calamity
            recipe1.AddTile(null, "LifePodTile"); //a place to build the body
            recipe1.AddTile(TileID.Solidifier); //solidify the flesh
            recipe1.AddTile(TileID.Blendomatic); //uhhh
            recipe1.AddTile(TileID.SteampunkBoiler); //uuuhhhhhhh
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}