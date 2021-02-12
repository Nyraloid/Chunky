using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class SandTablet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Tablet");
            if (!NPC.downedMoonlord) Tooltip.SetDefault("An artifact left by the Lunatic Cultist, the master of skills...\nThere is a seal on the knowledge held within.");
            else Tooltip.SetDefault("An artifact left by the Lunatic Cultist, the master of skills...\nThe knowledge held within awaits your reading it.");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 26;
            item.value = 0;
            item.rare = ItemRarityID.Expert;

            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (!NPC.downedMoonlord) return false;
            if (modPlayer.HasInfinite) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("SandTablet"), 1, true);
            return true;
        }
    }
}