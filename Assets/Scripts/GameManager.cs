using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 _instantiatePosition = new Vector2(-1000, -1000);

    public static Vector2 InstantiatePosition
    {
        get { return _instantiatePosition; }
    }
}
