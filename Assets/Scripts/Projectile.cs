using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isActive = false;
    public float speed = 5;

    void Update()
    {
        if (_isActive)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //Sample code to deactive projectile when the player cannot see it
            if (transform.position.x > 100 || transform.position.y > 100 || transform.position.x < -100 || 
                transform.position.y < -100)
            {
                _isActive = false;
            }
        }
    }

   public bool IsActive
    {
        set { _isActive = value; }
    }
}
