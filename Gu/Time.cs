using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class Time : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Freeze Time");
            Description.SetDefault("Normal Skill, lvl 3");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("Time"), 1, true);
            modPlayer.CanUseTimeMagic = true;
            modPlayer.HasNormal = true;
            player.accWatch = 3;
        }
    }
}