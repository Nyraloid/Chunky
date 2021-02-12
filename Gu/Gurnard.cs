using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class Gurnard : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gurnard Eye");
            Description.SetDefault("Infinite Skill, lvl 5");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            modPlayer.HasInfinite = true;
            player.AddBuff(mod.BuffType("Gurnard"), 1, true);
            player.endurance -= 0.02f;
            player.statDefense -= 2;
            player.statLifeMax2 -= 25;
            player.statManaMax2 -= 10;
        }
    }
}