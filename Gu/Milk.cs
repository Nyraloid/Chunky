using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class Milk : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Calcium Overdose");
            Description.SetDefault("Instant Skill, lvl 1");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            modPlayer.HasInstant = true;
            player.AddBuff(mod.BuffType("Milk"), 1);
            player.statLifeMax2 += 25;
            player.endurance += 0.01f;
            if (Chunky.Skill2.JustPressed && !modPlayer.noInstant)
            {
                player.AddBuff(mod.BuffType("NoInstant"), 30 * 60);
                player.AddBuff(mod.BuffType("MilkEff"), 15 * 60);
            }
        }
    }
}