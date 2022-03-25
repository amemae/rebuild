using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{
    protected Vector2 _direction;
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

    protected Vector2 TargetPlayer()
    {
        Vector2 targetPos;
        targetPos.x = (GameManager.Instance.Player.transform.position.x - transform.position.x) * 100;
        targetPos.y = (GameManager.Instance.Player.transform.position.y - transform.position.y) * 100;

        return targetPos;
    }
}
