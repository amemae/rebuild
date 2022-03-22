using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{
    protected override bool TakeDamage(Projectile otherProj)
    {
        if (otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }
    protected override bool TryingToAttack()
    {
        if (GameManager.Instance.Player)
        {
            return true;
        }
        return false;
    }
}
