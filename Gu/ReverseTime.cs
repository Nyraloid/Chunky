using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class ReverseTime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Reverse Time");
            Description.SetDefault("Instant Skill, lvl 4");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("ReverseTime"), 1, true);
            modPlayer.CanUseTimeReverse = true;
            modPlayer.HasInstant = true;
            player.accWatch = 3;
        }
    }
}