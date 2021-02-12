using Terraria;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class SkipTime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Skip Time");
            Description.SetDefault("Armor Skill, lvl 5");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }
    }
}