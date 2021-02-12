using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;

namespace Chunky.NPCs
{
    public class ChunkyGlobalNPCs : GlobalNPC
    {
        public float xV = 0;
        public float yV = 0;
        public float xP = 0;
        public float yP = 0;
        private int ai = 0;

        //Mandom
        private Vector2[] SaxPos = new Vector2[361];
        private Vector2[] SaxVel = new Vector2[361];
        private int[] SaxHP = new int[361];
        private int[] ai2 = new int[361]; //might be completely redundant but idk

        //Mandom 2
        private Vector2[] SaxPosD = new Vector2[121];
        private Vector2[] SaxVelD = new Vector2[121];
        private int[] SaxHPD = new int[121];
        private int[] ai2D = new int[121];

        //tbh idk what this does
        public override bool PreAI(NPC npc)
        {
            if (ChunkyWorld.TOKIWOTOMARE > 0 && npc.type != mod.NPCType("TimeMerchant")) return false;
            if (ChunkyWorld.TimeSkipping > 0 && npc.type != mod.NPCType("TimeMerchant")) return false;
            return true;
        }

        //all global things need this
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void PostAI(NPC npc)
        {
            Player player = Main.player[npc.target]; //Fix this //Fix what?
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            //Za Warudo
            if (ChunkyWorld.TOKIWOTOMARE > 0 && npc.type != mod.NPCType("TimeMerchant"))
            {
                //recording xV and yV as respective velocities
                if (xV == 0 && yV == 0)
                {
                    xV = npc.velocity.X;
                    yV = npc.velocity.Y;
                }
                npc.velocity.X = 0;
                npc.velocity.Y = 0;

                //record xP and yP as position and reset position to xP and yP every tick
                if (xP == 0 && yP == 0)
                {
                    xP = npc.position.X;
                    yP = npc.position.Y;
                }
                else
                {
                    npc.position.X = xP;
                    npc.position.Y = yP;
                }

                //hopefully this will pause the ai
                if (ai == 0) ai = npc.aiStyle;
                else npc.aiStyle = 0;
                //I  think it works so im gonna try to implement that on mandom
            }

            //Undoing the effects of time stop
            else
            {
                if (xV != 0 || yV != 0)
                {
                    npc.velocity.X = xV;
                    npc.velocity.Y = yV;
                    xV = 0;
                    yV = 0;
                }
                xP = 0;
                yP = 0;
                if (ai != 0) npc.aiStyle = ai;
            }

            //King Crimson
            if (ChunkyWorld.TimeSkipping > 0)
            {
                //This erases the AI and makes the velocity permanently equal to 40% the initial velocity
                if (xV == 0 && yV == 0)
                {
                    xV = npc.velocity.X;
                    yV = npc.velocity.Y;
                }
                npc.velocity.X = xV * 0.4f;
                npc.velocity.Y = yV * 0.4f;
            }
            else
            {
                if (xV != 0 || yV != 0)
                {
                    npc.velocity.X = xV;
                    npc.velocity.Y = yV;
                }
            }

            //Mandom
            if (ChunkyWorld.TOKIWOTOMARE == 0 && modPlayer.CanUseTimeReverse)
            {
                for (int i = 0; i < 360; i++)
                {
                    SaxPos[i] = SaxPos[i + 1];
                    SaxVel[i] = SaxVel[i + 1];
                    SaxHP[i] = SaxHP[i + 1];
                    ai2[i] = ai2[i + 1];
                }
                SaxPos[360] = npc.position;
                SaxVel[360] = npc.velocity;
                SaxHP[360] = npc.life;
                ai2[360] = npc.aiStyle;

                if (ChunkyPlayer.TimeReversed)
                {
                    npc.position = SaxPos[0];
                    npc.velocity = SaxVel[0];
                    npc.life = SaxHP[0];
                    npc.aiStyle = ai2[0];
                }
            }

            //Mandom for dio armor
            if (ChunkyWorld.TOKIWOTOMARE == 0 && modPlayer.DIO)
            {
                for (int i = 0; i < 120; i++)
                {
                    SaxPosD[i] = SaxPosD[i + 1];
                    SaxVelD[i] = SaxVelD[i + 1];
                    SaxHPD[i] = SaxHPD[i + 1];
                    ai2D[i] = ai2D[i + 1];
                }
                SaxPosD[120] = npc.position;
                SaxVelD[120] = npc.velocity;
                SaxHPD[120] = npc.life;
                ai2D[120] = npc.aiStyle;

                if (ChunkyPlayer.DioDeath)
                {
                    npc.position = SaxPosD[0];
                    npc.velocity = SaxVelD[0];
                    npc.life = SaxHPD[0];
                    npc.aiStyle = ai2D[0];
                }
            }

            //During a disaster we don't want things to despawn
            if (ChunkyWorld.disaster && (Main.invasionX == (double)Main.spawnTileX))
            {
                npc.timeLeft = 1000;
            }
        }

