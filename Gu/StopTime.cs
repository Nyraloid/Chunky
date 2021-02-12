using Terraria;
using Terraria.ModLoader;
using System;

namespace Chunky.Gu
{
    public class StopTime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Vampiric Time Stop");
            Description.SetDefault("Armor Skill, lvl 7");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            //We dont need this every other second thing for adding to AddTime since the dividing takes care of its job already
            //Math.DivRem((int)Main.time, 2, out int n);
            if (modPlayer.BodyType == null || modPlayer.BodyType == "OG")
            {
                if (ChunkyWorld.TOKIWOTOMARE > 0) modPlayer.AddTime[0]++;
                if (modPlayer.AddTime[0] < 113400) modPlayer.tsDuration += (int)(modPlayer.AddTime[0] / 90); //dividing by the amount of seconds it takes to increase duration by 1 seconds
                if (modPlayer.AddTime[0] >= 113400) modPlayer.tsDuration += (int)((modPlayer.AddTime[0]) / 600) + 1071; //I wanted to make it grow at sqrt(x) rate but that was too slow
            }
            if (modPlayer.BodyType == "Beggar")
            {
                if (ChunkyWorld.TOKIWOTOMARE > 0) modPlayer.AddTime[1]++;
                if (modPlayer.AddTime[1] < 226800) modPlayer.tsDuration += (int)(modPlayer.AddTime[1] / 180);
                if (modPlayer.AddTime[1] >= 226800) modPlayer.tsDuration += (int)((modPlayer.AddTime[1]) / 1200) + 2142; //I just multiplied everything by 2 hoping thatll make it take twice as long
            }
            if (modPlayer.BodyType == "God")
            {
                if (ChunkyWorld.TOKIWOTOMARE > 0) modPlayer.AddTime[2]++;
                modPlayer.tsDuration += (int)(modPlayer.AddTime[2] / 60); //every second you gain a second.
                //Im thinking I just wont have it slow down cuz that's totally balanced right
            }


            //if (ChunkyWorld.TOKIWOTOMARE > 0 && n == 0) player.statMana--;
        }
    }
}