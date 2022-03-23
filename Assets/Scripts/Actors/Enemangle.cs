using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemangle : Enemy
{
    protected override Projectile GenerateProjectilePrefab()
    {
        return PrefabGenerator.Instance.BlueChevronProjectile;
    }

    protected override Vector2 TargetPosition()
    {
        Vector2 targetPos;
        targetPos.x = (GameManager.Instance.Player.transform.position.x - transform.position.x) * 100;
        targetPos.y = (GameManager.Instance.Player.transform.position.y - transform.position.y) * 100;
        return targetPos;
    }

    protected override void Move()
    {
        //Doesn't move
    }
}