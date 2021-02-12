using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Material
{
    public class TimeDroplet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Droplet of Time");
            Tooltip.SetDefault("Cannot exist outside of a domain of time.\nA tiny, crystalline drop from the river of time.\nYou sense endless depth within it.\nIt is said that these drops attract a mystical merchant...");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = 0;
            item.rare = ItemRarityID.Gray;
            item.maxStack = 1;
        }

        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            if (ChunkyWorld.TimeSkipping == 0 && ChunkyWorld.TOKIWOTOMARE == 0) item.active = false;
        }
    }
}