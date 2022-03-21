using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    private static PrefabGenerator _instance;

    /************* Actors ******************/
    public Player _player;
    public Enemangle _enemangle;
    /************* Projectiles ******************/
    public Projectile _projectile;
    public EnemyProjectile _enemyProjectile;

    public Player Player
    {
        get { return Instantiate(_player, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Enemangle Enemangle
    {
        get { return Instantiate(_enemangle, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Projectile Projectile
    {
        get { return Instantiate(_projectile, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public EnemyProjectile EnemyProjectile
    {
        get { return Instantiate(_enemyProjectile, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public static PrefabGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("PrefabGenerator");
                go.AddComponent<PrefabGenerator>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
