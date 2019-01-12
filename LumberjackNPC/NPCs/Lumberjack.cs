using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace LumberjackNPC.NPCs
{
	[AutoloadHead]
	public class LumberjackNPC : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "LumberjackNPC/NPCs/Lumberjack";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "LumberjackNPC/NPCs/Lumberjack_Alt_1" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Lumberjack";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 70;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 25;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss1)  //after EoC is killed
            {
                return true;
            }
            return false;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)    
        {
            return true;  
        }

        public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Robbie";
				case 1:
					return "Jack";
				case 2:
					return "Yukon";
				default:
					return "Chuck";
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int Dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int Truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
            int TaxCollector = NPC.FindFirstNPC(NPCID.TaxCollector);

            if (Dryad >= 0 && Main.rand.Next(11) == 0)
			{
				return "Seems like " + Main.npc[Dryad].GivenName + " isn't too happy with my business. Even though my wood is completely natural! Can you understand that?";
			}
            if (Truffle >= 0 && Main.rand.Next(10) == 0)
            {
                return "Once I was just walking around in some caves when I saw some massive shiny mushrooms. Sure hope " + Main.npc[Truffle].GivenName + " doesn't mind me chopping them down.";
            }
            if (Wizard >= 0 && Main.rand.Next(9) == 0)
            {
                return Main.npc[Wizard].GivenName + " gave me some odd looking twigs the other day. Perhaps you know what to do with these.";
            }
            if (TaxCollector >= 0 && Main.rand.Next(8) == 0)
            {
                return "If " + Main.npc[TaxCollector].GivenName + " asks, I'm not home!";
            }
            switch (Main.rand.Next(7))
			{
				case 0:
					return "Despite what that salesman might tell you, Dynasty wood isn't actually real wood.";
				case 1:
					return "I have never actually found a spooky tree. At this point I'm not sure they exist.";
                case 2:
                    return "What's that? Cactus isn't wood? Say that to my axe.";
                case 3:
                    return "I've heard people saying they've found massive trees underground before! I would love to chop one down some day.";
                case 4:
                    return "Once I chopped down one of the largest trees I have ever seen, and it turned out there was a house hiding underneath it. I sure hope nobody lived there anymore.";
                case 5:
                    return "Did you know trees in the jungle can grow completely on their own? You don't even have to plant anything! Very convenient.";
				default:
					return "TIMBERRR!";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Shop";
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
            shop.item[nextSlot].SetDefaults(ItemID.Wood);
            shop.item[nextSlot].value = 50;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
            shop.item[nextSlot].value = 50;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.RichMahogany);
            shop.item[nextSlot].value = 60;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.PalmWood);
            shop.item[nextSlot].value = 60;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.PineTreeBlock);
            shop.item[nextSlot].value = 150;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Cactus);
            shop.item[nextSlot].value = 30;
            nextSlot++;

            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GlowingMushroom);
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }

            shop.item[nextSlot].SetDefaults(ItemID.Ebonwood);
            shop.item[nextSlot].value = 70;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Shadewood);
            shop.item[nextSlot].value = 70;
            nextSlot++;

            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Pearlwood);
                shop.item[nextSlot].value = 100;
                nextSlot++;
            }

            shop.item[nextSlot].SetDefaults(ItemID.LivingLoom);
            shop.item[nextSlot].value = 100000;
            nextSlot++;

            if (NPC.savedWizard)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LivingWoodWand);
                shop.item[nextSlot].value = 50000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LeafWand);
                shop.item[nextSlot].value = 50000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LivingMahoganyWand);
                shop.item[nextSlot].value = 75000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LivingMahoganyLeafWand);
                shop.item[nextSlot].value = 75000;
                nextSlot++;
            }
        }

        public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType<Items.Lumberhat>());
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 10;
			knockback = 2f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 10;
		}

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            scale = 1f;
            item = Main.itemTexture[3494]; //lead axe
            itemSize = 72;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) 
        {
            itemWidth = 50;
            itemHeight = 50;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Gore_3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Gore_2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Gore_1"));
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}