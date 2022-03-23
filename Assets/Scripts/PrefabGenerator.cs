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
    public Projectile _redCircleProj;
    public Projectile _blueSquareProj;
    public Projectile _blueChevronProj;
    /************* Environment ******************/
    public Blocker _blocker;
    public GameObject _redFloor;
    /************* UI ******************/
    public HealthBar _healthBar;
    public Player Player
    {
        get { return Instantiate(_player, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Enemangle Enemangle
    {
        get { return Instantiate(_enemangle, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Projectile RedCircleProjectile
    {
        get { return Instantiate(_redCircleProj, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Projectile BlueSquareProjectile
    {
        get { return Instantiate(_blueSquareProj, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Projectile BlueChevronProjectile
    {
        get { return Instantiate(_blueChevronProj, GameManager.Instance.InstantiatePosition, Quaternion.identity); }
    }

    public Blocker PlaceBlocker(Vector2 pos)
    {
        return Instantiate(_blocker, pos, Quaternion.identity);
    }

    public GameObject PlaceRedFloor(Vector2 pos)
    {
        return Instantiate(_redFloor, pos, Quaternion.identity);
    }

    public HealthBar PlaceHealthBar(Vector2 pos, int maxHp)
    {
        HealthBar healthBar = Instantiate(_healthBar, pos, Quaternion.identity);
        healthBar.MaxHp= maxHp;
        return healthBar;
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
