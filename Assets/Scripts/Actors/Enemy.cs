using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{
    protected override bool ShouldTakeDamage(Projectile otherProj)
    {
        if (otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }
    protected override bool WillAttack()
    {
        if (GameManager.Instance.Player)
        {
            return true;
        }
        return false;
    }

    protected override RigidbodyType2D GetRigidBodyType()
    {
        return RigidbodyType2D.Kinematic;
    }

    protected abstract void ChooseShotType();
}
