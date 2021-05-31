using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System;

namespace BossBarrage.Projectiles
{
    class GolemHead : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 110;
            projectile.height = 106;
            projectile.timeLeft = 300;
            projectile.damage = 1;
            projectile.hostile = false;
            projectile.friendly = false;
        }

        int projectileWait = 30;
        public override void AI()
        {
            Player player = Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)];
            if (projectileWait > 0)
            {
                projectileWait--;
            }
            else
            {
                projectileWait = Main.rand.Next(15, 45);
                Vector2 position = projectile.Center;
                Vector2 direction = player.DirectionFrom(position);
                float speed = 15f;
                Projectile.NewProjectile(position, direction * speed, ProjectileID.EyeLaser, BossBarrage.effectDamage / 4, 0);
            }
            
        }
    }
}
