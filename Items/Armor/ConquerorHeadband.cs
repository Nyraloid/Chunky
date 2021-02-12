using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Chunky.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ConquerorHeadband : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fate Breaker Vampire Headband");
            Tooltip.SetDefault("+16% damage\n+1 second of stopped time and -1 second of cooldown");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.value = 1000000;
            item.rare = ItemRarityID.Purple;
            item.defense = 0;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ConquerorShirt") && legs.type == mod.ItemType("ConquerorPants");
        }


        public override void UpdateEquip(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.meleeDamage *= 1.16f;
            player.magicDamage *= 1.16f;
            player.rangedDamage *= 1.16f;
            player.minionDamage *= 1.16f;
            modPlayer.tsDuration += 60;
            modPlayer.tsCoolDown -= 60;
            Vector2 position = player.position;
            Lighting.AddLight((int)((position.X + (float)(player.width / 2)) / 16f), (int)((position.Y + (float)(player.height / 2)) / 16f), 1.11f, .90f, .40f);
        }

        public override void UpdateArmorSet(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            player.setBonus = "Buffs a lot of stuff\n+1 second of stopped time and -1 second of cooldown\nImmunity to some things including knockback\n'You've conquerored the world, it only makes sense for you to control time as well'";

            modPlayer.tsDuration += 60;
            modPlayer.tsCoolDown -= 60;
            player.lifeRegen += 5;
            player.manaRegen += 5;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Suffocation] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.dangerSense = true;
            player.detectCreature = true;
            player.endurance += 0.1f;
            player.wingTimeMax += 100;
            /*
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.Suffocation] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
            */
            player.noKnockback = true;

            if (modPlayer.tsCoolDown <= modPlayer.tsDuration + 600) modPlayer.tsCoolDown = modPlayer.tsDuration + 600; //Cooldown always at least 10 seconds longer than duration

            //resuming time
            if ((Chunky.ArmorSkill.JustPressed) && ChunkyWorld.TOKIWOTOMARE > 0)
            {
                int t0 = modPlayer.tsCoolDown;
                int t = modPlayer.tsDuration;
                int x = t - ChunkyWorld.TOKIWOTOMARE;

                player.ClearBuff(mod.BuffType("StoppedTime"));
                player.ClearBuff(mod.BuffType("OutOfTime"));
                player.AddBuff(mod.BuffType("OutOfTime"), (int)((t0 - t) * (1 - Math.Cos(x * Math.PI / t)) / 2), true);
                ChunkyWorld.TOKIWOTOMARE = 0;
            }

            //stopping time
            if (Chunky.ArmorSkill.JustPressed && modPlayer.tsChillBro == false && ChunkyWorld.TOKIWOTOMARE == 0 && player.statMana >= 20)
            {
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/DubstepFarts"));
                ChunkyWorld.TOKIWOTOMARE = modPlayer.tsDuration;
                player.AddBuff(mod.BuffType("OutOfTime"), modPlayer.tsCoolDown, true);
                player.AddBuff(mod.BuffType("StoppedTime"), modPlayer.tsDuration, true);

                player.statMana -= 40; //too dang op
            }

            modPlayer.DIO = true;
            player.AddBuff(mod.BuffType("StopTime"), 1, true);
            modPlayer.tsImmune = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "InfestedMeteorite", 10);
            recipe.AddIngredient(null, "MagicWatch", 1);
            recipe.AddIngredient(mod.ItemType("KingCrimsonHead"), 1);
            recipe.AddIngredient(ItemID.SolarFlareHelmet, 1);
            recipe.AddIngredient(ItemID.VortexHelmet, 1);
            recipe.AddIngredient(ItemID.NebulaHelmet, 1);
            recipe.AddIngredient(ItemID.StardustHelmet, 1);
            recipe.AddIngredient(ItemID.GreenDye, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}