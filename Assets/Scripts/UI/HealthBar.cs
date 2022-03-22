using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    SpriteRenderer _health;
    int _maxHp;
    float _maxXScale;

    public int MaxHp
    {
        set { _maxHp = value; }
    }

    private void Awake()
    {
        _health = gameObject.transform.Find("Health").GetComponent<SpriteRenderer>();
        _maxXScale = _health.transform.localScale.x;
    }

    public void UpdateHealth(int currHp)
    {
        float scaleFactor = ((float)currHp / (float)_maxHp);
        _health.transform.localScale = new Vector2(_maxXScale * scaleFactor, _health.transform.localScale.y);
    }
}
