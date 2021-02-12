using Terraria;
using Terraria.ModLoader;

namespace Chunky.Buffs
{
    public class NoNormal : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("No Normals");
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
            modPlayer.noNormal = true;
        }
    }
}