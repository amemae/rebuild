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
    public Projectile _prefabProj;
    public int _numOfStartingProjs = 0;

    protected void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        InitProjs();
    }

    protected virtual void InitProjs()
    {
        if (_numOfStartingProjs != 0)
        {
            _projs = new List<Projectile>();
            for (int p = 0; p < _numOfStartingProjs; ++p)
            {
                _projs.Add(Instantiate(_prefabProj, GameManager.Instance.InstantiatePosition, Quaternion.identity));
            }
        }
    }

    protected virtual Projectile NewProj()
    {
        Projectile newProj = Instantiate(_prefabProj, GameManager.Instance.InstantiatePosition, Quaternion.identity);
        _projs.Add(newProj);
        return newProj;
    }

    //Find an inactive projectile and move it to the actor's position before firing it
    protected virtual void ShootProjectile()
    {
        Projectile inactiveProj = _projs.Where(p => !p.IsActive).FirstOrDefault();
        if (inactiveProj == null)
        {
            inactiveProj = Instantiate(_prefabProj, GameManager.Instance.InstantiatePosition, Quaternion.identity);
            _projs.Add(inactiveProj);
        }

        inactiveProj.transform.position = new Vector2(transform.position.x, transform.position.y);
        inactiveProj.Activate();
    }
}
