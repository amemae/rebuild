using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 oldPos, newPos;
    public float speed = 5;

    private void Update()
    {
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
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

    }
}
