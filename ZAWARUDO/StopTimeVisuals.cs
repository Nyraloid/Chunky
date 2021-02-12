using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Chunky;
using Chunky.NPCs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace Chunky.ZAWARUDO
{
    //Without Enigma, I don't know what I would've done. I don't think I could've even started modding what I wanted

    //yeah ngl idk wtf almost any of this does

    //for future reference, the hue of blocks is in Chunky.cs, not here.

    public class TsShader : ScreenShaderData
    {
        public TsShader(string passName)
            : base(passName)
        {}

        public override void Apply()
        {
            base.Apply();
        }
    }

    public class TsVisual : CustomSky
    {
        private bool isActive = false;
        private float intensity = 0f;

        public override void Update(GameTime gameTime)
        {
            if (isActive && intensity < 1f) //ok so until intensity is 100% it increases by 1%?
            {
                intensity += 0.02f;
            }
            else if (!isActive && intensity > 0f) //and then it goes from 100 to 0 the same way
            {
                intensity -= 0.02f;
            }
        }

        private float GetIntensity()
        {
            if (ChunkyWorld.TOKIWOTOMARE > 0)
            {
                return (1f - Utils.SmoothStep(3000f, 6000f, 1)) * 0.66f; //ok so 66% should be the level of overlay it has with the background
            }
            return 0.66f; //ok so intensity is normally 66% then?
        }

        public override Color OnTileColor(Color inColor) //yeah idk what this bit actually does cuz the tile color is handeled in Chunky.cs
        {
            float intensity = this.GetIntensity(); //ok
            return new Color(Vector4.Lerp(new Vector4(0.4f, 0.4f, 0.4f, 1f), inColor.ToVector4(), 1f - intensity)); //wtf is a 4D vector
        }


        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0 && minDepth < 0)
            {
                float intensity = this.GetIntensity();
                spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(10, 10, 10) * intensity); //this is the actual background color overlay thingy
            }
        }

        public override float GetCloudAlpha()
        {
            return 0f;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            isActive = false;
        }

        public override void Reset()
        {
            isActive = false;
        }

        public override bool IsActive()
        {
            return isActive || intensity > 0f;
        }
    }
}