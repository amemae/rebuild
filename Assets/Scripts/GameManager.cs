using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public Vector2 _instantiatePosition = new Vector2(-1000, -1000);
    public Player _player;

    public Vector2 InstantiatePosition
    {
        get { return _instantiatePosition; }
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
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
