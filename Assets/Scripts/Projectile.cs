using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private bool _isActive = false;
    public float _speed;
    public int _dmg;
    protected Vector2 _targetPos;
    protected CircleCollider2D _collider;

    public bool IsActive
    {
        get { return _isActive; }
    }

    public int Damage
    {
        get { return _dmg; }
    }

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isActive = false;
        transform.position = GameManager.Instance.InstantiatePosition;

    }

    public virtual void Activate()
    {
        _isActive = true;
    }
}
