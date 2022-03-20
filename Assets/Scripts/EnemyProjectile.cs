using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    public override void Activate()
    {
        base.Activate();
        _targetPos.x = (GameManager.Instance.Player.transform.position.x - transform.position.x) * 100;
        _targetPos.y = (GameManager.Instance.Player.transform.position.y - transform.position.y) * 100;
    }
}
