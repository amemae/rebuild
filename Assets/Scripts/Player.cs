using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public Projectile prefabProj;
    private Projectile proj;

    private void Start()
    {
        //Make starting position a global variable
        proj = Instantiate(prefabProj, GameManager.InstantiatePosition, Quaternion.identity);
    }

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
            //Move the projectile onto the player
            proj.transform.position = new Vector2(transform.position.x, transform.position.y);
            proj.Activate();
        }
    }
}
