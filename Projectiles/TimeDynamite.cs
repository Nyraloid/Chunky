using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace Chunky.Projectiles
{
	internal class TimeDynamite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("skip");
		}

		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
		}

		public override void AI()
		{
			int t = 61 - projectile.timeLeft;
			Main.time += (double)(24 * 60 * 60 / ((Math.Log(61) + 0.577) * t)) - 1; //heh heh

			//I want to make the screen go black and kill the player as well
		}
	}
}