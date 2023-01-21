using Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guns
{
    public class Bullet : HitGun
    {

        public override uint getDamage()
        {
            return 8;
        }

        public override uint getSpeed()
        {
            return 25;
        }

    }
}