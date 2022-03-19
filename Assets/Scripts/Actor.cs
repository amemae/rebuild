using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    protected Vector2 _oldPos, _newPos;
    public float _speed;

    public int _hp;
}
