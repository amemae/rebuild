using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isActive = false;
    public float _speed;
    public int _dmg;
    protected Vector2 _targetPos;
    protected Collider2D _collider;
    private bool _isPlayerProjectile = false;

    public bool IsActive
    {
        get { return _isActive; }
    }

    public int Damage
    {
        get { return _dmg; }
    }

    public bool IsPlayerProjectile
    {
        get { return _isPlayerProjectile; }
        set { _isPlayerProjectile = value; }
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;

        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<SpriteRenderer>().sortingLayerName = SortingLayerName();
    }

    private void Update()
    {
        if (_isActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        }
    }

    public virtual void Activate(Vector2 targetPos)
    {
        _targetPos = targetPos;

        //Point projectile towards target
        Vector2 direction = _targetPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        _isActive = true;
    }

    public virtual void Deactivate()
    {
        _isActive = false;
        transform.position = GameManager.Instance.InstantiatePosition;
    }

    protected virtual string SortingLayerName()
    {
        return "Projectile";
    }
}
