using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class SandTablet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Forbidden Knowledge");
            Description.SetDefault("Infinite Skill, lvl 6");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("SandTablet"), 1, true);
        }
    }
}