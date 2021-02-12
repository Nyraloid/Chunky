using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Items.Gu
{
    public class Terror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Artifact");
            Tooltip.SetDefault("What kind of artifact could come from an alien world?\nHow is this related to me?\nWhat lurks in the great beyond?");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 0;
            item.rare = ItemRarityID.Expert;

            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 18;
            item.useTime = 45;
            item.consumable = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(mod, "?", "Use it")
            {
                overrideColor = new Color(22, 22, 29)
            };
            tooltips.Add(line);
        }

        public override bool CanUseItem(Player player)
        {
            ChunkyPlayer modPlayer = player.GetModPlayer<ChunkyPlayer>();
            if (player.HasBuff(mod.BuffType("Terror"))) return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("Terror"), 1, true);
            Main.NewText("Great work.", Color.BlanchedAlmond, true);
            return true;
        }
    }
}