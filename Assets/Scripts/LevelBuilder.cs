using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelBuilder : MonoBehaviour
{
    private static LevelBuilder _instance;

    public static LevelBuilder Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("LevelBuilder");
                go.AddComponent<LevelBuilder>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void BuildLevel()
    {
        int x, y;
        //Build surrounding walls
        for (x = -8, y = -5; y <= 5; ++y)
        {
            PrefabGenerator.Instance.PlaceBlocker(new Vector2(x, y));
        }
        for (; x <= 7; ++x)
        {
            PrefabGenerator.Instance.PlaceBlocker(new Vector2(x, y));
        }
        for (; y >= -5; --y)
        {
            PrefabGenerator.Instance.PlaceBlocker(new Vector2(x, y));
        }
        for (; x >= -8; --x)
        {
            PrefabGenerator.Instance.PlaceBlocker(new Vector2(x, y));
        }

        for (x = -7; x <= 7; ++x)
        {
            for (y = -5; y < 6; ++y)
            {
                PrefabGenerator.Instance.PlaceRedFloor(new Vector2(x, y));
            }
        }
    }
}
