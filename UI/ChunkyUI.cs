using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace Chunky.UI
{
    internal class ChunkyUI : UIState
    {
        public static bool visible;
        private DragableUIPanel panel;
        public float oldScale;

        public override void OnInitialize()
        {
            // if you set this to true, it will show up in game
            visible = true;

            panel = new DragableUIPanel(); //initialize the panel
            // ignore these extra 0s
            panel.Left.Set(800, 0); //this makes the distance between the left of the screen and the left of the panel 800 pixels (somewhere by the middle).
            panel.Top.Set(100, 0); //this is the distance between the top of the screen and the top of the panel
            panel.Width.Set(100, 0);
            panel.Height.Set(100, 0);

            Append(panel); //appends the panel to the UIState
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
        }
    }
}

///No clue how to use UI as of 9/16/2020