using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void OnExplotion(Destroyable target)
    {
        base.OnExplotion(target);
        if (target)
        {
            target.rb.AddForce(transform.forward*600);
        }
    }
}
