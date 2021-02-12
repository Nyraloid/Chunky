using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Chunky
{
    public class CustomInvasion
    {
        //idk how to make it elegantly change the weight for these in editspawns but i still need this list for progressing the disaster
        public static int[] invaders = {
            //Normal
            NPCID.GiantTortoise,
            NPCID.Derpling,
            NPCID.GiantFlyingFox,
            NPCID.Moth,

            //Minibosses
            NPCID.MartianSaucerCore,
            NPCID.PirateShip,
            NPCID.SkeletronHead,
            NPCID.QueenBee,
            NPCID.EaterofWorldsHead,
            NPCID.EyeofCthulhu,
            NPCID.KingSlime,

            //Bosses
            NPCID.MoonLordCore,
            NPCID.IceQueen,
            NPCID.SantaNK1,
            NPCID.Everscream,
            NPCID.Pumpking,
            NPCID.MourningWood,
            NPCID.Golem,
            NPCID.Plantera,
            NPCID.SkeletronPrime,
            NPCID.Retinazer,
            NPCID.Spazmatism,
            NPCID.TheDestroyer,
        };
        //We don't need it anymore cuz im progressing the disaster differently

        //Setup for an Invasion
        public static void StartCustomInvasion()
        {
            //If an invasion is at 0 but isn't gone, stop it
            if (Main.invasionType != 0 && Main.invasionSize == 0)
            {
                Main.invasionType = 0;
            }

            //Now setting up the invasion
            if (Main.invasionType == 0)
            {
                //Checks amount of players for scaling
                int numPlayers = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
                    {
                        numPlayers++;
                    }
                }
                //I could probably remove that since this mod is already extremely multiplayer incompatible but I'll keep it

                int level = 0; //kinda represents the intensity of the calamity
                if (ChunkyWorld.NumDisasters <= 10) level = 5;
                if (ChunkyWorld.NumDisasters > 10 && ChunkyWorld.NumDisasters <= 15) level = 10;
                if (ChunkyWorld.NumDisasters > 15) level = ChunkyWorld.NumDisasters;


                if (numPlayers > 0)
                {
                    //Invasion setup
                    Main.invasionType = -1; //Not going to be using an invasion that is positive since those are vanilla invasions
                    ChunkyWorld.disaster = true; //There is a disaster
                    Main.invasionSize = 20 * level * numPlayers; //300 kills per player
                    Main.invasionSizeStart = Main.invasionSize; //Initial size is the max size, then it goes to 0 and ends
                    Main.invasionProgress = 0; //Starts at 0 progress
                    Main.invasionProgressIcon = 0 + 3; //not sure
                    Main.invasionProgressWave = 0; //also not sure
                    Main.invasionProgressMax = Main.invasionSizeStart; //Supposedly, Progress is how many things have been killed and the maximum is starting size?
                    Main.invasionWarn = 3600; //This doesn't really matter, as this does not work, I like to keep it here anyways
                    if (Main.rand.Next(2) == 0) //50% chance
                    {
                        Main.invasionX = 0.0; //Starts invasion immediately rather than wait for it to spawn
                        return;
                    }
                    //You'd best be well prepared, little one
                    Main.invasionX = (double)Main.maxTilesX; //Set the initial starting location of the invasion to the edge of the world
                }
            }
        }

        //Text for messages and syncing
        public static void CustomInvasionWarning()
        {
            String text = ""; //ok so we're using text as a variable and then going through those singleplayer and server things
            if (Main.invasionX == (double)Main.spawnTileX) //If it's begun
            {
                text = "A calamity descends!";
            }
            if (Main.invasionSize <= 0) //If it ended
            {
                text = "The disaster dissipates... " + ChunkyWorld.NumDisasters + " have been defeated so far.";
            }
            if (Main.netMode == NetmodeID.SinglePlayer) //if single player
            {
                Main.NewText(text, 175, 75, 255, false);
                return;
            }
            if (Main.netMode == NetmodeID.Server) //if it's a server, which it should not be with this mod
            {
                //Sync with net
                NetMessage.SendData(MessageID.ChatText, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0); //idk why its so different
            }
        }

        //Updating the invasion
        public static void UpdateCustomInvasion()
        {
            if (ChunkyWorld.disaster) //if there's an invasion
            {
                if (Main.invasionSize <= 0) //End it if the size goes 0 or lower, which I still think is the amount of enemies
                {
                    ChunkyWorld.disaster = false; //no more disaster
                    ChunkyWorld.NumDisasters++; //Another disaster passes
                    CustomInvasionWarning(); //call back on that cuz it ended and we need to show the text
                    Main.invasionType = 0; //no invasion is up
                    Main.invasionDelay = 0; //idk what that is
                }

                //Do not do the rest if invasion already at spawn
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    return;
                }
                //If you return it stops this code from continuing, even if it's a void as seen here

                //Update when the invasion gets to Spawn
                float moveRate = (float)Main.dayRate; //did not know dayRate is a thing. That might be a more elegant way of stopping, slowing, and speeding up time

                if (Main.invasionX > (double)Main.spawnTileX) //If the invasion is further away in the positive direction, which is probably to the right
                {
                    Main.invasionX -= (double)moveRate; //moving the invasion closer to spawn at the speed of the day

                    //if we go too far then we need to set to spawn location
                    if (Main.invasionX <= (double)Main.spawnTileX)
                    {
                        Main.invasionX = (double)Main.spawnTileX;
                        CustomInvasionWarning();
                    }
                    else
                    {
                        Main.invasionWarn--;
                    }
                }
                else
                {
                    //Same thing but for the left or negative direction
                    if (Main.invasionX < (double)Main.spawnTileX)
                    {
                        Main.invasionX += (double)moveRate;
                        if (Main.invasionX >= (double)Main.spawnTileX)
                        {
                            Main.invasionX = (double)Main.spawnTileX;
                            CustomInvasionWarning();
                        }
                        else
                        {
                            Main.invasionWarn--;
                        }
                    }
                }
            }
        }

        //Checks the players' progress in invasion
        public static void CheckCustomInvasionProgress()
        {
            //Not really sure what this is
            if (Main.invasionProgressMode != 2)
            {
                Main.invasionProgressNearInvasion = false;
                return;
            }

            
            //Checks if NPCs are in the spawn area to set the flag, which I do not know what it does
            /*
            bool flag = false;
            Player player = Main.player[Main.myPlayer];
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            int num = 5000;
            int icon = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active)
                {
                    icon = 0;
                    int type = Main.npc[i].type;
                    for (int n = 0; n < invaders.Length; n++)
                    {
                        if (type == invaders[n])
                        {
                            Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
                            if (rectangle.Intersects(value))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            Main.invasionProgressNearInvasion = flag;
            */

            int progressMax3 = 1; //why is it max3 though

            //If the custom invasion is up, set the max progress as the initial invasion size
            if (ChunkyWorld.disaster)
            {
                progressMax3 = Main.invasionSizeStart;
            }

            //If the custom invasion is up and the enemies are at the spawn pos
            if (ChunkyWorld.disaster && (Main.invasionX == (double)Main.spawnTileX))
            {
                //Shows the UI for the invasion
                Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, 0, 0);
                //Makes sense
                //Invasionsize is indeed determined by how many things have died
            }

            //Syncing start of invasion
            foreach (Player p in Main.player) //I think this is multiplayer again
            {
                NetMessage.SendData(MessageID.InvasionProgressReport, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
            }
        }
    }
}