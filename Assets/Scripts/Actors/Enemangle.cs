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
        if (!_isMoving)
        {
            _isMoving = true;
            _direction = Vector2.left;
        }
        else if (_rigidBody.velocity == Vector2.zero)
        {
            _direction *= -1;
        }
        _rigidBody.velocity = _direction * _speed;
    }

    protected override void Attack()
    {
        Vector2 target = TargetPlayer();
        switch (_activeShotType)
        {
            case (int)ShotTypes.BLUESQUARE:
                ShootProjectile(TargetPlayer());
                break;
            case (int)ShotTypes.BLUECHEVRON:
                float shotAngle = 25;
                ShootProjectile(target);
                ShootProjectile(MathFunctions.RotateVector(target, shotAngle));
                ShootProjectile(MathFunctions.RotateVector(target, -shotAngle));
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