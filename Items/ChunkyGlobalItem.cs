using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Chunky.Items
{
    public class ChunkyGlobalItem : GlobalItem
    {
        public ChunkyGlobalItem()
        {

        }

        public override bool InstancePerEntity => true; //ok i guess it can go like this too

        public override bool CloneNewInstances => true; //and also this is required apparently

        public override void SetDefaults(Item item)
        {

        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            base.OpenVanillaBag(context, player, arg);
            /*
            if (arg == ItemID.EaterOfWorldsBossBag)
            {
                int rand = Main.rand.Next(5);
                switch (rand)
                {
                    case 1:
                        player.QuickSpawnItem(ItemID.ShadowOrb, 1);
                        break;
                    case 2:
                        player.QuickSpawnItem(ItemID.Vilethorn, 1);
                        break;
                    case 3:
                        player.QuickSpawnItem(ItemID.BandofStarpower, 1);
                        break;
                    case 4:
                        player.QuickSpawnItem(ItemID.BallOHurt, 1);
                        break;
                    default:
                        player.QuickSpawnItem(ItemID.Musket, 1);
                        player.QuickSpawnItem(ItemID.MusketBall, 100);
                        break;
                }
            }
            */
            //that's how you put other stuff in treasure bags
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (ChunkyWorld.TOKIWOTOMARE > 0) maxFallSpeed = 0; //so apparently this removes falling during stopped time and then it goes back to normal once time resumes. No clue why I don't have to set it back myself.
            //Is there a way to do that for other directions though?
        }
    }
}
