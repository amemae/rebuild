using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{
    public float _shotsPerSecond;
    protected float _shotClock = 0;
    protected void FixedUpdate()
    {
        ++_shotClock;
        //50 represents the number of times FixedUpdate is called per second (with a framerate of at least 50)
        if (_shotClock >= _shotsPerSecond * 50)
        {
            _shotClock = 0;
            if (GameManager.Instance.Player)
            {
                ShootProjectile();
            }
        }
    }

    protected override bool TakeDamage(Projectile otherProj)
    {
        if (otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }
}
