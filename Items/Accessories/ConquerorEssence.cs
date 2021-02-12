using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Accessories
{
    public class ConquerorEssence : ModItem
    {
        //I think im just gonna leave these in. They're a reminder to keep the mod balanced.
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Conqueror");
            Tooltip.SetDefault("Replaces the Magic Watch and lets you stop time.\n+1 second of stopped time.\nHas the combined stats of the entire Conqueror set, including set bonus.\nEffects can be stacked with the Conqueror set itself.\n'The accumulated power of generations of time stopping vampires.'");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 7;
            item.height = 11;
            item.value = 1000000;
            item.rare = -12;
            item.maxStack = 1;
            item.accessory = true;
            item.defense = 3;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            modPlayer.CanUseTimeMagic = true;
            modPlayer.CanUseTimeReverse = true;
            Vector2 position = player.position;
            Lighting.AddLight((int)((position.X + (float)(player.width / 2)) / 16f), (int)((position.Y + (float)(player.height / 2)) / 16f), 1.11f, .90f, .40f);

            //Combined armor stats


            //Headband
            player.meleeDamage *= 2;
            player.magicDamage *= 2;
            player.rangedDamage *= 2;
            player.minionDamage *= 2;
            player.statManaMax2 += 100;
            player.statLifeMax2 += 100;
            player.manaCost -= 0.3f;
            modPlayer.tsDuration += 60;
            player.dangerSense = true;
            player.detectCreature = true;
            player.findTreasure = true;

            //Shirt
            player.meleeDamage += 0.16f;
            player.magicDamage += 0.16f;
            player.rangedDamage += 0.16f;
            player.minionDamage += 0.16f;
            player.longInvince = true;
            player.endurance += 0.1f;
            modPlayer.tsDuration += 60;
            if (ChunkyWorld.TOKIWOTOMARE == 0 && !modPlayer.tsChillBro)
            {
                player.buffImmune[BuffID.ChaosState] = true;
            }

            //Pants
            player.meleeDamage += 0.12f;
            player.magicDamage += 0.12f;
            player.rangedDamage += 0.12f;
            player.minionDamage += 0.12f;
            modPlayer.tsDuration += 60;
            player.buffImmune[BuffID.OnFire] = true;
            player.lavaImmune = true;
            player.waterWalk = true;
            player.buffImmune[BuffID.Burning] = true;
            player.moveSpeed += 4.5f;
            player.maxFallSpeed += 28;
            player.maxRunSpeed += 4.5f;
            player.jumpSpeedBoost += 4.5f;

            //Armor set
            modPlayer.tsDuration += 360;
            modPlayer.tsCoolDown -= 360;
            player.lifeRegen += 10;
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
            player.noKnockback = true;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.Black.ToVector3() * 0.6f * Main.essScale);
        }

        public override void AddRecipes() //I have to make this as impossible but probable as possible
        {
            //ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "InfestedMeteorite", 100);
            //recipe.AddIngredient(null, "MoreMagicalWatch", 1);
            //recipe.AddIngredient(ItemID.FragmentNebula, 50);
            //recipe.AddIngredient(ItemID.FragmentSolar, 50);
            //recipe.AddIngredient(ItemID.FragmentVortex, 50);
            //recipe.AddIngredient(ItemID.FragmentStardust, 50);
            //recipe.AddIngredient(ItemID.Sundial, 3);

            //That's right, you need two of the full armor set to condense it into this powerful accessory
            //recipe.AddIngredient(null, "ConquerorHeadband", 2);
            //recipe.AddIngredient(null, "ConquerorShirt", 2);
            //recipe.AddIngredient(null, "ConquerorPants", 2);
            
            //recipe.AddTile(TileID.LunarCraftingStation);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }
    }
}