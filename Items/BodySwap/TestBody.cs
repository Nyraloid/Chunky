using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.BodySwap
{
    public class TestBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Body");
            Tooltip.SetDefault("Completely white\n20 health and 0 mana");
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
            if (player.GetModPlayer<ChunkyPlayer>().BodyType != "Test") return true;

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

            //Give beggar body item
            if (modPlayer.BodyType == "Beggar")
            {
                Item.NewItem(player.position, mod.ItemType("BeggarBody"));
            }

            //Give god body item
            if (modPlayer.BodyType == "God")
            {
                Item.NewItem(player.position, mod.ItemType("GodBody"));
            }

            //Change to test body
            modPlayer.BodyType = "Test";
            player.statLifeMax = modPlayer.Health[1];
            player.statLifeMax2 = modPlayer.Health[1];
            player.statManaMax2 = modPlayer.Mana[1];
            player.statManaMax = modPlayer.Mana[1];
            player.statLife = modPlayer.Health2[1];
            player.statMana = modPlayer.Mana2[1];

            return true;
        }
    }
}