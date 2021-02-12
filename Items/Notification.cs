using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items
{
    public class Notification : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Notification");
            Tooltip.SetDefault("Use me");
        }

        public override void SetDefaults()
        {
            item.width = 0;
            item.height = 0;
            item.rare = 0;
            item.consumable = true;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("Thank you for playing the Chunky mod! Remember to configure your hotkeys, they're very important", 123, 1, 1);
            return true;
        }
    }
}
