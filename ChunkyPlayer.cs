using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Chunky.NPCs;

//Big thank you to Enigma for being open source

namespace Chunky
{
    public sealed partial class ChunkyPlayer : ModPlayer
    {
        //Body Swap
        public string BodyType = null; //null is the body you start with, OG is going back to the original body, Test is test body, Beggar is the inferior body, God is the 
        public Color Eyes = Color.White; //eye color of og body
        public Color Skin = Color.White; //skin color of og body
        public Color HairC = Color.White; //hair color of og body
        public int Hair = 0; //Type of hair the player's original body has
        public Color Shirt = Color.White;
        public Color UnderShirt = Color.White;
        public Color Pants = Color.White;
        public Color Shoes = Color.White;
        public bool Gender = true;
        public int[] Health = new int[4] { 100, 20, 20, 500 }; //max health of body types
        public int[] Mana = new int[4] { 20, 0, 0, 500 }; //max mana of body types
        public int[] Health2 = new int[4] { 100, 20, 20, 500 }; //current health of body types
        public int[] Mana2 = new int[4] { 20, 0, 0, 500 }; //current mana of body types

        //Variable made so bodytype can be saved correctly in tagcompounds
        public bool Body = false;
        //It actually works too which is nice

        //Number of Fetuses Consumed
        public int Fetuses = 0;
        public int FetusMax = 75; //you can go up to 600 health

        //ZA WARUDO
        public bool tsImmune = false;
        public bool tsChillBro = false;
        public int tsCoolDown = 0;
        public int tsDuration = 0;
        public float xP = 0;
        public float yP = 0;

        //King Crimson
        public bool kcImmune = false;
        public bool kcChillBro = false;
        public int kcCoolDown = 0;
        public int kcDuration = 0;
        public float xV = 0;
        public float yV = 0;

        //Cherry
        public bool CanEatCherry = true;
        public int CherryImmuneTime = 0;
        public int CherryCooldownTime = 0;

        //Other
        public bool CanUseTimeMagic = false;

        //Mandom
        private int[] t = new int[361];
        private Vector2[] SaxPos = new Vector2[361];
        private Vector2[] SaxVel = new Vector2[361];
        private int[] SaxHP = new int[361];
        private int[] SaxMana = new int[361];
        public bool CanUseTimeReverse = false;
        public static bool TimeReversed = false;
        public int[] time = new int[361];
        public bool[] day = new bool[361];
        //public static bool UnDie = false;

        //Mandom for Dio Death
        private int[] tD = new int[121];
        private Vector2[] SaxPosD = new Vector2[121];
        private Vector2[] SaxVelD = new Vector2[121];
        private int[] SaxHPD = new int[121];
        private int[] SaxManaD = new int[121];
        public static bool DioDeath = false;
        public int[] timeD = new int[361];
        public bool[] Dday = new bool[361];


        public bool HasInstant = false;
        public bool HasNormal = false;
        public bool HasInfinite = false;
        //These are essentially cooldowns
        public bool noInstant;
        public bool noNormal;
        public bool noInfinite;

        //Increasing time-stop ever so slowly
        public bool DIO = false;
        //private int T = 0;
        //Im going to try to use tagcompounds
        public int[] AddTime = new int[3] { 0, 0, 0 };
        //TagCompounds actually fucking worked
        //K so apparently floats wont work with tagcompunds
        public int tTime;
        //wtf? Floats work in tagcompound idiot

        public bool Terror;

        public override void Initialize()
        {
            
        }

