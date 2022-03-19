using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isActive = false;
    public float _speed = 5;

    private Vector2 _targetPos;

    void Update()
    {
        if (_isActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
            if (transform.position.x == _targetPos.x && transform.position.y == _targetPos.y)
            {
                _isActive = false;
            }
        }
    }

   public void Activate()
    {
        _isActive = true;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Find the slope of the line between player and mouse position than scale the line so it continues past cursor
        _targetPos.x = (mousePos.x - transform.position.x) * 100;
        _targetPos.y = (mousePos.y - transform.position.y) * 100;
    }
}
