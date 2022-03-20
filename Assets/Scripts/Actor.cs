using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InitProjs();
    }

    protected virtual void InitProjs()
    {
        if (_numOfStartingProjs != 0)
        {
            _projs = new List<Projectile>();
            for (int p = 0; p < _numOfStartingProjs; ++p)
            {
                _projs.Add(Instantiate(_prefabProj, GameManager.InstantiatePosition, Quaternion.identity));
            }
        }
    }

    protected virtual Projectile NewProj()
    {
        Projectile newProj = Instantiate(_prefabProj, GameManager.InstantiatePosition, Quaternion.identity);
        _projs.Add(newProj);
        return newProj;
    }
}
