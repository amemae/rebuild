using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isActive = true;
    public float speed = 5;

    void Update()
    {
        if (_isActive)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
