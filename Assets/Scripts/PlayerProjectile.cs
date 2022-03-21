using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    public override bool IsPlayerProjectile
    {
        get { return true; }
    }
}
