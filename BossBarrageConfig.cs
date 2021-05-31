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
    class BossBarrageConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static BossBarrageConfig Instance;


        [Header("Effect stats")]

        [Label("[i/s1:3099] Time in between effects (in seconds)")]
        [Tooltip("How much time, in seconds, there will be before another effect occurs")]
        [DefaultValue(30)]
        public int timeBetweenEffects;

        [Label("[i/s1:3106]  Effect damage")]
        [Tooltip("How much damage each effect does on-hit")]
        [DefaultValue(45)]
        public int damage;


        [Label("[i/s1:521] Effect chosing")]
        [Tooltip("How which effect happens is chosen")]
        [DefaultValue("Random")]
        [Slider()]
        [OptionStrings(new string[3]{
            "Random",
            "Alternating in order of progression",
            "All at once"
        })]
        public string method;

        [Label("[i/s1:522][i/s1:1332] Inflicted buffs")]
        [Tooltip("Add a buff's ID to the list to make the effect inflict that buff on hit\nYou can find a specific buff's ID on the terraria gamepedia wiki (debuffs are also technically buffs)")]
        public List<int> inflictedBuffs = new List<int>();

        [Label("[i/s1:678] Inflicted buff duration (in seconds)")]
        [Tooltip("How much time in seconds the inflicted buff will last" +
            "\nNote that some debuffs will automatically last twice as long in expert mod")]
        [DefaultValue(5)]
        public int buffTime;


        [Header("Effect Requirements/Type")]

        [Label("[i/s1:43]  Only spawn during boss fights")]
        [Tooltip("When enabled, the effect can only occur while there is a boss nearby")]
        [DefaultValue(false)]
        public bool bossfightonly;

        [Label("[i/s1:1968] Invert World Evils")]
        [Tooltip("When enabled, the world evil boss effect will be swapped to the one it usually isn't")]
        [DefaultValue(false)]
        public bool invertworldevils;


        [Header("Boss effects")]

        [Label("[i/s1:2493] King Slime")]
        [Tooltip("Whether or not King Slime's effect will occur")]
        [DefaultValue(false)]
        public bool kingSlime;

        [Label("[i/s1:2112] Eye of Cthulhu")]
        [Tooltip("Whether or not the EoC's effect will occur")]
        [DefaultValue(false)]
        public bool EoC;

        [Label("[i/s1:2111] /[i/s1:2104]  World Evil Boss")]
        [Tooltip("Whether or not EoW/BoC's effect will occur\nThe effect that occurs depends on the current world evil")]
        [DefaultValue(false)]
        public bool EoB;

        [Label("[i/s1:2108] Queen Bee")]
        [Tooltip("Whether or not the Queen Bee's effect will occur")]
        [DefaultValue(false)]
        public bool queenBee;

        [Label("[i/s1:1281] Skeletron")]
        [Tooltip("Whether or not Skeletron's effect will occur")]
        [DefaultValue(false)]
        public bool skeletron;

        [Label("[i/s1:2105] Wall of Flesh")]
        [Tooltip("Whether or not the WoF's effect will occur")]
        [DefaultValue(false)]
        public bool WoF;

        [Label("[i/s1:2113] Destroyer")]
        [Tooltip("Whether or not the Destroyer's effect will occur")]
        [DefaultValue(false)]
        public bool destroyer;

        [Label("[i/s1:2106] The Twins")]
        [Tooltip("Whether or not the Twins' effect will occur")]
        [DefaultValue(false)]
        public bool twins;

        [Label("[i/s1:2107] Skeletron Prime")]
        [Tooltip("Whether or not Skeletron Prime's effect will occur")]
        [DefaultValue(false)]
        public bool amazonPrime;

        [Label("[i/s1:2109] Plantera")]
        [Tooltip("Whether or not the Plantera's effect will occur")]
        [DefaultValue(false)]
        public bool plant;

        [Label("[i/s1:2110] Golem")]
        [Tooltip("Whether or not the Golem's effect will occur")]
        [DefaultValue(false)]
        public bool golem;

        [Label("[i/s1:2588] Duke Fishron")]
        [Tooltip("Whether or not Duke Fishron's effect will occur")]
        [DefaultValue(false)]
        public bool duke;

        [Label("[i/s1:3372] Lunatic Cultist")]
        [Tooltip("Whether or not the Lunatic Cultist's effect will occur")]
        [DefaultValue(false)]
        public bool cultist;

        [Label("[i/s1:3539] Solar Pillar")]
        [Tooltip("Whether or not the Solar Pillar's effect will occur")]
        [DefaultValue(false)]
        public bool solar;

        [Label("[i/s1:3537] Nebula Pillar")]
        [Tooltip("Whether or not the Nebula Pillar's effect will occur")]
        [DefaultValue(false)]
        public bool nebula;

        [Label("[i/s1:3536] Vortex Pillar")]
        [Tooltip("Whether or not the Vortex Pillar's effect will occur")]
        [DefaultValue(false)]
        public bool vortex;

        [Label("[i/s1:3538] Stardust Pillar")]
        [Tooltip("Whether or not the Stardust Pillar's effect will occur")]
        [DefaultValue(false)]
        public bool stardust;

        [Label("[i/s1:3601]  Combined Pillars")]
        [Tooltip("Whether or not the combined effects of the pillars will occur")]
        [DefaultValue(false)]
        public bool pillars;

        [Label("[i/s1:3373] Moon Lord")]
        [Tooltip("Whether or not the Moon Lord's effect will occur")]
        [DefaultValue(false)]
        public bool ML;



        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            return true;
        }

        public override void OnLoaded()
        {

        }

        public override void OnChanged()
        {
            BossBarrage.KingSlime = kingSlime;
            BossBarrage.EyeOfCthulhu = EoC;
            BossBarrage.EaterOfCthulhu = EoB;
            BossBarrage.QueenBee = queenBee;
            BossBarrage.Skeletron = skeletron;
            BossBarrage.WallOfFlesh = WoF;
            BossBarrage.TheDestroyer = destroyer;
            BossBarrage.TheTwins = twins;
            BossBarrage.SkeletronPrime = amazonPrime;
            BossBarrage.Plantera = plant;
            BossBarrage.Golem = golem;
            BossBarrage.DukeFishron = duke;
            BossBarrage.LunaticCultist = cultist;
            BossBarrage.MoonLord = ML;
            BossBarrage.VortexPillar = vortex;
            BossBarrage.NebulaPillar = nebula;
            BossBarrage.SolarPillar = solar;
            BossBarrage.StardustPillar = stardust;
            BossBarrage.AllPillars = pillars;

            BossBarrage.secondsBetweenEffects = timeBetweenEffects;
            BossBarrage.effectDamage = damage;
            BossBarrage.effectChosingMethod = method;
            BossBarrage.effectDebuffs = inflictedBuffs;
            BossBarrage.debuffDuration = buffTime;

            BossBarrage.OnlySpawnDuringBossFights = bossfightonly;
            BossBarrage.InvertWorldEvils = invertworldevils;
        }
    }
}

