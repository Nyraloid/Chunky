using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class LastRhymes : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blooming Power");
            Description.SetDefault("Normal Skill, lvl 6");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("LastRhymes"), 1, true);
            modPlayer.HasNormal = true;
            if (Chunky.Skill1.JustPressed && !player.HasBuff(mod.BuffType("NoRhymes"))) player.AddBuff(mod.BuffType("NoRhymes"), 1, true);
        }
    }
}