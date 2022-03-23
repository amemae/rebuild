using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : Actor
{
    protected HealthBar _healthBar;

    protected void Start()
    {
        _healthBar = PrefabGenerator.Instance.PlaceHealthBar(GameManager.Instance.PlayerHealthBarPosition, _maxHp).GetComponent<HealthBar>();
    }

    protected override Projectile GenerateProjectilePrefab()
    {
        Projectile newProj = PrefabGenerator.Instance.RedCircleProjectile;
        newProj.IsPlayerProjectile = true;
        return newProj;
    }

    protected override bool ShouldTakeDamage(Projectile otherProj)
    {
        if (!otherProj.IsPlayerProjectile)
        {
            return true;
        }
        return false;
    }
    
    protected override void OnDamage(Projectile otherProj)
    {
        base.OnDamage(otherProj);
        _healthBar.UpdateHealth(_hp);
    }

    protected override Vector2 TargetPosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Find the slope of the line between player and mouse position than scale the line so it continues past cursor
        Vector2 targetPos;
        targetPos.x = (mousePos.x - transform.position.x) * 100;
        targetPos.y = (mousePos.y - transform.position.y) * 100;
        return targetPos;
    }

    protected override void Move()
    {
        Vector2 velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity *= _speed;
        _rigidBody.velocity = velocity;

    }

    protected override bool WillAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    
    }
    protected override void Attack()
    {
        ShootProjectile();
    }

    protected override void ChooseShotType()
    {
        if (Input.GetMouseButton(0))
        {
            _activeShotType = 0;
        }
    }

    protected override RigidbodyType2D GetRigidBodyType()
    {
        return RigidbodyType2D.Dynamic;
    }
}
