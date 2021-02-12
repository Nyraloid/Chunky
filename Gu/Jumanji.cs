using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class Jumanji : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Jungle's Blessing");
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
            player.AddBuff(mod.BuffType("Jumanji"), 1);
            if (player.statLife <= (player.statLifeMax / 10)) player.AddBuff(BuffID.Honey, 1);

            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.JungleSpores, Main.rand.Next(1, 3));
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.Moonglow, 1);
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.JungleGrassSeeds, 1);
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.HoneyBlock, 1);
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.VioletHusk, 1);
            if (Main.rand.Next(3600 * 10) == 0) player.QuickSpawnItem(ItemID.JungleRose, 1);
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.Stinger, 1);
            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.Vine, 1);
            if (Main.rand.Next(3600 * 30) == 0) player.QuickSpawnItem(mod.ItemType("JungleGeode"), 1);
            if (Main.rand.Next(3600 * 70) == 0) player.QuickSpawnItem(ItemID.LivingMahoganyLeafWand, 1);
            if (Main.rand.Next(3600 * 70) == 0) player.QuickSpawnItem(ItemID.LivingMahoganyWand, 1);
            if (Main.rand.Next(3600 * 70) == 0) player.QuickSpawnItem(ItemID.SkyBlueFlower, 1);
            if (Main.rand.Next(3600 * 140) == 0) player.QuickSpawnItem(ItemID.NaturesGift, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.AnkletoftheWind, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.FeralClaws, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.FlowerBoots, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.StaffofRegrowth, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.Boomstick, 1);
            if (Main.rand.Next(3600 * 300) == 0) player.QuickSpawnItem(ItemID.FiberglassFishingPole, 1);

            if (Main.rand.Next(3600 * 20) == 0) player.QuickSpawnItem(ItemID.Grubby, 1);
            if (Main.rand.Next(3600 * 80) == 0) player.QuickSpawnItem(ItemID.Sluggy, 1);
            if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.Buggy, 1);
            if (Main.rand.Next(3600 * 500) == 0) player.QuickSpawnItem(mod.ItemType("SmugBug"), 1);

            if (Main.hardMode)
            {
                if (Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.ButterflyDust, 1);
                if (Main.rand.Next(3600 * 300) == 0) player.QuickSpawnItem(ItemID.LifeFruit, 1);
                if (Main.rand.Next(3600 * 150) == 0 && NPC.downedMechBossAny) player.QuickSpawnItem(ItemID.LifeFruit, 1);
                if (NPC.downedPlantBoss && Main.rand.Next(3600 * 200) == 0) player.QuickSpawnItem(ItemID.ChlorophyteOre, 1);
                if (NPC.downedPlantBoss && Main.rand.Next(3600 * 800) == 0) player.QuickSpawnItem(ItemID.ChlorophyteBar, 1);
                if (NPC.downedPlantBoss && Main.rand.Next(3600 * 800) == 0) player.QuickSpawnItem(ItemID.JungleKey, 1);
            }
        }
    }
}