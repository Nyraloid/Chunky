using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class Hive : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bees");
            Description.SetDefault("Infinite Skill, lvl 2");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("Hive"), 1, true);
            modPlayer.HasInfinite = true;
            player.honey = true;

            if (Main.rand.Next(3600 * 2) == 0) player.QuickSpawnItem(ItemID.BottledHoney, 1);
            if (Main.rand.Next(3600 * 5) == 0) player.QuickSpawnItem(ItemID.HoneyBlock, 1);
            if (Main.rand.Next(3600 * 7) == 0) player.QuickSpawnItem(ItemID.BeeWax, 1);
            if (Main.rand.Next(3600 * 8) == 0) player.QuickSpawnItem(ItemID.Stinger, 1);
            if (Main.rand.Next(3600 * 16) == 0) player.QuickSpawnItem(ItemID.Hive, 1);
            if (Main.rand.Next(3600 * 33) == 0) player.QuickSpawnItem(ItemID.HoneyComb, 1);
            if (Main.rand.Next(3600 * 50) == 0 && Main.hardMode) player.QuickSpawnItem(ItemID.TatteredBeeWing, 1);
        }
    }
}