using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public Vector2 _instantiatePosition = new Vector2(-1000, -1000);
    public Vector2 _playerInstantiationPosition = new Vector2(0, 0);
    public Vector2 _playerHealthBarPosition;

    public Player _player;

    public Vector2 InstantiatePosition
    {
        get { return _instantiatePosition; }
    }

    public Vector2 PlayerInstantiationPosition
    {
        get { return _playerInstantiationPosition; }
    }

    public Vector2 PlayerHealthBarPosition
    {
        get { return _playerHealthBarPosition; }
    }

    public Player Player
    {
        get { return _player; }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    //Temporary code for visual testing purposes
    private void Start()
    {
        _player = PrefabGenerator.Instance.Player;
        _player.transform.position = new Vector2(0, 0);
        Enemangle enemangle = PrefabGenerator.Instance.Enemangle;
        enemangle.transform.position = new Vector2(0, 4);

        LevelBuilder.Instance.BuildLevel();
        
    }
}
