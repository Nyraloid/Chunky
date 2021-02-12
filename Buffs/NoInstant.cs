using Terraria;
using Terraria.ModLoader;

namespace Chunky.Buffs
{
    public class NoInstant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("No Instants");
            Description.SetDefault("Generic Cooldown");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            modPlayer.noInstant = true;
        }
    }
}