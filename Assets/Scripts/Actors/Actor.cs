using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Actor : MonoBehaviour
{
    protected Vector2 _oldPos, _newPos;
    public float _speed;
    public int _hp, _maxHp;
    protected List<List<Projectile>> _projs;
    public int _numOfStartingProjs = 0;
    public int _numProjTypes = 0;
    protected int _activeShotType = 0;
    protected Rigidbody2D _rigidBody;
    public float _secondsPerShot;
    protected bool _canFire = true;

    protected void Awake()
    {
        _hp = _maxHp;

        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.bodyType = GetRigidBodyType();
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponent<SpriteRenderer>().sortingLayerName = SortingLayerName();
        InitProjs();
    }

    protected virtual void Update()
    {
        if (_canFire && WillAttack())
        {
            ChooseShotType();
            Attack();
            StartCoroutine(RateOfFire());
        }
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void InitProjs()
    {    
        if (_numOfStartingProjs != 0)
        {
            _projs = new List<List<Projectile>>();
            for (; _activeShotType < _numProjTypes; ++_activeShotType)
            {
                _projs.Add(new List<Projectile>());
                for (int p = 0; p < _numOfStartingProjs; ++p)
                {
                    _projs[_activeShotType].Add(GenerateProjectilePrefab());
                }
            }
            _activeShotType = 0;
        }
    }

    //Find an inactive projectile and move it to the actor's position before firing it
    protected virtual void ShootProjectile(Vector2 target)
    {
        Projectile inactiveProj = _projs[_activeShotType].Where(p => !p.IsActive).FirstOrDefault();
        if (inactiveProj == null)
        {
            inactiveProj = GenerateProjectilePrefab();
            _projs[_activeShotType].Add(inactiveProj);
        }

        inactiveProj.transform.position = new Vector2(transform.position.x, transform.position.y);
        inactiveProj.Activate(target);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Projectile otherProj = other.GetComponent<Projectile>();
        if (otherProj && ShouldTakeDamage(otherProj))
        {
            OnDamage(otherProj);
        }
    }

    protected IEnumerator RateOfFire()
    {
        _canFire = false;
        yield return new WaitForSeconds(_secondsPerShot);
        _canFire = true;
    }

    protected virtual void DestroyActor()
    {
        Destroy(gameObject);
    }

    protected virtual string SortingLayerName()
    {
        return "Actor";
    }

    protected virtual void OnDamage(Projectile otherProj)
    {
        _hp -= otherProj.Damage;

        if (_hp <= 0)
        {
            DestroyActor();
        }

        otherProj.Deactivate();
    }

    //Defer the type of the projectile to subclasses
    protected abstract Projectile GenerateProjectilePrefab();
    protected abstract bool ShouldTakeDamage(Projectile otherProj);
    protected abstract void Move();
    protected abstract void ChooseShotType();
    protected abstract bool WillAttack();
    protected abstract void Attack();
    protected abstract RigidbodyType2D GetRigidBodyType();
}
