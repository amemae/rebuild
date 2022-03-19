using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 oldPos, newPos;
    public float speed = 5;
    public Projectile prefabProj;
    private Projectile proj;

    private void Start()
    {
        //Make starting position a global variable
        proj = Instantiate(prefabProj, new Vector2(-1000, -1000), Quaternion.identity);
    }

    private void Update()
    {
        //Movement
        oldPos = transform.position;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        //Attacking
        //0 here represents primary mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //Move the projectile onto the player
            proj.transform.position = new Vector2(transform.position.x, transform.position.y);
            proj.IsActive = true;
            //Attack();
        }
    }

    private void Attack()
    {
        /*Vector2 mousePos = Input.mousePosition;
        //Converts the players position into pixel units so it can be compared against mousePosition
        Vector2 playerPixelPos = Camera.main.WorldToScreenPoint(transform.position);*/
    }
}