        public override void ResetEffects()
        {
            //if (player.statLife > player.statLifeMax) player.statLifeMax = player.statLife;

            //Body Swap
            if (BodyType == null) //null records the default info
            {
                Eyes = player.eyeColor;
                Skin = player.skinColor;
                HairC = player.hairColor;
                Hair = player.hair;
                Shirt = player.shirtColor;
                UnderShirt = player.shirtColor;
                Shoes = player.shoeColor;
                Gender = player.Male;

                Health[0] = player.statLifeMax;
                Mana[0] = player.statManaMax;
                Health2[0] = player.statLife;
                Mana2[0] = player.statMana;
            }
            if (BodyType == "OG") //OG uses the default info to turn you back
            {
                player.eyeColor = Eyes;
                player.skinColor = Skin;
                player.hairColor = HairC;
                player.hair = Hair;
                player.shirtColor = Shirt;
                player.underShirtColor = UnderShirt;
                player.pantsColor = Pants;
                player.shoeColor = Shoes;
                player.Male = Gender;

                //I think we want to keep these ones the real max
                Health[0] = player.statLifeMax;
                Mana[0] = player.statManaMax;
                Health2[0] = player.statLife;
                Mana2[0] = player.statMana;
            }
            if (BodyType == "Test")
            {
                player.eyeColor = Color.White;
                player.skinColor = Color.White;
                player.hairColor = Color.Green;
                player.hair = 1;
                player.shirtColor = Color.White;
                player.underShirtColor = Color.White;
                player.pantsColor = Color.White;
                player.shoeColor = Color.White;
                player.Male = true;

                Health[1] = player.statLifeMax;
                Mana[1] = player.statManaMax;
                Health2[1] = player.statLife;
                Mana2[1] = player.statMana;
            }
            if (BodyType == "Beggar") //Beggar's or Peasant's body
            {
                player.eyeColor = Color.DarkOliveGreen;
                player.skinColor = Color.Chocolate;
                player.hairColor = Color.DimGray;
                player.hair = 2;
                player.shirtColor = Color.SandyBrown;
                player.underShirtColor = Color.SandyBrown;
                player.pantsColor = Color.Brown;
                player.shoeColor = Color.Chocolate;
                player.Male = true;

                Health[2] = player.statLifeMax2;
                Mana[2] = player.statManaMax2;
                Health2[2] = player.statLife;
                Mana2[2] = player.statMana;

                player.endurance -= 0.02f;
                player.maxMinions -= 1;
                player.allDamage -= 0.07f;
                player.lifeRegen -= 1;
            }
            if (BodyType == "God") //Soveriegn body
            {
                player.eyeColor = Color.Black;
                player.skinColor = Color.Ivory;
                player.hairColor = Color.Black;
                if (Gender) player.hair = 66; else player.hair = 65;
                player.shirtColor = Shirt;
                player.underShirtColor = UnderShirt;
                player.pantsColor = Pants;
                player.shoeColor = Shoes;
                player.Male = Gender;

                //ok so statLifeMax2 is the one we should've been using but we got it now
                player.statLifeMax2 = Health[3];
                player.statManaMax2 = Mana[3];

                //Fetuses add life
                if (Fetuses <= 25) player.statLifeMax2 += 2 * Fetuses;
                else if (Fetuses <= 75) player.statLifeMax2 += 25 + Fetuses;
                else player.statLifeMax2 += 62 + (int)((Fetuses + 1) / 2); //so that it starts at 100

                //Health[3] = player.statLifeMax;
                //Mana[3] = player.statManaMax;
                Health2[3] = player.statLife;
                Mana2[3] = player.statMana;

                player.endurance += 0.20f;
                player.manaCost -= 0.10f;
                player.lifeRegen += 10;
                player.manaRegen += 10;
                player.moveSpeed += 4;
                player.maxRunSpeed += 4;
                player.jumpSpeedBoost += 4;
                player.noFallDmg = true;
                player.maxMinions += 1;
                player.dangerSense = true;
                player.detectCreature = true;
                player.nightVision = true;
                player.extraAccessorySlots += 1; //might be a yikes but idk
                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Bleeding] = true;
                player.buffImmune[BuffID.Venom] = true;

                player.meleeSpeed += 0.1f;
                player.allDamageMult += 0.1f;
                player.magicCrit += 5;
                player.meleeCrit += 5;
                player.rangedCrit += 5;
                player.thrownCrit += 5;
                player.pickSpeed += 0.1f;
                player.ignoreWater = true;
                player.accFlipper = true;
                player.gills = true;
            }

            if (BodyType != null) Body = true; //Fixes the initial inexistance of BodyType's tagcompound

            //Main.NewText(AddTime);
            //Main.NewText(Health[1]);
            //I just typed those in and it started working so that's cool I guess
            //Main.NewText(Health2[0] + ", " + Health2[3]);

            CanUseTimeMagic = false;

            //ZA WARUDO
            tsCoolDown = 2340;
            tsDuration = 1;
            tsImmune = false;
            tsChillBro = false;

            //King Crimson
            kcImmune = false;
            kcChillBro = false;
            kcCoolDown = 2400;
            kcDuration = 180;

            //Cherry
            CanEatCherry = true;
            CherryImmuneTime = 120;
            CherryCooldownTime = 2700;

            HasInstant = false;
            HasNormal = false;
            HasInfinite = false;
            noInstant = false;
            noNormal = false;
            noInfinite = false;

