using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class LittleStar : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Little Star");
            Description.SetDefault("Infinite Skill, lvl 2");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("LittleStar"), 1, true);
            modPlayer.HasInfinite = true;
            if (Main.dayTime == true)
            {
                Main.dayTime = false;
                Main.time = 0.0;
            }

            if (Main.rand.Next(3600 * 2) == 0) player.QuickSpawnItem(ItemID.Cloud, 1);
            if (Main.rand.Next(3600 * 3) == 0) player.QuickSpawnItem(ItemID.RainCloud, 1);
            if (Main.rand.Next(3600 * 5) == 0) player.QuickSpawnItem(ItemID.FallenStar, 1);
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.Starfury, 1);
            if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(ItemID.LuckyHorseshoe, 1);
            if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(ItemID.ShinyRedBalloon, 1);
        }
    }
}