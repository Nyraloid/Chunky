using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.BodySwap
{
    public class OriginalBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Original Body");
            Tooltip.SetDefault("Return to the original body");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = 0;
            item.rare = ItemRarityID.Red;
            item.maxStack = 1;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.noUseGraphic = true;
            item.consumable = true;
        }


        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<ChunkyPlayer>().BodyType != null && player.GetModPlayer<ChunkyPlayer>().BodyType != "OG") return true;

            return false;
        }

        public override bool UseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            //Give test body item
            if (modPlayer.BodyType == "Test") Item.NewItem(player.position, mod.ItemType("TestBody"));

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
            modPlayer.BodyType = "OG";
            player.statLifeMax = modPlayer.Health[0];
            player.statLifeMax2 = modPlayer.Health[0];
            player.statManaMax2 = modPlayer.Mana[0];
            player.statManaMax = modPlayer.Mana[0];
            player.statLife = modPlayer.Health2[0];
            player.statMana = modPlayer.Mana2[0];

            return true;
        }
    }
}