            //Mandom
            CanUseTimeReverse = false;
            //DioDeath = false; //gets turned to false before anything can happen

            DIO = false;
            /*
            if (player.HasBuff(mod.BuffType("StopTime"))) T++;
            else T = 0;
            tsDuration += (int)(T / 180);
            */

            Terror = false;

            //if (player.statLife <= player.statLife / 2) tsCoolDown += (int)(tsCoolDown * player.statLife / (player.statLifeMax2));
            if (NPC.downedQueenBee) { tsDuration += 30; tsCoolDown -= 30; }
            if (NPC.downedBoss3) tsDuration += 30;
            if (NPC.downedMechBoss1) tsDuration += 20;
            if (NPC.downedMechBoss2) tsDuration += 20;
            if (NPC.downedMechBoss3) tsDuration += 20;
            if (NPC.downedMechBoss3 && NPC.downedMechBoss2 && NPC.downedMechBoss1) tsDuration += 60;
            if (NPC.downedFishron)
            {
                tsDuration += 15;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 120;
                CherryCooldownTime -= 180;
            }
            if (NPC.downedAncientCultist)
            {
                tsDuration += 15;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 60;
                CherryCooldownTime -= 60;
            }
            if (NPC.downedTowerSolar)
            {
                tsDuration += 15;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 30;
                CherryCooldownTime -= 30;
            }
            if (NPC.downedTowerVortex)
            {
                tsDuration += 15;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 30;
                CherryCooldownTime -= 30;
            }
            if (NPC.downedTowerNebula)
            {
                tsDuration += 15;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 30;
                CherryCooldownTime -= 30;
            }
            if (NPC.downedTowerStardust)
            {
                tsDuration += 15;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 30;
                CherryCooldownTime -= 30;
            }
            if (NPC.downedMoonlord)
            {
                tsDuration += 30;
                tsCoolDown -= 60;
                kcDuration += 60;
                kcCoolDown -= 60;
                CherryImmuneTime += 600;
                CherryCooldownTime -= 60;
            }
            if (BodyType == "God") tsDuration += 60;

            //Main.NewText(AddTime[0] +", " + AddTime[1] + ", " + AddTime[2]);
            //We changed the AddTime variable from a single integer to an array so all players that had Chunky Mod needed to change it to an array

