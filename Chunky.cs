using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using System.Threading;
using Terraria.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Chunky.ZAWARUDO;
using Chunky.KingCrimson;
using Terraria.Localization;

namespace Chunky
{

    class Chunky : Mod
    {
        internal static ModHotKey Skill1; ///Normal Skill now
        internal static ModHotKey ArmorSkill;

        //Mandom
        ///Not mandom only; Instant Skills
        internal static ModHotKey Skill2;

        public static Chunky instance;

        public Chunky()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        //Recipe Groups
        public override void AddRecipeGroups()
        {
            RecipeGroup groupC = new RecipeGroup(() => "Copper/Tin", new int[]
            {
                ItemID.CopperBar,
                ItemID.TinBar
            });
            RecipeGroup.RegisterGroup("Chunky:Copper/Tin", groupC);

            RecipeGroup groupS = new RecipeGroup(() =>"Silver/Tungsten", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("Chunky:Silver/Tungsten", groupS);

            RecipeGroup groupG = new RecipeGroup(() => "Gold/Platinum", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("Chunky:Gold/Platinum", groupG);

            RecipeGroup groupD = new RecipeGroup(() => "Demonite/Crimtane", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("Chunky:Demonite/Crimtane", groupD);

            RecipeGroup groupP = new RecipeGroup(() => "Palladium/Cobalt", new int[]
            {
                ItemID.PalladiumBar,
                ItemID.CobaltBar
            });
            RecipeGroup.RegisterGroup("Chunky:Palladium/Cobalt", groupP);

            RecipeGroup groupM = new RecipeGroup(() => "Mythril/Orichalcum", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("Chunky:Mythril/Orichalcum", groupM);

            RecipeGroup groupA = new RecipeGroup(() => "Adamantite/Titanium", new int[]
            {
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            });
            RecipeGroup.RegisterGroup("Chunky:Adamantite/Titanium", groupA);

            RecipeGroup groupGem = new RecipeGroup(() => "Gem", new int[]
            {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            });
            RecipeGroup.RegisterGroup("Chunky:Gem", groupGem);
        }

        public override void AddRecipes()
        {
            ModRecipe ObsidianSkin = new ModRecipe(this); //idfk
            ObsidianSkin.AddIngredient(null, "Obstidian", 1);
            ObsidianSkin.AddIngredient(ItemID.BottledWater, 1);
            ObsidianSkin.SetResult(ItemID.ObsidianSkinPotion, 1);
            ObsidianSkin.AddTile(TileID.Bottles);
            ObsidianSkin.AddRecipe();

            ModRecipe Star = new ModRecipe(this);
            Star.AddIngredient(ItemID.Firefly, 4);
            Star.AddIngredient(ItemID.Moonglow, 1);
            Star.AddIngredient(ItemID.Daybloom, 1);
            Star.SetResult(ItemID.FallenStar, 5);
            Star.AddRecipe();

            ModRecipe Light = new ModRecipe(this);
            Light.AddIngredient(ItemID.SoulofLight, 1);
            Light.AddIngredient(null, "SoulOfWight", 10);
            Light.SetResult(ItemID.SoulofLight, 3);
            Light.AddRecipe();

            ModRecipe Night = new ModRecipe(this);
            Night.AddIngredient(ItemID.SoulofNight, 1);
            Night.AddIngredient(null, "SoulOfWight", 10);
            Night.SetResult(ItemID.SoulofNight, 3);
            Night.AddRecipe();

            ModRecipe Might = new ModRecipe(this);
            Might.AddIngredient(ItemID.SoulofMight, 1);
            Might.AddIngredient(null, "SoulOfWight", 10);
            Might.SetResult(ItemID.SoulofMight, 3);
            Might.AddRecipe();

            ModRecipe Sight = new ModRecipe(this);
            Sight.AddIngredient(ItemID.SoulofSight, 1);
            Sight.AddIngredient(null, "SoulOfWight", 10);
            Sight.SetResult(ItemID.SoulofSight, 3);
            Sight.AddRecipe();

            ModRecipe Fright = new ModRecipe(this);
            Fright.AddIngredient(ItemID.SoulofFright, 1);
            Fright.AddIngredient(null, "SoulOfWight", 10);
            Fright.SetResult(ItemID.SoulofFright, 3);
            Fright.AddRecipe();
        }

        //Hotkeys
        public override void Load()
        {
            instance = this;
            if (!Main.dedServ)
            {
                //Stopping time visuals
                Filters.Scene["Chunky:ZaWarudo"] = new Filter(new TsShader("FilterMiniTower").UseColor(.4f, .4f, .4f).UseOpacity(1f), EffectPriority.VeryHigh);
                SkyManager.Instance["Chunky:ZaWarudo"] = new TsVisual();

                //Skipping time visuals
                Filters.Scene["Chunky:KingCrimson"] = new Filter(new KcShader("FilterMiniTower").UseColor(.66f, .07f, .41f).UseOpacity(.4f), EffectPriority.VeryHigh);
                SkyManager.Instance["Chunky:KingCrimson"] = new KcVisual();

                //Blackout
                Filters.Scene["Chunky:Blackout"] = new Filter(new KcShader("FilterMiniTower").UseColor(0f, 0f, 0f).UseOpacity(1f), EffectPriority.VeryHigh);
            }

            ///Reworked for Gu's
            Skill1 = RegisterHotKey("Normal Skill", "Q");
            ArmorSkill = RegisterHotKey("Armor Skill", "F");

            //Mandom
            ///Not only mandom anymore
            Skill2 = RegisterHotKey("Instant Skill", "Y");
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                if (Main.LocalPlayer.HasBuff(BuffType("StoppedTime")))
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/DioTheme");
                    priority = MusicPriority.Environment;
                }

                if (Main.LocalPlayer.HasBuff(BuffType("TimeLeap")))
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/KingCrimsonTheme");
                    priority = MusicPriority.Environment;
                }

                
                if (Main.invasionX == Main.spawnTileX)
                {
                    music = 1;
                }
                
            }
        }

        public override void Unload()
        {
            instance = null;
        }
    }
}