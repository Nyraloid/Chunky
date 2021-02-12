using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Weapons
{
    public class GloryHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Timely Hammer");
            Tooltip.SetDefault("'Miniscule Goblins, Impractical Sword.'");
        }

        public override void SetDefaults()
        {
            item.scale = 1.5f;
            item.width = 64;
            item.height = 64;
            item.value = 10000000;
            item.rare = -1;
            item.melee = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 30;
            item.UseSound = SoundID.Item1;
            item.damage = 500;
            item.hammer = 9999;
            item.autoReuse = true;
            item.crit = 0;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int heal = damage / 60;
            if (heal > 50) heal = 50;
            player.statLife += heal;
            player.HealEffect(heal, true);
        }

        public override void UpdateInventory(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();

            modPlayer.CanUseTimeMagic = true;
            player.buffImmune[BuffID.ChaosState] = true;
            modPlayer.tsDuration += 360;
            player.statDefense += 100;
            player.statLifeMax2 += 100;
            player.statManaMax2 += 20;
            player.ZoneWaterCandle = true;
            player.wingTimeMax += 200;
            player.maxFallSpeed = 670000000;
            player.maxRunSpeed = 670000000;
            if (player.extraAccessorySlots <= 1 && Main.expertMode) player.extraAccessorySlots += 1;


            //the essence of the conqueror effects
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

        public override void HoldItem(Player player)
        {
            if (ChunkyWorld.TOKIWOTOMARE > 0)
            { 
                player.ClearBuff(mod.BuffType("OutOfTime"));
                player.ClearBuff(mod.BuffType("StoppedTime"));
                player.AddBuff(mod.BuffType("OutOfTime"), 720, true);
                player.AddBuff(mod.BuffType("StoppedTime"), 1, true);
                ChunkyWorld.TOKIWOTOMARE = 2;
            }

            if (player.moveSpeed == 0) player.shinyStone = true; player.invis = true;
            player.wingTimeMax = -1;
        }

        public override void AddRecipes()
        {
            //ModRecipe recipeP = new ModRecipe(mod);
            //recipeP.AddIngredient(null, "Man"); //An entire man
            //recipeP.AddIngredient(null, "ConquerorEssence"); //the essence of a conqueror
            //recipeP.AddIngredient(null, "MegaMetalBar"); //the entire world's metals
            //recipeP.AddIngredient(null, "EntireWorld"); //ZA WARUDO



            //recipeP.AddTile(TileID.LunarCraftingStation);
            //recipeP.SetResult(this);
            //recipeP.AddRecipe();

            //ModRecipe recipeE = new ModRecipe(mod);
            //recipeE.AddIngredient(null, "DIOLightSaber", 1); //It's literally the same thing
            //recipeE.AddTile(TileID.LunarCraftingStation);
            //recipeE.SetResult(this);
            //recipeE.AddRecipe();
        }
    }
}