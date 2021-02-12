using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class HalfTime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Half-Time");
            Description.SetDefault("Infinite Skill, lvl 1");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("HalfTime"), 1, true);
            modPlayer.HasInfinite = true;
            if (ChunkyWorld.EveryOther && ChunkyWorld.TOKIWOTOMARE == 0 && ChunkyWorld.TimeSkipping == 0) Main.time--;
            player.moveSpeed += 3;
        }
    }
}