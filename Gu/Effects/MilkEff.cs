using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu.Effects
{
    public class MilkEff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Calcium Overdose");
            Description.SetDefault("b o n e d");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.statLifeMax2 += 25;
            player.endurance += 0.01f;
            player.noFallDmg = true;
        }
    }
}