using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemangle : Actor
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        _hp -= other.GetComponent<Projectile>().Damage;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
