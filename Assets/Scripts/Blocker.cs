using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    private void Awake()
    {
        ComponentSetter.Rigidbody2DSetup(this);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Projectile proj))
        {
            proj.Deactivate();
        }

        if (other.TryGetComponent(out Enemy enemy))
        {
            other.GetComponent<Enemy>().HitWall();
        }
    }
}
