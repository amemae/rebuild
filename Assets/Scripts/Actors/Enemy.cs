using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{
    public float _secondsPerShot;
    protected float _prevShotTime = 0;

    protected override bool TakeDamage(Projectile otherProj)
    {
        if (otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }
    protected override void TryAttack()
    {
        float currTime = Time.time;
        if (currTime >= _prevShotTime + _secondsPerShot)
        {
            if (GameManager.Instance.Player)
            {
                ShootProjectile();
                _prevShotTime = currTime;
            }
        }
    }
}
