using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : Actor
{
    private void Update()
    {
        //Movement
        _oldPos = transform.position;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }

        //Attacking
        //0 represents primary mouse button
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

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
}