        //Spawn pool for disasters
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            //if there's a disaster and it's at spawn already
            if (ChunkyWorld.disaster && (Main.invasionX == (double)Main.spawnTileX))
            {
                //How do I change spawns based on biome?
                //Like this:
                /*
                if (Main.player[Main.myPlayer].ZoneSkyHeight)
                {
                    //Common
                    pool.Add(NPCID.WyvernHead, 0.8f);
                    pool.Add(NPCID.MartianDrone, 0.8f);

                    //Minibosses

                    //Bosses
                    if (ChunkyWorld.NumDisasters > 15) pool.Add(NPCID.MoonLordCore, 0.003f);
                    if (ChunkyWorld.NumDisasters > 10)
                    {
                        pool.Add(NPCID.MartianSaucerCore, 0.01f);
                        pool.Add(NPCID.Pumpking, 0.03f);
                    }
                }
                if (Main.player[Main.myPlayer].ZoneOverworldHeight)
                {
                    //Common
                    if (Main.dayTime)
                    {
                        pool.Add(NPCID.Eyezor, 1f);
                        pool.Add(NPCID.Vampire, 1f);
                        pool.Add(NPCID.DrManFly, 1f);
                        pool.Add(NPCID.Butcher, 1f);
                        pool.Add(NPCID.Reaper, 1f);
                    }
                    pool.Add(NPCID.GoblinSummoner, 0.05f);
                    pool.Add(NPCID.Mimic, 0.1f);

                    //Minibosses
                    if (Main.dayTime)
                    {
                        pool.Add(NPCID.Mothron, 0.25f);
                        pool.Add(NPCID.KingSlime, 0.05f);
                    }

                    //Bosses
                    if (ChunkyWorld.NumDisasters > 15) pool.Add(NPCID.MoonLordCore, 0.0005f);

                    if (!Main.dayTime)
                    {
                        //Common
                        if (ChunkyWorld.NumDisasters > 10)
                        {
                            pool.Add(NPCID.HeadlessHorseman, 1f);
                        }
                        pool.Add(NPCID.Clown, 1f);
                        pool.Add(NPCID.PossessedArmor, 1f);

                        //Minibosses
                        pool.Add(NPCID.EyeofCthulhu, 0.05f);

                        //Bosses
                        if (ChunkyWorld.NumDisasters > 10)
                        {
                            pool.Add(NPCID.Pumpking, 0.003f);
                            pool.Add(NPCID.MourningWood, 0.004f);
                        }
                        pool.Add(NPCID.SkeletronPrime, 0.005f);
                        pool.Add(NPCID.Retinazer, 0.005f);
                        pool.Add(NPCID.Spazmatism, 0.005f);
                        pool.Add(NPCID.TheDestroyer, 0.005f);
                    }
                }
                if (Main.player[Main.myPlayer].ZoneJungle)
                {
                    //Common
                    pool.Add(NPCID.GiantTortoise, 0.7f);
                    if (Main.dayTime) pool.Add(NPCID.Derpling, 0.7f); else pool.Add(NPCID.GiantFlyingFox, 0.7f);
                    pool.Add(NPCID.Moth, 0.4f);

                    //Minibosses
                    pool.Add(NPCID.QueenBee, 0.1f);

                    //Bosses
                    if (ChunkyWorld.NumDisasters > 10)
                    {
                        pool.Add(NPCID.Golem, 0.005f);
                        pool.Add(NPCID.Plantera, 0.01f);
                    }
                }
                if (Main.player[Main.myPlayer].ZoneDesert)
                {
                    //Common
                    pool.Add(NPCID.SandShark, 0.1f);
                    pool.Add(NPCID.DuneSplicerHead, 0.1f);

                    //Minibosses
                    pool.Add(NPCID.SandElemental, 0.1f);

                    //Bosses
                    if (ChunkyWorld.NumDisasters > 10)
                    {
                        pool.Add(NPCID.Golem, 0.01f); //idk why i just think golem belongs in the desert too
                    }
                }
                if (Main.player[Main.myPlayer].ZoneBeach)
                {
                    //Common
                    pool.Add(NPCID.DuneSplicerHead, 0.7f);

                    //Minibosses
                    //pool.Add(NPCID.PirateShip, 0.1f);
                    //pool.Add(NPCID.PirateCaptain, 0.08f);
                    pool.Remove(NPCID.PirateCaptain);
                    pool.Add(NPCID.PirateCaptain, 0.08f);

                    //Bosses
                    if (ChunkyWorld.NumDisasters > 10)
                    {
                        pool.Add(NPCID.DukeFishron, 0.003f);
                    }
                }
                */

                pool.Clear();

                //Intensity
                if (ChunkyWorld.NumDisasters <= 10)                                      //1st order
                {
                    //Height
                    if (Main.player[Main.myPlayer].ZoneSkyHeight)
                    {
                        pool.Add(NPCID.WyvernHead, 1f);
                        pool.Add(NPCID.MartianDrone, 1f);
                    }
                    if (Main.player[Main.myPlayer].ZoneOverworldHeight)
                    {
                        if (Main.dayTime)
                        {
                            pool.Add(NPCID.Mothron, 0.3f);
                            pool.Add(NPCID.Eyezor, 1f);
                            pool.Add(NPCID.Vampire, 1f);
                            pool.Add(NPCID.DrManFly, 1f);
                            pool.Add(NPCID.Butcher, 1f);
                            pool.Add(NPCID.Reaper, 1f);
                            pool.Add(NPCID.KingSlime, 0.05f);
                        }
                        else
                        {
                            pool.Add(NPCID.SkeletronPrime, 0.01f); //big uh oh if it turns day, even though you should be able to defeat him before then
                            pool.Add(NPCID.Retinazer, 0.1f);
                            pool.Add(NPCID.Spazmatism, 0.1f);
                            pool.Add(NPCID.TheDestroyer, 0.1f);
                            pool.Add(NPCID.EyeofCthulhu, 0.07f);
                            pool.Add(NPCID.Clown, 0.5f);
                            //pool.Add(NPCID.HeadlessHorseman, 0.7f);
                            //They take up too much space and progress the event too much
                            pool.Add(NPCID.Poltergeist, 0.7f);
                            pool.Add(NPCID.Hellhound, 0.7f);
                        }
                        pool.Add(NPCID.GoblinSummoner, 0.7f);
                        pool.Add(NPCID.Mimic, 0.1f);
                    }
                    if (Main.player[Main.myPlayer].ZoneDirtLayerHeight || Main.player[Main.myPlayer].ZoneRockLayerHeight)
                    {
                        pool.Add(NPCID.SkeletonArcher, 1f);
                        //pool.Add(NPCID.PigronHallow, 1f);
                        pool.Add(NPCID.Mimic, 0.5f);
                    }

                    //Biome
                    if (Main.player[Main.myPlayer].ZoneSnow)
                    {
                        pool.Add(NPCID.IceGolem, 1f);
                        pool.Add(NPCID.Krampus, 1f);
                        pool.Add(NPCID.IceTortoise, 1f);
                        pool.Add(NPCID.IceElemental, 1f);
                        //pool.Add(NPCID.PigronHallow, 1f);
                        //pigron is way too weak
                    }
                    if (Main.player[Main.myPlayer].ZoneDesert)
                    {
                        pool.Add(NPCID.SandElemental, 1f);
                        pool.Add(NPCID.SandShark, 1f);
                        pool.Add(NPCID.DuneSplicerHead, 1f);
                        pool.Add(NPCID.DesertDjinn, 1f);
                    }
                    if (Main.player[Main.myPlayer].ZoneBeach)
                    {
                        pool.Add(NPCID.Squid, 0.01f);
                        pool.Add(NPCID.SeaSnail, 0.01f);
                        //pool.Add(NPCID.Shark, 1f);
                        pool.Add(NPCID.DuneSplicerHead, 1f);
                        pool.Add(NPCID.PirateShip, 0.1f); //idk why but pirate stuff works fine everywhere except the ocean
                        pool.Add(NPCID.PirateCaptain, 0.3f);
                    }
                    if (Main.player[Main.myPlayer].ZoneJungle)
                    {
                        pool.Add(NPCID.GiantTortoise, 1f);
                        pool.Add(NPCID.Moth, 0.5f);
                        pool.Add(NPCID.Derpling, 1f);
                        pool.Add(NPCID.GiantFlyingFox, 1f);
                        pool.Add(NPCID.GiantMossHornet, 1f);
                        pool.Add(NPCID.QueenBee, 0.07f);
                    }
                    if (Main.player[Main.myPlayer].ZoneCorrupt)
                    {
                        pool.Add(NPCID.SeekerHead, 1f);
                        //pool.Add(NPCID.Corruptor, 1f);
                        pool.Add(NPCID.CursedHammer, 1f);
                        pool.Add(NPCID.BigMimicCorruption, 0.1f);
                        pool.Add(NPCID.EaterofWorldsHead, 0.07f);
                    }
                    if (Main.player[Main.myPlayer].ZoneCrimson)
                    {
                        pool.Add(NPCID.Herpling, 1f);
                        pool.Add(NPCID.IchorSticker, 1f);
                        pool.Add(NPCID.CrimsonAxe, 1f);
                        pool.Add(NPCID.BigMimicCrimson, 0.1f);
                        pool.Add(NPCID.BrainofCthulhu, 0.07f);
                    }
                    if (Main.player[Main.myPlayer].ZoneHoly)
                    {
                        pool.Add(NPCID.EnchantedSword, 1f);
                        pool.Add(NPCID.Unicorn, 1f);
                        pool.Add(NPCID.RainbowSlime, 1f);
                        pool.Add(NPCID.BigMimicHallow, 0.1f);
                    }
                }
                //Intensity
                if (ChunkyWorld.NumDisasters <= 15 && ChunkyWorld.NumDisasters > 10)                            //2nd order
                {
                    //Height
                    if (Main.player[Main.myPlayer].ZoneSkyHeight)
                    {
                        pool.Add(NPCID.WyvernHead, 1f);
                        pool.Add(NPCID.MartianDrone, 1f);
                        pool.Add(NPCID.MartianSaucerCore, 0.1f);
                        pool.Add(NPCID.PirateShip, 0.1f);
                    }
                    if (Main.player[Main.myPlayer].ZoneOverworldHeight)
                    {
                        if (Main.dayTime)
                        {
                            pool.Add(NPCID.Mothron, 0.7f);
                            pool.Add(NPCID.Nailhead, 0.7f);
                            pool.Add(NPCID.PirateShip, 0.1f);
                            pool.Add(NPCID.PirateCaptain, 0.5f);
                            pool.Add(NPCID.Eyezor, 1f);
                            pool.Add(NPCID.Vampire, 1f);
                            pool.Add(NPCID.DrManFly, 1f);
                            pool.Add(NPCID.Butcher, 1f);
                            pool.Add(NPCID.Psycho, 1f);
                            pool.Add(NPCID.KingSlime, 0.02f);
                        }
                        else
                        {
                            pool.Add(NPCID.Pumpking, 0.01f);
                            pool.Add(NPCID.MourningWood, 0.01f);
                            pool.Add(NPCID.SkeletronPrime, 0.02f);
                            pool.Add(NPCID.Retinazer, 0.5f);
                            pool.Add(NPCID.Spazmatism, 0.5f);
                            pool.Add(NPCID.TheDestroyer, 0.5f);
                            pool.Add(NPCID.EyeofCthulhu, 0.02f);
                            pool.Add(NPCID.Clown, 0.25f);
                            pool.Add(NPCID.HeadlessHorseman, 1f);
                            pool.Add(NPCID.Poltergeist, 1f);
                            pool.Add(NPCID.Hellhound, 1f);
                        }
                        pool.Add(NPCID.GoblinSummoner, 0.5f);
                        pool.Add(NPCID.Mimic, 0.5f);
                    }
                    if (Main.player[Main.myPlayer].ZoneDirtLayerHeight || Main.player[Main.myPlayer].ZoneRockLayerHeight)
                    {
                        pool.Add(NPCID.SkeletonArcher, 1f);
                        //pool.Add(NPCID.PigronHallow, 1f);
                        pool.Add(NPCID.Mimic, 1f);
                        pool.Add(NPCID.BigMimicHallow, 0.3f);
                        pool.Add(NPCID.BigMimicCrimson, 0.3f);
                        pool.Add(NPCID.BigMimicCorruption, 0.3f);
                    }

                    //Biome
                    if (Main.player[Main.myPlayer].ZoneSnow)
                    {
                        pool.Add(NPCID.IceGolem, 1f);
                        pool.Add(NPCID.Krampus, 1f);
                        pool.Add(NPCID.IceQueen, 0.01f);
                        pool.Add(NPCID.SantaNK1, 0.01f);
                        pool.Add(NPCID.Everscream, 0.01f);
                    }
                    if (Main.player[Main.myPlayer].ZoneDesert)
                    {
                        pool.Add(NPCID.SandElemental, 1f);
                        pool.Add(NPCID.SandShark, 1f);
                        pool.Add(NPCID.DuneSplicerHead, 1f);
                        pool.Add(NPCID.DesertDjinn, 1f);
                    }
                    if (Main.player[Main.myPlayer].ZoneBeach)
                    {
                        //pool.Add(NPCID.Shark, 1f);
                        pool.Add(NPCID.DuneSplicerHead, 1f);
                        pool.Add(NPCID.DukeFishron, 0.01f);
                        //Pirate stuff gets moved to daytime
                        //Beach is pretty damn peaceful apart from fishron

                    }
                    if (Main.player[Main.myPlayer].ZoneJungle)
                    {
                        pool.Add(NPCID.GiantTortoise, 1f);
                        pool.Add(NPCID.Moth, 0.5f);
                        pool.Add(NPCID.Derpling, 1f);
                        pool.Add(NPCID.GiantFlyingFox, 1f);
                        pool.Add(NPCID.GiantMossHornet, 1f);
                        pool.Add(NPCID.QueenBee, 0.07f);
                        pool.Add(NPCID.Plantera, 0.01f);
                        pool.Add(NPCID.Golem, 0.005f);
                    }
                    if (Main.player[Main.myPlayer].ZoneCorrupt)
                    {
                        pool.Add(NPCID.SeekerHead, 1f);
                        pool.Add(NPCID.CursedHammer, 1f);
                        pool.Add(NPCID.BigMimicCorruption, 0.5f);
                        pool.Add(NPCID.EaterofWorldsHead, 0.07f);
                    }
                    if (Main.player[Main.myPlayer].ZoneCrimson)
                    {
                        pool.Add(NPCID.Herpling, 1f);
                        pool.Add(NPCID.IchorSticker, 1f);
                        pool.Add(NPCID.CrimsonAxe, 1f);
                        pool.Add(NPCID.BigMimicCrimson, 0.5f);
                        pool.Add(NPCID.BrainofCthulhu, 0.07f);
                    }
                    if (Main.player[Main.myPlayer].ZoneHoly)
                    {
                        pool.Add(NPCID.EnchantedSword, 1f);
                        pool.Add(NPCID.Unicorn, 1f);
                        pool.Add(NPCID.RainbowSlime, 1f);
                        pool.Add(NPCID.BigMimicHallow, 0.5f);
                    }
                }
                //Intensity
                if (ChunkyWorld.NumDisasters > 15)                                                    //3rd order
                {
                    //Height
                    if (Main.player[Main.myPlayer].ZoneSkyHeight)
                    {
                        pool.Add(NPCID.WyvernHead, 1f);
                        pool.Add(NPCID.MartianSaucerCore, 0.1f);
                        pool.Add(NPCID.PirateShip, 0.1f);
                        pool.Add(NPCID.MoonLordCore, 0.001f); //yes
                        pool.Add(NPCID.StardustCellBig, 0.5f);
                        pool.Add(NPCID.StardustJellyfishBig, 0.5f);
                        pool.Add(NPCID.StardustWormHead, 0.5f);
                    }
                    if (Main.player[Main.myPlayer].ZoneOverworldHeight)
                    {
                        if (Main.dayTime)
                        {
                            pool.Add(NPCID.Mothron, 1f);
                            pool.Add(NPCID.Nailhead, 0.7f);
                            pool.Add(NPCID.PirateShip, 0.1f);
                            pool.Add(NPCID.PirateCaptain, 0.5f);
                            pool.Add(NPCID.Eyezor, 1f);
                            pool.Add(NPCID.Psycho, 1f);
                            pool.Add(NPCID.KingSlime, 0.07f);
                        }
                        else
                        {
                            pool.Add(NPCID.Pumpking, 0.04f);
                            pool.Add(NPCID.MourningWood, 0.01f);
                            pool.Add(NPCID.SkeletronPrime, 0.3f);
                            pool.Add(NPCID.Retinazer, 0.7f);
                            pool.Add(NPCID.Spazmatism, 0.7f);
                            pool.Add(NPCID.TheDestroyer, 0.7f);
                            pool.Add(NPCID.EyeofCthulhu, 0.1f);
                            pool.Add(NPCID.HeadlessHorseman, 0.5f);
                        }
                        pool.Add(NPCID.MoonLordCore, 0.001f); //yes
                        pool.Add(NPCID.SolarCrawltipedeHead, 0.5f);
                        pool.Add(NPCID.SolarSolenian, 0.5f);
                    }
                    if (Main.player[Main.myPlayer].ZoneDirtLayerHeight || Main.player[Main.myPlayer].ZoneRockLayerHeight)
                    {
                        pool.Add(NPCID.SkeletonArcher, 1f);
                        pool.Add(NPCID.Mimic, 1f);
                        pool.Add(NPCID.BigMimicHallow, 0.5f);
                        pool.Add(NPCID.BigMimicCrimson, 0.5f);
                        pool.Add(NPCID.BigMimicCorruption, 0.5f);
                        pool.Add(NPCID.SolarCorite, 1f);
                    }

                    //Biome
                    if (Main.player[Main.myPlayer].ZoneSnow)
                    {
                        pool.Add(NPCID.IceGolem, 1f);
                        pool.Add(NPCID.Krampus, 1f);
                        pool.Add(NPCID.IceQueen, 0.03f);
                        pool.Add(NPCID.SantaNK1, 0.03f);
                        pool.Add(NPCID.Everscream, 0.03f);
                        pool.Add(NPCID.StardustSpiderBig, 1f);
                    }
                    if (Main.player[Main.myPlayer].ZoneDesert)
                    {
                        pool.Add(NPCID.SandElemental, 1f);
                        pool.Add(NPCID.VortexSoldier, 1f);
                        pool.Add(NPCID.VortexRifleman, 1f);
                        pool.Add(NPCID.VortexHornetQueen, 1f);
                        //idk what else could be here
                    }
                    if (Main.player[Main.myPlayer].ZoneBeach)
                    {
                        pool.Add(NPCID.DuneSplicerHead, 1f);
                        pool.Add(NPCID.DukeFishron, 0.05f);
                        //I don't really wanna dump stuff in here since duke is second only to the moonlord imo

                    }
                    if (Main.player[Main.myPlayer].ZoneJungle)
                    {
                        pool.Add(NPCID.GiantTortoise, 1f);
                        pool.Add(NPCID.QueenBee, 0.1f);
                        pool.Add(NPCID.Plantera, 0.03f);
                        pool.Add(NPCID.Golem, 0.01f);
                        pool.Add(NPCID.NebulaBrain, 0.5f);
                        pool.Add(NPCID.NebulaHeadcrab, 0.5f);
                    }
                    if (Main.player[Main.myPlayer].ZoneCorrupt)
                    {
                        pool.Add(NPCID.SeekerHead, 1f);
                        //pool.Add(NPCID.Corruptor, 1f);
                        pool.Add(NPCID.CursedHammer, 1f);
                        pool.Add(NPCID.BigMimicCorruption, 0.5f);
                        pool.Add(NPCID.EaterofWorldsHead, 0.07f);
                        pool.Add(NPCID.NebulaBrain, 0.5f);
                        pool.Add(NPCID.NebulaHeadcrab, 0.5f);
                        pool.Add(NPCID.NebulaBeast, 0.5f);
                    }
                    if (Main.player[Main.myPlayer].ZoneCrimson)
                    {
                        pool.Add(NPCID.Herpling, 1f);
                        pool.Add(NPCID.IchorSticker, 1f);
                        pool.Add(NPCID.CrimsonAxe, 1f);
                        pool.Add(NPCID.BigMimicCrimson, 0.5f);
                        pool.Add(NPCID.BrainofCthulhu, 0.07f);
                        pool.Add(NPCID.NebulaBrain, 0.5f);
                        pool.Add(NPCID.NebulaHeadcrab, 0.5f);
                        pool.Add(NPCID.NebulaBeast, 0.5f);
                    }
                    if (Main.player[Main.myPlayer].ZoneHoly)
                    {
                        pool.Add(NPCID.EnchantedSword, 1f);
                        pool.Add(NPCID.Unicorn, 1f);
                        pool.Add(NPCID.RainbowSlime, 1f);
                        pool.Add(NPCID.BigMimicHallow, 0.5f);
                        pool.Add(NPCID.NebulaBrain, 0.5f);
                        pool.Add(NPCID.NebulaHeadcrab, 0.5f);
                        pool.Add(NPCID.NebulaBeast, 0.5f);
                    }
                }
                if (Main.player[Main.myPlayer].ZoneUnderworldHeight)
                {
                    pool.Add(NPCID.RedDevil, 1f);
                    if (ChunkyWorld.NumDisasters > 15) pool.Add(NPCID.SolarCrawltipedeHead, 1f);
                }
                if (Main.player[Main.myPlayer].ZoneGlowshroom)
                {
                    pool.Add(NPCID.AnomuraFungus, 1f);
                    pool.Add(NPCID.MushiLadybug, 1f);
                    pool.Add(NPCID.GiantFungiBulb, 1f);
                }
                //Underworld and glowing mushroom don't reall have stuff but they still have tough enemies
            }
        }

