using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentSetter
{
    public static Rigidbody2D Rigidbody2DSetup(Actor actor)
    {
        return Rigidbody2DActorSetup(actor);
    }

    public static Rigidbody2D Rigidbody2DSetup(Enemy enemy)
    {
        Rigidbody2D rb = Rigidbody2DActorSetup(enemy);

        //Make enemies unpushable
        rb.mass = 1000;
        rb.drag = 1000;
        rb.angularDrag = 1000;

        return rb;
    }   
    
    public static Rigidbody2D Rigidbody2DSetup(Blocker blocker)
    {
        Rigidbody2D rb = blocker.gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        return rb;
    }

    public static Rigidbody2D Rigidbody2DSetup(Projectile proj)
    {
        Rigidbody2D rb = proj.gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        return rb;
    }

    private static Rigidbody2D Rigidbody2DActorSetup(Actor actor)
    {
        Rigidbody2D rb = actor.gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0;

        return rb;
    }
}
