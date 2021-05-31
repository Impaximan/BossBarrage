using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using Terraria.Map;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;

namespace BossBarrage
{
    class BossBarragePlayer : ModPlayer
    {
        int currentBoss;
        int currentSpotInList;
        int effectCounter = 60;

        public override void OnRespawn(Player player)
        {
            effectCounter = BossBarrage.secondsBetweenEffects * 60;
        }

        public override void OnEnterWorld(Player player)
        {
            effectCounter = BossBarrage.secondsBetweenEffects * 60;
        }

        public override void PostUpdate()
        {
            List<int> activeBosses = new List<int>();
            activeBosses.Clear();
            if (BossBarrage.KingSlime)
            {
                activeBosses.Add(1);
            }
            if (BossBarrage.EyeOfCthulhu)
            {
                activeBosses.Add(2);
            }
            if (BossBarrage.EaterOfCthulhu)
            {
                activeBosses.Add(3);
            }
            if (BossBarrage.QueenBee)
            {
                activeBosses.Add(4);
            }
            if (BossBarrage.Skeletron)
            {
                activeBosses.Add(5);
            }
            if (BossBarrage.WallOfFlesh)
            {
                activeBosses.Add(6);
            }
            if (BossBarrage.TheDestroyer)
            {
                activeBosses.Add(7);
            }
            if (BossBarrage.TheTwins)
            {
                activeBosses.Add(8);
            }
            if (BossBarrage.SkeletronPrime)
            {
                activeBosses.Add(9);
            }
            if (BossBarrage.Plantera)
            {
                activeBosses.Add(10);
            }
            if (BossBarrage.Golem)
            {
                activeBosses.Add(11);
            }
            if (BossBarrage.DukeFishron)
            {
                activeBosses.Add(12);
            }
            if (BossBarrage.LunaticCultist)
            {
                activeBosses.Add(13);
            }
            if (BossBarrage.SolarPillar)
            {
                activeBosses.Add(14);
            }
            if (BossBarrage.NebulaPillar)
            {
                activeBosses.Add(15);
            }
            if (BossBarrage.VortexPillar)
            {
                activeBosses.Add(16);
            }
            if (BossBarrage.StardustPillar)
            {
                activeBosses.Add(17);
            }
            if (BossBarrage.AllPillars)
            {
                activeBosses.Add(18);
            }
            if (BossBarrage.MoonLord)
            {
                activeBosses.Add(19);
            }

            bool anyBoss = false;
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead) && Main.npc[i].active && Main.npc[i].life > 0)
                {
                    anyBoss = true;
                }
            }

            if (activeBosses.Count == 0 || (BossBarrage.OnlySpawnDuringBossFights && !anyBoss))
            {
                return;
            }

            if (effectCounter > BossBarrage.secondsBetweenEffects * 60)
            {
                effectCounter = BossBarrage.secondsBetweenEffects * 60;
            }

            if (activeBosses.Count > 0)
            {
                effectCounter--;
                if (currentSpotInList > activeBosses.Count - 1)
                {
                    currentBoss = activeBosses[activeBosses.Count - 1];
                }
            }
            if (effectCounter <= 0)
            {
                effectCounter = BossBarrage.secondsBetweenEffects * 60;

                if (BossBarrage.effectChosingMethod == "Random")
                {
                    int spot = Main.rand.Next(0, activeBosses.Count);

                    currentBoss = activeBosses[spot];
                    currentSpotInList = spot;
                }
                if (BossBarrage.effectChosingMethod == "Alternating in order of progression")
                {
                    currentSpotInList++;
                    if (currentSpotInList > activeBosses.Count - 1)
                    {
                        currentBoss = activeBosses[0];
                        currentSpotInList = 0;
                    }
                    else
                    {
                        currentBoss = activeBosses[currentSpotInList];
                    }
                }

                if (currentBoss == 1)
                {
                    KingSlime();
                }

                if (currentBoss == 2)
                {
                    EyeOfCthulhu();
                }

                if (currentBoss == 3)
                {
                    if (WorldGen.crimson)
                    {
                        if (BossBarrage.InvertWorldEvils)
                        {
                            EaterOfWorlds();
                        }
                        else
                        {
                            BrainOfCthulhu();
                        }
                    }
                    else
                    {
                        if (!BossBarrage.InvertWorldEvils)
                        {
                            EaterOfWorlds();
                        }
                        else
                        {
                            BrainOfCthulhu();
                        }
                    }
                }

                if (currentBoss == 4)
                {
                    QueenBee();
                }

                if (currentBoss == 5)
                {
                    Skeletron();
                }

                if (currentBoss == 6)
                {
                    WallOfFlesh();
                }

                if (currentBoss == 7)
                {
                    TheDestroyer();
                }

                if (currentBoss == 8)
                {
                    TheTwins();
                }

                if (currentBoss == 9)
                {
                    SkeletronPrime();
                }

                if (currentBoss == 10)
                {
                    Plantera();
                }

                if (currentBoss == 11)
                {
                    Golem();
                }

                if (currentBoss == 12)
                {
                    DukeFishron();
                }

                if (currentBoss == 13)
                {
                    LunaticCultist();
                }

                if (currentBoss == 14)
                {
                    SolarPillar();
                }

                if (currentBoss == 15)
                {
                    NebulaPillar();
                }

                if (currentBoss == 16)
                {
                    VortexPillar();
                }

                if (currentBoss == 17)
                {
                    StardustPillar();
                }

                if (currentBoss == 18)
                {
                    SolarPillar();
                    NebulaPillar();
                    VortexPillar();
                    StardustPillar();
                }

                if (currentBoss == 19)
                {
                    MoonLord();
                }
            }
        }

        public void KingSlime()
        {

        }

        public void EyeOfCthulhu()
        {

        }

        public void EaterOfWorlds()
        {

        }

        public void BrainOfCthulhu()
        {
            float direction = MathHelper.ToRadians(Main.rand.Next(361));
            Vector2 directionVector = direction.ToRotationVector2();
            int distance = 450;
            Vector2 position = directionVector * distance + player.Center;

            Main.PlaySound(SoundID.Roar, (int)position.X, (int)position.Y, Style: 0, pitchOffset: 0.5f);
            NPC.NewNPC((int)position.X, (int)position.Y, ModContent.NPCType<NPCs.BrainOfBarragethulhu>());
        }

        public void QueenBee()
        {

        }

        public void Skeletron()
        {

        }

        public void WallOfFlesh()
        {

        }

        public void TheDestroyer()
        {

        }

        public void TheTwins()
        {

        }

        public void SkeletronPrime()
        {

        }

        public void Plantera()
        {

        }

        public void Golem()
        {

        }

        public void DukeFishron()
        {

        }

        public void LunaticCultist()
        {

        }

        public void SolarPillar()
        {

        }

        public void NebulaPillar()
        {

        }

        public void VortexPillar()
        {

        }

        public void StardustPillar()
        {

        }

        public void MoonLord()
        {

        }
    }
}
