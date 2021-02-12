using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class StoneMan : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stone Skin");
            Description.SetDefault("Infinite Skill, lvl 2");
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
            player.AddBuff(mod.BuffType("StoneMan"), 1);
            player.maxFallSpeed += 20;
            player.statLifeMax2 -= 50;
            player.endurance += 0.10f;

            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.Topaz, 1);
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.Amethyst, 1);
            if (Main.rand.Next(3600 * 15) == 0) player.QuickSpawnItem(ItemID.Ruby, 1);
            if (Main.rand.Next(3600 * 15) == 0) player.QuickSpawnItem(ItemID.Sapphire, 1);
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.Emerald, 1);
            if (Main.rand.Next(3600 * 25) == 0) player.QuickSpawnItem(ItemID.Diamond, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.LifeCrystal, 1);
            if (Main.rand.Next(3600 * 150) == 0 && Main.hardMode) player.QuickSpawnItem(ItemID.CrystalShard, 1);

            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.CopperOre, 1);
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.TinOre, 1);
            if (Main.rand.Next(3600 * 15) == 0) player.QuickSpawnItem(ItemID.LeadOre, 1);
            if (Main.rand.Next(3600 * 15) == 0) player.QuickSpawnItem(ItemID.IronOre, 1);
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.TungstenOre, 1);
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.SilverOre, 1);
            if (Main.rand.Next(3600 * 25) == 0) player.QuickSpawnItem(ItemID.GoldOre, 1);

            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(mod.ItemType("Geode"), 1);

            /*
            if (Main.hardMode)
            {
                if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.CobaltOre, 1);
                if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(ItemID.PalladiumOre, 1);
                if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(ItemID.MythrilOre, 1);
                if (Main.rand.Next(3600 * 40) == 0) player.QuickSpawnItem(ItemID.OrichalcumOre, 1);
                if (Main.rand.Next(3600 * 50) == 0) player.QuickSpawnItem(ItemID.AdamantiteOre, 1);
                if (Main.rand.Next(3600 * 50) == 0) player.QuickSpawnItem(ItemID.TitaniumOre, 1);
            }
            */
        }
    }
}