using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Chunky.NPCs
{
	[AutoloadHead]
	class TimeMerchant : ModNPC
	{
		// Time of day for traveller to leave (6PM)
		//public const double despawnTime = 48600.0;
		//We want him to leave the moment he goes off screen

		// the time of day the traveler will spawn (double.MaxValue for no spawn)
		// saved and loaded with the world in ExampleWorld
		public static double spawnTime = double.MaxValue;
		//He spawns under different circumstances

		// The list of items in the traveler's shop. Saved with the world and reset when a new traveler spawns
		public static List<Item> shopItems = new List<Item>();
		//He'll trade things for droplets

		public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

		public static void UpdateTravelingMerchant()
		{
			NPC traveler = FindNPC(ModContent.NPCType<TimeMerchant>()); // Find an Explorer if there's one spawned in the world
			
			if (ChunkyWorld.TOKIWOTOMARE == 0 && ChunkyWorld.TimeSkipping == 0) //If not in domain of time
			{
				// Here we despawn the NPC and send a message stating that the NPC has despawned
				//if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText("Bye, kid!", 50, 125, 255);
				//else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Bye, kid!"), new Color(50, 125, 255));
				//Main.NewText("Bye");
				traveler.active = false;
				traveler.netSkip = -1;
				traveler.life = 0;
				traveler = null;
			}
			

			// Main.time is set to 0 each morning, and only for one update. Sundialling will never skip past time 0 so this is the place for 'on new day' code
			if (ChunkyWorld.TimeSkipping > 0 || ChunkyWorld.TOKIWOTOMARE > 0)
			{
				// insert code here to change the spawn chance based on other conditions (say, npcs which have arrived, or milestones the player has passed)
				// You can also add a day counter here to prevent the merchant from possibly spawning multiple days in a row.

				/*
				// NPC won't spawn today if it stayed all night
				if (traveler == null && Main.rand.NextBool(4))
				{ // 4 = 25% Chance
				  // Here we can make it so the NPC doesnt spawn at the EXACT same time every time it does spawn
					spawnTime = GetRandomSpawnTime(5400, 8100); // minTime = 6:00am, maxTime = 7:30am
				}
				else
				{
					spawnTime = double.MaxValue; // no spawn today
				}
				*/
			}

			// Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
			if (traveler == null && CanSpawnNow())
			{
				int newTraveler = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<TimeMerchant>(), 1); // Spawning at the world spawn
				traveler = Main.npc[newTraveler];
				traveler.homeless = true;
				traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
				traveler.netUpdate = true;
				shopItems = CreateNewShop();

				// Prevents the traveler from spawning again the same day
				spawnTime = double.MaxValue;

				/*
				// Annouce that the traveler has spawned in!
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", traveler.FullName), 50, 125, 255);
				else NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasArrived", traveler.GetFullNetName()), new Color(50, 125, 255));
				*/
			}
		}

		private static bool CanSpawnNow()
		{
			//Can spawn only if hardmode and in time stop or skip
			return (ChunkyWorld.TOKIWOTOMARE > 0 || ChunkyWorld.TimeSkipping > 0) && Main.hardMode;
		}

		private static bool IsNpcOnscreen(Vector2 center)
		{
			int w = NPC.sWidth + NPC.safeRangeX * 2;
			int h = NPC.sHeight + NPC.safeRangeY * 2;
			Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
			foreach (Player player in Main.player)
			{
				// If any player is close enough to the traveling merchant, it will prevent the npc from despawning
				if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
			}
			return false;
		}

		public static double GetRandomSpawnTime(double minTime, double maxTime)
		{
			// A simple formula to get a random time between two chosen times
			return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
		}

		public static List<Item> CreateNewShop()
		{
			// create a list of item ids
			var itemIds = new List<int>();

			itemIds.Add(ItemID.WaterBolt);

			// conver to a list of items
			var items = new List<Item>();
			foreach (int itemId in itemIds)
			{
				Item item = new Item();
				item.SetDefaults(itemId);
				items.Add(item);
			}

			var yes = new List<Item>();

			return items;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Merchant");
			
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			//NPCID.Sets.DangerDetectRange[npc.type] = 0; //danger doesnt exist
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			
			//He will not attack or be attacked so we need to change that later
		}

		public override void SetDefaults()
		{
			npc.townNPC = true; // This will be changed once the NPC is spawned
			npc.friendly = true; //How do I make it so it just can't take damage in general?
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			/*
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			*/
			npc.lifeMax = int.MaxValue;
			animationType = NPCID.Guide;
			npc.knockBackResist = -1;

			//npc.immortal = true; //There we go
		}

		public static TagCompound Save()
		{
			return new TagCompound
			{
				["spawnTime"] = spawnTime,
				["shopItems"] = shopItems
			};
		}
		//tagcompound is pretty cool ngl

		public static void Load(TagCompound tag)
		{
			spawnTime = tag.GetDouble("spawnTime");
			shopItems = tag.Get<List<Item>>("shopItems");
		}

		/*
		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Sparkle>());
			}
		}
		*/

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return false; // This should always be false, because we spawn in the Travleing Merchant manually
		}

		//Time merchant will always have the same name
		public override string TownNPCName()
		{
			return "Mimir";
		}

		public override string GetChat()
		{
			/*
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my cousin's house with colors?";
			}
			switch (Main.rand.Next(4))
			{
				case 0:
					return "Sometimes my cousin feels like they're different from everyone else here.";
				case 1:
					return "What's your favorite color? My cousin's favorite colors are white and black.";
				case 2:
					{
						// Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
						Main.npcChatCornerItem = ItemID.HiveBackpack;
						return $"Hey, if you find a [i:{ItemID.HiveBackpack}], my cousin can upgrade it for you.";
					}
				default:
					return "What? My cousin doesn't have any arms or legs? Oh, don't be ridiculous!";
			}
			*/

			if (NPC.downedAncientCultist && Main.rand.NextBool(10))
			{
				return "Kid, there are stronger things out there. These otherworldly invaders are mere insects. I would help you out but I can't safely exit these spaces. Sorry, kid.";
			}
			if (NPC.downedMoonlord && Main.rand.NextBool(15))
            {
				return "Good job, kid.";
            }
			switch (Main.rand.Next(4))
            {
				case 0:
					return "I've got some stuff that might entice ya, kid!";
				case 1:
					return "Hey, ever wonder why I'm still alive? It's because of these droplets! Oh, wait, I wasn't supposed to reveal that...";
				case 2:
					return "If I were to walk around outside of a domain of time I would probably fall apart.";
				default: //apparently default makes it so that all code paths return a value
					return "Each time you mess with, well, time, you halt your worlds tributary of the river of time. But the river itself doesn't stop flowing. It thrashes against your world and every so often a drop makes its way inside!";
            }
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			/*
			foreach (Item item in shopItems)
			{
				// We dont want "empty" items and unloaded items to appear
				if (item == null || item.type == ItemID.None)
					continue;

				shop.item[nextSlot].SetDefaults(item.type);
				nextSlot++;
			}
			*/

			shop.item[nextSlot].SetDefaults(ItemID.WaterBolt);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Material.Tooth>());
		}

		public override void AI()
		{
			npc.homeless = true; // Make sure it stays homeless
		}

		//special drop. Idk if we're gonna need it since he doesnt die
		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.WaterBucket);
		}

		//It doesnt attack
		/*
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<SparklingBall>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
		*/
	}
}