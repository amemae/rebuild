using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D collider = other.collider;
        if (collider.TryGetComponent(out Projectile proj))
        {
            proj.Deactivate();
        }
    }
}
