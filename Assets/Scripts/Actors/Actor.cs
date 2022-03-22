using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Actor : MonoBehaviour
{
    protected Vector2 _oldPos, _newPos;
    public float _speed;
    public int _hp;
    protected List<Projectile> _projs;
    public int _numOfStartingProjs = 0;
    protected bool _canMove = true;

    protected void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().isTrigger = true;

        InitProjs();
    }

    protected virtual void Update()
    {
       if (_canMove)
        {
            TryMove();
            _canMove = true;
        }
    }

    protected virtual void FixedUpdate()
    {
        TryAttack();
    }

    protected virtual void InitProjs()
    {    
        if (_numOfStartingProjs != 0)
        {
            _projs = new List<Projectile>();
            for (int p = 0; p < _numOfStartingProjs; ++p)
            {
                _projs.Add(GenerateProjectilePrefab());
            }
        }
    }

    //Find an inactive projectile and move it to the actor's position before firing it
    protected virtual void ShootProjectile()
    {
        Projectile inactiveProj = _projs.Where(p => !p.IsActive).FirstOrDefault();
        if (inactiveProj == null)
        {
            inactiveProj = GenerateProjectilePrefab();
            _projs.Add(inactiveProj);
        }

        inactiveProj.transform.position = new Vector2(transform.position.x, transform.position.y);
        inactiveProj.Activate(TargetPosition());
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Projectile otherProj = other.GetComponent<Projectile>();
        if (otherProj && TakeDamage(otherProj))
        {
            _hp -= otherProj.Damage;

            if (_hp <= 0)
            {
                DestroyActor();
            }

            otherProj.Deactivate();
        }
    }

    protected virtual void DestroyActor()
    {
        Destroy(gameObject);
    }

    public void PreventMove()
    {
        _canMove = false;
    }

    //Defer the type of the projectile to subclasses
    protected abstract Projectile GenerateProjectilePrefab();
    protected abstract bool TakeDamage(Projectile otherProj);
    protected abstract Vector2 TargetPosition();
    protected abstract void TryMove();
    protected abstract void TryAttack();
}
