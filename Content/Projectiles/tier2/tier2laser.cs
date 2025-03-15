using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace horsemod.Content.Projectiles.tier2
{
    public class tier2laser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Sets the amount of frames this minion has on its spritesheet
            //Main.projFrames[Projectile.type] = 1;
            // This is necessary for right-click targeting
            Main.projFrames[Projectile.type] = 3;


        }
        public override void SetDefaults()
        {
            Projectile.penetrate = 1;
            Projectile.width = 22;
            Projectile.height = 20;
            AIType = ProjectileID.ThrowingKnife;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            if (++Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                // Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }


    }
}
