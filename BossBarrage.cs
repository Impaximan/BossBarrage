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
	public class BossBarrage : Mod
	{
        public static bool KingSlime;
        public static bool EyeOfCthulhu;
        public static bool EaterOfCthulhu;
        public static bool QueenBee;
        public static bool Skeletron;
        public static bool WallOfFlesh;
        public static bool TheTwins;
        public static bool TheDestroyer;
        public static bool SkeletronPrime;
        public static bool Plantera;
        public static bool Golem;
        public static bool DukeFishron;
        public static bool LunaticCultist;
        public static bool SolarPillar;
        public static bool NebulaPillar;
        public static bool StardustPillar;
        public static bool VortexPillar;
        public static bool AllPillars;
        public static bool MoonLord;

        public static int secondsBetweenEffects;
        public static int effectDamage;
        public static string effectChosingMethod;
        public static List<int> effectDebuffs;
        public static int debuffDuration;

        public static bool OnlySpawnDuringBossFights;
        public static bool InvertWorldEvils;

        public BossBarrage()
        {

        }
    }
}