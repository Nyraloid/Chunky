using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class BabyDragonScale : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Baby Dragon's Flame");
            Description.SetDefault("Instant Skill, lvl 4");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            modPlayer.HasInstant = true;
            player.wingTimeMax += 20;
            player.statManaMax2 += 20;
            player.statLifeMax2 += 20;
            player.endurance += 0.015f;
            if (Chunky.Skill2.JustPressed && !modPlayer.noInstant)
            {
                player.AddBuff(mod.BuffType("BabyDomain"), 30, true);
                player.AddBuff(mod.BuffType("NoInstant"), 30, true);
            }
        }
    }
}