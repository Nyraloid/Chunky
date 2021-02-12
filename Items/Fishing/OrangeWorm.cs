using Terraria.ModLoader;

namespace Chunky.Items.Fishing
{
    public class OrangeWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magmatic Worm");
            Tooltip.SetDefault("Fished in the Underworld\n'How the hell did a worm survive down there? ;)'");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 18;
            item.maxStack = 10;
            item.value = 31415;
            item.bait = 40;
        }
    }
}