            if (ChunkyWorld.TOKIWOTOMARE > 0)
            {
                player.waterWalk = true;
                //player.waterWalk2 = true;
                player.lavaImmune = true;
                player.resistCold = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Frostburn] = true;
                player.buffImmune[BuffID.Frozen] = true;
                player.buffImmune[BuffID.ShadowFlame] = true;
                player.ignoreWater = true;
            }
            //Cannot be hot or cold in stopped time because atoms do not move. Technically you wouldnt be able to see or breath either but that's no fun.
        }

        //I don't know where to put this it's making weird problems though
        public override TagCompound Save()
        {
            return new TagCompound {
                {"AddTime", AddTime},
                {"tTime", tTime},

                //Body boolean is made to counteract weirdness of tagcompounds
                {"Body", Body},
                {"BodyType", BodyType}, //Bodytype was starting out as absolutely nothing instead of null. It was just empty. So that means everything was breaking. Body boolean fixed that.
                {"Health", Health},
                {"Mana", Mana},
                {"Health2", Health2},
                {"Mana2", Mana2},
                {"Eyes", Eyes},
                {"Skin", Skin},
                {"HairC", HairC},
                {"Hair", Hair},
                {"Shirt", Shirt},
                {"UnderShirt", UnderShirt},
                {"Pants", Pants},
                {"Shoes", Shoes},
                {"Gender", Gender},

                //fetuses
                {"Fetuses", Fetuses}
            };
        }
        public override void Load(TagCompound tag)
        {
            AddTime = tag.GetIntArray("AddTime");
            tTime = tag.GetInt("tTime");

            Body = tag.GetBool("Body");
            if (Body)
            {
                BodyType = tag.GetString("BodyType");
                Health = tag.GetIntArray("Health");
                Mana = tag.GetIntArray("Mana");
                Health2 = tag.GetIntArray("Health2");
                Mana = tag.GetIntArray("Mana");
                Eyes = tag.Get<Color>("Eyes");
                Skin = tag.Get<Color>("Skin");
                HairC = tag.Get<Color>("HairC");
                Hair = tag.GetInt("Hair");
                Shirt = tag.Get<Color>("Shirt");
                UnderShirt = tag.Get<Color>("UnderShirt");
                Pants = tag.Get<Color>("Pants");
                Shoes = tag.Get<Color>("Shoes");
                Gender = tag.GetBool("Gender");
            }

            Fetuses = tag.GetInt("Fetuses");
        }

        public override void PostUpdate()
        {
            //I wanna make it so that in stopped or erased time 
            if ((ChunkyWorld.TOKIWOTOMARE > 0 || ChunkyWorld.TimeSkipping > 0) && Main.rand.Next(3600*3) == 0) Item.NewItem(player.position, mod.ItemType("TimeDroplet"));


            /*
            if (NPC.FindFirstNPC(mod.NPCType("TimeMerchant")) > 0)
            {
                tsImmune = true;
                kcImmune = true;
                if (ChunkyWorld.TOKIWOTOMARE > 0 && ChunkyWorld.TOKIWOTOMARE <= 3)
                {
                    player.AddBuff(mod.BuffType("OutOfTime"), 720, true);
                    player.AddBuff(mod.BuffType("StoppedTime"), 2, true);
                    ChunkyWorld.TOKIWOTOMARE = 2;
                }
                if (ChunkyWorld.TimeSkipping > 0 && ChunkyWorld.TimeSkipping <= 2)
                {
                    player.AddBuff(mod.BuffType("OutOfTime"), 720, true);
                    player.AddBuff(mod.BuffType("TimeLeap"), 2, true);
                    ChunkyWorld.TimeSkipping = 2;
                }
            }
            */

            PostUpdateTimeStop();
            PostUpdateTimeSkip();

            //Mandom
            PostUpdateReverseTime();
        }

        private void PostUpdateTimeStop()
        {
            if (ChunkyWorld.TOKIWOTOMARE > 0 && !tsImmune)
            {
                player.velocity.X = 0;
                player.velocity.Y = 0;
                if (xP == 0 && yP == 0)
                {
                    xP = player.position.X;
                    yP = player.position.Y;
                }
                else
                {
                    player.position.X = xP;
                    player.position.Y = yP;
                }
            }
            else
            {
                xP = 0;
                yP = 0;
            }

            //Mana
            if (ChunkyWorld.TOKIWOTOMARE > 0 && tsImmune && !DIO && !Terror) player.statMana--;
            //if time is stopped wind cant blow you away because there shouldnt be wind
            if (ChunkyWorld.TOKIWOTOMARE > 0) player.buffImmune[BuffID.WindPushed] = true;
        }

        private void PostUpdateTimeSkip()
        {
            if (ChunkyWorld.TimeSkipping > 0 && !kcImmune)
            {
                if (xV == 0 && yV == 0)
                {
                    xV = player.velocity.X;
                    yV = player.velocity.Y;
                }
                else
                {
                    player.velocity.X = xV * 0.4f;
                    player.velocity.Y = yV * 0.4f;
                }
            }
            else
            {
                xV = 0;
                yV = 0;
            }

            if (ChunkyWorld.TimeSkipping > 0 && kcImmune) player.moveSpeed *= 0.75f;

            //Math.DivRem((int)Main.time, 4, out int n);
            //Mana
            //if (ChunkyWorld.TimeSkipping > 0 && kcImmune && n == 0) if (player.statMana >= 3) player.statMana -= 3; else player.statMana = 0;
            if (ChunkyWorld.TimeSkipping > 0 && kcImmune) player.statMana--;
        }

        //Mandom
        private void PostUpdateReverseTime()
        {
            if (ChunkyWorld.TOKIWOTOMARE == 0 && CanUseTimeReverse)
            {
                for (int i = 0; i < 360; i++) t[i] = t[i + 1]; t[360] = Convert.ToInt32(Main.time); //keeps track of time

                for (int i = 0; i < 360; i++)
                {
                    SaxPos[i] = SaxPos[i + 1];
                    SaxVel[i] = SaxVel[i + 1];
                    SaxHP[i] = SaxHP[i + 1];
                    SaxMana[i] = SaxMana[i + 1];
                    time[i] = time[i + 1];
                    day[i] = day[i + 1];
                }
                SaxPos[360] = player.position;
                SaxVel[360] = player.velocity;
                SaxHP[360] = player.statLife;
                SaxMana[360] = player.statMana;
                time[360] = (int)Main.time;
                day[360] = Main.dayTime;

                TimeReversed = false;
                /*
                max += (int)tTime / 3600;
                if (max > 360) max = 360;
                */

                if (Chunky.Skill2.JustPressed && !tsChillBro && CanUseTimeReverse && t[0] != t[1] && player.statMana >= 60)
                {
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/TimeLeap")); //That's the steins;gate time leap sound
                    player.position = SaxPos[0];
                    player.velocity = SaxVel[0];
                    player.statLife = SaxHP[0];
                    player.statMana = SaxMana[0];
                    player.AddBuff(mod.BuffType("OutOfTime"), 360, true);
                    Main.time = time[0]; //time[0] should be 6 seconds ago
                    //Main.dayTime = day[0]; //time variable does not account for night and day
                    player.immune = true;
                    player.immuneTime = 15; //that should work. I'd like to put this in the DIO one but its already handled in prekill. Kinda messy.

                    TimeReversed = true;
                }
            }

            //Mandom for Dio Death
            if (ChunkyWorld.TOKIWOTOMARE == 0 && DIO)
            {
                for (int i = 0; i < 120; i++) tD[i] = tD[i + 1]; tD[120] = Convert.ToInt32(Main.time); //keeps track of time

                for (int i = 0; i < 120; i++)
                {
                    SaxPosD[i] = SaxPosD[i + 1];
                    SaxVelD[i] = SaxVelD[i + 1];
                    SaxHPD[i] = SaxHPD[i + 1];
                    SaxManaD[i] = SaxManaD[i + 1];
                    timeD[i] = timeD[i + 1];
                    Dday[i] = Dday[i + 1];
                }
                SaxPosD[120] = player.position;
                SaxVelD[120] = player.velocity;
                SaxHPD[120] = player.statLife;
                SaxManaD[120] = player.statMana;
                timeD[120] = (int)Main.time;
                Dday[360] = Main.dayTime;

                if (DioDeath && !tsChillBro && tD[0] != tD[1])
                {
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/TimeLeap")); //That's the steins;gate time leap sound
                    player.position = SaxPosD[0];
                    player.velocity = SaxVelD[0];
                    player.statLife = SaxHPD[0];
                    player.statMana = SaxManaD[0];
                    player.AddBuff(mod.BuffType("OutOfTime"), 120, true);
                    Main.time -= timeD[120] - timeD[0];
                    //Main.dayTime = Dday[0];
                }
                else DioDeath = false; //I guess it works?
            }
        }

        public override bool PreItemCheck()
        {
            if (ChunkyWorld.TOKIWOTOMARE > 0 && tsImmune == false) return false;
            if (ChunkyWorld.TimeSkipping > 0) return false; //No using items in time skip anymore. Its too op.
            return true;
        }

        //Hotkey
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            //Resuming time
            if ((Chunky.Skill1.JustPressed || player.statMana <= 0) && ChunkyWorld.TOKIWOTOMARE > 0 && CanUseTimeMagic && !DIO)
            {
                int t0 = tsCoolDown;
                int t = tsDuration;
                int x = t - ChunkyWorld.TOKIWOTOMARE;

                player.ClearBuff(mod.BuffType("StoppedTime")); //completely forgot this existed when implementing the mana bit
                player.ClearBuff(mod.BuffType("OutOfTime"));
                player.AddBuff(mod.BuffType("OutOfTime"), (int)((t0 - t) * (1 - Math.Cos(x * Math.PI / t)) / 2), true);
                ChunkyWorld.TOKIWOTOMARE = 0;
            }

            //Stopping time
            if (Chunky.Skill1.JustPressed && tsChillBro == false && ChunkyWorld.TimeSkipping == 0 && CanUseTimeMagic && player.statMana > 25 && !DIO)
            {
                player.statMana -= 30;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/DubstepFarts"));
                ChunkyWorld.TOKIWOTOMARE = tsDuration;
                player.AddBuff(mod.BuffType("OutOfTime"), tsCoolDown, true);
                player.AddBuff(mod.BuffType("StoppedTime"), tsDuration, true);
            }
        }

        public override void UpdateBiomeVisuals()
        {
            bool stopTime = false;
            bool skipTime = false;
            if (ChunkyWorld.TOKIWOTOMARE > 0) stopTime = true;
            if (tsImmune == true) player.ManageSpecialBiomeVisuals("Chunky:ZaWarudo", stopTime); //Stopping Time visuals
            if (ChunkyWorld.TimeSkipping > 0) skipTime = true;
            if (kcImmune == true) player.ManageSpecialBiomeVisuals("Chunky:KingCrimson", skipTime); //Skipping time visuals

            //Removing the visuals
            if (ChunkyWorld.TOKIWOTOMARE > 0 && (Chunky.Skill1.JustPressed || player.statMana <= 0)) player.ManageSpecialBiomeVisuals("Chunky:ZaWarudo", false);
            if (ChunkyWorld.TimeSkipping > 0 && Chunky.ArmorSkill.JustPressed) player.ManageSpecialBiomeVisuals("Chunky:KingCrimson", false);
        }

        [Obsolete]
        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Notification"));
            item.stack = 1;
            items.Add(item);
        }

        //Fishy Fishy
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            //A lot of worms
            //if ((Main.bloodMoon || player.ZoneCrimson) && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("RedWorm");
            //if (player.ZoneUnderworldHeight && liquidType == 1 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("OrangeWorm");
            //if (player.ZoneDesert && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("YellowWorm");
            //if (player.ZoneJungle && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("LimeWorm");
            //if (player.ZoneDirtLayerHeight && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("GreenWorm");
            //if (player.ZoneHoly && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("LightBlueWorm");
            //if (player.ZoneSkyHeight && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("BlueWorm");
            //if ((Main.bloodMoon || player.ZoneCorrupt) && liquidType == 0 && Main.rand.Next(500) == 0) caughtType = mod.ItemType("VioletWorm");
            ///worms unobtainable for now
            ///
            if (liquidType == 0 && Main.rand.Next(250) == 0 && junk) caughtType = mod.ItemType("RedWorm");
            if (Main.eclipse && NPC.downedFishron && Main.rand.Next(150) == 0) caughtType = mod.ItemType("Gurnard");

            if (junk) return;
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            /*
            if (Terror && damage >= player.statLife)
            {
                UnDie = true;
                player.statLife = 100 + damage;
                player.immune = true;
                player.immuneTime = 60;
            }
            */

            if (player.HasBuff(mod.BuffType("Gurnard")) && damage > player.statLife)
            {
                player.statLife = 100 + damage;
                player.ClearBuff(mod.BuffType("Gurnard"));
                player.immune = true;
                player.immuneTime = 60;
            }

            //Reverse time 1 second instead of die for Dio armor
            /*if (DIO && damage > player.statLife && !tsChillBro)
            {
                player.statLife = 100 + damage;
                player.immune = true;
                player.immuneTime = 15;
                DioDeath = true;
            }*/
            //ok im pretty sure this can go in prekill to make it work on everything instead of just prehurt right

            /*
            if (Terror && !tsChillBro && t[0] != t[1] && damage >= player.statLife)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/TimeLeap")); //That's the steins;gate time leap sound
                player.position = SaxPos[0];
                player.velocity = SaxVel[0];
                player.statLife = SaxHP[0];
                player.statMana = SaxMana[0];
                player.AddBuff(mod.BuffType("OutOfTime"), 360, true);
                Main.time -= 360;

                player.immune = true;
                player.immuneTime = 120;
            }
            */
            return true;
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            //I think this will work here
            if (DIO && damage > player.statLife && !tsChillBro)
            {
                player.statLife = 100 + (int)damage;
                player.immune = true;
                player.immuneTime = 15;
                DioDeath = true;
                return false; //that's supposed to make me not die
            }

            if (BodyType == null || BodyType == "OG") AddTime[0] = 0;
            if (BodyType == "Beggar") AddTime[1] = 0;
            if (BodyType == "God") AddTime[2] = 0;
            //Changed so there's an AddTime for each body type excluding test because that one doesnt matter

            /*if (Terror)
            {
                tTime = 0;
                player.QuickSpawnItem(mod.ItemType("Terror"));
            }*/
            return true;
        }

        /*
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (player.HasBuff(mod.BuffType("LastRhymes")))
            {
                int heal = (int)damage / 100;
                if (heal > 3) heal = 3;
                if (ChunkyWorld.EveryOther && heal > 0)
                {
                    player.statLife += heal;
                    player.HealEffect(heal, true);
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (player.HasBuff(mod.BuffType("LastRhymes")))
            {
                int heal = (int)damage / 100;
                if (heal > 3) heal = 3;
                if (ChunkyWorld.EveryOther && heal > 0)
                {
                    player.statLife += heal;
                    player.HealEffect(heal, true);
                }
            }
        }
        */
    }
}