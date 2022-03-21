using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemangle : Enemy
{
    protected override Projectile GenerateProjectilePrefab()
    {
        return PrefabGenerator.Instance.EnemyProjectile;
    }
}