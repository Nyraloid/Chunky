using Terraria;
using Terraria.ModLoader;
using Chunky.NPCs;

namespace Chunky.KingCrimson
{
    public class TimeLeap : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Skipping Time");
            Description.SetDefault("It Just Works");
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ChunkyPlayer>().kcImmune = true;
        }
    }
}