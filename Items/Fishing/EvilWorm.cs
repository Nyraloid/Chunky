using Terraria.ModLoader;
using Terraria;

namespace Chunky.Items.Fishing
{
    public class EvilWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Worm");
            Tooltip.SetDefault("Increases fishing skill by 30 and ranged damage by 10%\n'The ancient spirits of darkness seem to have influenced this worm heavily'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 22;
            item.maxStack = 1;
            item.value = 10000000;
            item.accessory = true;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage *= 1.1f;
            player.fishingSkill += 30;
        }
    }
}