using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Chunky;
using Steamworks;

namespace Chunky
{
    public partial class ChunkyWorld : ModWorld
    {
        public static int TOKIWOTOMARE = 0;
        public static int TimeSkipping = 0;
        public static bool EveryOther = false;
        public static bool gurnard = false;

        //Disaster
        public static bool disaster = false; //if there's one up
        public static bool downedDisaster = false; //if it's been defeated
        public static int NumDisasters = 0; //Number of disasters the world has experienced. The higher this is the less frequent but harder they become.

        public override void Initialize()
        {
            Main.invasionSize = 0;
            disaster = false;
            downedDisaster = false;
            //now that I think about it, why isn't there anything else in here yet?
        }

        public override void PostUpdate()
        {
            if (TOKIWOTOMARE > 0) Main.time--; //Toki wo tomare
            if (TOKIWOTOMARE > 0) TOKIWOTOMARE--; //Toki wo ugoki desu
            if (TimeSkipping > 0) TimeSkipping--; //this is just to stop the time skip

            //Every other frame this will be true, though I'm not sure when that'll be useful
            EveryOther = !EveryOther;
            //I used it in time skip cuz I decided to slow everything down during it.
            //That way you can actually see through your enemy's movements.

            if (TimeSkipping > 0 && EveryOther) Main.time--; //Gotta double up on time

            //Disaster stuff
            if (disaster)
            {
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    //Checks and reports progress if disaster is at spawn
                    CustomInvasion.CheckCustomInvasionProgress();

                    if (Main.dayTime) Main.eclipse = true;
                    else
                    {
                        Main.bloodMoon = true;
                        Main.pumpkinMoon = true;
                        Main.snowMoon = true;
                    }

                    if (EveryOther) Main.time--; //double the time of day and night during disasters becuase skeletron
                }
                //Updates the disaster while it heads to spawn point and ends it
                CustomInvasion.UpdateCustomInvasion();
                //What does "ends it" mean? Idk how this is useful. I didn't know you could be unable to update anything
            }
        }

        //Save downed data
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedDisaster) downed.Add("Disaster"); //we have to see how to add to the description for bosschecklist

            return new TagCompound {
                {"downed", downed},
                {"NumDisasters", NumDisasters}
            };
        }
        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDisaster = downed.Contains("Disaster");
            NumDisasters = tag.GetInt("NumDisasters");
        }

        //Sync data
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedDisaster = flags[0];
        }
        //We probably dont need this since not multiplayer mod but oh well
    }
}