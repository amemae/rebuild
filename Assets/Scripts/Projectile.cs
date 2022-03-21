using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private bool _isActive = false;
    public float _speed;
    public int _dmg;
    protected Vector2 _targetPos;
    protected Collider2D _collider;

    public bool IsActive
    {
        get { return _isActive; }
    }

    public int Damage
    {
        get { return _dmg; }
    }

    public virtual bool IsPlayerProjectile
    {
        get { return false; }
    }
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
    }

    public virtual void Activate()
    {
        _isActive = true;
    }

    public virtual void Deactivate()
    {
        _isActive = false;
        transform.position = GameManager.Instance.InstantiatePosition;
    }
}
