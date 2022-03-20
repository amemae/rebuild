using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    public override void Activate()
    {
        base.Activate();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Find the slope of the line between player and mouse position than scale the line so it continues past cursor
        _targetPos.x = (mousePos.x - transform.position.x) * 100;
        _targetPos.y = (mousePos.y - transform.position.y) * 100;
    }
}
