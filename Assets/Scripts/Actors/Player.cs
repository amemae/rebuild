using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : Actor
{
    protected override Projectile GenerateProjectilePrefab()
    {
        return PrefabGenerator.Instance.PlayerProjectile;
    }

    protected override bool TakeDamage(Projectile otherProj)
    {
        if (!otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }

    protected override Vector2 TargetPosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Find the slope of the line between player and mouse position than scale the line so it continues past cursor
        Vector2 targetPos;
        targetPos.x = (mousePos.x - transform.position.x) * 100;
        targetPos.y = (mousePos.y - transform.position.y) * 100;
        return targetPos;
    }

    protected override void Move()
    {
        Vector2 velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (velocity != Vector2.zero)
        {
            Debug.Log(velocity);
        }
        velocity *= _speed;
        _rigidBody.velocity = velocity;

    }

    protected override void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }
}
