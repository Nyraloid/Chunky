using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class DemonMan : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hell Skin");
            Description.SetDefault("Infinite Skill, lvl 3");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            modPlayer.HasInfinite = true;
            player.AddBuff(mod.BuffType("DemonMan"), 1);
            player.maxFallSpeed += 10;
            player.statLifeMax2 -= 20;
            player.endurance += 0.15f;
            player.wingTime += 20;
            player.noFallDmg = true;
            player.lavaImmune = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Confused] = true;

            if (Main.rand.Next(3600 * 25) == 0) player.QuickSpawnItem(ItemID.Diamond, Main.rand.Next(1,3));
            if (Main.rand.Next(3600 * 500) == 0) player.QuickSpawnItem(ItemID.LifeCrystal, 1);
            if (Main.hardMode && Main.rand.Next(3600 * 50) == 0) player.QuickSpawnItem(ItemID.CrystalShard, 1);

            if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.Hellstone, Main.rand.Next(1, 5));
            if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.Obsidian, Main.rand.Next(1, 5));
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.DemoniteOre, Main.rand.Next(3, 6));
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.CrimtaneOre, Main.rand.Next(3, 6));
            if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(mod.ItemType("GeodeObsidian"), 1);

            if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.Fireblossom, 1);
            if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.LivingFireBlock, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.DemonScythe, 1);
            if (Main.hardMode && Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.DemonWings, 1);
            if (Main.hardMode && Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.CrystalStorm, 1); //heh heh...

            if (Main.hardMode)
            {
                if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.CobaltOre, 1);
                if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.PalladiumOre, 1);
                if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(ItemID.MythrilOre, 1);
                if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(ItemID.OrichalcumOre, 1);
                if (Main.rand.Next(3600 * 50) == 0) player.QuickSpawnItem(ItemID.AdamantiteOre, 1);
                if (Main.rand.Next(3600 * 50) == 0) player.QuickSpawnItem(ItemID.TitaniumOre, 1);
            }
        }
    }
}