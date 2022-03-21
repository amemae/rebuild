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

    protected override bool TakeDamage(Projectile otherProj)
    {
        if (!otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }

    protected override void DestroyActor()
    {
        GameManager.Instance.TriggerLoss();
    }
}
