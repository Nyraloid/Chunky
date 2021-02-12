using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class Terror : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("...");
            Description.SetDefault("??? Skill, lvl ?\nWe can see you, we can hear you,\nwe can almost feel you.\nYou are growing well...");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("Terror"), 1, true);
            modPlayer.Terror = true;
            modPlayer.tTime++;
            player.statLifeMax2 += 100;
            modPlayer.tsDuration += (int)(modPlayer.tTime / 360);
            modPlayer.kcDuration += (int)(modPlayer.tTime / 240);
        }
    }
}