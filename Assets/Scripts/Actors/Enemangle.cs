using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemangle : Enemy
{
    private enum ShotTypes
    {
        BLUESQUARE = 0,
        BLUECHEVRON = 1
    }

    protected override Projectile GenerateProjectilePrefab()
    {
        Projectile newProj = null;

        switch (_activeShotList)
        {
            case (int)ShotTypes.BLUESQUARE:
                newProj = PrefabGenerator.Instance.BlueSquareProjectile;
                break;
            case (int)ShotTypes.BLUECHEVRON:
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

    protected override void Attack()
    {
        ChooseShotType();
        switch (_activeShotList)
        {
            case (int)ShotTypes.BLUESQUARE:
                ShootProjectile();
                break;
            case (int)ShotTypes.BLUECHEVRON:
                for (int i = 0; i < 3; ++i)
                {
                    ShootProjectile();
                }
                break;
            default:
                Debug.Log("Invalid shot type >.< how did you even get here?");
                break;
        }
    }

    protected override void ChooseShotType()
    {
        _activeShotList = Random.Range(0, 2);
    }
}