using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System;

namespace BossBarrage.NPCs
{
    class BrainOfBarragethulhu : ModNPC
    {
        float sbeve = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brain of Cthulhu");
            Main.npcFrameCount[npc.type] = 4;
        }

        int frame = 0;
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter--;
            if (npc.frameCounter <= 0)
            {
                npc.frameCounter = 3;
                frame++;
                if (frame >= Main.npcFrameCount[npc.type])
                {
                    frame = 0;
                }
            }
            npc.frame.Y = frame * frameHeight;
        }

        public override void SetDefaults()
        {
            npc.width = 198;
            npc.height = 180;
            npc.lifeMax = 1000;
            npc.damage = 1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            NPC soundNPC = new NPC();
            soundNPC.SetDefaults(NPCID.BrainofCthulhu);
            npc.HitSound = soundNPC.HitSound;
            npc.DeathSound = soundNPC.DeathSound;
        }

        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            damage = 1;
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = 1;
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            damage = BossBarrage.effectDamage;
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            sbeve = -5;
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            sbeve = -5;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            sbeve = -10;
            if (BossBarrage.effectDebuffs.Count == 0)
            {
                return;
            }
            for (int i = 0; i < BossBarrage.effectDebuffs.Count; i++)
            {
                target.AddBuff(BossBarrage.effectDebuffs[i], BossBarrage.debuffDuration * 60);
            }
        }

        int timeLeft = 240;
        public override void AI()
        {
            npc.TargetClosest(false);
            Player player = Main.player[npc.target];

            sbeve += 0.35f;
            Vector2 velocity = npc.DirectionTo(player.Center) * sbeve;

            npc.velocity = velocity;

            timeLeft--;
            if (timeLeft <= 0)
            {
                npc.active = false;
                Main.PlaySound(npc.DeathSound);
                for (int i = 0; i < 100; i++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
                    Main.dust[dust].scale = 2;
                }
            }
        }
    }
}
