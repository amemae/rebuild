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

        switch (_activeShotType)
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

    protected override void Move()
    {
        //Doesn't move
    }

    protected override void Attack()
    {
        Vector2 targetPos;

        switch (_activeShotType)
        {
            case (int)ShotTypes.BLUESQUARE:
                ShootProjectile(TargetPlayer());
                break;
            case (int)ShotTypes.BLUECHEVRON:
                for (int i = 0; i < 3; ++i)
                {
                    ShootProjectile(TargetPlayer());
                }
                break;
            default:
                Debug.Log("Invalid shot type >.< how did you even get here?");
                break;
        }
    }

    protected override void ChooseShotType()
    {
        _activeShotType = Random.Range(0, 2);
    }
}