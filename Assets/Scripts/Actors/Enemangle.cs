using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemangle : Enemy
{
    protected override Projectile GenerateProjectilePrefab()
    {
        Projectile newProj = null;

        switch (_activeShotList)
        {
            case 0:
                newProj = PrefabGenerator.Instance.BlueSquareProjectile;
                break;
            case 1:
                newProj = PrefabGenerator.Instance.BlueChevronProjectile;
                break;
            default:
                Debug.Log("Invalid shot type >.< how did you even get here?");
                break;
        }
        return newProj;
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