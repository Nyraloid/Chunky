using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;

namespace Chunky.Gu.Effects
{
    public class NoRhymes : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Balance");
            Description.SetDefault("Sacrifice your life for a massive power boost and immunity to damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            modPlayer.tsCoolDown -= 360;
            modPlayer.tsDuration += 120;
            modPlayer.kcCoolDown -= 360;
            modPlayer.kcCoolDown += 120;
            //This could go horribly wrong

            player.AddBuff(mod.BuffType("NoRhymes"), 1, true);
            player.AddBuff(BuffID.PotionSickness, 1, true);
            player.AddBuff(BuffID.ManaSickness, 1, true);
            Math.DivRem((int)Main.time, 5, out int n);
            if (n == 0) player.statLife--;
            if (player.statLife >= 20) player.statLifeMax = player.statLife;
            player.maxRunSpeed += 10;
            player.moveSpeed += 20;
            player.jumpSpeedBoost += 5;
            player.wingTimeMax = -1;
            player.ignoreWater = true;
            player.lavaImmune = true;
            player.immune = true;

            player.allDamage *= 10; //This couldn't possibly be overpowered
            //player.manaCost = 0;

            if (player.statLife < 0) player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "'s wizarding rampage has come to an end."), 1, 0, false);
        }
    }
}