        //Changing the spawn rate
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            //if there's a disaster and it's at spawn
            if (ChunkyWorld.disaster && (Main.invasionX == (double)Main.spawnTileX))
            {
                spawnRate = 50; //The lower the number the more spawning. We want to absolutely drown the player in death.
                maxSpawns = 100000; //Max spawns of NPCs depending on NPC value which I think is the money they drop
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Golem) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("InfestedMeteorite"), Main.rand.Next(4, 7));
            if (npc.type == NPCID.CultistBoss && Main.expertMode) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SandTablet"), 1);
            if ((npc.friendly || npc.damage == 0 || Main.rand.Next(20) == 0) && Main.hardMode) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfWight"), 1);
            if (npc.townNPC && Main.hardMode) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfWight"), Main.rand.Next(2,3));
            if (npc.type == NPCID.Derpling && Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerplingEye"), 1);
            if (npc.type == NPCID.Derpling && Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerplingHusk"), 1);
            if (npc.type == NPCID.Harpy && Main.rand.Next(30) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TardyCardinal"), 1);

            //When an NPC from a disaster dies we decrease the size of the invasion just like I thought
            if (ChunkyWorld.disaster)
            {
                /*
            //Gets IDs of invaders from CustomInvasion file
            foreach (int invader in CustomInvasion.invaders)
            {
                //if the killed thing is one of the invaders then shrink the invasion size
                if (npc.type == invader)
                {
                    //Main.invasionSize -= 1;
                    //if (npc.boss) Main.invasionSize -= 4;
                    if (npc.lifeMax >= 10000) Main.invasionSize -= 1;
                    if (npc.lifeMax >= 10000) Main.invasionSize -= 4;
                    if (npc.lifeMax >= 50000) Main.invasionSize -= 5;
                    if (npc.type == NPCID.MoonLordCore) Main.invasionSize -= 15;
                }

            }
            */
                //Screw that list im just using this
                if (npc.lifeMax >= 1000) Main.invasionSize -= 1;
                if (npc.lifeMax >= 10000) Main.invasionSize -= 4;
                if (npc.lifeMax >= 50000) Main.invasionSize -= 5;
                if (npc.type == NPCID.MoonLordCore) Main.invasionSize -= 40;

                if (npc.type == NPCID.Mothron && Main.rand.NextBool(5)) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ginseng"), 1);
                if (npc.type == NPCID.Plantera && ChunkyWorld.NumDisasters > 10) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Durian"), Main.rand.Next(2,4));
            }
        }
    }
}