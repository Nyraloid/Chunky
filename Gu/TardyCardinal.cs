using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class TardyCardinal : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tardy Cardinal");
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
            player.AddBuff(mod.BuffType("TardyCardinal"), 1, true);
            modPlayer.HasInfinite = true;
            player.moveSpeed += 7;
            player.lifeRegen += 1;
            player.manaRegen += 1;
            Main.time++;
        }
    }
}