using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Chunky.Tiles
{
    public class LifePodTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            //Main.tileTable[Type] = true;
            //Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lifepod");
            AddMapEntry(new Color(200, 200, 200), name);
            disableSmartCursor = true;
            //adjTiles = new int[] { TileID.WorkBenches };
            //animationFrameHeight = 74;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 40, ModContent.ItemType<Items.BodySwap.LifePod>());
        }
    }
}