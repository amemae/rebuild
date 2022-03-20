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
        //0 here represents primary mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //Find an inactive projectile to use, if that can't be found make new ones
            Projectile nextProj = _projs.Where(p => !p.IsActive).FirstOrDefault();
            if (nextProj == null)
            {
                nextProj = NewProj();
            }
            //Move the projectile onto the player
            nextProj.transform.position = new Vector2(transform.position.x, transform.position.y);
            nextProj.Activate();
        }
    }
}