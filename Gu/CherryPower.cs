using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Gu
{
    public class CherryPower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cherry Power");
            Description.SetDefault("Instant Skill, lvl 3");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            longerExpertDebuff = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            player.AddBuff(mod.BuffType("CherryPower"), 1, true);
            modPlayer.HasInstant = true;

            if (modPlayer.CanEatCherry && Chunky.Skill2.JustPressed && player.statMana >= 100)
            {
                player.AddBuff(mod.BuffType("NoPain"), modPlayer.CherryImmuneTime, true);
                player.AddBuff(mod.BuffType("YesPain"), modPlayer.CherryCooldownTime, true);
                player.AddBuff(BuffID.ManaSickness, 2700, true);
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/HOOOOOOOOO"));
            }
        }
    }
}