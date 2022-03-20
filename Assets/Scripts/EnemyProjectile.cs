using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    public override void Activate()
    {
        base.Activate();
        _targetPos = GameManager.Instance.Player.transform.position;
    }
}
