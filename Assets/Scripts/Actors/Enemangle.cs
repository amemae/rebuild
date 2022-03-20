using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemangle : Actor
{
    public float _shotsPerSecond;
    private float _shotClock = 0;
    private void FixedUpdate()
    {
        ++_shotClock;
        //50 represents the number of times FixedUpdate is called per second (with a framerate of at least 50)
        if (_shotClock >= _shotsPerSecond * 50)
        {
            _shotClock = 0;
            ShootProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _hp -= other.GetComponent<Projectile>().Damage;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
